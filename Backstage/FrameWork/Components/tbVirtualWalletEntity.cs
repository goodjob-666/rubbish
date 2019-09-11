/********************************************************************************
    File:
          tbVirtualWalletEntity.cs
    Description:
          tbVirtualWallet实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2014/9/12 星期五 21:51:00
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbVirtualWalletEntity实体类(tbVirtualWallet)
    ///</summary>
    [Serializable]
    public partial class tbVirtualWalletEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _OPID=0; // OPID
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
        /// OPID
        /// </summary>
        public Int32  OPID
        {
            set { this._OPID = value; }
            get { return this._OPID; }
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
  