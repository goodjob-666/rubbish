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
using System.IO;

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

using System.Text.RegularExpressions;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

namespace DLT.Web.Module.DLT.PubSelect
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGameList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                S_dtDate_Input1.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input1.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                S_dtDate_Input2.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input2.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtNewAcceptStart.Text = (DateTime.Now.AddMonths(-1)).Date.ToString("yyyy-MM-dd");
                txtNewAcceptEnd.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TextBox2.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                TextBox3.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                //上家发单趋势统计  给开始时间和结束时间加上默认时间 by zhangwenxue
                txtStartDate.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGame.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
                ddlGLGameID.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList1()
        {
            //DataSet ds = BusinessFacadeDLT.OrderFreq(1, DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text));
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_OrderFreq", 1,
                DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), "", "", "");
            GridView1.DataSource = ds;
            GridView1.DataBind();
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
            DataTable dt = BusinessFacadeDLT.FTRightLock(UserID(id)).Tables[0];
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

        public string UserID(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UID]='" + id + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "0";
            }
            else
            {
                return lst[0].ID.ToString();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList2()
        {
            string Sort_Str = "";
            string PubCount_Str = "";
            if (Orderfld != "")
            {
                Sort_Str = Orderfld + "_" + (OrderType == 1 ? "asc" : "desc");
            }
            if (ddlPubCount1.Text != "")
            {
                if (tbPubCount2.Text != "")
                {
                    if (ddlPubCount1.Text == "==")
                    {
                        if (tbPubCount2.Text.IndexOf("-") > -1)
                        {
                            string[] astr = tbPubCount2.Text.Split('-');
                            PubCount_Str = "between " + astr[0] + " and " + astr[1];
                        }
                    }
                    else
                    {
                        PubCount_Str = ddlPubCount1.Text + " " + tbPubCount2.Text;
                    }
                }
            }
            //DataSet ds = BusinessFacadeDLT.OrderFreq(2, DateTime.Parse(S_dtDate_Input1.Text), DateTime.Parse(E_dtDate_Input1.Text));
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_OrderFreq", 2,
                DateTime.Parse(S_dtDate_Input1.Text), DateTime.Parse(E_dtDate_Input1.Text), PubCount_Str, tbUserID.Text, Sort_Str);
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList3()
        {
            string PubCount_Str = "";

            if (ddlPubCount2.Text != "")
            {
                if (tbPubCount3.Text != "")
                {
                    if (ddlPubCount2.Text == "==")
                    {
                        if (tbPubCount3.Text.IndexOf("-") > -1)
                        {
                            string[] astr = tbPubCount3.Text.Split('-');
                            PubCount_Str = "between " + astr[0] + " and " + astr[1];
                        }
                    }
                    else
                    {
                        PubCount_Str = ddlPubCount2.Text + " " + tbPubCount3.Text;
                    }
                }
            }
            //DataSet ds = BusinessFacadeDLT.OrderFreq(3, DateTime.Parse(S_dtDate_Input2.Text), DateTime.Parse(E_dtDate_Input2.Text));

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_OrderFreq", 3,
                DateTime.Parse(S_dtDate_Input2.Text), DateTime.Parse(E_dtDate_Input2.Text), PubCount_Str, "", "");
            GridView3.DataSource = ds;
            GridView3.DataBind();
        }


        private void GetTopPostUser()
        {
            // DataSet ds = BusinessFacadeDLT.GetTopPostUser(ddlGame.SelectedValue);
            //增加日期范围查询  by zhangwenxue 2016-12-23
            if (txtStartDate.Text == "")
            {
                txtStartDate.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
            }
            if (txtEndDate.Text == "")
            {
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetTopPostUser", int.Parse(ddlGame.SelectedValue),
              DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));
            GridView4.DataSource = ds;
            GridView4.DataBind();
        }

        private void GetUserPostByWeek()
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList1();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ViewState["sortOrderfld"] = "";
            BindDataList2();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BindDataList3();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateUserComment")
            {
                string uid = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                DataSet ds = BusinessFacadeDLT.UpdateUserComment(txtComment.Text, uid);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID："+Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
            else if (e.CommandName == "UpdateUserRoleComment")
            {
                string code = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                HiddenField actor = (HiddenField)row.FindControl("hfActor");
                DataSet ds = BusinessFacadeDLT.UpdateRoleComment(txtComment.Text,actor.Value, code);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "角色备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
        }


        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateUserComment")
            {
                string uid = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                DataSet ds = BusinessFacadeDLT.UpdateUserComment(txtComment.Text, uid);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
            else if (e.CommandName == "UpdateUserRoleComment")
            {
                string code = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                HiddenField actor = (HiddenField)row.FindControl("hfActor");
                DataSet ds = BusinessFacadeDLT.UpdateRoleComment(txtComment.Text, actor.Value, code);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "角色备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
        }

        protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateGLUserComment")
            {
                string uid = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtGLComment");
                DataSet ds = BusinessFacadeDLT.UpdateUserComment(txtComment.Text, uid);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
        }


        protected void GridView4_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblWeek = (Label)e.Row.FindControl("lblWeek");
                HiddenField hf = (HiddenField)e.Row.FindControl("hf");
                //DataSet ds = BusinessFacadeDLT.GetTopPostUser();
                ////10000-4
                //ArrayList arr = new ArrayList();
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    arr.Add(ds.Tables[0].Rows[i][0].ToString()/* + "-" + ds.Tables[0].Rows[i][1].ToString()*/);
                //}
                //DataSet dsByWeek = BusinessFacadeDLT.GetUserPostByWeek(int.Parse(hf.Value.ToString()));
                //增加日期范围查询  by zhangwenxue 2016-12-23
                int userId=int.Parse(hf.Value.ToString());
                DataSet dsByWeek = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetUserPostByWeek", userId,
                  DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(ddlGame.SelectedValue));
                string str = "";
                int num = dsByWeek.Tables[0].Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    if (i < 7)
                    {
                        str += dsByWeek.Tables[0].Rows[i][0].ToString() + "：" + dsByWeek.Tables[0].Rows[i][1].ToString() + "<br />";
                    }
                }

                lblWeek.Text = str;
                if (num > 7)
                {
                    lblWeek.Text = str + "<a href=\"javascript:showPopWin('近15天内符合条件的订单','More.aspx?ID="+userId+"',1080, 550, null,false)\">更多</a>";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GetTopPostUser();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindDataList5();
            TabOptionWebControls1.SelectIndex = 4;
        }

        protected void btnGL_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindDataList6();
            TabOptionWebControls1.SelectIndex = 5;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList5();
            TabOptionWebControls1.SelectIndex = 4;
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList6();
            TabOptionWebControls1.SelectIndex = 5;
        }

        public bool IsValidate(string str)
        {
            string validate = @"^\d+";
            return Regex.IsMatch(str, validate);
        }

        private void BindDataList5()
        {

            if (txtNewAccept.Text != "")
            {

                if (IsValidate(txtNewAccept.Text))
                {

                    QueryParam qp = new QueryParam();
                    qp.PageIndex = AspNetPager1.CurrentPageIndex;
                    qp.PageSize = AspNetPager1.PageSize;
                    int RecordCount = 0;
                    DataSet ds = null;
                    ds = BusinessFacadeDLT.NewAcceptJRCount(int.Parse(txtNewAccept.Text), DateTime.Parse(txtNewAcceptStart.Text), DateTime.Parse(txtNewAcceptEnd.Text), qp.PageIndex, qp.PageSize);

                    GridView5.DataSource = ds.Tables[0];
                    GridView5.DataBind();
                    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    this.AspNetPager1.RecordCount = RecordCount;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('新手下家总发单数必须为正整数！');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请输入新手下家总发单数！');</script>");
                return;
            }
        }

        private void BindDataList6()
        {

            if (txtGLNumStart.Text != "" && txtGLNumEnd.Text!= " ")
            {

                if (IsValidate(txtGLNumStart.Text) && IsValidate(txtGLNumEnd.Text))
                {

                    QueryParam qp = new QueryParam();
                    qp.PageIndex = AspNetPager2.CurrentPageIndex;
                    qp.PageSize = AspNetPager2.PageSize;
                    int RecordCount = 0;
                    DataSet ds = null;
                    ds = BusinessFacadeDLT.UserGLCount(ddlGLGameID.SelectedValue, txtGLNumStart.Text, txtGLNumEnd.Text, DateTime.Parse(TextBox2.Text), DateTime.Parse(TextBox3.Text), qp.PageIndex, qp.PageSize,ddlOrderType.SelectedValue);

                    GridView6.DataSource = ds.Tables[0];
                    GridView6.DataBind();
                    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    this.AspNetPager2.RecordCount = RecordCount;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('下家接单数必须为正整数！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('下家接单数范围不能为空！');</script>");
                return;
            }
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataList6();
            TabOptionWebControls1.SelectIndex = 5;
        }

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow|| e.Row.RowType== DataControlRowType.Separator)
            {

                Label lblZHJ = e.Row.FindControl("lblZHJ") as Label;
                Label lblZHD = e.Row.FindControl("lblZHD") as Label;

                Label lblYXJDS = e.Row.FindControl("lblYXJDS") as Label;

                lblYXJDS.Text = BusinessFacadeDLT.YXAcceptOrder(lblYXJDS.Text, DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString();

                Label lblSRPrice = e.Row.FindControl("lblSRPrice") as Label;

                lblSRPrice.Text = BusinessFacadeDLT.SRPriceAcceptOrder(lblSRPrice.Text, DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString();

                DateTime dtZHJ = Convert.ToDateTime(lblZHJ.Text);
                DateTime dtZHD = Convert.ToDateTime(lblZHD.Text);
                DateTime endTime = DateTime.Now;
                TimeSpan tsZHJ = endTime - dtZHJ;
                TimeSpan tsZHD = endTime - dtZHD;
                lblZHJ.Text = Math.Floor(tsZHJ.TotalHours).ToString();
                lblZHD.Text = Math.Floor(tsZHD.TotalHours).ToString();


            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            if (txtGLNumStart.Text != "" && txtGLNumEnd.Text != " ")
            {

                if (IsValidate(txtGLNumStart.Text) && IsValidate(txtGLNumEnd.Text))
                {

                    QueryParam qp = new QueryParam();
                    qp.PageIndex = AspNetPager1.CurrentPageIndex;
                    qp.PageSize = AspNetPager1.PageSize;
                    DataSet ds = null;
                    ds = BusinessFacadeDLT.UserGLCount(ddlGLGameID.SelectedValue, txtGLNumStart.Text, txtGLNumEnd.Text, DateTime.Parse(TextBox2.Text), DateTime.Parse(TextBox3.Text), 1, 1000000, ddlOrderType.SelectedValue);

                    if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        Random rd = new Random();
                        int rd1 = rd.Next(111111, 999999);
                        string path = this.Server.MapPath("~\\Public\\Execl\\") + DateTime.Now.ToString("yyyyMMddhhmmss") + rd1.ToString() + ".xls";
                        if (!Directory.Exists(this.Server.MapPath("~\\Public\\Execl\\")))
                        {
                            Directory.CreateDirectory(this.Server.MapPath("~\\Public\\Execl\\"));
                        }
                        bool status = ExportExcel(ds, path);
                        string Redirectpath = "~\\Public\\Execl\\" + path.Substring(path.LastIndexOf("\\") + 1);
                        if (status)
                        {
                            Response.Redirect(Redirectpath);
                            File.Delete(path);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('生成Excel失败！')", true);
                        }
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('下家接单数必须为正整数！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('下家接单数范围不能为空！');</script>");
                return;
            }

        }


        private bool ExportExcel(DataSet ds, string path)
        {
            //创建标题行
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("用户归类报表");
            IRow rowtitle = sheet.CreateRow(0);

            //设置列宽
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 30 * 256);
            sheet.SetColumnWidth(2, 30 * 256);
            sheet.SetColumnWidth(3, 30 * 256);
            sheet.SetColumnWidth(4, 30 * 256);
            sheet.SetColumnWidth(5, 30 * 256);
            sheet.SetColumnWidth(6, 30 * 256);
            sheet.SetColumnWidth(7, 30 * 256);
            sheet.SetColumnWidth(8, 30 * 256);
            sheet.SetColumnWidth(9, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("游戏");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("绑定手机");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("接单数");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("有效接单数");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("接单金额");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("收入金额");
            rowtitle.CreateCell(7, CellType.STRING).SetCellValue("未接单时间");
            rowtitle.CreateCell(8, CellType.STRING).SetCellValue("未登录时间");
            rowtitle.CreateCell(9, CellType.STRING).SetCellValue("备注");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(ddlGLGameID.SelectedItem.Text.ToString());
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["UID"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["BindMobile"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["ZJD"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(BusinessFacadeDLT.YXAcceptOrder(Convert.ToString(row["UserID"]), DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString());
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["ZJE"]));
                newrow.CreateCell(6, CellType.STRING).SetCellValue(BusinessFacadeDLT.SRPriceAcceptOrder(Convert.ToString(row["UserID"]), DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString());
                newrow.CreateCell(7, CellType.STRING).SetCellValue(Convert.ToString(row["ZHJ"]));
                newrow.CreateCell(8, CellType.STRING).SetCellValue(Convert.ToString(row["ZHD"]));
                newrow.CreateCell(9, CellType.STRING).SetCellValue(Convert.ToString(row["Comment"]));
                i++;
            }
            try
            {
                using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    workbook.Write(stream);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

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

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
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
            BindDataList2();
        }

    }
}
