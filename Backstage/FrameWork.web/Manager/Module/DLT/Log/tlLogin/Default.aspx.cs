/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            登录日志列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2014/8/5 13:39:35
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tlLogin
{
    public partial class Default : System.Web.UI.Page
    {
        public string UserID_Value;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    RequestSQL();
                    divMacInfo.Visible = false;
                    divIPInfo.Visible = false;
                }
                else if (Request["MAC"] != null)
                {
                    RequestMACSQL();
                    lblMAC.Text = Request["MAC"].ToString();
                    lblMACCOUNT.Text = BusinessFacadeDLT.GetUserCountByMAC(Request["MAC"].ToString()).Tables[0].Rows[0][0].ToString();
                    AMacToUser.Attributes.Add("href", "../../service/tsuser/default.aspx?MAC=" + Request["MAC"].ToString());
                    divMacInfo.Visible = true;
                }
                else if (Request["IP"] != null)
                {
                    RequestIPSQL();
                    lblIP.Text = Request["IP"].ToString();
                    lblIPCOUNT.Text = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetUserCountByIP",Request["IP"].ToString()).Tables[0].Rows[0][0].ToString();
                    AIPToUser.Attributes.Add("href", "../../service/tsuser/default.aspx?IP=" + Request["IP"].ToString());
                    divIPInfo.Visible = true;
                }
                else
                {
                    TabOptionWebControls1.SelectIndex = 1;
                    divMacInfo.Visible = false;
                    divIPInfo.Visible = false;
                }
                //BindDataList();
                BindLoginType();
                BindStatus();
                LoginDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                LoginDate_Input_E.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.LoginList(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public string RightLock(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1005 and Kind=" + status;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
        }

        public string XQStatus(string id)
        {
            //需要如果这个用户被封了“发单功能”或者“接发单功能”，这个状态就需要显示”封停“字样，如果没有封号或者只封了”接单功能“，那这个状态还是显示”正常“字样即可
            DataTable dt = BusinessFacadeDLT.FTRightLock(id).Tables[0];
            string str = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i][0].ToString())
                    {
                        case "10":
                        case "11":
                        case "12":
                        case "14":
                            str += RightLock(dt.Rows[i][0].ToString()) + "<br />";
                            break;
                    }
                }
            }
            if (str.IndexOf("禁止接发订单") > -1)
            {
                str = str.Replace("禁止发单<br />", "");
                str = str.Replace("禁止接单<br />", "");
            }
            if (str == "")
            {
                str = "正常";
            }
            return str;

        }

        public string GetUID(string ID)
        {
            if (ID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [ID]=" + ID;
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                if (lst.Count > 0)
                {
                    return lst[0].UID;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public string GetID(string UID)
        {
            if (UID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [UID]='" + UID+"'";
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                if (lst.Count > 0)
                {
                    return lst[0].ID.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public void BindLoginType()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1010";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlLoginType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public void BindStatus()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1011";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public string LoginType(string logintype)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1010 and Kind=" + logintype;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            if (lst != null && lst.Count > 0)
            {
                return lst[0].Value;
            }
            else
            {
                return "";
            }
        }

        public string Status(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1011 and Kind=" + status;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            if (lst != null && lst.Count > 0)
            {
                return lst[0].Value;
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string SubUserID_Value = (string)Common.sink(SubUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string LoginType_Value = (string)Common.sink(ddlLoginType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string PCName_Value = (string)Common.sink(PCName_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string HD_Value = (string)Common.sink(HD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string Mac_Value = (string)Common.sink(Mac_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OS_Value = (string)Common.sink(OS_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Status_Value = (string)Common.sink(ddlStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);


            StringBuilder sb = new StringBuilder();

            if (UserID_Value.Trim() != string.Empty)
            {
                if (GetID(UserID_Value.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.UserID = {0} ", Common.inSQL(GetID(UserID_Value.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }

            if (SubUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.SubUserID = {0} ", Convert.ToInt32(SubUserID_Value));
            }

            if (LoginType_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.LoginType = {0} ", Convert.ToInt32(LoginType_Value));
            }

            if (PCName_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.PCName = '{0}' ", Common.inSQL(PCName_Value));
            }

            if (HD_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.HD = '{0}' ", Common.inSQL(HD_Value));
            }

            if (Mac_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Mac = '{0}' ", Common.inSQL(Mac_Value));
            }

            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.IP = '{0}' ", Common.inSQL(IP_Value));
            }

            if (OS_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.OS = '{0}' ", Common.inSQL(OS_Value));
            }

            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and a.LoginDate between '{0} 00:00:00' and '{1} 23:59:59' ", LoginDate_Input.Text, LoginDate_Input_E.Text));
            }

            if (Mac_Value != "")
            {
                lblMAC.Text = Mac_Value;
                if (BusinessFacadeDLT.GetUserCountByMAC(Mac_Value).Tables[0].Rows.Count > 0)
                {
                    lblMACCOUNT.Text = BusinessFacadeDLT.GetUserCountByMAC(Mac_Value).Tables[0].Rows[0][0].ToString();
                    AMacToUser.Attributes.Add("href", "../../service/tsuser/default.aspx?MAC=" + Mac_Value);
                    divMacInfo.Visible = true;
                }
                else
                {
                    divMacInfo.Visible = false;
                }
            }
            else if (IP_Value != "")
            {
                lblIP.Text = IP_Value;
                if (SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetUserCountByIP",IP_Value).Tables[0].Rows.Count > 0)
                {
                    lblIPCOUNT.Text = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetUserCountByIP", IP_Value).Tables[0].Rows[0][0].ToString();
                    AIPToUser.Attributes.Add("href", "../../service/tsuser/default.aspx?IP=" + IP_Value);
                    divIPInfo.Visible = true;
                }
                else
                {
                    divIPInfo.Visible = false;
                }
            }
            else
            {
                divMacInfo.Visible = false;
                divIPInfo.Visible = false;
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        private void RequestMACSQL()
        {
            string RequestMAC_Value = "";
            if (Request["MAC"] != null)
            {
                RequestMAC_Value = Request["MAC"].ToString();
            }
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string SubUserID_Value = (string)Common.sink(SubUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string LoginType_Value = (string)Common.sink(ddlLoginType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string PCName_Value = (string)Common.sink(PCName_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string HD_Value = (string)Common.sink(HD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string Mac_Value = (string)Common.sink(Mac_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OS_Value = (string)Common.sink(OS_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Status_Value = (string)Common.sink(ddlStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);


            StringBuilder sb = new StringBuilder();

            if (UserID_Value.Trim() != string.Empty)
            {
                if (GetID(UserID_Value.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.UserID = {0} ", Common.inSQL(GetID(UserID_Value.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }

            if (SubUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.SubUserID = {0} ", Convert.ToInt32(SubUserID_Value));
            }

            if (LoginType_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.LoginType = {0} ", Convert.ToInt32(LoginType_Value));
            }

            if (PCName_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.PCName = '{0}' ", Common.inSQL(PCName_Value));
            }

            if (HD_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.HD = '{0}' ", Common.inSQL(HD_Value));
            }

            if (RequestMAC_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Mac = '{0}' ", Common.inSQL(RequestMAC_Value));
            }

            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.IP = '{0}' ", Common.inSQL(IP_Value));
            }

            if (OS_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.OS = '{0}' ", Common.inSQL(OS_Value));
            }

            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and a.LoginDate between '{0} 00:00:00' and '{1} 23:59:59' ", LoginDate_Input.Text, LoginDate_Input_E.Text));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        private void RequestIPSQL()
        {
            string RequestIP_Value = "";
            if (Request["IP"] != null)
            {
                RequestIP_Value = Request["IP"].ToString();
            }
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string SubUserID_Value = (string)Common.sink(SubUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string LoginType_Value = (string)Common.sink(ddlLoginType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string PCName_Value = (string)Common.sink(PCName_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string HD_Value = (string)Common.sink(HD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string Mac_Value = (string)Common.sink(Mac_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OS_Value = (string)Common.sink(OS_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Status_Value = (string)Common.sink(ddlStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);


            StringBuilder sb = new StringBuilder();

            if (UserID_Value.Trim() != string.Empty)
            {
                if (GetID(UserID_Value.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.UserID = {0} ", Common.inSQL(GetID(UserID_Value.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }

            if (SubUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.SubUserID = {0} ", Convert.ToInt32(SubUserID_Value));
            }

            if (LoginType_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.LoginType = {0} ", Convert.ToInt32(LoginType_Value));
            }

            if (PCName_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.PCName = '{0}' ", Common.inSQL(PCName_Value));
            }

            if (HD_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.HD = '{0}' ", Common.inSQL(HD_Value));
            }

            if (RequestIP_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Mac = '{0}' ", Common.inSQL(RequestIP_Value));
            }

            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.IP = '{0}' ", Common.inSQL(IP_Value));
            }

            if (OS_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.OS = '{0}' ", Common.inSQL(OS_Value));
            }

            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and a.LoginDate between '{0} 00:00:00' and '{1} 23:59:59' ", LoginDate_Input.Text, LoginDate_Input_E.Text));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        private void RequestSQL()
        {
            string RequestID_Value = "";
            if (Request["ID"] != null)
            {
                RequestID_Value = Request["ID"].ToString();
            }
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string SubUserID_Value = (string)Common.sink(SubUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string LoginType_Value = (string)Common.sink(ddlLoginType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string PCName_Value = (string)Common.sink(PCName_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string HD_Value = (string)Common.sink(HD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string Mac_Value = (string)Common.sink(Mac_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OS_Value = (string)Common.sink(OS_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Status_Value = (string)Common.sink(ddlStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(LoginDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);


            StringBuilder sb = new StringBuilder();

            if (UserID_Value.Trim() != string.Empty)
            {
                if (GetID(UserID_Value.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.UserID = {0} ", Common.inSQL(GetID(UserID_Value.Trim())));
                    RequestID_Value = "";
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }
            if (RequestID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.UserID ={0} ", Convert.ToInt32(RequestID_Value));
            }

            if (SubUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.SubUserID = {0} ", Convert.ToInt32(SubUserID_Value));
            }

            if (LoginType_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.LoginType = {0} ", Convert.ToInt32(LoginType_Value));
            }

            if (PCName_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.PCName = '{0}' ", Common.inSQL(PCName_Value));
            }

            if (HD_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.HD = '{0}' ", Common.inSQL(HD_Value));
            }

            if (Mac_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Mac = '{0}' ", Common.inSQL(Mac_Value));
            }

            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.IP = '{0}' ", Common.inSQL(IP_Value));
            }

            if (OS_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.OS = '{0}' ", Common.inSQL(OS_Value));
            }

            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and a.LoginDate between '{0} 00:00:00' and '{1} 23:59:59' ", LoginDate_Input.Text, LoginDate_Input_E.Text));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        #region "排序"
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Orderfld == e.SortExpression)
            {
                if (OrderType == 0)
                {
                    OrderType = 1;
                }
                else
                {
                    OrderType = 0;
                }
            }
            Orderfld = e.SortExpression;
            BindDataList();
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "ID";

                return (string)ViewState["sortOrderfld"];
            }
            set
            {
                ViewState["sortOrderfld"] = value;
            }
        }

        /// <summary>
        /// 排序类型 1:降序 0:升序
        /// </summary>
        public int OrderType
        {

            get
            {

                if (ViewState["sortOrderType"] == null)
                    ViewState["sortOrderType"] = 1;

                return (int)ViewState["sortOrderType"];


            }

            set { ViewState["sortOrderType"] = value; }

        }
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    tlLoginEntity et = new tlLoginEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tlLoginInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
