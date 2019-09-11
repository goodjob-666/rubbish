/********************************************************************************
    File:
          tlOperateEntity.cs
    Description:
          操作日志实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2014/8/5 13:39:35
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbRechargeEntity实体类(操作日志)
    ///</summary>
    [Serializable]
    public partial class tbRechargeEntity
    {
        


        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private String _SerialNo = ""; 
        private Int32 _UserID=0; // 用户ID
        private Double _Bal = 0; // 
        private String _ExChargeNo = ""; // 
        private DateTime? _CreateDate; // 创建时间
        private String _Comment = ""; //
        #endregion

        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }

        public String SerialNo
        {
            set { this._SerialNo = value; }
            get { return this._SerialNo; }
        }

        public String ExChargeNo
        {
            set { this._ExChargeNo = value; }
            get { return this._ExChargeNo; }
        }


        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32 UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }

        public Double Bal
        {
            get { return _Bal; }
            set { _Bal = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

        public String Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
    }
}
  