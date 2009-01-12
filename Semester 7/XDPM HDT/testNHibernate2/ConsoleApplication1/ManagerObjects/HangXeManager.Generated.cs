using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IHangXeManager : IManagerBase<HangXe, int>
    {
		// Get Methods
    }

    partial class HangXeManager : ManagerBase<HangXe, int>, IHangXeManager
    {
		#region Constructors
		
		public HangXeManager() : base()
        {
        }
        public HangXeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}