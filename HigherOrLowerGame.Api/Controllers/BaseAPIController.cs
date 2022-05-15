using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace HigherOrLowerGame.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
        
    }
}