using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Generated.BusinessObjects;
using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public partial interface ICTHDNhapPhuTungManager : IManagerBase<CTHDNhapPhuTung, int>
    {
		// Get Methods
		IList<CTHDNhapPhuTung> GetByMaHoaDonNhap(System.Int32 maHoaDonNhap);
		IList<CTHDNhapPhuTung> GetByMaPhuTung(System.Int32 maPhuTung);
    }

    partial class CTHDNhapPhuTungManager : ManagerBase<CTHDNhapPhuTung, int>, ICTHDNhapPhuTungManager
    {
		#region Constructors
		
		public CTHDNhapPhuTungManager() : base()
        {
        }
        public CTHDNhapPhuTungManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<CTHDNhapPhuTung> GetByMaHoaDonNhap(System.Int32 maHoaDonNhap)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CTHDNhapPhuTung));
			
			
			ICriteria hDNhapPhuTungCriteria = criteria.CreateCriteria("HDNhapPhuTungMember");
            hDNhapPhuTungCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maHoaDonNhap));
			
			return criteria.List<CTHDNhapPhuTung>();
        }
		
		public IList<CTHDNhapPhuTung> GetByMaPhuTung(System.Int32 maPhuTung)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CTHDNhapPhuTung));
			
			
			ICriteria phuTungCriteria = criteria.CreateCriteria("PhuTungMember");
            phuTungCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", maPhuTung));
			
			return criteria.List<CTHDNhapPhuTung>();
        }
		
		#endregion
    }
}