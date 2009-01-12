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
    public partial class PhuTungTests : UNuitTestBase
    {
        protected IPhuTungManager manager;
		
		public PhuTungTests()
        {
            manager = managerFactory.GetPhuTungManager();
        }
		
		protected PhuTung CreateNewPhuTung()
		{
			PhuTung entity = new PhuTung();
			
			
			entity.MaSoPhuTung = "Test Te";
			entity.TenPhuTung = "Test Test Test Test Test Test T";
			entity.SoLuong = 82;
			entity.DonVi = "Te";
			entity.TongTienVon = 99;
			entity.GiaVonTren1DV = 6;
			entity.GiaBanTren1DV = 60;
			entity.GhiChu = "Test Test ";
			
			IModelManager modelManager = managerFactory.GetModelManager();
			entity.ModelMember = modelManager.GetAll(1)[0];
			
			return entity;
		}
		protected PhuTung GetFirstPhuTung()
        {
            IList<PhuTung> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				PhuTung entity = CreateNewPhuTung();
				
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
                PhuTung entityA = CreateNewPhuTung();
				manager.Save(entityA);

                PhuTung entityB = manager.GetById(entityA.Id);

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
                PhuTung entityA = GetFirstPhuTung();
				entityA.MaSoPhuTung = "Test Test T";
				
				manager.Update(entityA);

                PhuTung entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.MaSoPhuTung, entityB.MaSoPhuTung);
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
                PhuTung entity = GetFirstPhuTung();
				
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

