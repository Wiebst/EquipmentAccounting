using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetEquipmentByDepartmentsAsync()
        {
            return await (from e in _context.Equipments
                          join emp in _context.Employees on e.ResponsibleEmployeeId equals emp.Id
                          join d in _context.Departments on emp.DepartmentId equals d.Id
                          select new
                          {
                              DepartmentName = d.Name,
                              EmployeeName = emp.FullName,
                              Equipment = e.InventoryNumber + " - " + e.Name
                          }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetSoftwareByEmployeeAsync(int employeeId)
        {
            return await (from e in _context.Equipments
                          where e.ResponsibleEmployeeId == employeeId
                          join isw in _context.InstalledSoftwares on e.Id equals isw.EquipmentId
                          join sl in _context.SoftwareLicenses on isw.SoftwareLicenseId equals sl.Id
                          select new
                          {
                              Equipment = e.InventoryNumber,
                              Software = sl.Name,
                              LicenseKey = sl.LicenseKey,
                              InstallDate = isw.InstallationDate
                          }).ToListAsync();
        }
    }
}
