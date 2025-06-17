using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.Accounts;

public class AccountIdNotFoundInClaimsException()
    : ApiException("AccountId not found in claims", HttpStatusCode.Unauthorized);