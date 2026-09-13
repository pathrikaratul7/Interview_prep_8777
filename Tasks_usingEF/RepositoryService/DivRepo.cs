using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var query = await _context.divisions.ToListAsync(cancellationToken);
                 

            return new OkObjectResult(query);
        }
        public async Task<IActionResult> GetDivisioByIdAsynch(long DIVID,int Takelimit,long lastpageDIVID, CancellationToken cancellationToken)
        {
            var data = await _context.divisions.FindAsync(DIVID);
            if (data == null)
            {


                if (data == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        StatusCode = 404,
                        Message = $"No result found for ID {DIVID}"
                    });
                }

            }

            return new OkObjectResult(data);
        }
        public async Task<IActionResult> GetDivisionByNameAsynch(string DivName, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
