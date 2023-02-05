using MediatR;

using Microsoft.AspNetCore.Mvc;
//using WebUI.Model.Attribute;

namespace CleanArchitecture.WebUI.Controllers;

[ApiController]
//[ResponseAttribute]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
