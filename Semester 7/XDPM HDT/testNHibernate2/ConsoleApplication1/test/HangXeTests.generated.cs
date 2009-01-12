using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NHibernate.Generated.ManagerObjects;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace test
{
	[TestFixture]
    public partial class HangXeTests : UNuitTestBase
    {
        protected IHangXeManager manager;
		
		public HangXeTests()
        {
            manager = managerFactory.GetHangXeManager();
        }
		
		protected HangXe CreateNewHangXe()
		{
			HangXe entity = new HangXe();
			
			
			entity.HangXeMember = "Test Test Test";
			entity.GhiChu = "Test Test ";
			
			return entity;
		}
		protected HangXe GetFirstHangXe()
        {
            IList<HangXe> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				HangXe entity = CreateNewHangXe();
				
                object result = manager.Save(entity);

                Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Read()
        {
            try
            {
                HangXe entityA = CreateNewHangXe();
				manager.Save(entityA);

                HangXe entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
		[Test]
		public void Update()
        {
            try
            {
                HangXe entityA = GetFirstHangXe();
				entityA.HangXeMember = "Test Test ";
				
				manager.Update(entityA);

                HangXe entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.HangXeMember, entityB.HangXeMember);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Delete()
        {
            try
            {
                HangXe entity = GetFirstHangXe();
				
                manager.Delete(entity);

                entity = manager.GetById(entity.Id);
                Assert.IsNull(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
	}
}

