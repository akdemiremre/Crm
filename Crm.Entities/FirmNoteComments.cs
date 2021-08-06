using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmNoteComments")]
    public class FirmNoteComments : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Description { get; set; }
        public virtual FirmNote FirmNote { get; set; }
        public virtual User Owner { get; set; }
    }
}
