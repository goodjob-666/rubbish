/********************************************************************************
    File:
          tsZoneServerEntity.cs
    Description:
          区服汇总实体类
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
    ///tsZoneServerEntity实体类(区服汇总)
    ///</summary>
    [Serializable]
    public partial class tsUserZoneServerEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _UserID = 0;
        private Int32 _GameID = 0; // 游戏ID
        private Int32 _ZoneID = 0; // 大区ID
        private Int32 _ServerID = 0; // 服务器ID
        private String _RoleName = "";

      
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
        /// 大区ID
        /// </summary>
        public Int32  ZoneID
        {
            set { this._ZoneID = value; }
            get { return this._ZoneID; }
        }
            
       
            
        /// <summary>
        /// 服务器ID
        /// </summary>
        public Int32  ServerID
        {
            set { this._ServerID = value; }
            get { return this._ServerID; }
        }

        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public String RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        } 
      
            
        #endregion
    }
}
  