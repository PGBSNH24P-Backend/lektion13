using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("secure")]
public class SecureController : ControllerBase
{

    [HttpGet]
    [Authorize]
    public string HelloWorld()
    {
        return "Hello World!";
    }

    [HttpPut("withdraw")]
    [Authorize("withdraw-money")]
    public string WithdrawMoney()
    {
        return "Withdraw money!";
    }

    [HttpGet("view")]
    [Authorize("view-balance")]
    public string ViewBalance()
    {
        return "View balance!";
    }
}

/*

CLAIMS: (permission, authority, privilege)
- view balance
- withdraw money

ROLE:
Owner: view balance, withdraw money
Employee: view balance

*/