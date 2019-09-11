/********************************************************************************
    File:
          tsActivityEntity.cs
    Description:
          活动实体类
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
    ///tbSubmissionEntity实体类
    ///</summary>
    [Serializable]
    public partial class tbSubmissionEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private Int32 _UserID = 0;
        private Int32 _ImgID = 0;
        private String _ImageUrl = "";
        private String _FormID = "";
        private String _Ip = "";
        private DateTime _CreateDate;

        //ID, UserID, ImgID, ImageUrl, FormID, Ip, CreateDate
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public Int32 ImgID
        {
            get { return _ImgID; }
            set { _ImgID = value; }
        }

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        public String ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; }
        }

        public String FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }

        public String Ip
        {
            get { return _Ip; }
            set { _Ip = value; }
        }

        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }

        #endregion

    }
}
