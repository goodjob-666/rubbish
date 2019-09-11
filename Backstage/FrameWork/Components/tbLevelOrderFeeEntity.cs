/********************************************************************************
    File:
          tbLevelOrderFeeEntity.cs
    Description:
          订单费用实体类
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
    ///tbLevelOrderFeeEntity实体类(订单费用)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderFeeEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // 订单流水号
        private Int32 _UserID=0; // 用户ID
        private Double _Bal=0.0000f; // 金额
        private Double _Fee=0.0000f; // 手续费
        private DateTime? _CreateDate; // 创建时间
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
        /// 订单流水号
        /// </summary>
        public String  ODSerialNo
        {
            set { this._ODSerialNo = value; }
            get { return this._ODSerialNo; }
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
        /// 金额
        /// </summary>
        public Double  Bal
        {
            set { this._Bal = value; }
            get { return this._Bal; }
        }
            
        /// <summary>
        /// 手续费
        /// </summary>
        public Double  Fee
        {
            set { this._Fee = value; }
            get { return this._Fee; }
        }
            
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        #endregion
    }
}
  