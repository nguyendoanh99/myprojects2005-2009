using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IHDNhapPhuTungManager : IManagerBase<HDNhapPhuTung, int>
    {
		// Get Methods
    }

    partial class HDNhapPhuTungManager : ManagerBase<HDNhapPhuTung, int>, IHDNhapPhuTungManager
    {
		#region Constructors
		
		public HDNhapPhuTungManager() : base()
        {
        }
        public HDNhapPhuTungManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}