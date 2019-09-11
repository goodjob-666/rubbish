/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            用户列表
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

namespace DLT.Web.Module.DLT.tsUser
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["MAC"] != null)
                {
                    RequestSQL();
                }
                else if (Request["IDLIST"]!= null)
                {
                    RequestSQL1();
                }
                else if (Request["IP"] != null)
                {
                    RequestSQL3();
                }
                else if (Request["IDLIST1"] != null)
                {
                    RequestSQL2();
                }
                else
                {
                    TabOptionWebControls1.SelectIndex = 1;
                }
                BindUserStatus();
                
            }
        }

        public string IsGoodUser(string ID)
        {

            string result = "普通用户";

            DataTable dt = BusinessFacadeDLT.IsGoodPost(ID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = "优质用户";
            }

            DataTable dt1 = BusinessFacadeDLT.IsGoodAccept(ID).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                result = "优质用户";
            }

            return result;
        }




        public string HaveSubUser(string havesubuser)
        {
            if (havesubuser == "True")
            {
                return "启用";
            }
            else
            {
                return "禁用";
            }
        }

        public string Status(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1002 and Kind=" + status;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
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
            DataSet ds = BusinessFacadeDLT.UserList(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request["MAC"] != null)
            {
                RequestSQL();
            }
            else if (Request["IP"] != null)
            {
                RequestSQL3();
            }
            else if (Request["IDLIST"] != null)
            {
                RequestSQL1();
            }
            else
            {
                BindDataList();
            }

        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 绑定用户状态
        /// </summary>
        private void BindUserStatus()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1002";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                dllUserStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public string SaveTwoDec(string money)
        {
            if (money != "")
            {
                return Convert.ToDouble(money).ToString("0.00");
            }
            else
            {
                return "";
            }
        }




        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UID_Value = (string)Common.sink(UID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string Nickname_Value = (string)Common.sink(Nickname_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string LoginID_Value = (string)Common.sink(LoginID_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Pass_Value = (string)Common.sink(Pass_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Email_Value = (string)Common.sink(Email_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string QQ_Value = (string)Common.sink(QQ_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Mobile_Value = (string)Common.sink(Mobile_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Question_Value = (string)Common.sink(Question_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Answer_Value = (string)Common.sink(Answer_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string BindMobile_Value = (string)Common.sink(BindMobile_Input.UniqueID, MethodType.Post, 128, 0, DataType.Str);
            string PayPass_Value = (string)Common.sink(PayPass_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string LoginMode_Value = (string)Common.sink(LoginMode_Input.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string IsOnline_Value = (string)Common.sink(IsOnline_Input.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string HaveSubUser_Value = (string)Common.sink(HaveSubUser_Input.UniqueID, MethodType.Post, 1, 0, DataType.Str);
            string IconIndex_Value = (string)Common.sink(IconIndex_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Status_Value = (string)Common.sink(dllUserStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Sign_Value = (string)Common.sink(Sign_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();

            sb.Append(" Where 1=1 ");

            if (UID_Value == string.Empty && Nickname_Value == string.Empty && LoginID_Value == string.Empty && Email_Value == string.Empty && QQ_Value == string.Empty && Mobile_Value == string.Empty && BindMobile_Value == string.Empty)
            {
                TabOptionWebControls1.SelectIndex = 1;
                Response.Write("<script language='javascript'>alert('请输入搜索内容！');</script>");
                return;
            }


            if (UID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UID = '{0}' ", Common.inSQL(UID_Value));
            }

            if (Nickname_Value != string.Empty)
            {
                sb.AppendFormat(" AND Nickname like '%{0}%' ", Common.inSQL(Nickname_Value.Replace("'", "''")));
            }

            if (LoginID_Value != string.Empty)
            {
                sb.AppendFormat(" AND LoginID like '%{0}%' ", Common.inSQL(LoginID_Value));
            }

            if (Pass_Value != string.Empty)
            {
                sb.AppendFormat(" AND Pass like '%{0}%' ", Common.inSQL(Pass_Value));
            }

            if (Email_Value != string.Empty)
            {
                sb.AppendFormat(" AND Email like '%{0}%' ", Common.inSQL(Email_Value));
            }

            if (QQ_Value != string.Empty)
            {
                sb.AppendFormat(" AND QQ like '%{0}%' ", Common.inSQL(QQ_Value));
            }

            if (Mobile_Value != string.Empty)
            {
                sb.AppendFormat(" AND Mobile like '%{0}%' ", Common.inSQL(Mobile_Value));
            }

            if (Question_Value != string.Empty)
            {
                sb.AppendFormat(" AND Question like '%{0}%' ", Common.inSQL(Question_Value));
            }

            if (Answer_Value != string.Empty)
            {
                sb.AppendFormat(" AND Answer like '%{0}%' ", Common.inSQL(Answer_Value));
            }

            if (BindMobile_Value != string.Empty)
            {
                sb.AppendFormat(" AND BindMobile like '%{0}%' ", Common.inSQL(BindMobile_Value));
            }

            if (PayPass_Value != string.Empty)
            {
                sb.AppendFormat(" AND PayPass like '%{0}%' ", Common.inSQL(PayPass_Value));
            }

            if (LoginMode_Value != string.Empty)
            {
                sb.AppendFormat(" AND LoginMode = {0} ", Convert.ToInt32(LoginMode_Value));
            }

            if (IsOnline_Value != string.Empty)
            {
                sb.AppendFormat(" AND IsOnline = {0} ", Convert.ToInt32(IsOnline_Value));
            }

            if (HaveSubUser_Value != string.Empty)
            {
                sb.AppendFormat(" AND HaveSubUser = {0} ", Convert.ToInt32(HaveSubUser_Value));
            }

            if (IconIndex_Value != string.Empty)
            {
                sb.AppendFormat(" AND IconIndex = {0} ", Convert.ToInt32(IconIndex_Value));
            }



            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Sign_Value != string.Empty)
            {
                sb.AppendFormat(" AND Sign like '{0}' ", Common.inSQL(Sign_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND Comment like '{0}' ", Common.inSQL(Comment_Value));
            }
            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        private void RequestSQL()
        {
            if (Request["MAC"] != null)
            {
                //mac = Request["MAC"].ToString();
                //sb.Append(" Where 1=1 ");
                //DataTable dt = BusinessFacadeDLT.BM_GetUserListByMAC(mac).Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    idStr += dt.Rows[i][0].ToString() + ",";
                //}
                //idStr = idStr.Substring(0, idStr.Length - 1);
                //sb.Append(" AND ID IN(" + idStr + ")");
                //ViewState["SearchTerms"] = sb.ToString();

                BindDataList2(Request["MAC"].ToString());

                TabOptionWebControls1.SelectIndex = 0;



            }
            else
            {
                Response.Write("<script language='javascript'>alert('MAC获取出错，请重新执行操作！');</script>");
                TabOptionWebControls1.SelectIndex = 1;
                return;
            }
        }

        private void RequestSQL3()
        {
            if (Request["IP"] != null)
            {
                //mac = Request["MAC"].ToString();
                //sb.Append(" Where 1=1 ");
                //DataTable dt = BusinessFacadeDLT.BM_GetUserListByMAC(mac).Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    idStr += dt.Rows[i][0].ToString() + ",";
                //}
                //idStr = idStr.Substring(0, idStr.Length - 1);
                //sb.Append(" AND ID IN(" + idStr + ")");
                //ViewState["SearchTerms"] = sb.ToString();

                BindDataList4(Request["IP"].ToString());

                TabOptionWebControls1.SelectIndex = 0;



            }
            else
            {
                Response.Write("<script language='javascript'>alert('IP获取出错，请重新执行操作！');</script>");
                TabOptionWebControls1.SelectIndex = 1;
                return;
            }
        }


        private void BindDataList1(string ID)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.UserListByMAC(ID,qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }

        private void BindDataList3(string ID)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.UserListByHD(ID, qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }


        private void BindDataList2(string MAC)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.UserListByMAC1(MAC, qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }

        private void BindDataList4(string IP)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByIP", IP, qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }

        private void RequestSQL1()
        {
            string id = "";
            if (Request["IDLIST"] != null)
            {
                id = Request["IDLIST"].ToString();
                BindDataList1(id);
                TabOptionWebControls1.SelectIndex = 0;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('用户ID获取出错，请重新执行操作！');</script>");
                TabOptionWebControls1.SelectIndex = 1;
                return;
            }
        }

        private void RequestSQL2()
        {
            string id = "";
            if (Request["IDLIST1"] != null)
            {
                id = Request["IDLIST1"].ToString();
                BindDataList3(id);
                TabOptionWebControls1.SelectIndex = 0;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('用户ID获取出错，请重新执行操作！');</script>");
                TabOptionWebControls1.SelectIndex = 1;
                return;
            }
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
                    tsUserEntity et = new tsUserEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tsUserInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int result = BusinessFacadeDLT.SetUserSubAccount(subUserID.Text,int.Parse(ddlSubAccount.SelectedValue));
            if (result == 1)
            {
                EventMessage.MessageBox(1, "设置子帐号成功", "设置子帐号成功", Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int index = row.RowIndex;
                Label lblUID = GridView1.Rows[index].FindControl("lblUID") as Label;

                Label lblSubStatus = GridView1.Rows[index].FindControl("Label1") as Label;

                subUserID.Text = lblUID.Text;

                if (lblSubStatus.Text == "禁用")
                {
                    ddlSubAccount.SelectedValue = "0";

                }
                else
                {
                    ddlSubAccount.SelectedValue = "1";
                }
                TabOptionWebControls1.SelectIndex = 2;


        }

    }
}
