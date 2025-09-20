using _51_entity_lab2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public EntityStatus Status { get; set; } = EntityStatus.aktif;

        public void setactive()
        {
            if (Status== EntityStatus.pasif)
                Status = EntityStatus.aktif;
            

        }

        public void setpasif()
        {
            if (Status == EntityStatus.aktif)
                Status = EntityStatus.pasif;

        }
    }
}
