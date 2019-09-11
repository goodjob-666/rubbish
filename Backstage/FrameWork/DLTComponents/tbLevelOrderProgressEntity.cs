/********************************************************************************
    File:
          tbLevelOrderProgressEntity.cs
    Description:
          代练进度实体类
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
    ///tbLevelOrderProgressEntity实体类(代练进度)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderProgressEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID=0; // 用户ID
        private String _ODSerialNo=""; // 订单流水号
        private DateTime _CreateDate=DateTime.Now; // 创建时间
        private String _Img=""; // 图片地址
        private String _Comment=""; // 描述
        private Int16 _Source=0; // 进度来源
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
        /// 订单流水号
        /// </summary>
        public String  ODSerialNo
        {
            set { this._ODSerialNo = value; }
            get { return this._ODSerialNo; }
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
        /// 图片地址
        /// </summary>
        public String  Img
        {
            set { this._Img = value; }
            get { return this._Img; }
        }
            
        /// <summary>
        /// 描述
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// 进度来源
        /// </summary>
        public Int16  Source
        {
            set { this._Source = value; }
            get { return this._Source; }
        }
            
        #endregion
    }
}
  