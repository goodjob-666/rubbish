/********************************************************************************
    File:
          tbServiceHelpEntity.cs
    Description:
          tbServiceHelp实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/11/6 11:46:14
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbServiceHelpEntity实体类(tbServiceHelp)
    ///</summary>
    [Serializable]
    public partial class tbServiceHelpEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // ODSerialNo
        private Int32 _UserID=0; // UserID
        private Int32 _AcceptUserID=0; // AcceptUserID
        private String _Content=""; // Content
        private Boolean _IsDeal=false; // IsDeal
        private DateTime? _CreateDate; // CreateDate
        private DateTime? _DealDate; // DealDate
        private Int32 _DealCustomerID=0; // DealCustomerID
        private String _Remark=""; // Remark
        private Int32 _HelpType = 0; // IsDeal
        
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
        /// ODSerialNo
        /// </summary>
        public String  ODSerialNo
        {
            set { this._ODSerialNo = value; }
            get { return this._ODSerialNo; }
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
        /// AcceptUserID
        /// </summary>
        public Int32  AcceptUserID
        {
            set { this._AcceptUserID = value; }
            get { return this._AcceptUserID; }
        }
            
        /// <summary>
        /// Content
        /// </summary>
        public String  Content
        {
            set { this._Content = value; }
            get { return this._Content; }
        }
            
        /// <summary>
        /// IsDeal
        /// </summary>
        public Boolean  IsDeal
        {
            set { this._IsDeal = value; }
            get { return this._IsDeal; }
        }

        /// <summary>
        /// HelpType
        /// </summary>
        public Int32 HelpType
        {
            set { this._HelpType = value; }
            get { return this._HelpType; }
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
        /// DealDate
        /// </summary>
        public DateTime?  DealDate
        {
            set { this._DealDate = value; }
            get { return this._DealDate; }
        }
            
        /// <summary>
        /// DealCustomerID
        /// </summary>
        public Int32  DealCustomerID
        {
            set { this._DealCustomerID = value; }
            get { return this._DealCustomerID; }
        }
            
        /// <summary>
        /// Remark
        /// </summary>
        public String  Remark
        {
            set { this._Remark = value; }
            get { return this._Remark; }
        }
            
        #endregion
    }
}
  