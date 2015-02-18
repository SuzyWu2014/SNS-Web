using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// FansIdolMap:实体类 
	/// </summary>
	[Serializable]
	public partial class FansIdolMap
	{
		public FansIdolMap()
		{}
		#region Model
        private string _id;
		private  Customer  _fans;
		private Customer  _idol;
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
		public Customer  Fans 
		{
			set{ _fans=value;}
			get{return _fans;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Idol 
		{
			set{ _idol=value;}
			get{return _idol;}
		}
		#endregion Model

	}
}

