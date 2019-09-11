/********************************************************************************
    File:
          tbFeedBackEntity.cs
    Description:
          tbFeedBack实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/8/30 17:25:37
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbFeedBackEntity实体类(tbFeedBack)
    ///</summary>
    [Serializable]
    public partial class tbFeedBackEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0; // 序号ID
        private Int32 _UserID = 0; // 用户ID
        private String _Source = ""; // 提交来源
        private String _Feedback = ""; // 反馈内容
        private DateTime _CreateDate = DateTime.Now; // 提交时间
        private String _Comment = ""; // Comment
        private Int32 _CustomerID = 0; // CustomerID
        private Int32 _Mark = 10; // 序号ID
        #endregion

        #region "Public Variables"
        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }
        /// <summary>
        /// 序号ID
        /// </summary>
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32 UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }

        /// <summary>
        /// 提交来源
        /// </summary>
        public String Source
        {
            set { this._Source = value; }
            get { return this._Source; }
        }

        /// <summary>
        /// 反馈内容
        /// </summary>
        public String Feedback
        {
            set { this._Feedback = value; }
            get { return this._Feedback; }
        }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }

        /// <summary>
        /// CustomerID
        /// </summary>
        public Int32 CustomerID
        {
            set { this._CustomerID = value; }
            get { return this._CustomerID; }
        }

        /// <summary>
        /// Mark
        /// </summary>
        public Int32 Mark
        {
            set { this._Mark = value; }
            get { return this._Mark; }
        }
        #endregion
    }
}
