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
    public partial class tsZoneServerEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _Code=""; // 编码
        private Int32 _GameID=0; // 游戏ID
        private String _Game=""; // 游戏
        private Int32 _ZoneID=0; // 大区ID
        private String _Zone=""; // 大区
        private Int32 _ServerID=0; // 服务器ID
        private String _Server=""; // 服务器
        private Int32 _FactionID=0; // 阵营ID
        private String _Faction=""; // 阵营
        private String _SpellFull=""; // 拼音全称
        private String _SpellShort=""; // 拼音简称
        private Boolean _IsOnline=false; // 运营状态
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
        /// 编码
        /// </summary>
        public String  Code
        {
            set { this._Code = value; }
            get { return this._Code; }
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
        /// 游戏
        /// </summary>
        public String  Game
        {
            set { this._Game = value; }
            get { return this._Game; }
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
        /// 大区
        /// </summary>
        public String  Zone
        {
            set { this._Zone = value; }
            get { return this._Zone; }
        }
            
        /// <summary>
        /// 服务器ID
        /// </summary>
        public Int32  ServerID
        {
            set { this._ServerID = value; }
            get { return this._ServerID; }
        }
            
        /// <summary>
        /// 服务器
        /// </summary>
        public String  Server
        {
            set { this._Server = value; }
            get { return this._Server; }
        }
            
        /// <summary>
        /// 阵营ID
        /// </summary>
        public Int32  FactionID
        {
            set { this._FactionID = value; }
            get { return this._FactionID; }
        }
            
        /// <summary>
        /// 阵营
        /// </summary>
        public String  Faction
        {
            set { this._Faction = value; }
            get { return this._Faction; }
        }
            
        /// <summary>
        /// 拼音全称
        /// </summary>
        public String  SpellFull
        {
            set { this._SpellFull = value; }
            get { return this._SpellFull; }
        }
            
        /// <summary>
        /// 拼音简称
        /// </summary>
        public String  SpellShort
        {
            set { this._SpellShort = value; }
            get { return this._SpellShort; }
        }
            
        /// <summary>
        /// 运营状态
        /// </summary>
        public Boolean  IsOnline
        {
            set { this._IsOnline = value; }
            get { return this._IsOnline; }
        }
            
        #endregion
    }
}
  