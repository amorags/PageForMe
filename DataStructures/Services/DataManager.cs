using DataStructures.Services.Interfaces;
using PageForMe.Models;
using PageForMe.Repository;

namespace DataStructures.Services
{
    public class DataManager : IDataManager
    {
        private readonly EmpRepo _empRepo;

        public DataManager(EmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<Dictionary<int, Employee>> OrderByName()
        {
            var emps = await _empRepo.GetEmployees();
            return emps;
        }
        
    }
}