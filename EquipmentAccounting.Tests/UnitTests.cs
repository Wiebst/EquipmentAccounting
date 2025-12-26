using BLL.Services;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Tests
{
    [Collection("Database")]
    public class UnitTests
    {
        private readonly AppDbContext _context = new(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options);

        [Fact]
        public async Task AddAsync_Works()
        {
            var service = new DepartmentService(new GenericRepository<Department>(_context));
            var dept = new Department { Name = "IT" };

            await service.AddAsync(dept);

            var count = await _context.Departments.CountAsync();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DeleteAsync_Works()
        {
            var dept = new Department { Name = "HR" };
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();

            var service = new DepartmentService(new GenericRepository<Department>(_context));
            await service.DeleteAsync(dept.Id);

            var count = await _context.Departments.CountAsync();
            Assert.Equal(0, count);
        }
    }
}
