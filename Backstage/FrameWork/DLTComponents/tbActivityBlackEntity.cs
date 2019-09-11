/********************************************************************************
    File:
          tbActivityBlackEntity.cs
    Description:
          tbActivityBlack实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/8/30 14:54:12
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbActivityBlackEntity实体类(tbActivityBlack)
    ///</summary>
    [Serializable]
    public partial class tbActivityBlackEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // UserID
        private DateTime? _CreateDate; // CreateDate
        private String _Comment=""; // Comment
        private Int32 _CustomerID=0; // CustomerID
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
        /// ID
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// UserID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime?  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// Comment
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// CustomerID
        /// </summary>
        public Int32  CustomerID
        {
            set { this._CustomerID = value; }
            get { return this._CustomerID; }
        }
            
        #endregion
    }
}
  