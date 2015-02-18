
using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// ActivityParticipantsMap:实体类 
	/// </summary>
	[Serializable]
	public partial class ActivityParticipantsMap
	{
		public ActivityParticipantsMap()
		{}
		#region Model
		private string _id;
		private string _relatetype;
		private DateTime? _createtime;
		private Activity _activity;
		private Customer _participants;
		private string _email;
		private string _tel;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 关联方式：如参加，收藏
		/// </summary>
		public string RelateType
		{
			set{ _relatetype=value;}
			get{return _relatetype;}
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
		public Activity Activity
		{
			set{ _activity=value;}
			get{return _activity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer Participants 
		{
			set{ _participants=value;}
			get{return _participants;}
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
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model

	}
}

