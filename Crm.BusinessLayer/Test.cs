using Crm.DataAccessLayer;
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
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            object sonuc = db.Database.CreateIfNotExists(); // db ve tablo oluşumunu sağlar ama örnek data oluşumunu sağlamaz.
            // örnek data oluşumu için bir tane tabloyu tolist etmek yeterlı
            db.Firms.ToList();
        }
    }
}
