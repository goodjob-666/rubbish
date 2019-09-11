/********************************************************************************
    File:
          tbActivityEntity.cs
    Description:
          tbActivity实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2016/8/24 11:21:15
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbActivityEntity实体类(tbActivity)
    ///</summary>
    [Serializable]
    public partial class tbOrdersEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0; // ID
        private String _Title = ""; // Title
        private String _SeriaNo = ""; // UserType
        private Int32 _ZoneID =0; // GameID
        private Int32 _ServerID; // StartDate
        private String _Zone;
        private String _Server; // EndDate
        private String _RoleName = ""; // Channel
        private Double? _ResAmount = 0.0000f; // Price
        private Double _RegAmount = 0.0000f; // Pirce2
        private DateTime _StartDate; // SendDate
        private DateTime? _EndDate; // Status
        private Int32 _UserID = 0; // Comment
        private Int32 _ActivityID = 0; // CreateDate
        private Int32 _Status = 0;
        private Int32 _qf = 0;
        private String _unid = "";
        private Int32 _TimeLimit = 0;
        private Double _Reward = 0;

        private Int32 _ModuleID = 0;

        private Int32 _OddEven = 0;

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
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        /// <summary>
        /// Title
        /// </summary>
        public String Title
        {
            set { this._Title = value; }
            get { return this._Title; }
        }

        /// <summary>
        /// UserType
        /// </summary>
        public Int32 ZoneID
        {
            set { this._ZoneID = value; }
            get { return this._ZoneID; }
        }

        /// <summary>
        /// GameID
        /// </summary>
        public Int32 ServerID
        {
            set { this._ServerID = value; }
            get { return this._ServerID; }
        }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime StartDate
        {
            set { this._StartDate = value; }
            get { return this._StartDate; }
        }

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime? EndDate
        {
            set { this._EndDate = value; }
            get { return this._EndDate; }
        }

        public String Zone
        {
            get { return _Zone; }
            set { _Zone = value; }
        }


        public String Server
        {
            set { this._Server = value; }
            get { return this._Server; }
        }

         public String RoleName
        {
            set { this._RoleName = value; }
            get { return this._RoleName; }
        }
        

        /// <summary>
        /// Price
        /// </summary>
         public Double? ResAmount
        {
            set { this._ResAmount = value; }
            get { return this._ResAmount; }
        }

        /// <summary>
        /// Pirce2
        /// </summary>
         public Double RegAmount
        {
            set { this._RegAmount = value; }
            get { return this._RegAmount; }
        }
       
         public Int32 UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }

        /// <summary>
        /// Status
        /// </summary>
        public Int32 Status
        {
            set { this._Status = value; }
            get { return this._Status; }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public String SeriaNo
        {
            set { this._SeriaNo = value; }
            get { return this._SeriaNo; }
        }

        /// <summary>
        /// CreateDate
        /// </summary>
        public Int32 ActivityID
        {
            set { this._ActivityID = value; }
            get { return this._ActivityID; }
        }

        public Int32 qf
        {
            set { this._qf = value; }
            get { return this._qf; }
        }

        public Int32 TimeLimit
        {
            set { this._TimeLimit = value; }
            get { return this._TimeLimit; }
        }

        public String unid
        {
            set { this._unid = value; }
            get { return this._unid; }
        }

        public Double Reward
        {
            get { return _Reward; }
            set { _Reward = value; }
        }

        public Int32 ModuleID
        {
            set { this._ModuleID = value; }
            get { return this._ModuleID; }
        }

        public Int32 OddEven
        {
            set { this._OddEven = value; }
            get { return this._OddEven; }
        }

        #endregion
    }
}
