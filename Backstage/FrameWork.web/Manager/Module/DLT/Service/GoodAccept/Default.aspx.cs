using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.GoodAccept
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input2.Text = S_dtDate_Input1.Text = S_dtDate_Input.Text = (DateTime.Now.AddDays(-30)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input2.Text = E_dtDate_Input1.Text = E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                Button5.Attributes.Add("onclick", "return   confirm('确定要添加该优质下家吗？')");
            }
        }

        /// <summary>
        /// 查询[优质下家申请]
        /// </summary>
        private void BindData1()
        {
            string Sort_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptList", txtUID.Text, DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), 10,
                Sort_Str, int.Parse(ddlTier.Text), chkUpTier.Checked ? 1 : 0, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        /// <summary>
        /// 查询[未通过下家]
        /// </summary>
        private void BindData2()
        {
            string Sort_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptList", txtUID1.Text, DateTime.Parse("1900-01-01 00:00:00"), DateTime.Parse("1900-01-01 00:00:00"), 12,
                Sort_Str,int.Parse(ddlTier1.Text), 0, AspNetPager2.CurrentPageIndex, AspNetPager2.PageSize);
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;
        }

        /// <summary>
        /// 查询[优质下家]
        /// </summary>
        private void BindData3()
        {
            string Sort_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptList", txtUID2.Text, DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), 11,
                Sort_Str, int.Parse(ddlTier2.Text), 0, AspNetPager3.CurrentPageIndex, AspNetPager3.PageSize);
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager3.RecordCount = RecordCount;
        }

        /// <summary>
        /// 查询[已踢出下家]
        /// </summary>
        private void BindData4()
        {
            string Sort_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptList", txtUID3.Text, DateTime.Parse("1900-01-01 00:00:00"), DateTime.Parse("1900-01-01 00:00:00"), 13,
                Sort_Str, int.Parse(ddlTier3.Text),0, AspNetPager4.CurrentPageIndex, AspNetPager4.PageSize);
            GridView4.DataSource = ds.Tables[0];
            GridView4.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager4.RecordCount = RecordCount;
        }

        /// <summary>
        /// 优质区日志
        /// </summary>
        private void BindData5()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodLogList", txtUID8.Text.Trim(), 
                AspNetPager5.CurrentPageIndex, AspNetPager5.PageSize);
            GridView5.DataSource = ds.Tables[0];
            GridView5.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager5.RecordCount = RecordCount;
        }

        /// <summary>
        /// 查询[优质下家申请退出]
        /// </summary>
        private void BindData6()
        {
            string Sort_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptList", txtUID9.Text, DateTime.Parse(S_dtDate_Input2.Text), DateTime.Parse(E_dtDate_Input2.Text), 14,
                Sort_Str, int.Parse(ddlTier4.Text), 0, AspNetPager6.CurrentPageIndex, AspNetPager6.PageSize);
            GridView6.DataSource = ds.Tables[0];
            GridView6.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager6.RecordCount = RecordCount;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["sortOrderfld"] = "";
            BindData1();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ViewState["sortOrderfld"] = "";
            BindData2();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ViewState["sortOrderfld"] = "";
            BindData3();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ViewState["sortOrderfld"] = "";
            BindData4();
        }

        /// <summary>
        /// 添加下家ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            //添加下家ID
            if (txtUID0.Text.Trim() != "")
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptAdd", Common.Get_UserID, txtUID0.Text.Trim(), ddlTierApply.Text, ddlFreezeBal.Text, 0);
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["Result"].ToString() == "1")
                {
                    //EventMessage.EventWriteDB(1, "添加下家到优质频道申请成功.");
                    Response.Write("<script language='javascript'>alert('添加下家到优质频道申请成功！');</script>");
                    BindData1();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                }
                txtUID0.Text = ""; 
            }
            else
            {
                Response.Write("<script language:javascript>javascript:window:alert('请输入下家ID');</script>");
            }
        }

        #region 排序

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "";

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
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
        }

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
            BindData1();
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string DataIDX = "";

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button8.Visible = true;
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
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    if (e.Row.DataItem != null)
                    {
                        DataIDX = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                        TableCell cell = new TableCell();
                        cell.Width = Unit.Pixel(5);
                        cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                        e.Row.Cells.AddAt(0, cell);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.FindControl("LinkButton3") != null)
                {
                    LinkButton CtlButton = (LinkButton)e.Row.FindControl("LinkButton3");
                    CtlButton.Click +=new EventHandler(CtlButton_Click);
                }
            }
        }

        private void CtlButton_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string ID = GridView2.Rows[gvr.RowIndex].Cells[2].Text.Trim();
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 2, "");
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                BindData2();
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
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
            BindData2();
        }

        protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
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
            BindData3();
        }

        protected void GridView4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string DataIDX = "";

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button9.Visible = true;
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
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    if (e.Row.DataItem != null)
                    {
                        DataIDX = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                        TableCell cell = new TableCell();
                        cell.Width = Unit.Pixel(5);
                        cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                        e.Row.Cells.AddAt(0, cell);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.FindControl("LinkButton6") != null)
                {
                    LinkButton CtlButton = (LinkButton)e.Row.FindControl("LinkButton6");
                    CtlButton.Click += new EventHandler(CtlButton_Click2);
                }
            }
        }

        private void CtlButton_Click2(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string ID = GridView4.Rows[gvr.RowIndex].Cells[2].Text.Trim();
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 2, "");
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                BindData4();
            }
        }

        protected void GridView4_Sorting(object sender, GridViewSortEventArgs e)
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
            BindData4();
        }
        #endregion

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            string tip = "";
            if (e.CommandName == "Pass")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 1, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData1();
                }
                /*
                result = BusinessFacadeDLT.GoodAcceptPast(ID, 1,"");
                tip = "通过";
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作下家" + tip + "优质频道");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData1();
                }
                */
            }
            else if (e.CommandName == "NoPass")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 0, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData1();
                }
                /*
                result = BusinessFacadeDLT.GoodAcceptPast(ID, 0, "");
                tip = "不通过";
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作下家" + tip + "优质频道");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData1();
                }
                */
            }
            else if (e.CommandName == "refresh")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptSettleRefresh", ID);
                BindData1();
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            string tip = "";
            if (e.CommandName == "Del")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 2, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData2();
                }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            string tip = "";
            if (e.CommandName == "Check")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 4, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData3();
                }
                /*
                result = BusinessFacadeDLT.GoodAcceptPast(ID, 4,"");
                tip = "考核";
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作下家" + tip + "优质频道");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData3();
                }
                */
            }
            else if (e.CommandName == "KickOut")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 3, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData3();
                }
                /*
                result = BusinessFacadeDLT.GoodAcceptPast(ID, 3, "");
                tip = "踢出";
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作下家" + tip + "优质频道");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData3();
                }
                */
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            string tip = "";
            if (e.CommandName == "Del")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 2, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData4();
                }
                /*
                result = BusinessFacadeDLT.GoodAcceptPast(ID, 2, "");
                tip = "删除";
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作下家" + tip + "优质频道");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData4();
                }
                */
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData1();//绑定 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData1();//绑定 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();
            string Comment = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tbGoodAccept set Comment = '" + Comment + "' where ID = " + ID);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView1.EditIndex = -1;
            BindData1();//绑定数据
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindData2();//绑定 
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            BindData2();//绑定 
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView2.Rows[e.RowIndex].Cells[2].Text.Trim();
            string Comment = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox1")).Text;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tbGoodAccept set Comment = '" + Comment + "' where ID = " + ID);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView2.EditIndex = -1;
            BindData2();//绑定数据
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            BindData3();//绑定 
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            BindData3();//绑定 
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView3.Rows[e.RowIndex].Cells[1].Text.Trim();

            string Comment = ((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBox1")).Text;

            string EnsureMoney = ((DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddlEnsureMoney")).Text;

            string Tier = ((DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddlTier4")).Text;

            //SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
            //        "update dbo.tbGoodAccept set Comment = '" + Comment + "' where ID = " + ID);

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptUpdate", ID, Tier, EnsureMoney, Comment);
            DataTable dt = ds.Tables[0];
            if (dt.Rows[0]["Result"].ToString() == "1")
            {
                Response.Write("<script language='javascript'>alert('修改成功！');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
            }
            GridView3.EditIndex = -1;
            BindData3();//绑定数据
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            BindData4();//绑定 
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            BindData4();//绑定 
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView4.Rows[e.RowIndex].Cells[2].Text.Trim();  
            string Comment = ((TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox1")).Text;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tbGoodAccept set Comment = '" + Comment + "' where ID = " + ID);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView4.EditIndex = -1;
            BindData4();//绑定数据
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData1();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindData2();
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            BindData3();
        }

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            BindData4();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            BindData5();
        }

        protected void AspNetPager5_PageChanged(object sender, EventArgs e)
        {
            BindData5();
        }

        protected void GridView6_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView6.EditIndex = -1;
            BindData6();//绑定 
        }

        protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            string tip = "";
            if (e.CommandName == "Quit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, 5, "");
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData6();
                }
            }
        }

        protected void GridView6_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void GridView6_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView6.EditIndex = e.NewEditIndex;
            BindData6();//绑定 
        }

        protected void GridView6_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView6.Rows[e.RowIndex].Cells[1].Text.Trim();
            string Comment = ((TextBox)GridView6.Rows[e.RowIndex].FindControl("TextBox1")).Text;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tbGoodAccept set Comment = '" + Comment + "' where ID = " + ID);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView6.EditIndex = -1;
            BindData6();//绑定数据
        }

        protected void GridView6_Sorting(object sender, GridViewSortEventArgs e)
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
            BindData6();
        }

        protected void AspNetPager6_PageChanged(object sender, EventArgs e)
        {
            BindData6();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            BindData6();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button8_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            string IDX = "";
            string Err_Value = "";

            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                IDX = Checkbox_Value_Array[i];
                if (IDX != "")
                {
                    //删除
                    DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, IDX, 2, "");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() != "1")
                        {
                            if (Err_Value != "")
                            {
                                Err_Value += ",";
                            }
                            Err_Value += IDX;
                            Checkbox_Value = Checkbox_Value.Replace(IDX + ",", "");
                            Checkbox_Value = Checkbox_Value.Replace(IDX, "");
                        }
                    }
                }
            }


            if (Err_Value != "")
            {
                Response.Write("<script language='javascript'>alert('" + string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value) + "');</script>");
                BindData2();
                //EventMessage.MessageBox(1, "批量删除结果", string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value), Icon_Type.Alert, Common.GetHomeBaseUrl("default.aspx"));
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + string.Format("批量删除({0})成功!", Checkbox_Value) + "');</script>");
                BindData2();
                //EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button9_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            string IDX = "";
            string Err_Value = "";

            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                IDX = Checkbox_Value_Array[i];
                if (IDX != "")
                {
                    //删除
                    DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, IDX, 2, "");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() != "1")
                        {
                            if (Err_Value != "")
                            {
                                Err_Value += ",";
                            }
                            Err_Value += IDX;
                            Checkbox_Value = Checkbox_Value.Replace(IDX + ",", "");
                            Checkbox_Value = Checkbox_Value.Replace(IDX, "");
                        }
                    }
                }
            }


            if (Err_Value != "")
            {
                Response.Write("<script language='javascript'>alert('" + string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value) + "');</script>");
                BindData4();
                //EventMessage.MessageBox(1, "批量删除结果", string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value), Icon_Type.Alert, Common.GetHomeBaseUrl("default.aspx"));
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + string.Format("批量删除({0})成功!", Checkbox_Value) + "');</script>");
                BindData4();
                //EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
            }
        }
        
    }
}
