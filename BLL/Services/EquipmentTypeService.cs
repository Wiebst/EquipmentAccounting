using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EquipmentTypeService
    {
        private readonly IGenericRepository<EquipmentType> _repository;

        public EquipmentTypeService(IGenericRepository<EquipmentType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EquipmentType>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<EquipmentType?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<EquipmentType> AddAsync(EquipmentType type)
        {
            await _repository.AddAsync(type);
            await _repository.SaveChangesAsync();
            return type;
        }
        public async Task UpdateAsync(EquipmentType type)
        {
            await _repository.UpdateAsync(type);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var type = await _repository.GetByIdAsync(id);
            if (type != null)
            {
                await _repository.DeleteAsync(type);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
