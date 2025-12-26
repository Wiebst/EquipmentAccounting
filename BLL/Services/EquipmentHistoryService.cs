using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EquipmentHistoryService
    {
        private readonly IGenericRepository<EquipmentHistory> _repository;

        public EquipmentHistoryService(IGenericRepository<EquipmentHistory> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EquipmentHistory>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<EquipmentHistory>> GetByEquipmentAsync(int equipmentId)
        {
            var history = await _repository.FindAsync(h => h.EquipmentId == equipmentId);
            return history.OrderByDescending(h => h.MovementDate).ToList();
        }
        public async Task<EquipmentHistory> AddAsync(EquipmentHistory history)
        {
            await _repository.AddAsync(history);
            await _repository.SaveChangesAsync();
            return history;
        }
    }
}
