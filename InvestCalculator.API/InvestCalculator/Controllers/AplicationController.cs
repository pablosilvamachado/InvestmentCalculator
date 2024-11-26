using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InvestmentCalculator.API.Controllers
{
    public abstract class AplicationController : ControllerBase
    {
        [NonAction]
        public virtual OkObjectResult Error([ActionResultObjectValue] object? value)
        {
            return new OkObjectResult(value);
        }
    }
}
