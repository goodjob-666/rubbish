/********************************************************************************
    File:
          tbChatMessageEntity.cs
    Description:
          tbChatMessage实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/2/5 星期四 9:28:00
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbChatMessageEntity实体类(tbChatMessage)
    ///</summary>
    [Serializable]
    public partial class tbChatMessageEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // UserID
        private String _UID=""; // UID
        private String _NickName=""; // NickName
        private Int32 _IconIndex=0; // IconIndex
        private Int32 _ChatType=0; // ChatType
        private String _TargetID=""; // TargetID
        private String _Comment=""; // Comment
        private DateTime _CreateDate=DateTime.Now; // CreateDate
        private DateTime? _BeginTime; // BeginTime
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
        /// UserID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// UID
        /// </summary>
        public String  UID
        {
            set { this._UID = value; }
            get { return this._UID; }
        }
            
        /// <summary>
        /// NickName
        /// </summary>
        public String  NickName
        {
            set { this._NickName = value; }
            get { return this._NickName; }
        }
            
        /// <summary>
        /// IconIndex
        /// </summary>
        public Int32  IconIndex
        {
            set { this._IconIndex = value; }
            get { return this._IconIndex; }
        }
            
        /// <summary>
        /// ChatType
        /// </summary>
        public Int32  ChatType
        {
            set { this._ChatType = value; }
            get { return this._ChatType; }
        }
            
        /// <summary>
        /// TargetID
        /// </summary>
        public String  TargetID
        {
            set { this._TargetID = value; }
            get { return this._TargetID; }
        }
            
        /// <summary>
        /// Comment
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// BeginTime
        /// </summary>
        public DateTime?  BeginTime
        {
            set { this._BeginTime = value; }
            get { return this._BeginTime; }
        }
            
        #endregion
    }
}
  