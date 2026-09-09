using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tasks_usingEF.Database;
using Tasks_usingEF.InterfaceService;
using Tasks_usingEF.Models;

namespace Tasks_usingEF.RepositoryService
{
    public class DivRepo : IDivision
    {
        private readonly AppDbContext _context;
        public DivRepo(AppDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> AddDivisionAsynch(Division div, CancellationToken cancellationToken)
        {
            _context.divisions.Add(div);
            await _context.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(div);
           
        }
        public async Task<IActionResult> UpdateDivisionAsynch(Division division, CancellationToken cancellationToken)
        {
            var DivData = await _context.divisions.FindAsync(division.DIVID);
            if (DivData != null)
            {
                DivData.DivName = division.DivName;
                DivData.IsActive = division.IsActive;
                await _context.SaveChangesAsync(cancellationToken);
                return new OkObjectResult(division);
            }
            return new NotFoundObjectResult(division);
        }
        public async Task<IActionResult> DeleteDivisionAsync(Division division, CancellationToken cancellationToken)
        {
            var result = await _context.divisions.FindAsync(division.DIVID);
            if (result != null)
            {
                 _context.divisions.Remove(division);
                 await _context.SaveChangesAsync(cancellationToken);
                return new OkObjectResult(result);
            }
            return new NotFoundObjectResult(new
            {


            });
            
        }
        public async Task<IActionResult> GetAllDivisionAsynch(CancellationToken cancellationToken)
        {
            return null;
        }
        public async Task<IActionResult> GetDivisioByIdAsynch(long DIVID, CancellationToken cancellationToken)
        {
            var DivData = await _context.divisions.FindAsync(DIVID);
            return new OkObjectResult(DivData);
        }
        public async Task<IActionResult> GetDivisionByNameAsynch(string DivName, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
