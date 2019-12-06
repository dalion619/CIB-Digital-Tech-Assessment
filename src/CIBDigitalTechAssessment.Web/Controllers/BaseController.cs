using System;
using Microsoft.AspNetCore.Mvc;

namespace CIBDigitalTechAssessment.Web.Controllers
{
    [Produces(contentType: "application/json")]
    [ApiController]
    [Route(template: "/api/[controller]/")]
    public class BaseController: ControllerBase
    {
        protected BadRequestObjectResult BadRequestProblemDetailsResponse(Exception exception) =>
            new BadRequestObjectResult(error: new ProblemDetails
                                              {
                                                  Title = "Something bad occurred.",
                                                  Status = 400
                                              });
    }
}