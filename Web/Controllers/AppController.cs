using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
public abstract class AppController : ControllerBase
{
    protected ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IPublisher Publisher => HttpContext.RequestServices.GetRequiredService<IPublisher>();
}