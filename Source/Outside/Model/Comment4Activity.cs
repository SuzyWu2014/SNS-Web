using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Comment4Activity:实体类 
	/// </summary>
	[Serializable]
	public partial class Comment4Activity
	{
		public Comment4Activity()
		{}
		#region Model
        private string _id;
		private string _content;
		private DateTime? _createtime;
		private Customer  _commentator;
		private Activity  _activity;
		private bool _istop= false;
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
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Commentator 
		{
			set{ _commentator=value;}
			get{return _commentator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Activity  Activity 
		{
			set{ _activity=value;}
			get{return _activity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		#endregion Model

	}
}

