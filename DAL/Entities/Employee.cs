using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; };

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public string? Position { get; set; }
    }
}
