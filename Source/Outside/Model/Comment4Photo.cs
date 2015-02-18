using System;
namespace Suzy.Outside.Model
{
    /// <summary>
    /// Comment4Photo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Comment4Photo
    {
        public Comment4Photo()
        { }
        #region Model
        private string _id;
        private string _content;
        private DateTime? _createtime;
        private bool _istop = false;
        private Photo _photo;
        private Customer _commentator;


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
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>


        public Photo Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public Customer Commentator
        {
            get { return _commentator; }
            set { _commentator = value; }
        }
        #endregion Model
    }
}

