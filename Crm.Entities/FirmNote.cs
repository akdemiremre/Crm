using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmNotes")]
    public class FirmNote : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Description { get; set; }
        public int FirmNoteCategoryId { get; set; }
        public virtual FirmNoteCategory FirmNoteCategory { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<FirmNoteUsers> TaskUsers { get; set; }
        public virtual List<FirmNoteComments> NoteComments { get; set; }

        public FirmNote()
        {
            NoteComments = new List<FirmNoteComments>();
            TaskUsers = new List<FirmNoteUsers>();
        }
    }
}
