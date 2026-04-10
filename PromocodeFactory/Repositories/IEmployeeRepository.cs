using PromocodeFactory.Models;

namespace PromocodeFactory.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetById(int id);
    }
}