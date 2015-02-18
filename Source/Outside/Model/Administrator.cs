using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Administrator:实体类
	/// </summary>
	[Serializable]
	public partial class Administrator
	{
		public Administrator()
		{}
		#region Model
        private string _id;
		private string _admin;
		private string _password;
		private string _realname;
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
		/// 
		/// </summary>
		public string Admin
		{
			set{ _admin=value;}
			get{return _admin;}
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
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
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

