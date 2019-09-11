/********************************************************************************
    File:
          sys_CommentEntity.cs
    Description:
          sys_Comment实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/1/17 星期六 17:32:45
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_CommentEntity实体类(sys_Comment)
    ///</summary>
    [Serializable]
    public partial class sys_CommentEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _C_CommentID=0; // C_CommentID
        private Int32 _C_NewsID=0; // C_NewsID
        private Int32 _C_PostID=0; // C_PostID
        private String _C_Content=""; // C_Content
        private String _C_Remarks=""; // C_Remarks
        private DateTime? _C_CreateDate; // C_CreateDate
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
        /// C_CommentID
        /// </summary>
        public Int32  C_CommentID
        {
            set { this._C_CommentID = value; }
            get { return this._C_CommentID; }
        }

        /// <summary>
        /// C_CreateDate
        /// </summary>
        public DateTime? C_CreateDate
        {
            set { this._C_CreateDate = value; }
            get { return this._C_CreateDate; }
        }
            
        /// <summary>
        /// C_NewsID
        /// </summary>
        public Int32  C_NewsID
        {
            set { this._C_NewsID = value; }
            get { return this._C_NewsID; }
        }
            
        /// <summary>
        /// C_PostID
        /// </summary>
        public Int32  C_PostID
        {
            set { this._C_PostID = value; }
            get { return this._C_PostID; }
        }
            
        /// <summary>
        /// C_Content
        /// </summary>
        public String  C_Content
        {
            set { this._C_Content = value; }
            get { return this._C_Content; }
        }
            
        /// <summary>
        /// C_Remarks
        /// </summary>
        public String  C_Remarks
        {
            set { this._C_Remarks = value; }
            get { return this._C_Remarks; }
        }
            
        #endregion
    }
}
  