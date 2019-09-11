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
    public partial class tbActivityEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0; // ID
        private String _Title = ""; // Title
        private Int32 _UserType = 0; // UserType
        private String _GameID = ""; // GameID
        private DateTime? _StartDate; // StartDate
        private DateTime? _EndDate; // EndDate
        private Int32 _Channel = 0; // Channel
        private Double _Price = 0.0000f; // Price
        private Double _Pirce2 = 0.0000f; // Pirce2
        private Double _Price3 = 0.0000f; // Pirce3
        private DateTime? _SendDate; // SendDate
        private Int32 _Status = 0; // Status
        private String _Comment = ""; // Comment
        private DateTime? _CreateDate; // CreateDate
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
        public Int32 UserType
        {
            set { this._UserType = value; }
            get { return this._UserType; }
        }

        /// <summary>
        /// GameID
        /// </summary>
        public String GameID
        {
            set { this._GameID = value; }
            get { return this._GameID; }
        }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime? StartDate
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

        /// <summary>
        /// Channel
        /// </summary>
        public Int32 Channel
        {
            set { this._Channel = value; }
            get { return this._Channel; }
        }

        /// <summary>
        /// Price
        /// </summary>
        public Double Price
        {
            set { this._Price = value; }
            get { return this._Price; }
        }

        /// <summary>
        /// Pirce2
        /// </summary>
        public Double Pirce2
        {
            set { this._Pirce2 = value; }
            get { return this._Pirce2; }
        }

        /// <summary>
        /// Pirce3
        /// </summary>
        public Double Price3
        {
            set { this._Price3 = value; }
            get { return this._Price3; }
        }

        /// <summary>
        /// SendDate
        /// </summary>
        public DateTime? SendDate
        {
            set { this._SendDate = value; }
            get { return this._SendDate; }
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
        public String Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

        #endregion
    }
}
