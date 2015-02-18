using System;
namespace Suzy.Outside.Model
{
    /// <summary>
    /// InvitationCode:实体类 
    /// </summary>
    [Serializable]
    public partial class InvitationCode
    {
        public InvitationCode()
        { }
        #region Model
        private string _id;
        private string _code;
        private bool _isused = false;
        private string _createusertype;
        private Customer _customercreator;
        private Administrator _admincreator;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsUsed
        {
            set { _isused = value; }
            get { return _isused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUserType
        {
            set { _createusertype = value; }
            get { return _createusertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Customer CustomerCreator
        {
            set { _customercreator = value; }
            get { return _customercreator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Administrator AdminCreator
        {
            set { _admincreator = value; }
            get { return _admincreator; }
        }
        #endregion Model

    }
}

