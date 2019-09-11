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
    ///tbImgEntity实体类( 活动)
    ///</summary>
    [Serializable]
    public partial class tbImgEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private String _ImageName = "";
        private String _BgImageUrl = "";
        private String _ImageUrl = "";
        private Int32 _AlbumID = 0;
        private Int32 _ImageType = 0;
        private Int32 _IsHot = 0;
        private Int32 _Enable = 0;
        private Int32 _Delay = 0;
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

        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        public String ImageName
        {
            set { this._ImageName = value; }
            get { return this._ImageName; }
        }

        public String BgImageUrl
        {
            set { this._BgImageUrl = value; }
            get { return this._BgImageUrl; }
        }

        public String ImageUrl
        {
            set { this._ImageUrl = value; }
            get { return this._ImageUrl; }
        }

        public Int32 AlbumID
        {
            set { this._AlbumID = value; }
            get { return this._AlbumID; }
        }

        public Int32 ImageType
        {
            set { this._ImageType = value; }
            get { return this._ImageType; }
        }

        public Int32 IsHot
        {
            set { this._IsHot = value; }
            get { return this._IsHot; }
        }

        public Int32 Enable
        {
            set { this._Enable = value; }
            get { return this._Enable; }
        }

        public Int32 Delay
        {
            set { this._Delay = value; }
            get { return this._Delay; }
        }

        #endregion
    }
}
