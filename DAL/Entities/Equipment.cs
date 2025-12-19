using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Equipment : BaseEntity
    {
        public string InventoryNumber { get; set; }

        public int TypeId { get; set; }
        public EquipmentType Type { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string? SerialNumber { get; set; }
    }
}
