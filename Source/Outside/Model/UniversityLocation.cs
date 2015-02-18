using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// UniversityLocation:实体类 
	/// </summary>
	[Serializable]
	public partial class UniversityLocation
	{
		public UniversityLocation()
		{}
		#region Model
        private string _id;
		private string _university;
		private string _city;
		private string _province;
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
		public string University
		{
			set{ _university=value;}
			get{return _university;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		#endregion Model

	}
}

