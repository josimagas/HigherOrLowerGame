using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace HigherOrLowerGame.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
        
    }
}