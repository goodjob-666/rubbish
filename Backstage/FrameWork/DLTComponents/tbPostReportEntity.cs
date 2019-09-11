/********************************************************************************
    File:
          tbPostReportEntity.cs
    Description:
          tbPostReport实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/12/23 15:35:26
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbPostReportEntity实体类(tbPostReport)
    ///</summary>
    [Serializable]
    public partial class tbPostReportEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _SerialNo=""; // SerialNo
        private Int32 _UserID=0; // UserID
        private Int32 _ReportCustomerID=0; // ReportCustomerID
        private DateTime? _CreateDate; // CreateDate
        private Int32 _DealCustomerID=0; // DealCustomerID
        private DateTime? _DealDate; // DealDate
        private Int32 _Status=0; // Status
        private String _Remark=""; // Remark
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
        /// SerialNo
        /// </summary>
        public String  SerialNo
        {
            set { this._SerialNo = value; }
            get { return this._SerialNo; }
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
        /// ReportCustomerID
        /// </summary>
        public Int32  ReportCustomerID
        {
            set { this._ReportCustomerID = value; }
            get { return this._ReportCustomerID; }
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
        /// DealCustomerID
        /// </summary>
        public Int32  DealCustomerID
        {
            set { this._DealCustomerID = value; }
            get { return this._DealCustomerID; }
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
        /// Status
        /// </summary>
        public Int32  Status
        {
            set { this._Status = value; }
            get { return this._Status; }
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
  