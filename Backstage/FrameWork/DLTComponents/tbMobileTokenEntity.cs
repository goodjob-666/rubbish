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
    ///短信实体类
    ///</summary>
    [Serializable]
    public partial class tbMobileTokenEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private String _SerialNo = "";
        private Int32 _UserID = 0;
        private Int32 _IsVerify = 0;
        private Int32 _SmsStyle = 0;
        private Int32 _UseType = 0;
        private DateTime? _CreateDate; // 创建时间
        private String _Mobile = "";
        private String _VerifyCode = "";
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
        public Int32 UserID
        {
            set { this._UserID = value; }
            get { return this._UserID; }
        }

        public Int32 IsVerify
        {
            set { this._IsVerify = value; }
            get { return this._IsVerify; }
        }

        public Int32 SmsStyle
        {
            set { this._SmsStyle = value; }
            get { return this._SmsStyle; }
        }

        public Int32 UseType
        {
            set { this._UseType = value; }
            get { return this._UseType; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }

       
        public String Mobile
        {
            set { this._Mobile = value; }
            get { return this._Mobile; }
        }

        public String VerifyCode
        {
            set { this._VerifyCode = value; }
            get { return this._VerifyCode; }
        }

        #endregion
    }
}
