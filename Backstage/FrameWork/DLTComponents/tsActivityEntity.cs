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
    ///tsActivityEntity实体类( 活动)
    ///</summary>
    [Serializable]
    public partial class tsActivityEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ImageUrl = ""; // 图片路径
        private String _Name = ""; // 描述
        private Double _Reward = 0.00f;
        private Int32 _GameID = 0;
        private Int32 _TimeLimit = 0;
        private String _Content = ""; // 描述
        private Int32 _Sort = 0;
        private Boolean _Enable = false;
        private String _Game = "";
        private String _Rule = "";
        private String _Question = "";

        private int _StartPosition = 0;
        private int _EndPosition = 0;

        private int _num = 0;
        private DateTime? _StartD;
        private DateTime? _EndD;

        private int _ModuleID;    //模式类型
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

         public Int32  TimeLimit
        {
            set { this._TimeLimit = value; }
            get { return this._TimeLimit; }
        }

         public Int32 GameID
         {
             set { this._GameID = value; }
             get { return this._GameID; }
         }

        /// <summary>
        /// 厂商ID
        /// </summary>
        public String ImageUrl
        {
            set { this._ImageUrl = value; }
            get { return this._ImageUrl; }
        }
            
       
        public String Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }

        public String Game
        {
            set { this._Game = value; }
            get { return this._Game; }
        }

        public Double Reward
        {
            set { this._Reward = value; }
            get { return this._Reward; }
        }
            
        /// <summary>
        /// 描述
        /// </summary>
        public String Content
        {
            set { this._Content = value; }
            get { return this._Content; }
        }
            
        /// <summary>
        /// 运营状态
        /// </summary>
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

        public String Rule
        {
            set { this._Rule = value; }
            get { return this._Rule; }
        }

        public String Question
        {
            set { this._Question = value; }
            get { return this._Question; }
        }

        public Int32 StartPosition
        {
            set { this._StartPosition = value; }
            get { return this._StartPosition; }
        }

        public Int32 EndPosition
        {
            set { this._EndPosition = value; }
            get { return this._EndPosition; }
        }

        public Int32 num
        {
            set { this._num = value; }
            get { return this._num; }
        }

        public DateTime? StartD
        {
            set { this._StartD = value; }
            get { return this._StartD; }
        }

        public DateTime? EndD
        {
            set { this._EndD = value; }
            get { return this._EndD; }
        }

        public Int32 ModuleID
        {
            set { this._ModuleID = value; }
            get { return this._ModuleID; }
        }
            
        #endregion
    }
}
  