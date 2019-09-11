/********************************************************************************
    File:
          tbActivityEntity.cs
    Description:
          tbActivity实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/8/24 11:21:15
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbMoneyChangeEntity实体类(tbActivity)
    ///</summary>
    [Serializable]
    public partial class tbMoneyChangeEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private String _SerialNo = "";
        private Int32 _UserID = 0; 
        private Int32 _ChangeType = 0;
        private Double _PreBal = 0.0000f;
        private Double _ChangeBal = 0.0000f;
        private Double _CurBal = 0.0000f;
        private DateTime _ChangeDate;
        private String _RelaSerialNo = "";
        private String _Comment = "";
       
       
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
       
         public Int32 UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }

       
        /// <summary>
        /// 
        /// </summary>
         public String SerialNo
        {
            set { this._SerialNo = value; }
            get { return this._SerialNo; }
        }

        public Int32 ChangeType
        {
            set { this._ChangeType = value; }
            get { return this._ChangeType; }
        }

        public Double PreBal
        {
            get { return _PreBal; }
            set { _PreBal = value; }
        }

        public Double ChangeBal
        {
            get { return _ChangeBal; }
            set { _ChangeBal = value; }
        }

        public Double CurBal
        {
            get { return _CurBal; }
            set { _CurBal = value; }
        }

        public DateTime ChangeDate
        {
            get { return _ChangeDate; }
            set { _ChangeDate = value; }
        }

        public String RelaSerialNo
        {
            get { return _RelaSerialNo; }
            set { _RelaSerialNo = value; }
        }

        public String Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        #endregion
    }
}
