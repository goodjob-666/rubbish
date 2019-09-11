/********************************************************************************
    File:
          tsBlackEntity.cs
    Description:
          黑名单实体类
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
    ///tsBlackEntity实体类(黑名单)
    ///</summary>
    [Serializable]
    public partial class tsBlackEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int32 _BlackUserID=0; // 拉黑用户
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
        /// 拉黑用户
        /// </summary>
        public Int32  BlackUserID
        {
            set { this._BlackUserID = value; }
            get { return this._BlackUserID; }
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
  