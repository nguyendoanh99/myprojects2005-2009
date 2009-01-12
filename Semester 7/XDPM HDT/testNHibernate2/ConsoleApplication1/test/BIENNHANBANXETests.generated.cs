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
    public partial class BIENNHANBANXETests : UNuitTestBase
    {
        protected IBIENNHANBANXEManager manager;
		
		public BIENNHANBANXETests()
        {
            manager = managerFactory.GetBIENNHANBANXEManager();
        }
		
		protected BIENNHANBANXE CreateNewBIENNHANBANXE()
		{
			BIENNHANBANXE entity = new BIENNHANBANXE();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = 99;
			
			entity.GhiChu = "Test Test ";
			entity.GiaThuTuc = 60;
			entity.GiaXe = 21;
			entity.MaSoBienNhan = "Te";
			entity.NgayMua = DateTime.Now;
			entity.TienUngTruoc = 2;
			
			IKHACHHANGManager kHACHHANGManager = managerFactory.GetKHACHHANGManager();
			entity.KHACHHANGMember = kHACHHANGManager.GetAll(1)[0];
			
			INGUOILAMTHUTUCManager nGUOILAMTHUTUCManager = managerFactory.GetNGUOILAMTHUTUCManager();
			entity.NGUOILAMTHUTUCMember = nGUOILAMTHUTUCManager.GetAll(1)[0];
			
			IXEMAYManager xEMAYManager = managerFactory.GetXEMAYManager();
			entity.XEMAYMember = xEMAYManager.GetAll(1)[0];
			
			return entity;
		}
		protected BIENNHANBANXE GetFirstBIENNHANBANXE()
        {
            IList<BIENNHANBANXE> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BIENNHANBANXE entity = CreateNewBIENNHANBANXE();
				
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
                BIENNHANBANXE entityA = CreateNewBIENNHANBANXE();
				manager.Save(entityA);

                BIENNHANBANXE entityB = manager.GetById(entityA.Id);

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
                BIENNHANBANXE entityA = GetFirstBIENNHANBANXE();
				entityA.GhiChu = "Test Test ";
				
				manager.Update(entityA);

                BIENNHANBANXE entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.GhiChu, entityB.GhiChu);
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
                BIENNHANBANXE entity = GetFirstBIENNHANBANXE();
				
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

