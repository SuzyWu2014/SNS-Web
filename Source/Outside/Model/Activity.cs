 
using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Activity:实体类
	/// </summary>
	[Serializable]
	public partial class Activity
	{
		public Activity()
		{}
		#region Model
		private string _id;
		private string _topic;
		private DateTime? _createtime=DateTime.Now;
		private string _activitytype;
		private string _timedes;
		private string _timecycle;
		private string _posterpath;
		private string _placetype= "0";
		private string _university;
		private string _place;
		private int? _countjoin=0;
		private int? _countrecommend=0;
		private int? _countcollect=0;
		private string _activitystatus="即将开始";
		private string _adminattitude="unchecked";
		private decimal? _fee;
		private string _detail;
		private string _tag;
		private ActivityIdeas  _activityideas;
		private Customer  _sponsor;
        private bool _isneedcontact = false;

        public bool IsNeedContact
        {
            get { return _isneedcontact; }
            set { _isneedcontact = value; }
        }
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
		public string Topic
		{
			set{ _topic=value;}
			get{return _topic;}
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
		public string ActivityType
		{
			set{ _activitytype=value;}
			get{return _activitytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TimeDes
		{
			set{ _timedes=value;}
			get{return _timedes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TimeCycle
		{
			set{ _timecycle=value;}
			get{return _timecycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PosterPath
		{
			set{ _posterpath=value;}
			get{return _posterpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlaceType
		{
			set{ _placetype=value;}
			get{return _placetype;}
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
		public string Place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountJoin
		{
			set{ _countjoin=value;}
			get{return _countjoin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountRecommend
		{
			set{ _countrecommend=value;}
			get{return _countrecommend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountCollect
		{
			set{ _countcollect=value;}
			get{return _countcollect;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActivityStatus
		{
			set{ _activitystatus=value;}
			get{return _activitystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminAttitude
		{
			set{ _adminattitude=value;}
			get{return _adminattitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
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
		public ActivityIdeas  ActivityIdeas
		{
			set{ _activityideas=value;}
			get{return _activityideas;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Sponsor
		{
			set{ _sponsor=value;}
			get{return _sponsor;}
		}
		#endregion Model

	}
}

