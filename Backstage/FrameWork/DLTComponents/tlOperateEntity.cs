/********************************************************************************
    File:
          tlOperateEntity.cs
    Description:
          操作日志实体类
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
    ///tlOperateEntity实体类(操作日志)
    ///</summary>
    [Serializable]
    public partial class tlOperateEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int32 _OPType=0; // 操作类别
        private String _OPLog=""; // 操作日志
        private DateTime? _CreateDate; // 创建时间
        private String _IP=""; // IP地址
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
        /// 操作类别
        /// </summary>
        public Int32  OPType
        {
            set { this._OPType = value; }
            get { return this._OPType; }
        }
            
        /// <summary>
        /// 操作日志
        /// </summary>
        public String  OPLog
        {
            set { this._OPLog = value; }
            get { return this._OPLog; }
        }
            
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// IP地址
        /// </summary>
        public String  IP
        {
            set { this._IP = value; }
            get { return this._IP; }
        }
            
        #endregion
    }
}
  