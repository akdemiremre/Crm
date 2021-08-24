using Crm.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.BusinessLayer
{
    public class Denemeler : RepositoryBase
    {
        public Denemeler()
        {
            //context.Database.CreateIfNotExists(); // db ve tablo oluşumunu sağlar ama örnek data oluşumunu sağlamaz.
            context.Users.ToList(); // örnek data oluşumu için bir tane tabloyu tolist etmek yeterlı
        }
    }
}
