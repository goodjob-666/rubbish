using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLT.Components
{
    ///<summary>
    ///tbAlbumEntity实体类(类别)
    ///</summary>
    [Serializable]
    public partial class tbAlbumEntity
    {
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private String _AlbumName = "";
        private String _AlbumUrl = "";
        private Int32 _AlbumType = 0;
        private double _Amounts = 0;
        private Int32 _IsHot = 0;
        private Int32 _IsNew = 0;
        private Int32 _OrderBy = 0;
        private Int32 _Enable = 0;

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

        public String AlbumName
        {
            set { this._AlbumName = value; }
            get { return this._AlbumName; }
        }

        public String AlbumUrl
        {
            set { this._AlbumUrl = value; }
            get { return this._AlbumUrl; }
        }

        public Int32 AlbumType
        {
            set { this._AlbumType = value; }
            get { return this._AlbumType; }
        }

        public double Amounts
        {
            set { this._Amounts = value; }
            get { return this._Amounts; }
        }

        public Int32 IsHot
        {
            set { this._IsHot = value; }
            get { return this._IsHot; }
        }

        public Int32 IsNew
        {
            set { this._IsNew = value; }
            get { return this._IsNew; }
        }

        public Int32 OrderBy
        {
            set { this._OrderBy = value; }
            get { return this._OrderBy; }
        }

        public Int32 Enable
        {
            set { this._Enable = value; }
            get { return this._Enable; }
        }
    }
}
