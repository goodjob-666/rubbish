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
    public partial class tsUserEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _UID=""; // 字符串ID
        private String _Nickname=""; // 昵称
        private String _LoginID=""; // 登录ID
        private String _Pass=""; // 登录密码
        private String _Email=""; // 邮箱
        private String _QQ=""; // 联系QQ
        private String _Mobile=""; // 联系电话
        private String _Question=""; // 安全问题
        private String _Answer=""; // 安全答案
        private String _BindMobile=""; // 绑定手机
        private String _PayPass=""; // 支付密码
        private Int16 _LoginMode=0; // 登录模式
        private Int16 _IsOnline=0; // 在线状态
        private Boolean _HaveSubUser=false; // 有子帐号
        private Int32 _IconIndex=0; // 图标序号
        private DateTime _CreateDate=DateTime.Now; // 创建时间
        private DateTime? _LoginDate; // 登录时间
        private Int16 _Status=0; // 状态
        private String _Sign=""; // 签名
        private String _Comment=""; // 备注

        private Double _SumBal =0.0000f; // 总金额

        private String _Figureurl = "";   //头像
        private String _OpenID = "";
        private Int32 _Sex = 0;
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
        /// 字符串ID
        /// </summary>
        public String  UID
        {
            set { this._UID = value; }
            get { return this._UID; }
        }
            
        /// <summary>
        /// 昵称
        /// </summary>
        public String  Nickname
        {
            set { this._Nickname = value; }
            get { return this._Nickname; }
        }
            
        /// <summary>
        /// 登录ID
        /// </summary>
        public String  LoginID
        {
            set { this._LoginID = value; }
            get { return this._LoginID; }
        }
            
        /// <summary>
        /// 登录密码
        /// </summary>
        public String  Pass
        {
            set { this._Pass = value; }
            get { return this._Pass; }
        }
            
        /// <summary>
        /// 邮箱
        /// </summary>
        public String  Email
        {
            set { this._Email = value; }
            get { return this._Email; }
        }
            
        /// <summary>
        /// 联系QQ
        /// </summary>
        public String  QQ
        {
            set { this._QQ = value; }
            get { return this._QQ; }
        }
            
        /// <summary>
        /// 联系电话
        /// </summary>
        public String  Mobile
        {
            set { this._Mobile = value; }
            get { return this._Mobile; }
        }
            
        /// <summary>
        /// 安全问题
        /// </summary>
        public String  Question
        {
            set { this._Question = value; }
            get { return this._Question; }
        }
            
        /// <summary>
        /// 安全答案
        /// </summary>
        public String  Answer
        {
            set { this._Answer = value; }
            get { return this._Answer; }
        }
            
        /// <summary>
        /// 绑定手机
        /// </summary>
        public String  BindMobile
        {
            set { this._BindMobile = value; }
            get { return this._BindMobile; }
        }
            
        /// <summary>
        /// 支付密码
        /// </summary>
        public String  PayPass
        {
            set { this._PayPass = value; }
            get { return this._PayPass; }
        }
            
        /// <summary>
        /// 登录模式
        /// </summary>
        public Int16  LoginMode
        {
            set { this._LoginMode = value; }
            get { return this._LoginMode; }
        }
            
        /// <summary>
        /// 在线状态
        /// </summary>
        public Int16  IsOnline
        {
            set { this._IsOnline = value; }
            get { return this._IsOnline; }
        }
            
        /// <summary>
        /// 有子帐号
        /// </summary>
        public Boolean  HaveSubUser
        {
            set { this._HaveSubUser = value; }
            get { return this._HaveSubUser; }
        }
            
        /// <summary>
        /// 图标序号
        /// </summary>
        public Int32  IconIndex
        {
            set { this._IconIndex = value; }
            get { return this._IconIndex; }
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
        /// 登录时间
        /// </summary>
        public DateTime?  LoginDate
        {
            set { this._LoginDate = value; }
            get { return this._LoginDate; }
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
        public String  Sign
        {
            set { this._Sign = value; }
            get { return this._Sign; }
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
        public String Figureurl
        {
            set { this._Figureurl = value; }
            get { return this._Figureurl; }
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
        public Int32 Sex
        {
            set { this._Sex = value; }
            get { return this._Sex; }
        }
            
        #endregion
    }
}
  