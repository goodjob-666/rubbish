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
    ///赠送乐币实体类
    ///</summary>
    [Serializable]
    public partial class tbGiveEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private String _SerialNo = "";
        private Int32 _GiveID = 0;
        private Int32 _AcceptID = 0;
        private Double _Money = 0.0000f; // 总金额
        private DateTime? _CreateDate; // 创建时间
        private String _Comment = "";
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

        public String SerialNo
        {
            set { this._SerialNo = value; }
            get { return this._SerialNo; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32 GiveID
        {
            set { this._GiveID = value; }
            get { return this._GiveID; }
        }

        public Int32 AcceptID
        {
            set { this._AcceptID = value; }
            get { return this._AcceptID; }
        }

        /// <summary>
        ///金额
        /// </summary>
        public Double Money
        {
            set { this._Money = value; }
            get { return this._Money; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public String Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }

        #endregion
    }
}
