using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IKhachHangManager : IManagerBase<KhachHang, int>
    {
		// Get Methods
    }

    partial class KhachHangManager : ManagerBase<KhachHang, int>, IKhachHangManager
    {
		#region Constructors
		
		public KhachHangManager() : base()
        {
        }
        public KhachHangManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}