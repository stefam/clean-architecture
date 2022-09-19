using CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.WebUI.Controllers;

public class AccountsController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateAccountCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}
