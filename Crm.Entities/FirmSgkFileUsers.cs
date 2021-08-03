using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmSgkFileUsers")]
    public class FirmSgkFileUsers
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual FirmSgkFile FirmSgkFile { get; set; }
        public virtual User User { get; set; }
    }
}
