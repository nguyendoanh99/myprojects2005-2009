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
    public partial class XeDaSuaTests : UNuitTestBase
    {
        protected IXeDaSuaManager manager;
		
		public XeDaSuaTests()
        {
            manager = managerFactory.GetXeDaSuaManager();
        }
		
		protected XeDaSua CreateNewXeDaSua()
		{
			XeDaSua entity = new XeDaSua();
			
			
			entity.LoaiXe = "Test Test ";
			entity.BienSo = "Test T";
			entity.MauSac = "Test Test Test Test Test";
			entity.SoKhung = "Test Test ";
			entity.SoMay = "Test Test Test Test Test Test";
			entity.NgayMua = DateTime.Now;
			entity.GhiChu = "Test Test ";
			
			IKhachHangManager khachHangManager = managerFactory.GetKhachHangManager();
            entity.KhachHangMember = null;//khachHangManager.GetAll(1)[0];
			
			return entity;
		}
		protected XeDaSua GetFirstXeDaSua()
        {
            IList<XeDaSua> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				XeDaSua entity = CreateNewXeDaSua();
				
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
                XeDaSua entityA = CreateNewXeDaSua();
				manager.Save(entityA);

                XeDaSua entityB = manager.GetById(entityA.Id);

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
                XeDaSua entityA = GetFirstXeDaSua();
				entityA.LoaiXe = "Test Test ";
				
				manager.Update(entityA);

                XeDaSua entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.LoaiXe, entityB.LoaiXe);
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
                XeDaSua entity = GetFirstXeDaSua();
				
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

