using System.Security.Claims;
using AdminPanel.Application.Abstractions.Authentication;
using AdminPanel.Domain.Accounts;
using Microsoft.AspNetCore.Http;

namespace AdminPanel.Infrastructure.Authentication;

public class AccountContext(IHttpContextAccessor contextAccessor) : IAccountContext
{
    public Guid AccountId
    {
        get
        {
            var value = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (value != null)
                return Guid.Parse(value);

            throw new AccountIdNotFoundInClaimsException();
        }
    }
}
