using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmSgkFiles")]
    public class FirmSgkFile : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Slug { get; set; }
        [Required, StringLength(500)]
        public string Name { get; set; } // dosya adı
        [Required, StringLength(500)]
        public string Username { get; set; } // dosya kullanıcı adı
        [Required, StringLength(500)]
        public string Number { get; set; } // dosya no
        [Required, StringLength(500)]
        public string SystemPassword { get; set; } // sistem şifresi
        [Required, StringLength(500)]
        public string WorkPlacePassword { get; set; } // İşyeri şifresi
        [Required, StringLength(500)]
        public string RegisterNumber { get; set; } // Sicil
        [Required, StringLength(500)]
        public string Branch { get; set; } // Şube
        [Required, StringLength(500)]
        public string Title { get; set; } // ünvan
        [Required, StringLength(500)]
        public string Address { get; set; }
        [Required]
        public int FirmId { get; set; } // virtual olanı kullanırsak fazladan 1 select atacaktı. bunu kullandıgımızda kendisi ılıskılendırcegı ıcın fazladan select atmaz
        public virtual Firm Firm { get; set; }
        public virtual List<FirmSgkFileUsers> TaskUsers { get; set; }

        public virtual User Owner { get; set; }
        public FirmSgkFile()
        {
            TaskUsers = new List<FirmSgkFileUsers>();
        }

    }
}
