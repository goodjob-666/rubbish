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
    ///tbFieldsEntity
    ///</summary>
    [Serializable]
    public partial class tbFieldsEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Int32 _ImgID = 0;

        public Int32 ImgID
        {
            get { return _ImgID; }
            set { _ImgID = value; }
        }

        private String _Title = "";

        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private String _PreValue = "";

        public String PreValue
        {
            get { return _PreValue; }
            set { _PreValue = value; }
        }
        private String _Placeholder = "";

        public String Placeholder
        {
            get { return _Placeholder; }
            set { _Placeholder = value; }
        }
        private String _Default = "";

        public String Default
        {
            get { return _Default; }
            set { _Default = value; }
        }
        private String _SuffixValue = "";

        public String SuffixValue
        {
            get { return _SuffixValue; }
            set { _SuffixValue = value; }
        }
        private String _Type = "";

        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private String _Data = "";

        public String Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        private Int32 _FontSize = 0;

        public Int32 FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }
        private String _FontFamily = "";

        public String FontFamily
        {
            get { return _FontFamily; }
            set { _FontFamily = value; }
        }
        private String _FontColor = "";

        public String FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }
        private String _FontStyle = "";

        public String FontStyle
        {
            get { return _FontStyle; }
            set { _FontStyle = value; }
        }

        private Int32 _X = 0;

        public Int32 X
        {
            get { return _X; }
            set { _X = value; }
        }
        private Int32 _Y = 0;

        public Int32 Y
        {
            get { return _Y; }
            set { _Y = value; }
        }
        private Int32 _Width = 0;

        public Int32 Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private Int32 _Height = 0;

        public Int32 Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        private Int32 _IsCircle = 0;

        public Int32 IsCircle
        {
            get { return _IsCircle; }
            set { _IsCircle = value; }
        }
        private Int32 _Rotate = 0;

        public Int32 Rotate
        {
            get { return _Rotate; }
            set { _Rotate = value; }
        }
        private Int32 _IsRandom = 0;

        public Int32 IsRandom
        {
            get { return _IsRandom; }
            set { _IsRandom = value; }
        }
        private Int32 _OrderBy = 0;

        public Int32 OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        private Double _BorderSize = 0;
        public Double BorderSize
        {
            get { return _BorderSize; }
            set { _BorderSize = value; }
        }

        private String _BorderColor = "";

        public String BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        #endregion

        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }
    }
}
