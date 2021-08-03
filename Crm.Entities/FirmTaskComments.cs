using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Entities
{
    [Table("FirmTaskComments")]
    public class FirmTaskComments : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Description { get; set; }
        public virtual FirmTask FirmTask { get; set; }
    }
}
