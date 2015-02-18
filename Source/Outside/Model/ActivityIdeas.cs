using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// ActivityIdeas:实体类 
	/// </summary>
	[Serializable]
	public partial class ActivityIdeas
	{
		public ActivityIdeas()
		{}
		#region Model
        private string _id;
		private string _title;
		private string _des;
		private string _activitytype;
		private bool _isrealized= false;
		private string _tag;
		private string _university;
		private string _scope;
		private string _remark;
		private int? _countinterested=0;
		private Customer  _creator;
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
		public string Des
		{
			set{ _des=value;}
			get{return _des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActivityType
		{
			set{ _activitytype=value;}
			get{return _activitytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsRealized
		{
			set{ _isrealized=value;}
			get{return _isrealized;}
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
		public string University
		{
			set{ _university=value;}
			get{return _university;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Scope
		{
			set{ _scope=value;}
			get{return _scope;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountInterested
		{
			set{ _countinterested=value;}
			get{return _countinterested;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Creator 
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		#endregion Model

	}
}

