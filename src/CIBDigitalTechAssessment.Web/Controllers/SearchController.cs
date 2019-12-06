using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.ResponseModels.Common;
using CIBDigitalTechAssessment.ResponseModels.PhoneBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CIBDigitalTechAssessment.Web.Controllers
{
    public class SearchController:BaseController
    {
        public SearchController()
        {
            
            
        }
        [HttpGet("search/{term}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Search Phone Book Entries")]
        public async Task<ActionResult<PaginationResponseModel<List<KeyValuePair<string,string>>, NumericPaginationMetaResponseModel>>> GetSearchResults(string term)
        {
            try
            {
                 
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequestProblemDetailsResponse(exception: e);
            }
        }
    }
}