using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTrip.DataAccessLayer.Concrete.Entity_Framework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreatContext();
        }

        private static void CreatContext()
        {
            if (context == null)
            {
                //lock aynı aynı iki thead in calıstırılamayacağını söyler ilk iş biter sonra diğerini yapar
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
