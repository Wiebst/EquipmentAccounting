using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EquipmentHistory
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public int? OldEmployeeId { get; set; }
        public int NewEmployeeId { get; set; }
    }

}
