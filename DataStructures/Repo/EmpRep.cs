using Microsoft.EntityFrameworkCore;
using PageForMe.Models;
using PageForMe.Data;

namespace PageForMe.Repository
{

    public class EmpRepo

    {
        private readonly ApplicationDbContext _context;

        public EmpRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Dictionary<int, Employee>> GetEmployees()
        {
            var emps = await _context.Employees.ToDictionaryAsync(e => e.Id);
            return emps;
        }
    }
}