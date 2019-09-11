/********************************************************************************
    File:
          tbFinancialDayEntity.cs
    Description:
          财务每日数据实体类
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
    ///tbFinancialDayEntity实体类(财务每日数据)
    ///</summary>
    [Serializable]
    public partial class tbFinancialDayEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Double _TotalBal=0.0000f; // 总资金
        private Double _TotalFreeze=0.0000f; // 总冻结资金
        private Double _TotalWithDraw=0.0000f; // 总提现资金
        private Double _TotalOperate=0.0000f; // 总可操作资金
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
        /// <summary>
        /// ID
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 总资金
        /// </summary>
        public Double  TotalBal
        {
            set { this._TotalBal = value; }
            get { return this._TotalBal; }
        }
            
        /// <summary>
        /// 总冻结资金
        /// </summary>
        public Double  TotalFreeze
        {
            set { this._TotalFreeze = value; }
            get { return this._TotalFreeze; }
        }
            
        /// <summary>
        /// 总提现资金
        /// </summary>
        public Double  TotalWithDraw
        {
            set { this._TotalWithDraw = value; }
            get { return this._TotalWithDraw; }
        }
            
        /// <summary>
        /// 总可操作资金
        /// </summary>
        public Double  TotalOperate
        {
            set { this._TotalOperate = value; }
            get { return this._TotalOperate; }
        }
            
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
            
        #endregion
    }
}
  