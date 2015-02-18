using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Article:实体类 
	/// </summary>
	[Serializable]
	public partial class Article
	{
		public Article()
		{}
		#region Model
        private string _id;
		private string _title;
		private DateTime _createtime;
		private DateTime? _updatetime;
		private string _content;
		private string _tag;
		private Customer  _author;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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
		public string Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Author 
		{
			set{ _author=value;}
			get{return _author;}
		}
		#endregion Model

	}
}

