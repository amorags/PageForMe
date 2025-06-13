

using PageForMe.Models;

namespace DataStructures.Services.Interfaces
{
    public interface IDataManager
    {
        Task<Dictionary<int, Employee>> OrderByName();
    }
}