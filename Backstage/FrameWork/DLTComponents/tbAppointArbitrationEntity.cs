/********************************************************************************
    File:
          tbAppointArbitrationEntity.cs
    Description:
          tbAppointArbitration实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/9/22 22:19:02
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbAppointArbitrationEntity实体类(tbAppointArbitration)
    ///</summary>
    [Serializable]
    public partial class tbAppointArbitrationEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _CustomerID=0; // CustomerID
        private String _UserID=""; // UserID
        private DateTime? _CreateDate; // CreateDate
        private String _Comment=""; // Comment
        private Int32 _OpCustomerID=0; // OpCustomerID
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
        /// CustomerID
        /// </summary>
        public Int32  CustomerID
        {
            set { this._CustomerID = value; }
            get { return this._CustomerID; }
        }
            
        /// <summary>
        /// UserID
        /// </summary>
        public String  UserID
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
        /// OpCustomerID
        /// </summary>
        public Int32  OpCustomerID
        {
            set { this._OpCustomerID = value; }
            get { return this._OpCustomerID; }
        }
            
        #endregion
    }
}
  