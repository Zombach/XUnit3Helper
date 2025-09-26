using Microsoft.AspNetCore.Mvc;

namespace XUnit3Helper.Example.Api.Api.Controllers.Common;

[ApiController]
[Route("[controller]")]
public abstract class BaseController
    : ControllerBase;
