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
	}
	
	partial class LoaiXeManager : ManagerBase<LoaiXe, int>, ILoaiXeManager
    {
	}
}