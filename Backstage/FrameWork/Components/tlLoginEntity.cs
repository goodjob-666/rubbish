/********************************************************************************
    File:
          tlLoginEntity.cs
    Description:
          登录日志实体类
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
    ///tlLoginEntity实体类(登录日志)
    ///</summary>
    [Serializable]
    public partial class tlLoginEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int32 _SubUserID=0; // 子帐号ID
        private Int32 _LoginType=0; // 登录类别
        private String _PCName=""; // 机器名
        private String _HD=""; // 硬盘
        private String _Mac=""; // 网卡
        private String _IP=""; // IP地址
        private String _OS=""; // 操作系统
        private DateTime? _LoginDate; // 登录时间
        private DateTime? _LogoutDate; // 登出时间
        private Int16 _Status=0; // 状态
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
        /// 子帐号ID
        /// </summary>
        public Int32  SubUserID
        {
            set { this._SubUserID = value; }
            get { return this._SubUserID; }
        }
            
        /// <summary>
        /// 登录类别
        /// </summary>
        public Int32  LoginType
        {
            set { this._LoginType = value; }
            get { return this._LoginType; }
        }
            
        /// <summary>
        /// 机器名
        /// </summary>
        public String  PCName
        {
            set { this._PCName = value; }
            get { return this._PCName; }
        }
            
        /// <summary>
        /// 硬盘
        /// </summary>
        public String  HD
        {
            set { this._HD = value; }
            get { return this._HD; }
        }
            
        /// <summary>
        /// 网卡
        /// </summary>
        public String  Mac
        {
            set { this._Mac = value; }
            get { return this._Mac; }
        }
            
        /// <summary>
        /// IP地址
        /// </summary>
        public String  IP
        {
            set { this._IP = value; }
            get { return this._IP; }
        }
            
        /// <summary>
        /// 操作系统
        /// </summary>
        public String  OS
        {
            set { this._OS = value; }
            get { return this._OS; }
        }
            
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime?  LoginDate
        {
            set { this._LoginDate = value; }
            get { return this._LoginDate; }
        }
            
        /// <summary>
        /// 登出时间
        /// </summary>
        public DateTime?  LogoutDate
        {
            set { this._LogoutDate = value; }
            get { return this._LogoutDate; }
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
            
        #endregion
    }
}
  