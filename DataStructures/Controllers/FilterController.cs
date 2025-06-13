using DataStructures.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageForMe.Data;
using PageForMe.Models;
using PageForMe.Services;

namespace PageForMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly IDataManager _dataManager;


        public FilterController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }


        [HttpGet("get/employees")]
        public async Task<Dictionary<int, Employee>> GetAllEmps()
        {
            try
            {
                var emps = await _dataManager.OrderByName();
                return emps;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}