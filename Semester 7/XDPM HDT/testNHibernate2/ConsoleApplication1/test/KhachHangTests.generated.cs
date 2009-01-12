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
    public partial class KhachHangTests : UNuitTestBase
    {
        protected IKhachHangManager manager;
		
		public KhachHangTests()
        {
            manager = managerFactory.GetKhachHangManager();
        }
		
		protected KhachHang CreateNewKhachHang()
		{
			KhachHang entity = new KhachHang();
			
			
			entity.HoTen = "Test Test ";
			entity.SoNha = "Te";
			entity.Duong = "Test T";
			entity.Phuong = "Test Test Test Tes";
			entity.Quan = "Test Test Test Tes";
			entity.ThanhPho = "Test Tes";
			entity.DienThoaiBan = "Test Te";
			entity.DiDong = "Test Test Test T";
			entity.Nam = true;
			entity.NamSinh = default(Int16);
			entity.GhiChu = "Test Test ";
			
			return entity;
		}
		protected KhachHang GetFirstKhachHang()
        {
            IList<KhachHang> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				KhachHang entity = CreateNewKhachHang();
				
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
                KhachHang entityA = CreateNewKhachHang();
				manager.Save(entityA);

                KhachHang entityB = manager.GetById(entityA.Id);

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
                KhachHang entityA = GetFirstKhachHang();
				entityA.HoTen = "Test Test Test Test Test";
				
				manager.Update(entityA);

                KhachHang entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.HoTen, entityB.HoTen);
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
                KhachHang entity = GetFirstKhachHang();
				
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

