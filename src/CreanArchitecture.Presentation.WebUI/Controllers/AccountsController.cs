using CleanArchitecture.Core.Application.Services.AccountServices.Commands.CreateAccount;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.WebUI.Controllers;

public class AccountsController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateAccountCommand request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            if (ex is ValidationException)
            {
                var validations = ex as ValidationException;
                return BadRequest(string.Join(',', validations!.Errors.Select(x => x.ErrorMessage)));
            }

            throw;
        }
    }
}
