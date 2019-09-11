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
    ///自动权限控制
    ///</summary>
    [Serializable]
    public partial class tsRightLockAutoEntity
    {
        //ID, ActivityID, StartDate, EndDate, Nums, Moneys, CreateDate
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0;
        private Int32 _ActivityID = 0;
        private String _Name = "";
        private DateTime _StartDate;
        private DateTime _EndDate;
        private String _Nums ="";
        private String _Moneys = "";
        private DateTime? _CreateDate; // 创建时间
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

        public String Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }

        public String Nums
        {
            set { this._Nums = value; }
            get { return this._Nums; }
        }

        public String Moneys
        {
            set { this._Moneys = value; }
            get { return this._Moneys; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        public Int32 ActivityID
        {
            set { this._ActivityID = value; }
            get { return this._ActivityID; }
        }

      

        public DateTime StartDate
        {
            set { this._StartDate = value; }
            get { return this._StartDate; }
        }

        public DateTime EndDate
        {
            set { this._EndDate = value; }
            get { return this._EndDate; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

       
        #endregion
    }
}
