
using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace himusic
{
	#region Album

	/// <summary>
	/// Album object for NHibernate mapped table 'album'.
	/// </summary>
	public class Album : System.IComparable
		{
		#region Member Variables
		
		protected int _id;
		protected string _tenAlbum;
		protected DateTime _ngayPhatHanh;
		protected Casi _casi;
		protected IList _baihats;
		protected static String _sortExpression = "Id";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public Album() { }

		public Album( string tenAlbum, DateTime ngayPhatHanh, Casi casi )
		{
			this._tenAlbum = tenAlbum;
			this._ngayPhatHanh = ngayPhatHanh;
			this._casi = casi;
		}

		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual string TenAlbum
		{
			get { return _tenAlbum; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for TenAlbum", value, value.ToString());
				_tenAlbum = value;
			}
		}

        public virtual DateTime NgayPhatHanh
		{
			get { return _ngayPhatHanh; }
			set { _ngayPhatHanh = value; }
		}

        public virtual Casi Casi
		{
			get { return _casi; }
			set { _casi = value; }
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
			if (!(obj is Album))
				throw new InvalidCastException("This object is not of type Album");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "Id":
					relativeValue = this.Id.CompareTo(((Album)obj).Id);
					break;
				case "TenAlbum":
					relativeValue = this.TenAlbum.CompareTo(((Album)obj).TenAlbum);
					break;
				case "NgayPhatHanh":
					relativeValue = this.NgayPhatHanh.CompareTo(((Album)obj).NgayPhatHanh);
					break;
                default:
                    goto case "Id";
			}
            if (Album.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
