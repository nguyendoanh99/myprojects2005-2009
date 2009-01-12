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
    public partial class HDSuaXeTests : UNuitTestBase
    {
        protected IHDSuaXeManager manager;
		
		public HDSuaXeTests()
        {
            manager = managerFactory.GetHDSuaXeManager();
        }
		
		protected HDSuaXe CreateNewHDSuaXe()
		{
			HDSuaXe entity = new HDSuaXe();
			
			
			entity.MaSoHoaDon = "Test Test Tes";
			entity.KhachHang = "Test Test Test Te";
			entity.DiaChi = "Test Test ";
			entity.DienThoai = "Test Test ";
			entity.SoKm = 23;
			entity.NgaySua = DateTime.Now;
			entity.LoaiHinhSuaChua = "Test Test ";
			entity.TinhTrangHuHong = "Test Test ";
			entity.TimPanSuaChua = "Test Test ";
			entity.TienPhuTung = 10;
			entity.TienCong = 58;
			entity.ThanhTien = 87;
			entity.NhanVienPhucVu = "Test Test ";
			entity.GhiChu = "Test Test ";
			
			IXeDaSuaManager xeDaSuaManager = managerFactory.GetXeDaSuaManager();
			entity.XeDaSuaMember = xeDaSuaManager.GetAll(1)[0];
			
			return entity;
		}
		protected HDSuaXe GetFirstHDSuaXe()
        {
            IList<HDSuaXe> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				HDSuaXe entity = CreateNewHDSuaXe();
				
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
                HDSuaXe entityA = CreateNewHDSuaXe();
				manager.Save(entityA);

                HDSuaXe entityB = manager.GetById(entityA.Id);

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
                HDSuaXe entityA = GetFirstHDSuaXe();
				entityA.MaSoHoaDon = "Test Tes";
				
				manager.Update(entityA);

                HDSuaXe entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.MaSoHoaDon, entityB.MaSoHoaDon);
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
                HDSuaXe entity = GetFirstHDSuaXe();
				
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

