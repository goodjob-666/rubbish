/********************************************************************************
    File:
          tsSerialNoEntity.cs
    Description:
          流水号实体类
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
    ///tsSerialNoEntity实体类(流水号)
    ///</summary>
    [Serializable]
    public partial class tsSerialNoEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _SType=""; // 类别
        private String _Prefix=""; // 前缀
        private Int32 _Seed=0; // 种子
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
        /// 类别
        /// </summary>
        public String  SType
        {
            set { this._SType = value; }
            get { return this._SType; }
        }
            
        /// <summary>
        /// 前缀
        /// </summary>
        public String  Prefix
        {
            set { this._Prefix = value; }
            get { return this._Prefix; }
        }
            
        /// <summary>
        /// 种子
        /// </summary>
        public Int32  Seed
        {
            set { this._Seed = value; }
            get { return this._Seed; }
        }
            
        #endregion
    }
}
  