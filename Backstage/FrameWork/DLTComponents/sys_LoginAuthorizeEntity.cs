/********************************************************************************
    File:
          sys_LoginAuthorizeEntity.cs
    Description:
          sys_LoginAuthorize实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2015/6/30 23:12:10
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace DLT.Components
{
    ///<summary>
    ///sys_LoginAuthorizeEntity实体类(sys_LoginAuthorize)
    ///</summary>
    [Serializable]
    public partial class sys_LoginAuthorizeEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _L_ID=0; // L_ID
        private Int32 _L_Status=0; // L_Status
        private DateTime? _L_CreateDate; // L_CreateDate
        private DateTime? _L_StartDate; // L_StartDate
        private DateTime? _L_EndDate; // L_EndDate
        private String _L_Remark=""; // L_Remark
        private String _L_IP=""; // L_IP
        private String _L_MAC=""; // L_MAC
        private Int32 _L_BC1=0; // L_BC1
        private DateTime? _L_BC2; // L_BC2
        private String _L_BC3=""; // L_BC3
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
        /// L_ID
        /// </summary>
        public Int32  L_ID
        {
            set { this._L_ID = value; }
            get { return this._L_ID; }
        }
            
        /// <summary>
        /// L_Status
        /// </summary>
        public Int32  L_Status
        {
            set { this._L_Status = value; }
            get { return this._L_Status; }
        }
            
        /// <summary>
        /// L_CreateDate
        /// </summary>
        public DateTime?  L_CreateDate
        {
            set { this._L_CreateDate = value; }
            get { return this._L_CreateDate; }
        }
            
        /// <summary>
        /// L_StartDate
        /// </summary>
        public DateTime?  L_StartDate
        {
            set { this._L_StartDate = value; }
            get { return this._L_StartDate; }
        }
            
        /// <summary>
        /// L_EndDate
        /// </summary>
        public DateTime?  L_EndDate
        {
            set { this._L_EndDate = value; }
            get { return this._L_EndDate; }
        }
            
        /// <summary>
        /// L_Remark
        /// </summary>
        public String  L_Remark
        {
            set { this._L_Remark = value; }
            get { return this._L_Remark; }
        }
            
        /// <summary>
        /// L_IP
        /// </summary>
        public String  L_IP
        {
            set { this._L_IP = value; }
            get { return this._L_IP; }
        }
            
        /// <summary>
        /// L_MAC
        /// </summary>
        public String  L_MAC
        {
            set { this._L_MAC = value; }
            get { return this._L_MAC; }
        }
            
        /// <summary>
        /// L_BC1
        /// </summary>
        public Int32  L_BC1
        {
            set { this._L_BC1 = value; }
            get { return this._L_BC1; }
        }
            
        /// <summary>
        /// L_BC2
        /// </summary>
        public DateTime?  L_BC2
        {
            set { this._L_BC2 = value; }
            get { return this._L_BC2; }
        }
            
        /// <summary>
        /// L_BC3
        /// </summary>
        public String  L_BC3
        {
            set { this._L_BC3 = value; }
            get { return this._L_BC3; }
        }
            
        #endregion
    }
}
  