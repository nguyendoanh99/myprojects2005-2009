using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface ILoaiXeManager : IManagerBase<LoaiXe, int>
    {
		// Get Methods
		IList<LoaiXe> GetByMaHangXe(System.Int32 maHangXe);
    }

    partial class LoaiXeManager : ManagerBase<LoaiXe, int>, ILoaiXeManager
    {
		#region Constructors
		
		public LoaiXeManager() : base()
        {
        }
        public LoaiXeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<LoaiXe> GetByMaHangXe(System.Int32 maHangXe)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(LoaiXe));
			
			
			ICriteria hangXeCriteria = criteria.CreateCriteria("HangXeMember");
            hangXeCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maHangXe));
			
			return criteria.List<LoaiXe>();
        }
		
		#endregion
    }
}