/********************************************************************************
    File:
          tbLevelOrderCancelEntity.cs
    Description:
          代练撤销实体类
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
    ///tbLevelOrderCancelEntity实体类(代练撤销)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderCancelEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // 订单流水号
        private Int32 _UserID=0; // 用户ID
        private DateTime _CreateDate=DateTime.Now; // 创建时间
        private Double _PayLevelBal=0.0000f; // 支付代练费
        private Double _RepEnsureBal=0.0000f; // 赔偿保证金
        private Int16 _Status=0; // 状态
        private String _Comment=""; // 备注
        private Int32 _AcceptCount=0; // 接单方撤销次数
        private Int32 _PublishCount=0; // 发单方撤销次数
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
        /// 创建时间
        /// </summary>
        public DateTime  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// 支付代练费
        /// </summary>
        public Double  PayLevelBal
        {
            set { this._PayLevelBal = value; }
            get { return this._PayLevelBal; }
        }
            
        /// <summary>
        /// 赔偿保证金
        /// </summary>
        public Double  RepEnsureBal
        {
            set { this._RepEnsureBal = value; }
            get { return this._RepEnsureBal; }
        }
            
        /// <summary>
        /// 状态
        /// </summary>
        public Int16  Status
        {
            set { this._Status = value; }
            get { return this._Status; }
        }
            
        /// <summary>
        /// 备注
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// 接单方撤销次数
        /// </summary>
        public Int32  AcceptCount
        {
            set { this._AcceptCount = value; }
            get { return this._AcceptCount; }
        }
            
        /// <summary>
        /// 发单方撤销次数
        /// </summary>
        public Int32  PublishCount
        {
            set { this._PublishCount = value; }
            get { return this._PublishCount; }
        }
            
        #endregion
    }
}
  