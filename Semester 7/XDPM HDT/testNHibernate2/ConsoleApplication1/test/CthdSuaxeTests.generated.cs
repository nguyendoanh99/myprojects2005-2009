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
    public partial class CTHDSuaXeTests : UNuitTestBase
    {
        protected ICTHDSuaXeManager manager;
		
		public CTHDSuaXeTests()
        {
            manager = managerFactory.GetCTHDSuaXeManager();
        }
		
		protected CTHDSuaXe CreateNewCTHDSuaXe()
		{
			CTHDSuaXe entity = new CTHDSuaXe();
			
			
			entity.STT = 5;
			entity.ChiTietSua = "Test Test Test Test T";
			entity.SoLuong = 87;
			entity.DonGium = 90;
			entity.PhanTramGiam = default(Double);
			entity.ThanhTien = 81;
			entity.GhiChu = "Test Test ";
			entity.Loai = true;
			
			IHDSuaXeManager hDSuaXeManager = managerFactory.GetHDSuaXeManager();
			entity.HDSuaXeMember = hDSuaXeManager.GetAll(1)[0];
			
			IPhuTungManager phuTungManager = managerFactory.GetPhuTungManager();
			entity.PhuTungMember = phuTungManager.GetAll(1)[0];
			
			return entity;
		}
		protected CTHDSuaXe GetFirstCTHDSuaXe()
        {
            IList<CTHDSuaXe> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				CTHDSuaXe entity = CreateNewCTHDSuaXe();
				
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
                CTHDSuaXe entityA = CreateNewCTHDSuaXe();
				manager.Save(entityA);

                CTHDSuaXe entityB = manager.GetById(entityA.Id);

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
                CTHDSuaXe entityA = GetFirstCTHDSuaXe();
				entityA.STT = 8;
				
				manager.Update(entityA);

                CTHDSuaXe entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.STT, entityB.STT);
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
                CTHDSuaXe entity = GetFirstCTHDSuaXe();
				
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

