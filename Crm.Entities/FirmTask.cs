using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("FirmTasks")]
    public class FirmTask : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Title { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int FirmTaskCategoryId { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<FirmTaskUsers> TaskUsers { get; set; }
        public virtual List<FirmTaskComments> TaskComments { get; set; }
        public FirmTask()
        {
            TaskComments = new List<FirmTaskComments>();
            TaskUsers = new List<FirmTaskUsers>();
        }

    }
}
