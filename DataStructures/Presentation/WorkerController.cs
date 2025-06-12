using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using WorkerData.Services;
using WorkerData.Services.Interfaces;


namespace WorkerData.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {

        private readonly WorkerDataInterface _workerService;


        public WorkerController(WorkerDataInterface workerData)
        {
            _workerService = workerData;
        }


        [HttpGet]
        public async Task<String[]> GetArray()
        {
            var Object = await _workerService.GetAllNames();
            return Object;
        }


    }
}