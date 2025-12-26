using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Employee?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Employee> AddAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
            return employee;
        }
        public async Task UpdateAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee != null)
            {
                await _repository.DeleteAsync(employee);
                await _repository.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId)
        {
            return await _repository.FindAsync(e => e.DepartmentId == departmentId);
        }
    }
}
