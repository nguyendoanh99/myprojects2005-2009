using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class Model : BusinessBase<int>
    {
        #region Declarations

		private string _tenModel = String.Empty;
		private string _phuKien = String.Empty;
		private decimal _giaBan = default(Decimal);
		private string _ghiChu = String.Empty;
		
		private LoaiXe _loaiXe = null;
		
		private IList<PhuTung> _phuTungs = new List<PhuTung>();
		
		#endregion

        #region Constructors

        public Model() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_tenModel);
			sb.Append(_phuKien);
			sb.Append(_giaBan);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string TenModel
        {
            get { return _tenModel; }
			set
			{
				
				_tenModel = value;
				
			}
        }
		
		public virtual string PhuKien
        {
            get { return _phuKien; }
			set
			{
				
				_phuKien = value;
				
			}
        }
		
		public virtual decimal GiaBan
        {
            get { return _giaBan; }
			set
			{
				
				_giaBan = value;
				
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
		
		public virtual LoaiXe LoaiXeMember
        {
            get { return _loaiXe; }
			set
			{
				
				_loaiXe = value;
				
			}
        }
		
		public virtual IList<PhuTung> PhuTungs
        {
            get { return _phuTungs; }
            set
			{
				
				_phuTungs = value;
				
			}
        }
		
        #endregion
    }
}
