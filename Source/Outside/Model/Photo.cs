using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Photo:实体类 
	/// </summary>
	[Serializable]
	public partial class Photo
	{
		public Photo()
		{}
		#region Model
        private string _id;
		private string _imagesmallpath;
		private string _imagebigpath;
		private string _title;
		private string _des;
		private DateTime? _uploadtime;
		private Activity  _activity ;
		private  Album  _album ;
		private Customer  _uploader ;
		/// <summary>
		/// 
		/// </summary>
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageSmallPath
		{
			set{ _imagesmallpath=value;}
			get{return _imagesmallpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageBigPath
		{
			set{ _imagebigpath=value;}
			get{return _imagebigpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Des
		{
			set{ _des=value;}
			get{return _des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public  Activity  Activity 
		{
			set{ _activity=value;}
			get{return _activity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Album  Album 
		{
			set{ _album=value;}
			get{return _album;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Uploader 
		{
			set{ _uploader=value;}
			get{return _uploader;}
		}
		#endregion Model

	}
}

