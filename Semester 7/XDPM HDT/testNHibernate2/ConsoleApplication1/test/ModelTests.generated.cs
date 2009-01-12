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
    public partial class ModelTests : UNuitTestBase
    {
        protected IModelManager manager;
		
		public ModelTests()
        {
            manager = managerFactory.GetModelManager();
        }
		
		protected Model CreateNewModel()
		{
			Model entity = new Model();
			
			
			entity.TenModel = "T";
			entity.PhuKien = "Te";
			entity.GiaBan = 16;
			entity.GhiChu = "Test Test ";
			
			ILoaiXeManager loaiXeManager = managerFactory.GetLoaiXeManager();
			entity.LoaiXeMember = loaiXeManager.GetAll(1)[0];
			
			return entity;
		}
		protected Model GetFirstModel()
        {
            IList<Model> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				Model entity = CreateNewModel();
				
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
                Model entityA = CreateNewModel();
				manager.Save(entityA);

                Model entityB = manager.GetById(entityA.Id);

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
                Model entityA = GetFirstModel();
				entityA.TenModel = "Test Te";
				
				manager.Update(entityA);

                Model entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.TenModel, entityB.TenModel);
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
                Model entity = GetFirstModel();
				
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

