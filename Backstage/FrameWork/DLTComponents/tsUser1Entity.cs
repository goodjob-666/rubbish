/********************************************************************************
    File:
          tsUserEntity.cs
    Description:
          用户实体类
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
    ///tsUserEntity实体类(用户)
    ///</summary>
    [Serializable]
    public partial class tsUser1Entity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _NickName = ""; // 昵称
        private String _Country = "";
        private String _Province = "";
        private String _City = "";
        private DateTime _CreateDate=DateTime.Now; // 创建时间
        private Int16 _Status=0; // 状态
        private String _Token = ""; // 签名
        private String _Comment=""; // 备注
        private Double _SumBal =0.0000f; // 总金额
        private String _AvatarUrl = "";   //头像
        private String _OpenID = "";
        private Int32 _Gender = 0;
        private String _UID = "";

        private Int32 _MemberID = 0;
        private DateTime _EndDate = DateTime.Now; 

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
        /// 昵称
        /// </summary>
        public String NickName
        {
            set { this._NickName = value; }
            get { return this._NickName; }
        }

        public String Country
        {
            set { this._Country = value; }
            get { return this._Country; }
        }

        public String Province
        {
            set { this._Province = value; }
            get { return this._Province; }
        }

        public String City
        {
            set { this._City = value; }
            get { return this._City; }
        }
  
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  CreateDate
        {
            set { this._CreateDate = value; }
            get { return this._CreateDate; }
        }
      
        /// <summary>
        /// 状态
        /// </summary>
        public Int16  Status
        {
            set { this._Status = value; }
            get { return this._Status; }
        }
            
        /// <summary>
        /// 签名
        /// </summary>
        public String Token
        {
            set { this._Token = value; }
            get { return this._Token; }
        }
            
        /// <summary>
        /// 备注
        /// </summary>
        public String  Comment
        {
            set { this._Comment = value; }
            get { return this._Comment; }
        }

        /// <summary>
        ///头像
        /// </summary>
        public String AvatarUrl
        {
            set { this._AvatarUrl = value; }
            get { return this._AvatarUrl; }
        }


        /// <summary>
        ///金额
        /// </summary>
        public Double SumBal
        {
            set { this._SumBal = value; }
            get { return this._SumBal; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String OpenID
        {
            set { this._OpenID = value; }
            get { return this._OpenID; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public Int32 Gender
        {
            set { this._Gender = value; }
            get { return this._Gender; }
        }

        public String UID
        {
            set { this._UID = value; }
            get { return this._UID; }
        }



        public Int32 MemberID
        {
            set { this._MemberID = value; }
            get { return this._MemberID; }
        }

        public DateTime EndDate
        {
            set { this._EndDate = value; }
            get { return this._EndDate; }
        }
            
        #endregion
    }
}
  