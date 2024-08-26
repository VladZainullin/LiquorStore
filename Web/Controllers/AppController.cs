using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
public abstract class AppController : ControllerBase
{
    public ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();
}