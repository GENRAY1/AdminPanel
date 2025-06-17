namespace AdminPanel.Web.Abstractions;

public interface IModule
{
    void RegisterEndpoints(IEndpointRouteBuilder app);
}