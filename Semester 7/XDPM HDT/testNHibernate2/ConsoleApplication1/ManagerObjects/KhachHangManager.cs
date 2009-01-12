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
	}
	
	partial class KhachHangManager : ManagerBase<KhachHang, int>, IKhachHangManager
    {
	}
}