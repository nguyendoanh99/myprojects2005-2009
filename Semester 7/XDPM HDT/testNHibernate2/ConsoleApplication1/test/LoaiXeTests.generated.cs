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
    public partial class LoaiXeTests : UNuitTestBase
    {
        protected ILoaiXeManager manager;
		
		public LoaiXeTests()
        {
            manager = managerFactory.GetLoaiXeManager();
        }
		
		protected LoaiXe CreateNewLoaiXe()
		{
			LoaiXe entity = new LoaiXe();
			
			
			entity.TenLoaiXe = "Test Test Test T";
			entity.GhiChu = "Test Test ";
			
			IHangXeManager hangXeManager = managerFactory.GetHangXeManager();
			entity.HangXeMember = hangXeManager.GetAll(1)[0];
			
			return entity;
		}
		protected LoaiXe GetFirstLoaiXe()
        {
            IList<LoaiXe> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				LoaiXe entity = CreateNewLoaiXe();
				
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
                LoaiXe entityA = CreateNewLoaiXe();
				manager.Save(entityA);

                LoaiXe entityB = manager.GetById(entityA.Id);

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
                LoaiXe entityA = GetFirstLoaiXe();
				entityA.TenLoaiXe = "Test Test Test Test Tes";
				
				manager.Update(entityA);

                LoaiXe entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.TenLoaiXe, entityB.TenLoaiXe);
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
                LoaiXe entity = GetFirstLoaiXe();
				
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

