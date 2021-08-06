using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmTaskCategories")]
    public class FirmTaskCategory : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Name { get; set; }
        [Required, StringLength(500)]
        public string Color { get; set; }
        public virtual User Owner { get; set; }
    }
}
