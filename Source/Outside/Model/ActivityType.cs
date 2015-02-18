using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// ActivityType:实体类
	/// </summary>
	[Serializable]
	public partial class ActivityType
	{
		public ActivityType()
		{}
		#region Model
        private string _id;
		private string _parenttype;
		private string _subtype;
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
		public string ParentType
		{
			set{ _parenttype=value;}
			get{return _parenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubType
		{
			set{ _subtype=value;}
			get{return _subtype;}
		}
		#endregion Model

	}
}

