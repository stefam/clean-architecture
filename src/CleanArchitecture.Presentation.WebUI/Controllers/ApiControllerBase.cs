using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    protected ISender _mediator =>
        HttpContext.RequestServices.GetRequiredService<ISender>();
}
