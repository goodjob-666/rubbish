/********************************************************************************
    File:
          tsMoneyEntity.cs
    Description:
          余额实体类
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
    ///tsMoneyEntity实体类(余额)
    ///</summary>
    [Serializable]
    public partial class tsMoneyEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Double _SumBal=0.0000f; // 总金额
        private Double _FreezeBal=0.0000f; // 冻结资金
        private DateTime _ChangeDate=DateTime.Now; // 变动日期
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
        /// 总金额
        /// </summary>
        public Double  SumBal
        {
            set { this._SumBal = value; }
            get { return this._SumBal; }
        }
            
        /// <summary>
        /// 冻结资金
        /// </summary>
        public Double  FreezeBal
        {
            set { this._FreezeBal = value; }
            get { return this._FreezeBal; }
        }
            
        /// <summary>
        /// 变动日期
        /// </summary>
        public DateTime  ChangeDate
        {
            set { this._ChangeDate = value; }
            get { return this._ChangeDate; }
        }
            
        #endregion
    }
}
  