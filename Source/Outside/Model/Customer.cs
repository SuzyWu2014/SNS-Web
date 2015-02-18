using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Customer:实体类 
	/// </summary>
	[Serializable]
	public partial class Customer
	{
		public Customer()
		{}
		#region Model
        private string _id;
		private string _username;
		private string _password;
		private string _email;
		private string _introself;
		private string _university;
		private string _college;
		private bool _iscollegeprivate= false;
		private string _major;
		private bool _ismajorprivate= false;
        private string _headportraitpath = "/Resource/Images/Project/defaultPortrait.JPG";
		private DateTime? _createtime;
		private string _entranceyear;
		private bool _isentraceyearprivate= false;
		private bool _isorganization= false;
		private string _nickname;
		private int _countfans=0;
		private int _countactivities=0;
		private string _realname;
		private bool _isrealnameprivate= false;
		private string _tag;
		private long? _score=0;
        private string sex = "女";

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
		private InvitationCode _invitationcode ;
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IntroSelf
		{
			set{ _introself=value;}
			get{return _introself;}
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
		public string College
		{
			set{ _college=value;}
			get{return _college;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsCollegePrivate
		{
			set{ _iscollegeprivate=value;}
			get{return _iscollegeprivate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMajorPrivate
		{
			set{ _ismajorprivate=value;}
			get{return _ismajorprivate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HeadPortraitPath
		{
			set{ _headportraitpath=value;}
			get{return _headportraitpath;}
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
		public string EntranceYear
		{
			set{ _entranceyear=value;}
			get{return _entranceyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsEntraceYearPrivate
		{
			set{ _isentraceyearprivate=value;}
			get{return _isentraceyearprivate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsOrganization
		{
			set{ _isorganization=value;}
			get{return _isorganization;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CountFans
		{
			set{ _countfans=value;}
			get{return _countfans;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CountActivities
		{
			set{ _countactivities=value;}
			get{return _countactivities;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsRealNamePrivate
		{
			set{ _isrealnameprivate=value;}
			get{return _isrealnameprivate;}
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
		public long? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public InvitationCode InvitationCode 
		{
			set{ _invitationcode=value;}
			get{return _invitationcode;}
		}
		#endregion Model

	}
}

