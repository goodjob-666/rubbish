/********************************************************************************
    File:
          sys_PendingMattersEntity.cs
    Description:
          sys_PendingMatters实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/5/20 18:51:40
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_PendingMattersEntity实体类(sys_PendingMatters)
    ///</summary>
    [Serializable]
    public partial class sys_PendingMattersEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _P_ID=0; // P_ID
        private Int32 _P_Type=0; // P_Type
        private String _P_UserID=""; // P_UserID
        private String _P_Contact=""; // P_Contact
        private String _P_OrderNum=""; // P_OrderNum
        private DateTime _P_CreateDate=DateTime.Now; // P_CreateDate
        private DateTime? _P_ReplyDate; // P_ReplyDate
        private String _P_Content=""; // P_Content
        private Int32 _P_PostID=0; // P_PostID
        private Int32 _P_ReplyID=0; // P_ReplyID
        private String _P_ReContent=""; // P_ReContent
        private Int32 _P_IsDeal=0; // P_IsDeal
        private Int32 _P_Pre1=0; // P_Pre1
        private String _P_Pre2=""; // P_Pre2
        private DateTime? _P_Pre3; // P_Pre3
        private String _P_Pre4=""; // P_Pre4
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
        /// P_ID
        /// </summary>
        public Int32  P_ID
        {
            set { this._P_ID = value; }
            get { return this._P_ID; }
        }
            
        /// <summary>
        /// P_Type
        /// </summary>
        public Int32  P_Type
        {
            set { this._P_Type = value; }
            get { return this._P_Type; }
        }
            
        /// <summary>
        /// P_UserID
        /// </summary>
        public String  P_UserID
        {
            set { this._P_UserID = value; }
            get { return this._P_UserID; }
        }
            
        /// <summary>
        /// P_Contact
        /// </summary>
        public String  P_Contact
        {
            set { this._P_Contact = value; }
            get { return this._P_Contact; }
        }
            
        /// <summary>
        /// P_OrderNum
        /// </summary>
        public String  P_OrderNum
        {
            set { this._P_OrderNum = value; }
            get { return this._P_OrderNum; }
        }
            
        /// <summary>
        /// P_CreateDate
        /// </summary>
        public DateTime  P_CreateDate
        {
            set { this._P_CreateDate = value; }
            get { return this._P_CreateDate; }
        }
            
        /// <summary>
        /// P_ReplyDate
        /// </summary>
        public DateTime?  P_ReplyDate
        {
            set { this._P_ReplyDate = value; }
            get { return this._P_ReplyDate; }
        }
            
        /// <summary>
        /// P_Content
        /// </summary>
        public String  P_Content
        {
            set { this._P_Content = value; }
            get { return this._P_Content; }
        }
            
        /// <summary>
        /// P_PostID
        /// </summary>
        public Int32  P_PostID
        {
            set { this._P_PostID = value; }
            get { return this._P_PostID; }
        }
            
        /// <summary>
        /// P_ReplyID
        /// </summary>
        public Int32  P_ReplyID
        {
            set { this._P_ReplyID = value; }
            get { return this._P_ReplyID; }
        }
            
        /// <summary>
        /// P_ReContent
        /// </summary>
        public String  P_ReContent
        {
            set { this._P_ReContent = value; }
            get { return this._P_ReContent; }
        }
            
        /// <summary>
        /// P_IsDeal
        /// </summary>
        public Int32  P_IsDeal
        {
            set { this._P_IsDeal = value; }
            get { return this._P_IsDeal; }
        }
            
        /// <summary>
        /// P_Pre1
        /// </summary>
        public Int32  P_Pre1
        {
            set { this._P_Pre1 = value; }
            get { return this._P_Pre1; }
        }
            
        /// <summary>
        /// P_Pre2
        /// </summary>
        public String  P_Pre2
        {
            set { this._P_Pre2 = value; }
            get { return this._P_Pre2; }
        }
            
        /// <summary>
        /// P_Pre3
        /// </summary>
        public DateTime?  P_Pre3
        {
            set { this._P_Pre3 = value; }
            get { return this._P_Pre3; }
        }
            
        /// <summary>
        /// P_Pre4
        /// </summary>
        public String  P_Pre4
        {
            set { this._P_Pre4 = value; }
            get { return this._P_Pre4; }
        }
            
        #endregion
    }
}
  