/********************************************************************************
    File:
          sys_StatisticalGroupingEntity.cs
    Description:
          sys_StatisticalGrouping实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/12/27 18:46:29
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_StatisticalGroupingEntity实体类(sys_StatisticalGrouping)
    ///</summary>
    [Serializable]
    public partial class sys_StatisticalGroupingEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _S_ID=0; // S_ID
        private String _S_Name=""; // S_Name
        private String _S_Remark=""; // S_Remark
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
        /// S_ID
        /// </summary>
        public Int32  S_ID
        {
            set { this._S_ID = value; }
            get { return this._S_ID; }
        }
            
        /// <summary>
        /// S_Name
        /// </summary>
        public String  S_Name
        {
            set { this._S_Name = value; }
            get { return this._S_Name; }
        }
            
        /// <summary>
        /// S_Remark
        /// </summary>
        public String  S_Remark
        {
            set { this._S_Remark = value; }
            get { return this._S_Remark; }
        }
            
        #endregion
    }
}
  