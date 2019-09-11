/********************************************************************************
    File:
          tsCategoryEntity.cs
    Description:
          商品分类实体类
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
    ///tsCategoryEntity实体类(商品分类)
    ///</summary>
    [Serializable]
    public partial class tsCategoryEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _Category=""; // 分类
        private Int32 _ParentID=0; // 父分类
        private Int32 _Depth=0; // 深度
        private String _Spell=""; // 拼音
        private Int32 _Order=0; // 排序
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
        /// 分类
        /// </summary>
        public String  Category
        {
            set { this._Category = value; }
            get { return this._Category; }
        }
            
        /// <summary>
        /// 父分类
        /// </summary>
        public Int32  ParentID
        {
            set { this._ParentID = value; }
            get { return this._ParentID; }
        }
            
        /// <summary>
        /// 深度
        /// </summary>
        public Int32  Depth
        {
            set { this._Depth = value; }
            get { return this._Depth; }
        }
            
        /// <summary>
        /// 拼音
        /// </summary>
        public String  Spell
        {
            set { this._Spell = value; }
            get { return this._Spell; }
        }
            
        /// <summary>
        /// 排序
        /// </summary>
        public Int32  Order
        {
            set { this._Order = value; }
            get { return this._Order; }
        }
            
        #endregion
    }
}
  