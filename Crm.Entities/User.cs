using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    [Table("Users")]
    public class User : MyEntityBase
    {
        [Required, StringLength(500)]
        public string Name { get; set; }
        [Required, StringLength(500)]
        public string Surname { get; set; }
        [Required, StringLength(500)]
        public string Username { get; set; }
        [Required, StringLength(500)]
        public string Password { get; set; }
        [Required, StringLength(500)]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }
    }
}
