using Crm.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context; // private dan protected yapık: miras alındığı repository.cs de kullanabilmek için
        private static object _lockSync = new object(); // lock 1 tane object ister.

        protected RepositoryBase() 
        {
            // miras alındığı an constructor ı calısacak
            CreateContext();
        }
        private static void CreateContext() // protected oldugu ıcın new lenmeyecek direkt olarak functionı kullanması için static tanımladık. // protected a gerek yok. artık dışardan görünmesi gerekmiyor. private yaptık.
        {
            if (context == null)
            {
                // multithread lerde aynı anda 2 thread bu if e girebilir. bunun için lock kullanıp 2 threadi kitleyip aynı anda girmelerini engelledik.
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
