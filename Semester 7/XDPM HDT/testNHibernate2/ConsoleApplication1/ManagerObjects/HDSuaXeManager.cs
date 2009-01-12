using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IHDSuaXeManager : IManagerBase<HDSuaXe, int>
    {
	}
	
	partial class HDSuaXeManager : ManagerBase<HDSuaXe, int>, IHDSuaXeManager
    {
	}
}