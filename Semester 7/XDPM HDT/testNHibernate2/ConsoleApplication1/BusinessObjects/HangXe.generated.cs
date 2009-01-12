using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class HangXe : BusinessBase<int>
    {
        #region Declarations

		private string _hangXeMember = String.Empty;
		private string _ghiChu = String.Empty;
		
		
		private IList<LoaiXe> _loaiXes = new List<LoaiXe>();
		
		#endregion

        #region Constructors

        public HangXe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_hangXeMember);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string HangXeMember
        {
            get { return _hangXeMember; }
			set
			{
				
				_hangXeMember = value;
				
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
		
		public virtual IList<LoaiXe> LoaiXes
        {
            get { return _loaiXes; }
            set
			{
				
				_loaiXes = value;
				
			}
        }
		
        #endregion
    }
}
