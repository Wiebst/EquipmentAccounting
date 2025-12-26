using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EquipmentService
    {
        private readonly IGenericRepository<Equipment> _repository;

        public EquipmentService(IGenericRepository<Equipment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Equipment?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<Equipment?> GetByInventoryNumberAsync(string inventoryNumber)
        {
            var equipments = await _repository.FindAsync(e => e.InventoryNumber == inventoryNumber);
            return equipments.FirstOrDefault();
        }

        public async Task<IEnumerable<Equipment>> GetByEmployeeAsync(int employeeId)
        {
            return await _repository.FindAsync(e => e.ResponsibleEmployeeId == employeeId);
        }

        public async Task<IEnumerable<Equipment>> GetByStatusAsync(EquipmentStatus status)
        {
            return await _repository.FindAsync(e => e.Status == status);
        }

        public async Task<Equipment> AddAsync(Equipment equipment)
        {
            await _repository.AddAsync(equipment);
            await _repository.SaveChangesAsync();
            return equipment;
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            await _repository.UpdateAsync(equipment);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipment = await _repository.GetByIdAsync(id);
            if (equipment != null)
            {
                await _repository.DeleteAsync(equipment);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
