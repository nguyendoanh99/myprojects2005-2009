using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class LoaiXe : BusinessBase<int>
    {
        #region Declarations

		private string _tenLoaiXe = String.Empty;
		private string _ghiChu = String.Empty;
		
		private HangXe _hangXe = null;
		
		private IList<Model> _models = new List<Model>();
		
		#endregion

        #region Constructors

        public LoaiXe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_tenLoaiXe);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string TenLoaiXe
        {
            get { return _tenLoaiXe; }
			set
			{
				
				_tenLoaiXe = value;
				
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
		
		public virtual HangXe HangXeMember
        {
            get { return _hangXe; }
			set
			{
				
				_hangXe = value;
				
			}
        }
		
		public virtual IList<Model> Models
        {
            get { return _models; }
            set
			{
				
				_models = value;
				
			}
        }
		
        #endregion
    }
}
