/********************************************************************************
    File:
          sys_PendingCommentEntity.cs
    Description:
          sys_PendingComment实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/5/23 2:08:31
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_PendingCommentEntity实体类(sys_PendingComment)
    ///</summary>
    [Serializable]
    public partial class sys_PendingCommentEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _P_CommentID=0; // P_CommentID
        private Int32 _P_PendingID=0; // P_PendingID
        private Int32 _P_CommentPostID=0; // P_CommentPostID
        private Int32 _P_CommentStauts=0; // P_CommentStauts
        private String _P_CommentContent=""; // P_CommentContent
        private String _P_CommentRemarks=""; // P_CommentRemarks
        private String _P_Pre=""; // P_Pre
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
        /// P_CommentID
        /// </summary>
        public Int32  P_CommentID
        {
            set { this._P_CommentID = value; }
            get { return this._P_CommentID; }
        }
            
        /// <summary>
        /// P_PendingID
        /// </summary>
        public Int32  P_PendingID
        {
            set { this._P_PendingID = value; }
            get { return this._P_PendingID; }
        }
            
        /// <summary>
        /// P_CommentPostID
        /// </summary>
        public Int32  P_CommentPostID
        {
            set { this._P_CommentPostID = value; }
            get { return this._P_CommentPostID; }
        }
            
        /// <summary>
        /// P_CommentStauts
        /// </summary>
        public Int32  P_CommentStauts
        {
            set { this._P_CommentStauts = value; }
            get { return this._P_CommentStauts; }
        }
            
        /// <summary>
        /// P_CommentContent
        /// </summary>
        public String  P_CommentContent
        {
            set { this._P_CommentContent = value; }
            get { return this._P_CommentContent; }
        }
            
        /// <summary>
        /// P_CommentRemarks
        /// </summary>
        public String  P_CommentRemarks
        {
            set { this._P_CommentRemarks = value; }
            get { return this._P_CommentRemarks; }
        }
            
        /// <summary>
        /// P_Pre
        /// </summary>
        public String  P_Pre
        {
            set { this._P_Pre = value; }
            get { return this._P_Pre; }
        }
            
        #endregion
    }
}
  