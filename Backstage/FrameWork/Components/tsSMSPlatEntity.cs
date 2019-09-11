/********************************************************************************
    File:
          tsSMSPlatEntity.cs
    Description:
          短信平台实体类
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
    ///tsSMSPlatEntity实体类(短信平台)
    ///</summary>
    [Serializable]
    public partial class tsSMSPlatEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _PlatName=""; // 平台名称
        private String _PostUrl=""; // 提交地址
        private String _UserName=""; // 用户名
        private String _Password=""; // 密码
        private String _AppID=""; // 应用ID
        private String _SuccessKey=""; // 成功关键字
        private Int16 _SmsStyle=0; // 发送方式
        private Boolean _IsEnable=false; // 是否使用
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
        /// 平台名称
        /// </summary>
        public String  PlatName
        {
            set { this._PlatName = value; }
            get { return this._PlatName; }
        }
            
        /// <summary>
        /// 提交地址
        /// </summary>
        public String  PostUrl
        {
            set { this._PostUrl = value; }
            get { return this._PostUrl; }
        }
            
        /// <summary>
        /// 用户名
        /// </summary>
        public String  UserName
        {
            set { this._UserName = value; }
            get { return this._UserName; }
        }
            
        /// <summary>
        /// 密码
        /// </summary>
        public String  Password
        {
            set { this._Password = value; }
            get { return this._Password; }
        }
            
        /// <summary>
        /// 应用ID
        /// </summary>
        public String  AppID
        {
            set { this._AppID = value; }
            get { return this._AppID; }
        }
            
        /// <summary>
        /// 成功关键字
        /// </summary>
        public String  SuccessKey
        {
            set { this._SuccessKey = value; }
            get { return this._SuccessKey; }
        }
            
        /// <summary>
        /// 发送方式
        /// </summary>
        public Int16  SmsStyle
        {
            set { this._SmsStyle = value; }
            get { return this._SmsStyle; }
        }
            
        /// <summary>
        /// 是否使用
        /// </summary>
        public Boolean  IsEnable
        {
            set { this._IsEnable = value; }
            get { return this._IsEnable; }
        }
            
        #endregion
    }
}
  