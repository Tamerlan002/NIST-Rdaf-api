using Microsoft.AspNetCore.Mvc;

namespace RDaF.Api.Infrastructure
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
           : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

    }
}
