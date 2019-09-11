/********************************************************************************
    File:
          tbVirtualBankEntity.cs
    Description:
          tbVirtualBank实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2014/9/12 星期五 22:12:33
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbVirtualBankEntity实体类(tbVirtualBank)
    ///</summary>
    [Serializable]
    public partial class tbVirtualBankEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _BankName=""; // BankName
        private Double _MONEY=0.0000f; // MONEY
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
        /// BankName
        /// </summary>
        public String  BankName
        {
            set { this._BankName = value; }
            get { return this._BankName; }
        }
            
        /// <summary>
        /// MONEY
        /// </summary>
        public Double  MONEY
        {
            set { this._MONEY = value; }
            get { return this._MONEY; }
        }
            
        #endregion
    }
}
  