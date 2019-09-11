/********************************************************************************
    File:
          tsSysParamEntity.cs
    Description:
          系统参数实体类
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
    ///tsSysParamEntity实体类(系统参数)
    ///</summary>
    [Serializable]
    public partial class tsSysParamEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _Name=""; // 名称
        private String _Value=""; // 值
        private String _Comment=""; // 描述
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
        /// 名称
        /// </summary>
        public String  Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }
            
        /// <summary>
        /// 值
        /// </summary>
        public String  Value
        {
            set { this._Value = value; }
            get { return this._Value; }
        }
            
        /// <summary>
        /// 描述
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        #endregion
    }
}
  