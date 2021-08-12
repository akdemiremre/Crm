using Crm.DataAccessLayer;
using Crm.DataAccessLayer.EntityFramework;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.BusinessLayer
{
    public class Test
    {
        public Test()
        {
            /*
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            //db.Database.CreateIfNotExists(); // db ve tablo oluşumunu sağlar ama örnek data oluşumunu sağlamaz.
            // örnek data oluşumu için bir tane tabloyu tolist etmek yeterlı
            db.Users.ToList();
            */
            Repository<FirmSgkFile> repo = new Repository<FirmSgkFile>();
            List<FirmSgkFile> FirmSgkFiles = repo.List();
        }
    }
}
