/********************************************************************************
    File:
          tsRightLockEntity.cs
    Description:
          权限锁定实体类
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
    ///tsRightLockEntity实体类(权限锁定)
    ///</summary>
    [Serializable]
    public partial class tsRightLockEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int16 _LockType=0; // 锁定类别
        private Boolean _IsForever=false; // 是否永久
        private DateTime? _StartDate; // 开始日期
        private DateTime? _EndDate; // 结束日期
        private String _Notice=""; // 通知内容
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
        /// 用户ID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// 锁定类别
        /// </summary>
        public Int16  LockType
        {
            set { this._LockType = value; }
            get { return this._LockType; }
        }
            
        /// <summary>
        /// 是否永久
        /// </summary>
        public Boolean  IsForever
        {
            set { this._IsForever = value; }
            get { return this._IsForever; }
        }
            
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime?  StartDate
        {
            set { this._StartDate = value; }
            get { return this._StartDate; }
        }
            
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime?  EndDate
        {
            set { this._EndDate = value; }
            get { return this._EndDate; }
        }
            
        /// <summary>
        /// 通知内容
        /// </summary>
        public String  Notice
        {
            set { this._Notice = value; }
            get { return this._Notice; }
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
  