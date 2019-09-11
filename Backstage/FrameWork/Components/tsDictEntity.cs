/********************************************************************************
    File:
          tsDictEntity.cs
    Description:
          数据字典实体类
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
    ///tsDictEntity实体类(数据字典)
    ///</summary>
    [Serializable]
    public partial class tsDictEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _Key=0; // 大类
        private String _Name=""; // 名称
        private Int16 _Kind=0; // 小类
        private String _Value=""; // 值
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
        /// 大类
        /// </summary>
        public Int32  Key
        {
            set { this._Key = value; }
            get { return this._Key; }
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
        /// 小类
        /// </summary>
        public Int16  Kind
        {
            set { this._Kind = value; }
            get { return this._Kind; }
        }
            
        /// <summary>
        /// 值
        /// </summary>
        public String  Value
        {
            set { this._Value = value; }
            get { return this._Value; }
        }
            
        #endregion
    }
}
  