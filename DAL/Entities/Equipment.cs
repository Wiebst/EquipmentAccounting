using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public enum EquipmentStatus
    {
        InWork,
        OnRetirement,
        InRepair
    }

    public class Equipment
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Name { get; set; }
        public int EquipmentTypeId { get; set; }
        public string SerialNumber { get; set; }
        public int? ResponsibleEmployeeId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public EquipmentStatus Status { get; set; } = EquipmentStatus.InWork;
    }
}
