using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class InstalledSoftware
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int SoftwareLicenseId { get; set; }
        public DateTime InstallationDate { get; set; } = DateTime.Now;
    }

}
