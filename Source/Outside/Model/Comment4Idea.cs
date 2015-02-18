using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Comment4Idea:实体类 
	/// </summary>
	[Serializable]
	public partial class Comment4Idea
	{
		public Comment4Idea()
		{}
		#region Model
        private string _id;
		private string _content;
		private DateTime? _createtime;
		private ActivityIdeas   _activityideas ;
		private Customer _commentator ;
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
		public ActivityIdeas  ActivityIdeas 
		{
			set{ _activityideas=value;}
			get{return _activityideas;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Commentator 
		{
			set{ _commentator=value;}
			get{return _commentator;}
		}
		#endregion Model

	}
}

