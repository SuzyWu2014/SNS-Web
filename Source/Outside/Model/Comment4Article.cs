using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Comment4Article:实体类 
	/// </summary>
	[Serializable]
	public partial class Comment4Article
	{
		public Comment4Article()
		{}
		#region Model
        private string _id;
		private string _content;
		private DateTime? _createtime;
		private Customer  _commentator;
		private  Article  _article;
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
		public Article  Article 
		{
			set{ _article=value;}
			get{return _article;}
		}
		#endregion Model

	}
}

