using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using FrameWork;
using FrameWork.Components;
using DLT;
using DLT.Components;
using FrameWork.WebControls;


namespace FrameWork.web
{
    public partial class Login : System.Web.UI.Page
    {
        public string FrameName;
        public string FrameNameVer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //清除在线用户
                FrameWorkOnline.Instance().ClearOnlineUserTimeOut();
            }

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("default.aspx");
            }
            FrameName = FrameSystemInfo.GetSystemInfoTable.S_Name;
            FrameNameVer = FrameSystemInfo.GetSystemInfoTable.S_Version;

            //Button1.Attributes.Add("Onclick", "javascript:return checkForm(ctl00);");
            string CMD = (string)Common.sink("CMD", MethodType.Get, 255, 0, DataType.Str);
            if (CMD == "OutOnline")
            {
                string U_LoginName = (string)Common.sink("U_LoginName", MethodType.Get, 20, 1, DataType.Str);
                string U_Password = (string)Common.sink("U_Password", MethodType.Get, 50, 1, DataType.Str);
                string OPCode = (string)Common.sink("OPCode", MethodType.Get, 4, 4, DataType.Str);

                MessageBox MBx = new MessageBox();
                MBx.M_Type = 2;
                MBx.M_Title = "强制下线！";
                MBx.M_IconType = Icon_Type.Error;
                MBx.M_Body = "强制下线失败.验证码无效，请确认您输入的验证码有效！";


                if (Session["CheckCode"] == null || OPCode.ToLower() != Session["CheckCode"].ToString())
                {
                    MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
                }
                else
                {
                    QueryParam qp = new QueryParam();
                    qp.Where = string.Format(" Where U_StatUs=0 and  U_LoginName='{0}' and U_Password='{1}'", Common.inSQL(U_LoginName), Common.inSQL(Common.md5(U_Password,32)));
                    int iInt = 0;
                    ArrayList lst = BusinessFacade.sys_UserList(qp, out iInt);
                    if (iInt > 0)
                    {
                        //FrameWorkPermission.UserOnlineList.RemoveUserName(U_LoginName.ToLower());
                        string sessionid = (string)Common.sink("SessionID", MethodType.Get, 24, 0, DataType.Str);
                        FrameWorkOnline.Instance().OnlineRemove(sessionid);
                        MBx.M_IconType = Icon_Type.OK;
                        MBx.M_Body = string.Format("强制帐号{0}下线成功！", U_LoginName);
                        //写入强制帐号下线日志
                        EventMessage.EventWriteDB(2, MBx.M_Body, ((sys_UserTable)lst[0]).UserID);
                        LoginUser(U_LoginName, U_Password, OPCode, UserKey);
                        //MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "", UrlType.Href, true));
                        //设置用户为登陆状态

                    }
                    else
                    {
                        MBx.M_Body = "强制下线失败.用户名/密码无效！";
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "", UrlType.Href, true));
                    }

                }
                Session["CheckCode"] = Common.RndNum(4);
                EventMessage.MessageBox(MBx);


            }

            if (!DispCode)
            {
                Logincode_op.Src = "images/Logon/Logon_7no.gif";
                inputcode_op.Visible = false;
            }


        }

        /// <summary>
        /// 是否显示验证码(出错6次,出现验证码)
        /// </summary>
        private bool DispCode
        {
            get {
                if (FrameWorkLogin.GetLoginUserError(UserKey) > 5)
                    return true;
                else
                    return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginUser(sLoginName, sLoginPass, sCode_op,UserKey);
        }


        private string SuperUser(string sLoginName)
        {
            int f = 0;
            string superUser = ConfigurationManager.AppSettings["SuperUser"].ToString();
            string[] su = superUser.Split(',');
            for (int i = 0; i < su.Length; i++)
            {
                if (su[i] == sLoginName)
                {
                    f = 1;
                    break;
                }
            }
            return f.ToString();
        }

        /// <summary>
        /// 进行登陆操作
        /// </summary>
        /// <param name="sLoginName">用户名</param>
        /// <param name="sLoginPass">密码</param>
        /// <param name="sCode_op">验证码</param>
        /// <param name="UserKey">用户key</param>
        private void LoginUser(string sLoginName, string sLoginPass, string sCode_op, string UserKey)
        {
            MessageBox MBx = new MessageBox();
            MBx.M_Type = 2;
            MBx.M_Title = "登陆出错！";
            MBx.M_IconType = Icon_Type.Error;
            MBx.M_Body = "验证码无效，请确认您输入的验证码有效！";




            //判断当前MAC是否允许登录
            string flag = ConfigurationManager.AppSettings["LoginValidate"].ToString();
            if (flag == "true")
            {
                //判断是否是超级用户

                if (SuperUser(sLoginName) == "1")
                {
                    if (DispCode && (Session["CheckCode"] == null || sCode_op != Session["CheckCode"].ToString()))
                    {
                        MBx.M_WriteToDB = false;
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
                    }
                    else if (!FrameWorkLogin.CheckDisableLoginUser(UserKey))
                    {
                        MBx.M_Body = string.Format("当前IP:{0}登陆出错次数({1})超过系统允许,已经禁止登陆.请联系管理员！", Common.GetIPAddress(), FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_LoginErrorMaxNum);
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮返回！", UrlType.Href, true));

                    }
                    else if (new FrameWorkLogin().CheckLogin(sLoginName, sLoginPass, UserKey))
                    {
                        MBx.M_IconType = Icon_Type.OK;
                        MBx.M_Title = "登陆成功！";
                        MBx.M_Body = string.Format("欢迎您{0}，成功登入。您的IP为：{1}！", sLoginName, Common.GetIPAddress());
                        MBx.M_WriteToDB = false;
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("确定", "default.aspx", "点击按钮登陆！", UrlType.Href, true));
                        FrameWorkLogin.MoveErrorLoginUser(UserKey);
                        //写登入日志
                        EventMessage.EventWriteDB(2, MBx.M_Body, UserData.Get_sys_UserTable(sLoginName).UserID);
                    }
                    else
                    {
                        MBx.M_Body = string.Format("用户名/密码({0}/{1})错误！", sLoginName, sLoginPass);
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入！", UrlType.Href, true));
                    }
                }
                else
                {
                    //获取当前登录人的IP地址
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                    QueryParam qp = new QueryParam();
                    qp.Where = " where 1=1 and L_Status=1 and L_MAC='" + ip.Trim() + "' and getdate()>L_StartDate and getdate()<L_EndDate";
                    qp.PageIndex = 1;
                    qp.PageSize = 1;
                    int RecordCount = 0;
                    List<sys_LoginAuthorizeEntity> lst = BusinessFacadeDLT.sys_LoginAuthorizeList(qp, out RecordCount);
                    if (RecordCount > 0)
                    {
                        if (DispCode && (Session["CheckCode"] == null || sCode_op != Session["CheckCode"].ToString()))
                        {
                            MBx.M_WriteToDB = false;
                            MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
                        }
                        else if (!FrameWorkLogin.CheckDisableLoginUser(UserKey))
                        {
                            MBx.M_Body = string.Format("当前IP:{0}登陆出错次数({1})超过系统允许,已经禁止登陆.请联系管理员！", Common.GetIPAddress(), FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_LoginErrorMaxNum);
                            MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮返回！", UrlType.Href, true));

                        }
                        else if (new FrameWorkLogin().CheckLogin(sLoginName, sLoginPass, UserKey))
                        {
                            MBx.M_IconType = Icon_Type.OK;
                            MBx.M_Title = "登陆成功！";
                            MBx.M_Body = string.Format("欢迎您{0}，成功登入。您的IP为：{1}！", sLoginName, Common.GetIPAddress());
                            MBx.M_WriteToDB = false;
                            MBx.M_ButtonList.Add(new sys_NavigationUrl("确定", "default.aspx", "点击按钮登陆！", UrlType.Href, true));
                            FrameWorkLogin.MoveErrorLoginUser(UserKey);
                            //写登入日志
                            EventMessage.EventWriteDB(2, MBx.M_Body, UserData.Get_sys_UserTable(sLoginName).UserID);
                        }
                        else
                        {
                            MBx.M_Body = string.Format("用户名/密码({0}/{1})错误！", sLoginName, sLoginPass);
                            MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入！", UrlType.Href, true));
                        }
                    }
                    else
                    {
                        MBx.M_WriteToDB = false;
                        MBx.M_Body = string.Format("对不起{0}，您的IP为：{1}，此IP无授权或授权过期，请申请授权此IP后重新登录！", sLoginName, Common.GetIPAddress());
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "此IP无授权或授权过期，请申请授权此IP后重新登录！", UrlType.Href, true));
                    }
                }

                
            }
            else
            {
                if (DispCode && (Session["CheckCode"] == null || sCode_op != Session["CheckCode"].ToString()))
                {
                    MBx.M_WriteToDB = false;
                    MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
                }
                else if (!FrameWorkLogin.CheckDisableLoginUser(UserKey))
                {
                    MBx.M_Body = string.Format("当前IP:{0}登陆出错次数({1})超过系统允许,已经禁止登陆.请联系管理员！", Common.GetIPAddress(), FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_LoginErrorMaxNum);
                    MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮返回！", UrlType.Href, true));

                }
                else if (new FrameWorkLogin().CheckLogin(sLoginName, sLoginPass, UserKey))
                {
                    MBx.M_IconType = Icon_Type.OK;
                    MBx.M_Title = "登陆成功！";
                    MBx.M_Body = string.Format("欢迎您{0}，成功登入。您的IP为：{1}！", sLoginName, Common.GetIPAddress());
                    MBx.M_WriteToDB = false;
                    MBx.M_ButtonList.Add(new sys_NavigationUrl("确定", "default.aspx", "点击按钮登陆！", UrlType.Href, true));
                    FrameWorkLogin.MoveErrorLoginUser(UserKey);
                    //写登入日志
                    EventMessage.EventWriteDB(2, MBx.M_Body, UserData.Get_sys_UserTable(sLoginName).UserID);
                }
                else
                {
                    MBx.M_Body = string.Format("用户名/密码({0}/{1})错误！", sLoginName, sLoginPass);
                    MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入！", UrlType.Href, true));
                }
            }
            Session["CheckCode"] = Common.RndNum(4);
            EventMessage.MessageBox(MBx);
        }

        /// <summary>
        /// 获得用户登陆Key(根据IP)
        /// </summary>
        string UserKey
        {
            get
            {
                return Common.GetIPAddress().Replace(".", "_");
            }
        }
        string sLoginName
        {
            get
            {
                return this.LoginName.Text.Trim();
            }
        }
        /// <summary>
        /// 32位用户加密md5
        /// </summary>
        string sLoginPass
        {
            get
            {
                return this.LoginPass.Text.Trim();
            }
        }
        string sCode_op
        {
            get
            {
                return this.code_op.Text.Trim();
            }
        }

    }
}
