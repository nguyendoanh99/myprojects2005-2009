using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IPhuTungManager : IManagerBase<PhuTung, int>
    {
		// Get Methods
		IList<PhuTung> GetByMaModel(System.Int32 maModel);
    }

    partial class PhuTungManager : ManagerBase<PhuTung, int>, IPhuTungManager
    {
		#region Constructors
		
		public PhuTungManager() : base()
        {
        }
        public PhuTungManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PhuTung> GetByMaModel(System.Int32 maModel)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PhuTung));
			
			
			ICriteria modelCriteria = criteria.CreateCriteria("ModelMember");
            modelCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maModel));
			
			return criteria.List<PhuTung>();
        }
		
		#endregion
    }
}