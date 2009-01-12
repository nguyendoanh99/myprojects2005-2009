using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IPhuTungManager : IManagerBase<PhuTung, int>
    {
	}
	
	partial class PhuTungManager : ManagerBase<PhuTung, int>, IPhuTungManager
    {
	}
}