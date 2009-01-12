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
	}
	
	partial class HangXeManager : ManagerBase<HangXe, int>, IHangXeManager
    {
	}
}