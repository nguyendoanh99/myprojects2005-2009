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
		// Get Methods
		IList<HDSuaXe> GetByMaXeDaSua(System.Int32 maXeDaSua);
    }

    partial class HDSuaXeManager : ManagerBase<HDSuaXe, int>, IHDSuaXeManager
    {
		#region Constructors
		
		public HDSuaXeManager() : base()
        {
        }
        public HDSuaXeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<HDSuaXe> GetByMaXeDaSua(System.Int32 maXeDaSua)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(HDSuaXe));
			
			
			ICriteria xeDaSuaCriteria = criteria.CreateCriteria("XeDaSuaMember");
            xeDaSuaCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maXeDaSua));
			
			return criteria.List<HDSuaXe>();
        }
		
		#endregion
    }
}