using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;


namespace WorkerData.Controllers
{

[ApiController]
[Route("[controller]")]
    public class WorkerController : ControllerBase

    {

        [HttpGet]
        public Task<Exception> GetError()
        {
            throw new NotImplementedException();
        }


    }
}