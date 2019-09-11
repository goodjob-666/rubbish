/********************************************************************************
    File:
          tbLevelOrderRightEntity.cs
    Description:
          订单可查看权限实体类
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
    ///tbLevelOrderRightEntity实体类(订单可查看权限)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderRightEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // 订单流水号
        private Int16 _RightType=0; // 权限类别
        private Int32 _RelaID=0; // 相关ID
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
        /// 权限类别
        /// </summary>
        public Int16  RightType
        {
            set { this._RightType = value; }
            get { return this._RightType; }
        }
            
        /// <summary>
        /// 相关ID
        /// </summary>
        public Int32  RelaID
        {
            set { this._RelaID = value; }
            get { return this._RelaID; }
        }
            
        #endregion
    }
}
  