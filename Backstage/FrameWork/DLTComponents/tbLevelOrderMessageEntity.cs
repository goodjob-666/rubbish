/********************************************************************************
    File:
          tbLevelOrderMessageEntity.cs
    Description:
          订单交互留言实体类
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
    ///tbLevelOrderMessageEntity实体类(订单交互留言)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderMessageEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // 订单流水号
        private Int32 _UserID=0; // 用户ID
        private Int16 _MsgType=0; // 留言类别
        private String _Msg=""; // 留言内容
        private DateTime _CreateDate=DateTime.Now; // 创建时间
        private Boolean _IsRead=false; // 已读标记
        private Boolean _IsRead2=false; // 已读标记2
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
        /// 用户ID
        /// </summary>
        public Int32  UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }
            
        /// <summary>
        /// 留言类别
        /// </summary>
        public Int16  MsgType
        {
            set { this._MsgType = value; }
            get { return this._MsgType; }
        }
            
        /// <summary>
        /// 留言内容
        /// </summary>
        public String  Msg
        {
            set { this._Msg = value; }
            get { return this._Msg; }
        }
            
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// 已读标记
        /// </summary>
        public Boolean  IsRead
        {
            set { this._IsRead = value; }
            get { return this._IsRead; }
        }
            
        /// <summary>
        /// 已读标记2
        /// </summary>
        public Boolean  IsRead2
        {
            set { this._IsRead2 = value; }
            get { return this._IsRead2; }
        }
            
            
        #endregion
    }
}
  