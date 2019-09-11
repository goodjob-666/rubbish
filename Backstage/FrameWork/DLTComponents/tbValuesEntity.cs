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
    ///tbValuesEntity实体类( 活动)
    ///</summary>
    [Serializable]
    public partial class tbValuesEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private Int32 _FieldsID = 0;
        private String _Value = "";
        private Int32 _X = 0;
        private Int32 _Y = 0;
        private Int32 _RelaID = 0;
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

        public Int32 FieldsID
        {
            set { this._FieldsID = value; }
            get { return this._FieldsID; }
        }

        public String Value
        {
            set { this._Value = value; }
            get { return this._Value; }
        }

        public Int32 X
        {
            set { this._X = value; }
            get { return this._X; }
        }

        public Int32 Y
        {
            set { this._Y = value; }
            get { return this._Y; }
        }

        public Int32 RelaID
        {
            set { this._RelaID = value; }
            get { return this._RelaID; }
        }

        #endregion
    }
}
