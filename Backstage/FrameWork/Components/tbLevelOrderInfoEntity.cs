/********************************************************************************
    File:
          tbLevelOrderInfoEntity.cs
    Description:
          代练订单角色资料实体类
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
    ///tbLevelOrderInfoEntity实体类(代练订单角色资料)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderInfoEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // 订单流水号
        private String _GameAcc=""; // 帐号
        private String _GamePass=""; // 密码
        private String _Actor=""; // 角色
        private String _CurrInfo=""; // 代练前角色信息
        private String _Require=""; // 代练最终要求
        private Byte[] _SecPic=null; // 密保图片
        private String _Comment=""; // 描述
        private Int32 _ChangePassCount=0; // 改密次数
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
        /// 帐号
        /// </summary>
        public String  GameAcc
        {
            set { this._GameAcc = value; }
            get { return this._GameAcc; }
        }
            
        /// <summary>
        /// 密码
        /// </summary>
        public String  GamePass
        {
            set { this._GamePass = value; }
            get { return this._GamePass; }
        }
            
        /// <summary>
        /// 角色
        /// </summary>
        public String  Actor
        {
            set { this._Actor = value; }
            get { return this._Actor; }
        }
            
        /// <summary>
        /// 代练前角色信息
        /// </summary>
        public String  CurrInfo
        {
            set { this._CurrInfo = value; }
            get { return this._CurrInfo; }
        }
            
        /// <summary>
        /// 代练最终要求
        /// </summary>
        public String  Require
        {
            set { this._Require = value; }
            get { return this._Require; }
        }
            
        /// <summary>
        /// 密保图片
        /// </summary>
        public Byte[]  SecPic
        {
            set { this._SecPic = value; }
            get { return this._SecPic; }
        }
            
        /// <summary>
        /// 描述
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// 改密次数
        /// </summary>
        public Int32  ChangePassCount
        {
            set { this._ChangePassCount = value; }
            get { return this._ChangePassCount; }
        }
            
        #endregion
    }
}
  