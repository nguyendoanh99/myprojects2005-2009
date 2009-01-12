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
    public partial class CTHDNhapPhuTungTests : UNuitTestBase
    {
        protected ICTHDNhapPhuTungManager manager;
		
		public CTHDNhapPhuTungTests()
        {
            manager = managerFactory.GetCTHDNhapPhuTungManager();
        }
		
		protected CTHDNhapPhuTung CreateNewCTHDNhapPhuTung()
		{
			CTHDNhapPhuTung entity = new CTHDNhapPhuTung();
			
			
			entity.SoLuong = 17;
			entity.DonGiaNhap = 32;
			entity.ThanhTien = 18;
			entity.GhiChu = "Test Test ";
			
			IHDNhapPhuTungManager hDNhapPhuTungManager = managerFactory.GetHDNhapPhuTungManager();
			entity.HDNhapPhuTungMember = hDNhapPhuTungManager.GetAll(1)[0];
			
			IPhuTungManager phuTungManager = managerFactory.GetPhuTungManager();
			entity.PhuTungMember = phuTungManager.GetAll(1)[0];
			
			return entity;
		}
		protected CTHDNhapPhuTung GetFirstCTHDNhapPhuTung()
        {
            IList<CTHDNhapPhuTung> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				CTHDNhapPhuTung entity = CreateNewCTHDNhapPhuTung();
				
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
                CTHDNhapPhuTung entityA = CreateNewCTHDNhapPhuTung();
				manager.Save(entityA);

                CTHDNhapPhuTung entityB = manager.GetById(entityA.Id);

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
                CTHDNhapPhuTung entityA = GetFirstCTHDNhapPhuTung();
				entityA.SoLuong = 40;
				
				manager.Update(entityA);

                CTHDNhapPhuTung entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.SoLuong, entityB.SoLuong);
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
                CTHDNhapPhuTung entity = GetFirstCTHDNhapPhuTung();
				
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

