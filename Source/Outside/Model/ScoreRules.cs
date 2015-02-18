using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// ScoreRules:实体类 
	/// </summary>
	[Serializable]
	public partial class ScoreRules
	{
		public ScoreRules()
		{}
		#region Model
        private string _id;
		private string _itermcode;
		private string _itermname;
		private int? _score;
		private string _remark;
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
		public string ItermCode
		{
			set{ _itermcode=value;}
			get{return _itermcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItermName
		{
			set{ _itermname=value;}
			get{return _itermname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

