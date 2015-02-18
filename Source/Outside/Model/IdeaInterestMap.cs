using System;
namespace Suzy.Outside.Model
{
	/// <summary>
	/// IdeaInterestMap:实体类 
	/// </summary>
	[Serializable]
	public partial class IdeaInterestMap
	{
		public IdeaInterestMap()
		{}
		#region Model
        private string _id;
		private ActivityIdeas _activityideas ;
		private Customer  _interester ;
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
		public ActivityIdeas  ActivityIdeas 
		{
			set{ _activityideas=value;}
			get{return _activityideas;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Customer  Interester 
		{
			set{ _interester=value;}
			get{return _interester;}
		}
		#endregion Model

	}
}

