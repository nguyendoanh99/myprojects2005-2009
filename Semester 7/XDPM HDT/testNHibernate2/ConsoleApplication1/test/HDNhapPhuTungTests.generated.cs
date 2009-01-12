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
    public partial class HDNhapPhuTungTests : UNuitTestBase
    {
        protected IHDNhapPhuTungManager manager;
		
		public HDNhapPhuTungTests()
        {
            manager = managerFactory.GetHDNhapPhuTungManager();
        }
		
		protected HDNhapPhuTung CreateNewHDNhapPhuTung()
		{
			HDNhapPhuTung entity = new HDNhapPhuTung();
			
			
			entity.NgayNhap = DateTime.Now;
			entity.ThanhTien = 9;
			entity.GhiChu = "Test Test ";
			
			return entity;
		}
		protected HDNhapPhuTung GetFirstHDNhapPhuTung()
        {
            IList<HDNhapPhuTung> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				HDNhapPhuTung entity = CreateNewHDNhapPhuTung();
				
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
                HDNhapPhuTung entityA = CreateNewHDNhapPhuTung();
				manager.Save(entityA);

                HDNhapPhuTung entityB = manager.GetById(entityA.Id);

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
                HDNhapPhuTung entityA = GetFirstHDNhapPhuTung();
				entityA.NgayNhap = DateTime.Now;
				
				manager.Update(entityA);

                HDNhapPhuTung entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.NgayNhap, entityB.NgayNhap);
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
                HDNhapPhuTung entity = GetFirstHDNhapPhuTung();
				
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

