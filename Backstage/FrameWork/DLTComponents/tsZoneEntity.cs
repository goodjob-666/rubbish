/********************************************************************************
    File:
          tsZoneEntity.cs
    Description:
          大区实体类
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
    ///tsZoneEntity实体类(大区)
    ///</summary>
    [Serializable]
    public partial class tsZoneEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _GameID=0; // 游戏ID
        private String _Zone=""; // 大区

        private Int32 _Sort = 0;
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
        /// 游戏ID
        /// </summary>
        public Int32  GameID
        {
            set { this._GameID = value; }
            get { return this._GameID; }
        }
            
        /// <summary>
        /// 大区
        /// </summary>
        public String  Zone
        {
            set { this._Zone = value; }
            get { return this._Zone; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public Int32 Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
            
        #endregion
    }
}
  