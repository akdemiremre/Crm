using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("Firms")]
    public class Firm : MyEntityBase
    {
        [Required,StringLength(500)]
        public string Slug { get; set; }
        [Required,StringLength(500)]
        public string Name { get; set; } // firma adı
        [Required, StringLength(500)]
        public string Title { get; set; } // ünvan
        [Required, StringLength(500)]
        public string TaxNumber { get; set; } // vergi no
        [Required, StringLength(500)]
        public string TaxOffice { get; set; } // vergi dairesi
        [Required,StringLength(500)]
        public string RegisterNumber { get; set; } // sicil no
        [Required, StringLength(500)]
        public string Address { get; set; }
        public int FirmCategoryId { get; set; } // aşağıdaki virtual ı kullanırsak fazladan 1 select atar. ama bunu kullanırsak dırekt ılıskılendırır ve fazladan select atmaz.

        public virtual Firm Referance { get; set; }

        public virtual List<FirmNote> FirmNotes { get; set; }
        public virtual List<FirmTask> FirmTasks { get; set; }
        public virtual List<FirmSgkFile> FirmSgkFiles { get; set; }
        public virtual FirmCategory FirmCategory { get; set; }
        public virtual User Owner { get; set; }

        public Firm()
        {
            FirmNotes = new List<FirmNote>();
            FirmTasks = new List<FirmTask>();
            FirmSgkFiles = new List<FirmSgkFile>();
        }
    }
}
