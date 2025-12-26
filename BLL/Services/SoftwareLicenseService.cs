using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SoftwareLicenseService
    {
        private readonly IGenericRepository<SoftwareLicense> _repository;

        public SoftwareLicenseService(IGenericRepository<SoftwareLicense> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SoftwareLicense>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<SoftwareLicense?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<SoftwareLicense> AddAsync(SoftwareLicense license)
        {
            await _repository.AddAsync(license);
            await _repository.SaveChangesAsync();
            return license;
        }
        public async Task UpdateAsync(SoftwareLicense license)
        {
            await _repository.UpdateAsync(license);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var license = await _repository.GetByIdAsync(id);
            if (license != null)
            {
                await _repository.DeleteAsync(license);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
