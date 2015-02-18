
using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// ActivityTime:实体类 
	/// </summary>
	[Serializable]
	public partial class ActivityTime
	{
		public ActivityTime()
		{}
		#region Model
		private string _id;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _week;
		private int? _day;
		private Activity _activity;
		private bool _isend= false;
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
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Week
		{
			set{ _week=value;}
			get{return _week;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Day
		{
			set{ _day=value;}
			get{return _day;}
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
		public bool IsEnd
		{
			set{ _isend=value;}
			get{return _isend;}
		}
		#endregion Model

	}
}

