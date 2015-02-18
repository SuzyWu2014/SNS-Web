using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// Tag:实体类 
	/// </summary>
	[Serializable]
	public partial class Tag
	{
		public Tag()
		{}
		#region Model
        private string _id;
		private string _tagname;
		private int? _countused=0;
		private string _type;
		private bool _isenabled= true;
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
		public string TagName
		{
			set{ _tagname=value;}
			get{return _tagname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountUsed
		{
			set{ _countused=value;}
			get{return _countused;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsEnabled
		{
			set{ _isenabled=value;}
			get{return _isenabled;}
		}
		#endregion Model

	}
}

