using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class HDNhapPhuTung : BusinessBase<int>
    {
        #region Declarations

		private System.DateTime _ngayNhap = new DateTime();
		private decimal _thanhTien = default(Decimal);
		private string _ghiChu = String.Empty;
		
		
		private IList<CTHDNhapPhuTung> _cTHDNhapPhuTungs = new List<CTHDNhapPhuTung>();
		
		#endregion

        #region Constructors

        public HDNhapPhuTung() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_ngayNhap);
			sb.Append(_thanhTien);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime NgayNhap
        {
            get { return _ngayNhap; }
			set
			{
				
				_ngayNhap = value;
				
			}
        }
		
		public virtual decimal ThanhTien
        {
            get { return _thanhTien; }
			set
			{
				
				_thanhTien = value;
				
			}
        }
		
		public virtual string GhiChu
        {
            get { return _ghiChu; }
			set
			{
				
				_ghiChu = value;
				
			}
        }
		
		public virtual IList<CTHDNhapPhuTung> CTHDNhapPhuTungs
        {
            get { return _cTHDNhapPhuTungs; }
            set
			{
				
				_cTHDNhapPhuTungs = value;
				
			}
        }
		
        #endregion
    }
}
