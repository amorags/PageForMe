using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using WorkerData.Repostiories;
using WorkerData.Repostiories.Interfaces;
using WorkerData.Services.Interfaces;


namespace WorkerData.Services
{
    public class WorkerService : WorkerDataInterface
    {

        private readonly IWorkerRepo _workerRepo;

        public WorkerService(IWorkerRepo workerRepo)
        {
            _workerRepo = workerRepo;
        }
        public async Task<String[]> GetAllNames()
        {
            return _workerRepo.getList();
        }

        public String[] sortArray()
        {
            throw new NotImplementedException();
        }
        
    }
}