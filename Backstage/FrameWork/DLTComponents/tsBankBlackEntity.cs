/********************************************************************************
    File:
          tsBankBlackEntity.cs
    Description:
          tsBankBlack实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/3/19 16:53:44
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tsBankBlackEntity实体类(tsBankBlack)
    ///</summary>
    [Serializable]
    public partial class tsBankBlackEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int16 _BankID=0; // BankID
        private String _BankUser=""; // BankUser
        private String _BankAcc=""; // BankAcc
        private DateTime? _CreateDate; // CreateDate
        private Int32 _CustomerID=0; // CustomerID
        private String _Comment=""; // Comment
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
        /// BankID
        /// </summary>
        public Int16  BankID
        {
            set { this._BankID = value; }
            get { return this._BankID; }
        }
            
        /// <summary>
        /// BankUser
        /// </summary>
        public String  BankUser
        {
            set { this._BankUser = value; }
            get { return this._BankUser; }
        }
            
        /// <summary>
        /// BankAcc
        /// </summary>
        public String  BankAcc
        {
            set { this._BankAcc = value; }
            get { return this._BankAcc; }
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
        /// CustomerID
        /// </summary>
        public Int32  CustomerID
        {
            set { this._CustomerID = value; }
            get { return this._CustomerID; }
        }
            
        /// <summary>
        /// Comment
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        #endregion
    }
}
  