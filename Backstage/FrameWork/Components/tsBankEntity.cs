/********************************************************************************
    File:
          tsBankEntity.cs
    Description:
          银行账户实体类
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
    ///tsBankEntity实体类(银行账户)
    ///</summary>
    [Serializable]
    public partial class tsBankEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int16 _BankID=0; // 银行ID
        private String _BankUser=""; // 银行户名
        private String _BankAcc=""; // 银行账号
        private String _BankAddr=""; // 开户地址
        private Boolean _IsDefault=false; // 是否缺省
        private String _Comment=""; // 备注
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
        /// 用户ID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// 银行ID
        /// </summary>
        public Int16  BankID
        {
            set { this._BankID = value; }
            get { return this._BankID; }
        }
            
        /// <summary>
        /// 银行户名
        /// </summary>
        public String  BankUser
        {
            set { this._BankUser = value; }
            get { return this._BankUser; }
        }
            
        /// <summary>
        /// 银行账号
        /// </summary>
        public String  BankAcc
        {
            set { this._BankAcc = value; }
            get { return this._BankAcc; }
        }
            
        /// <summary>
        /// 开户地址
        /// </summary>
        public String  BankAddr
        {
            set { this._BankAddr = value; }
            get { return this._BankAddr; }
        }
            
        /// <summary>
        /// 是否缺省
        /// </summary>
        public Boolean  IsDefault
        {
            set { this._IsDefault = value; }
            get { return this._IsDefault; }
        }
            
        /// <summary>
        /// 备注
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        #endregion
    }
}
  