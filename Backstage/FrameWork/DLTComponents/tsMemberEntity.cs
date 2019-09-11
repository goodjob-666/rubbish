/********************************************************************************
    File:
          tsMemberEntity.cs
    Description:
          用户成员实体类
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
    ///tsMemberEntity实体类(用户成员)
    ///</summary>
    [Serializable]
    public partial class tsMemberEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _GroupID=0; // 用户分组ID
        private Int32 _UserID=0; // 用户ID
        private Int32 _MemberUserID=0; // 成员用户
        private DateTime? _CreateDate; // 创建时间
        private String _Comment=""; // 描述
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
        /// 用户分组ID
        /// </summary>
        public Int32  GroupID
        {
            set { this._GroupID = value; }
            get { return this._GroupID; }
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
        /// 成员用户
        /// </summary>
        public Int32  MemberUserID
        {
            set { this._MemberUserID = value; }
            get { return this._MemberUserID; }
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
        /// 描述
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        #endregion
    }
}
  