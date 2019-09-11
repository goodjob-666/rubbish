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
using FrameWork.WebControls;
using DLT;
using DLT.Components;


namespace FrameWork.web.Module.FrameWork.EventOrderManager
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_E_DateTime.Text = (DateTime.Now.AddDays(-3)).Date.ToString("yyyy-MM-dd");
                E_E_DateTime.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                CheckDown();
                TabOptionWebControls1.SelectIndex = 1;
                //ListBind();
                OnStart();
            }
        }

        /// <summary>
        /// 检测是否下载/删除
        /// </summary>
        protected void CheckDown()
        {
            if (!Common.AllowClearData)
                HeadMenuWebControls1.ButtonList[1].ButtonVisible = false;

            string cmd = (string)Common.sink("cmd", MethodType.Get, 255, 0, DataType.Str);
            if (string.Compare(cmd, "ClearData", true)==0)
            {
                ClearData();
            }
            else if (string.Compare(cmd, "DownLoadAndClearData", true)==0)
            {
                ExportTxt(true);
            }
            else if (string.Compare(cmd, "DownLoad", true)==0)
            {
                ExportTxt(false);
            }
        }

        public string FomartContent(string content)
        {
            if (content.Length == 33)
            {
                return content.Substring(3,20);
            }
            else
            {
                return content;
            }
        }

        public string JRDate(string content)
        {
            string searialNo = FomartContent(content);
            return BusinessFacadeDLT.ArbitrationList(searialNo).Tables[0].Rows[0]["CreateDate"].ToString();
        }

        public string SCDate(string content)
        {
            string searialNo = FomartContent(content);
            return BusinessFacadeDLT.LevelOrderList(searialNo).Tables[0].Rows[0]["FirstDate"].ToString();
            
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        protected void ClearData()
        {
            if (Common.AllowClearData)
            {
                BusinessFacade.sys_EventClearData();
                EventMessage.EventWriteDB(2, "清空操作日志!");
            }
        }

        /// <summary>
        /// 导出文件为txt
        /// </summary>
        /// <param name="isdelete">是否删除数据</param>
        protected void ExportTxt(bool isdelete)
        {

            Page.Response.Clear();
            Page.Response.Buffer = true;
            Page.Response.Charset = "GB2312";
            Page.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename=sys_EventLog{0}.csv",DateTime.Now.ToShortDateString()));
            Page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
            Response.ContentType = "text/plain";//设置输出文件类型为txt文件。 
            this.EnableViewState = false;
            System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("EventID,E_U_LoginName,E_UserID,E_DateTime,E_ApplicationID,E_A_AppName,E_M_Name,E_M_PageCode,E_From,E_Type,E_IP,E_Record");
            sb.Append("\n");
            int rCount = 0;
            ArrayList lst = BusinessFacade.sys_EventList(new QueryParam(1, int.MaxValue),out rCount);
            foreach (sys_EventTable var in lst)
            {
                sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},\"{11}\"\n", var.EventID,
                var.E_U_LoginName,var.E_UserID,var.E_DateTime,var.E_ApplicationID,
                var.E_A_AppName,var.E_M_Name,var.E_M_PageCode,var.E_From,
                var.E_Type,var.E_IP,var.E_Record
                );
            }

            Page.Response.Write(sb.ToString());
            if (isdelete)
            {
                ClearData();
            }
            EventMessage.EventWriteDB(2, "导出操作日志!");
            Page.Response.End();
        }

        public string Get_Type(string E_Type)
        {
            return MessageBox.Get_Type(int.Parse(E_Type));

        }

        private void OnStart()
        {
            BindUserList();
            BindE_ApplicationID();
        }

        private void BindE_ApplicationID()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_ApplicationsList(qp, out RecordCount);
            E_ApplicationID.DataTextField = "A_AppName";
            E_ApplicationID.DataValueField = "ApplicationID";
            E_ApplicationID.DataSource = lst;
            E_ApplicationID.DataBind();
            E_ApplicationID.Items.Insert(0, new ListItem("不限", ""));
        }

        private void BindUserList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_UserList(qp, out RecordCount);
            string stringDel = "";
            foreach (sys_UserTable var in lst)
            {
                stringDel = "";
                if (var.U_Status == 2)
                {
                    stringDel = "己删除";
                }
                E_UserID.Items.Add(new ListItem(var.U_LoginName + "(" + var.U_CName + ")" + stringDel, var.UserID.ToString()));
            }

            E_UserID.Items.Insert(0,new ListItem("不限", ""));
        }

        private void ListBind()
        {
            QueryParam qp = new QueryParam();
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            DataSet ds = null;

            string keyText=E_Record.Text;
            string tmpStr = "";

            //客服登录名转客服ID
            if (ddlSearch.SelectedValue == "客服ID")
            {
                if (keyText != "")
                {
                    if (keyText.IndexOf(",") < 0)
                    {
                        keyText = GetUserIDByLoginName(keyText);
                        if (keyText == "")
                        {
                            Response.Write("<script language='javascript'>alert('客服人员ID输入错误！');</script>");
                            return;
                        }
                    }
                    else
                    {
                        string s = "";
                        string[] opList = keyText.Split(',');
                        for (int i = 0; i < opList.Length; i++)
                        {
                            s = GetUserIDByLoginName(opList[i].ToString());
                            if (s != "")
                            {
                                tmpStr += GetUserIDByLoginName(opList[i].ToString()) + ",";
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('客服人员ID输入错误！');</script>");
                                return;
                            }
                        }
                        tmpStr = tmpStr.Substring(0, tmpStr.Length - 1);
                        keyText = tmpStr; 
                    }
                }
            }

            ds = BusinessFacadeDLT.OrderEvent(DateTime.Parse(S_E_DateTime.Text+" 00:00:00"), DateTime.Parse(E_E_DateTime.Text+" 23:59:59"),ddlSearch.Text, keyText, qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        }


        private string GetUserIDByLoginName(string LoginName)
        {
            if (LoginName != string.Empty)
            {
                if (UserData.Get_sys_UserTable1(LoginName) != null)
                {
                    return UserData.Get_sys_UserTable1(LoginName).UserID.ToString();
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

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            ListBind();
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            TabOptionWebControls1.SelectIndex = 0;
            ListBind();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1 = 1";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        protected void E_ApplicationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.E_ApplicationID.SelectedValue != "")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                qp.Where = string.Format(" Where M_ApplicationID = {0} and M_ParentID<>0 ", this.E_ApplicationID.SelectedValue);
                int RecordCount = 0;
                ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                E_M_PageCode.DataTextField = "M_CName";
                E_M_PageCode.DataValueField = "M_PageCode";
                E_M_PageCode.DataSource = lst;
                E_M_PageCode.DataBind();
                E_M_PageCode.Items.Insert(0, new ListItem("不限", ""));
            }
            else {
                E_M_PageCode.Items.Clear();
            }
            TabOptionWebControls1.SelectIndex = 1;
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
            ListBind();
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "EventID";

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
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                        }
                    }
                }
            }
        }
        #endregion
    }
}
