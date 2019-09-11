/********************************************************************************
    File:
          tcUserStatEntity.cs
    Description:
          用户统计数据实体类
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
    ///tcUserStatEntity实体类(用户统计数据)
    ///</summary>
    [Serializable]
    public partial class tcUserStatEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private Int32 _PubCount=0; // 发单总数
        private Int32 _PubCancel=0; // 发单介入撤单数
        private Int32 _PubConsultCancel=0; // 发单协商撤单数
        private Int32 _AcceptCount=0; // 接单介入总数
        private Int32 _AcceptCancel=0; // 接单撤单数
        private Int32 _AcceptConsultCancel=0; // 接单协商撤单数
        private Int64 _OnlineMin=0; // 在线时长
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
        /// 发单总数
        /// </summary>
        public Int32  PubCount
        {
            set { this._PubCount = value; }
            get { return this._PubCount; }
        }
            
        /// <summary>
        /// 发单介入撤单数
        /// </summary>
        public Int32  PubCancel
        {
            set { this._PubCancel = value; }
            get { return this._PubCancel; }
        }
            
        /// <summary>
        /// 发单协商撤单数
        /// </summary>
        public Int32  PubConsultCancel
        {
            set { this._PubConsultCancel = value; }
            get { return this._PubConsultCancel; }
        }
            
        /// <summary>
        /// 接单介入总数
        /// </summary>
        public Int32  AcceptCount
        {
            set { this._AcceptCount = value; }
            get { return this._AcceptCount; }
        }
            
        /// <summary>
        /// 接单撤单数
        /// </summary>
        public Int32  AcceptCancel
        {
            set { this._AcceptCancel = value; }
            get { return this._AcceptCancel; }
        }
            
        /// <summary>
        /// 接单协商撤单数
        /// </summary>
        public Int32  AcceptConsultCancel
        {
            set { this._AcceptConsultCancel = value; }
            get { return this._AcceptConsultCancel; }
        }
            
        /// <summary>
        /// 在线时长
        /// </summary>
        public Int64  OnlineMin
        {
            set { this._OnlineMin = value; }
            get { return this._OnlineMin; }
        }
            
        #endregion
    }
}
  