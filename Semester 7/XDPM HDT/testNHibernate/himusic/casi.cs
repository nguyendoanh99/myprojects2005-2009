
using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace himusic
{
	#region Casi

	/// <summary>
	/// Casi object for NHibernate mapped table 'casi'.
	/// </summary>
	public class Casi : System.IComparable
		{
		#region Member Variables
		
		protected int _id;
		protected string _tenCaSi;
		protected string _quocGia;
		protected IList _albums;
		protected IList _baihats;
		protected static String _sortExpression = "Id";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public Casi() { }

		public Casi( string tenCaSi, string quocGia )
		{
			this._tenCaSi = tenCaSi;
			this._quocGia = quocGia;
		}

		#endregion

		#region Public Properties

        public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual string TenCaSi
		{
			get { return _tenCaSi; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TenCaSi", value, value.ToString());
				_tenCaSi = value;
			}
		}

        public virtual string QuocGia
		{
			get { return _quocGia; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for QuocGia", value, value.ToString());
				_quocGia = value;
			}
		}

        public virtual IList albums
		{
			get
			{
				if (_albums==null)
				{
					_albums = new ArrayList();
				}
				return _albums;
			}
			set { _albums = value; }
		}

        public virtual IList baihats
		{
			get
			{
				if (_baihats==null)
				{
					_baihats = new ArrayList();
				}
				return _baihats;
			}
			set { _baihats = value; }
		}

        public static String SortExpression
        {
            get { return _sortExpression; }
            set { _sortExpression = value; }
        }

        public static SortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }
		#endregion
		
        #region IComparable Methods
        public virtual int CompareTo(object obj)
        {
			if (!(obj is Casi))
				throw new InvalidCastException("This object is not of type Casi");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "Id":
					relativeValue = this.Id.CompareTo(((Casi)obj).Id);
					break;
				case "TenCaSi":
					relativeValue = this.TenCaSi.CompareTo(((Casi)obj).TenCaSi);
					break;
				case "QuocGia":
					relativeValue = this.QuocGia.CompareTo(((Casi)obj).QuocGia);
					break;
                default:
                    goto case "Id";
			}
            if (Casi.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
