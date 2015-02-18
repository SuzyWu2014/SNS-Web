using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Msg:实体类 
	/// </summary>
	[Serializable]
	public partial class Msg
	{
		public Msg()
		{}
		#region Model
        private string _id;
		private string _content;
		private bool _isread= false;
		private string _relatedpath;
		private string _msgtype;
		private Customer  _customer ;
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
		public bool IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RelatedPath
		{
			set{ _relatedpath=value;}
			get{return _relatedpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Customer 
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		#endregion Model

	}
}

