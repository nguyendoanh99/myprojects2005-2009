using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IXeDaSuaManager : IManagerBase<XeDaSua, int>
    {
		// Get Methods
		IList<XeDaSua> GetByMaKhachHang(System.Int32 maKhachHang);
    }

    partial class XeDaSuaManager : ManagerBase<XeDaSua, int>, IXeDaSuaManager
    {
		#region Constructors
		
		public XeDaSuaManager() : base()
        {
        }
        public XeDaSuaManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<XeDaSua> GetByMaKhachHang(System.Int32 maKhachHang)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(XeDaSua));
			
			
			ICriteria khachHangCriteria = criteria.CreateCriteria("KhachHangMember");
            khachHangCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maKhachHang));
			
			return criteria.List<XeDaSua>();
        }
		
		#endregion
    }
}