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
    public partial class CthdSuaxeExtraTests : UNuitTestBase
    {
        protected ICthdSuaxeExtraManager manager;
		
		public CthdSuaxeExtraTests()
        {
            manager = managerFactory.GetCthdSuaxeExtraManager();
        }
		
		protected CthdSuaxeExtra CreateNewCthdSuaxeExtra()
		{
			CthdSuaxeExtra entity = new CthdSuaxeExtra();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = 45;
			
			entity.DonGium = 2;
			entity.GhiChu = "Test Test ";
			entity.PhanTramGiam = 5;
			entity.SoLuong = 35;
			entity.STT = 97;
			entity.TenPhuTung = "Test Test Tes";
			entity.ThanhTien = 22;
			
			IHdSuaxeManager hdSuaxeManager = managerFactory.GetHdSuaxeManager();
			entity.HdSuaxeMember = hdSuaxeManager.GetAll(1)[0];
			
			return entity;
		}
		protected CthdSuaxeExtra GetFirstCthdSuaxeExtra()
        {
            IList<CthdSuaxeExtra> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				CthdSuaxeExtra entity = CreateNewCthdSuaxeExtra();
				
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
                CthdSuaxeExtra entityA = CreateNewCthdSuaxeExtra();
				manager.Save(entityA);

                CthdSuaxeExtra entityB = manager.GetById(entityA.Id);

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
                CthdSuaxeExtra entityA = GetFirstCthdSuaxeExtra();
				entityA.DonGium = 72;
				
				manager.Update(entityA);

                CthdSuaxeExtra entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.DonGium, entityB.DonGium);
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
                CthdSuaxeExtra entity = GetFirstCthdSuaxeExtra();
				
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

