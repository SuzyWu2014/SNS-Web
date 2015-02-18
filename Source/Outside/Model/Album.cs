using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Album:实体类 
	/// </summary>
	[Serializable]
	public partial class Album
	{
		public Album()
		{}
		#region Model
        private string _id;
		private string _title;
		private DateTime _createtime;
		private string _des;
		private Customer _customer;
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
		public string Des
		{
			set{ _des=value;}
			get{return _des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer Customer 
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		#endregion Model

	}
}

