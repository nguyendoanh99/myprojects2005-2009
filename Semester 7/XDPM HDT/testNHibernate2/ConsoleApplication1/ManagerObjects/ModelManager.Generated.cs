using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IModelManager : IManagerBase<Model, int>
    {
		// Get Methods
		IList<Model> GetByMaLoaiXe(System.Int32 maLoaiXe);
    }

    partial class ModelManager : ManagerBase<Model, int>, IModelManager
    {
		#region Constructors
		
		public ModelManager() : base()
        {
        }
        public ModelManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Model> GetByMaLoaiXe(System.Int32 maLoaiXe)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Model));
			
			
			ICriteria loaiXeCriteria = criteria.CreateCriteria("LoaiXeMember");
            loaiXeCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maLoaiXe));
			
			return criteria.List<Model>();
        }
		
		#endregion
    }
}