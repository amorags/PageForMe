using System;

namespace WorkerData.Services.Interfaces
{
    public interface WorkerDataInterface
    {
        
        Task<String[]> GetAllNames();
    }
}