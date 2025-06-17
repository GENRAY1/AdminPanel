using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Middaleware;

internal sealed class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(
		RequestDelegate next,
		ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

			ProblemDetails exceptionDetails = GetExceptionDetails(exception);
			
			context.Response.StatusCode = exceptionDetails.Status ?? StatusCodes.Status500InternalServerError ;

			await context.Response.WriteAsJsonAsync(exceptionDetails);
		}
	}

	private static ProblemDetails GetExceptionDetails(Exception exception)
	{
		return exception switch
		{
			_ => new ProblemDetails{
				Status = StatusCodes.Status500InternalServerError,
				Type = "Server error",
				Detail = exception.Message
			}
		};
	}
}
