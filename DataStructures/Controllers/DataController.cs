using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageForMe.Data;
using PageForMe.Models;
using PageForMe.Services;

namespace PageForMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DataGeneratorService _dataGenerator;

        public DataController(ApplicationDbContext context, DataGeneratorService dataGenerator)
        {
            _context = context;
            _dataGenerator = dataGenerator;
        }

        #region Data Generation Endpoints

        [HttpPost("generate/employees/{count:int?}")]
        public async Task<IActionResult> GenerateEmployees(int count = 100)
        {
            try
            {
                await _dataGenerator.GenerateEmployeesAsync(count);
                return Ok(new { message = $"Generated {count} employees successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("generate/projects/{count:int?}")]
        public async Task<IActionResult> GenerateProjects(int count = 50)
        {
            try
            {
                await _dataGenerator.GenerateProjectsAsync(count);
                return Ok(new { message = $"Generated {count} projects successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("generate/sales/{count:int?}")]
        public async Task<IActionResult> GenerateSales(int count = 200)
        {
            try
            {
                await _dataGenerator.GenerateSalesAsync(count);
                return Ok(new { message = $"Generated {count} sales records successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("generate/all")]
        public async Task<IActionResult> GenerateAllData()
        {
            try
            {
                await _dataGenerator.GenerateAllDataAsync();
                return Ok(new { message = "Generated all sample data successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearAllData()
        {
            try
            {
                await _dataGenerator.ClearAllDataAsync();
                return Ok(new { message = "Cleared all data successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        #endregion
    }
}