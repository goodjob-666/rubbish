/********************************************************************************
    File:
          tsGameEntity.cs
    Description:
          游戏实体类
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
    ///tsGameEntity实体类(游戏)
    ///</summary>
    [Serializable]
    public partial class tsGameEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _CompID=0; // 厂商ID
        private String _Game=""; // 游戏
        private String _Comment=""; // 描述
        private Boolean _IsOnline=false; // 运营状态

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
        /// 厂商ID
        /// </summary>
        public Int32  CompID
        {
            set { this._CompID = value; }
            get { return this._CompID; }
        }
            
        /// <summary>
        /// 游戏
        /// </summary>
        public String  Game
        {
            set { this._Game = value; }
            get { return this._Game; }
        }
            
        /// <summary>
        /// 描述
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }
            
        /// <summary>
        /// 运营状态
        /// </summary>
        public Boolean  IsOnline
        {
            set { this._IsOnline = value; }
            get { return this._IsOnline; }
        }

        /// <summary>
        /// Sort
        /// </summary>
        public Int32 Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
            
        #endregion
    }
}
  