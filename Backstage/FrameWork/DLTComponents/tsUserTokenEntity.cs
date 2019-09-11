/********************************************************************************
    File:
          tsUserTokenEntity.cs
    Description:
          授权令牌实体类
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
    ///tsUserTokenEntity实体类(授权令牌)
    ///</summary>
    [Serializable]
    public partial class tsUserTokenEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private String _Token=""; // 令牌
        private DateTime? _LiveTime; // 活动时间
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
        /// 令牌
        /// </summary>
        public String  Token
        {
            set { this._Token = value; }
            get { return this._Token; }
        }
            
        /// <summary>
        /// 活动时间
        /// </summary>
        public DateTime?  LiveTime
        {
            set { this._LiveTime = value; }
            get { return this._LiveTime; }
        }
            
        #endregion
    }
}
  