using System;
using System.Collections.Generic;
using System.Text;
using NHibernateSimpleDemo;
using himusic;
namespace himusic
{
    class Program
    {
        static void Main(string[] args)
        {
            PersistenceManager pm = new PersistenceManager();
            IList<Album> q = pm.RetrieveAll<Album>(SessionAction.Begin);
            
        }
    }
}
