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
    ///
    ///</summary>
    [Serializable]
    public partial class tsModuleEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _Title;
        private String _Description;
        private String _Comment;
        private Int32 _Sort = 0;
        private Boolean _Enable = false;
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

        public String Title
        {
            set { this._Title = value; }
            get { return this._Title; }
        }


        public String Description
        {
            set { this._Description = value; }
            get { return this._Description; }
        }

        public String Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }

        public Int32 Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }

        /// <summary>
        /// Sort
        /// </summary>
        public Boolean Enable
        {
            set { this._Enable = value; }
            get { return this._Enable; }
        }  
        #endregion
    }
}
  