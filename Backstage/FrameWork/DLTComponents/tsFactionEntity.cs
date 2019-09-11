/********************************************************************************
    File:
          tsFactionEntity.cs
    Description:
          阵营实体类
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
    ///tsFactionEntity实体类(阵营)
    ///</summary>
    [Serializable]
    public partial class tsFactionEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _GameID=0; // 游戏ID
        private String _Faction=""; // 阵营
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
        /// 阵营
        /// </summary>
        public String  Faction
        {
            set { this._Faction = value; }
            get { return this._Faction; }
        }
            
        #endregion
    }
}
  