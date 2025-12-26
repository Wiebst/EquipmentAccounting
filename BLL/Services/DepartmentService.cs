using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService
    {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentService(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Department?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Department> AddAsync(Department department)
        {
            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
            return department;
        }
        public async Task UpdateAsync(Department department)
        {
            await _repository.UpdateAsync(department);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department != null)
            {
                await _repository.DeleteAsync(department);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
