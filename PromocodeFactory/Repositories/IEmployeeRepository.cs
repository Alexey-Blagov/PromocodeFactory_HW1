using PromocodeFactory.Models;

namespace PromocodeFactory.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetById(int id);
        Task<Employee?> Add(Employee employee);
        Task<Employee?> Update(Employee employee);
        Task Delete(int id);
    }
}
