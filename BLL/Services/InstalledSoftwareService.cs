using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InstalledSoftwareService
    {
        private readonly IGenericRepository<InstalledSoftware> _repository;

        public InstalledSoftwareService(IGenericRepository<InstalledSoftware> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InstalledSoftware>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<InstalledSoftware>> GetByEquipmentAsync(int equipmentId)
        {
            return await _repository.FindAsync(isw => isw.EquipmentId == equipmentId);
        }
        public async Task<IEnumerable<InstalledSoftware>> GetByLicenseAsync(int licenseId)
        {
            return await _repository.FindAsync(isw => isw.SoftwareLicenseId == licenseId);
        }
        public async Task<InstalledSoftware> AddAsync(InstalledSoftware installedSoftware)
        {
            await _repository.AddAsync(installedSoftware);
            await _repository.SaveChangesAsync();
            return installedSoftware;
        }
        public async Task DeleteAsync(int equipmentId, int licenseId)
        {
            var installedSoftware = await _repository.Query()
                .FirstOrDefaultAsync(isw => isw.EquipmentId == equipmentId && isw.SoftwareLicenseId == licenseId);
            if (installedSoftware != null)
            {
                await _repository.DeleteAsync(installedSoftware);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
