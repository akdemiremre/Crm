using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmCategories")]
    public class FirmCategory:MyEntityBase
    {
        [Required,StringLength(500)]
        public string Name { get; set; }
    }
}
