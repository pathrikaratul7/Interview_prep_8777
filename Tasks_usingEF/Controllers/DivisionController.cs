using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks_usingEF.InterfaceService;
using Tasks_usingEF.Models;

namespace Tasks_usingEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivision _division;
        public DivisionController(IDivision division)
        {
                _division = division;
        }

        [HttpPost]
        [Route("AddDivisionAsync")]
        public async Task<IActionResult> AddDivisionAsync(Division division, CancellationToken cancellationToken)
        {

            var Result =await _division.AddDivisionAsynch(division, cancellationToken);
            return Result ?? NotFound();
        
        }
        [HttpPut]
        [Route("UpdateDivisionAsynch")]
        public async Task<IActionResult> UpdateDivisionAsynch(Division division, CancellationToken cancellationToken)
        { 
           var Result = await _division.UpdateDivisionAsynch(division, cancellationToken);
            return Result ?? NotFound();
         
        }
        [HttpDelete]
        [Route("DeleteDivisionAsync")]
        public async Task<IActionResult> DeleteDivisionAsync(Division division, CancellationToken cancellationToken)
        {

            var Result = await _division.DeleteDivisionAsync(division, cancellationToken);
            return Result ?? NotFound();
        }
    }
}
