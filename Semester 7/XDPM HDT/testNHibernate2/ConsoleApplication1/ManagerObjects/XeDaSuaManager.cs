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
	}
	
	partial class XeDaSuaManager : ManagerBase<XeDaSua, int>, IXeDaSuaManager
    {
	}
}