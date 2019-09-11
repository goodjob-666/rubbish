/********************************************************************************
    File:
          sys_NewsEntity.cs
    Description:
          sys_News实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/1/17 星期六 17:32:45
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_NewsEntity实体类(sys_News)
    ///</summary>
    [Serializable]
    public partial class sys_NewsEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _N_ID=0; // N_ID
        private Int32 _N_TypeID=0; // N_TypeID
        private String _N_Title=""; // N_Title
        private String _N_Author=""; // N_Author
        private DateTime? _N_CreateDate; // N_CreateDate
        private Int32 _N_Click=0; // N_Click
        private String _N_Content=""; // N_Content
        private String _N_Remarks=""; // N_Remarks
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
        /// N_ID
        /// </summary>
        public Int32  N_ID
        {
            set { this._N_ID = value; }
            get { return this._N_ID; }
        }
            
        /// <summary>
        /// N_TypeID
        /// </summary>
        public Int32  N_TypeID
        {
            set { this._N_TypeID = value; }
            get { return this._N_TypeID; }
        }
            
        /// <summary>
        /// N_Title
        /// </summary>
        public String  N_Title
        {
            set { this._N_Title = value; }
            get { return this._N_Title; }
        }
            
        /// <summary>
        /// N_Author
        /// </summary>
        public String  N_Author
        {
            set { this._N_Author = value; }
            get { return this._N_Author; }
        }
            
        /// <summary>
        /// N_CreateDate
        /// </summary>
        public DateTime?  N_CreateDate
        {
            set { this._N_CreateDate = value; }
            get { return this._N_CreateDate; }
        }
            
        /// <summary>
        /// N_Click
        /// </summary>
        public Int32  N_Click
        {
            set { this._N_Click = value; }
            get { return this._N_Click; }
        }
            
        /// <summary>
        /// N_Content
        /// </summary>
        public String  N_Content
        {
            set { this._N_Content = value; }
            get { return this._N_Content; }
        }
            
        /// <summary>
        /// N_Remarks
        /// </summary>
        public String  N_Remarks
        {
            set { this._N_Remarks = value; }
            get { return this._N_Remarks; }
        }
            
        #endregion
    }
}
  