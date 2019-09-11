/********************************************************************************
    File:
          tsNoticeEntity.cs
    Description:
          系统公告实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/8/22 14:33:20
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tsNoticeEntity实体类(系统公告)
    ///</summary>
    [Serializable]
    public partial class tsNoticeEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _Title=""; // 标题
        private String _Body=""; // 正文
        private String _Url=""; // 链接
        private DateTime _PubDate=DateTime.Now; // 发布日期
        private DateTime? _StartDate; // 开始日期
        private DateTime? _EndDate; // 结束日期
        private Boolean _Enable=false; // 是否启用
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
        /// 标题
        /// </summary>
        public String  Title
        {
            set { this._Title = value; }
            get { return this._Title; }
        }
            
        /// <summary>
        /// 正文
        /// </summary>
        public String  Body
        {
            set { this._Body = value; }
            get { return this._Body; }
        }
            
        /// <summary>
        /// 链接
        /// </summary>
        public String  Url
        {
            set { this._Url = value; }
            get { return this._Url; }
        }
            
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime  PubDate
        {
            set { this._PubDate = value; }
            get { return this._PubDate; }
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
        /// 是否启用
        /// </summary>
        public Boolean  Enable
        {
            set { this._Enable = value; }
            get { return this._Enable; }
        }
            
        #endregion
    }
}
  