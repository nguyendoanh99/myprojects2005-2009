using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface IModelManager : IManagerBase<Model, int>
    {
	}
	
	partial class ModelManager : ManagerBase<Model, int>, IModelManager
    {
	}
}