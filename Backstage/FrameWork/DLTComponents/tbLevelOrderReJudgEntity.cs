/********************************************************************************
    File:
          tbLevelOrderReJudgEntity.cs
    Description:
          tbLevelOrderReJudg实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/11/28 18:10:17
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///tbLevelOrderReJudgEntity实体类(tbLevelOrderReJudg)
    ///</summary>
    [Serializable]
    public partial class tbLevelOrderReJudgEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ODSerialNo=""; // ODSerialNo
        private Int32 _CustomerID=0; // CustomerID
        private String _Reason=""; // Reason
        private DateTime? _CreateDate;
        private Int32 _MarkColor = 0;
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

        public Int32 MarkColor
        {
            set { this._MarkColor = value; }
            get { return this._MarkColor; }
        }

        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        /// <summary>
        /// ODSerialNo
        /// </summary>
        public String  ODSerialNo
        {
            set { this._ODSerialNo = value; }
            get { return this._ODSerialNo; }
        }
            
        /// <summary>
        /// CustomerID
        /// </summary>
        public Int32  CustomerID
        {
            set { this._CustomerID = value; }
            get { return this._CustomerID; }
        }
            
        /// <summary>
        /// Reason
        /// </summary>
        public String  Reason
        {
            set { this._Reason = value; }
            get { return this._Reason; }
        }
            
        #endregion
    }
}
  