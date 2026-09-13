using Microsoft.AspNetCore.Mvc;
using Tasks_usingEF.Models;

namespace Tasks_usingEF.InterfaceService
{
    public interface IDivision
    {

         Task<IActionResult> AddDivisionAsynch(Division div,CancellationToken cancellationToken);
         Task<IActionResult> UpdateDivisionAsynch(Division division,CancellationToken cancellationToken);
         Task<IActionResult> DeleteDivisionAsync(Division division,CancellationToken cancellationToken);
         Task<IActionResult> GetAllDivisionAsynch(CancellationToken cancellationToken);
         Task<IActionResult> GetDivisioByIdAsynch(long DIVID,int Takelimit,long lastpageDIVID, CancellationToken cancellationToken);
        Task<IActionResult> GetDivisionByNameAsynch(string DivName, CancellationToken cancellationToken);
        
    }
}
