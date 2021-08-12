using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FirmCategory> FirmCategories { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<FirmSgkFile> FirmSgkFiles { get; set; }
        public DbSet<FirmSgkFileUsers> FirmSgkFileUsers { get; set; }
        public DbSet<FirmNoteCategory> FirmNoteCategories { get; set; }
        public DbSet<FirmNote> FirmNotes { get; set; }
        public DbSet<FirmNoteComments> FirmNoteComments {get; set;}
        public DbSet<FirmNoteUsers> FirmNoteUsers { get; set; }
        public DbSet<FirmTaskCategory> FirmTaskCategories { get; set; }
        public DbSet<FirmTask> FirmTasks { get; set; }
        public DbSet<FirmTaskComments> FirmTaskComments { get; set; }
        public DbSet<FirmTaskUsers> FirmTaskUser { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
