using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NHibernate.Generated.ManagerObjects;
using NHibernate.Generated.BusinessObjects;

namespace NHibernate.Generated.Base
{
    public class UNuitTestBase
    {
        protected IManagerFactory managerFactory = new ManagerFactory();

        [SetUp]
        public void SetUp()
        {
            NHibernateSessionManager.Instance.Session.BeginTransaction();
        }
        [TearDown]
        public void TearDown()
        {
            NHibernateSessionManager.Instance.Session.RollbackTransaction();
        }
    }
}