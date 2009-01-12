using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface ICTHDSuaXeManager : IManagerBase<CTHDSuaXe, int>
    {
		// Get Methods
		IList<CTHDSuaXe> GetByMaHoaDon(System.Int32 maHoaDon);
		IList<CTHDSuaXe> GetByMaPhuTung(System.Int32 maPhuTung);
    }

    partial class CTHDSuaXeManager : ManagerBase<CTHDSuaXe, int>, ICTHDSuaXeManager
    {
		#region Constructors
		
		public CTHDSuaXeManager() : base()
        {
        }
        public CTHDSuaXeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<CTHDSuaXe> GetByMaHoaDon(System.Int32 maHoaDon)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CTHDSuaXe));
			
			
			ICriteria hDSuaXeCriteria = criteria.CreateCriteria("HDSuaXeMember");
            hDSuaXeCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maHoaDon));
			
			return criteria.List<CTHDSuaXe>();
        }
		
		public IList<CTHDSuaXe> GetByMaPhuTung(System.Int32 maPhuTung)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CTHDSuaXe));
			
			
			ICriteria phuTungCriteria = criteria.CreateCriteria("PhuTungMember");
            phuTungCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maPhuTung));
			
			return criteria.List<CTHDSuaXe>();
        }
		
		#endregion
    }
}