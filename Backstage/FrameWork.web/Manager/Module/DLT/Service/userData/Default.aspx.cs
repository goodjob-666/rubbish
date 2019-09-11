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

namespace DLT.Web.Module.DLT.userData
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGameList();
                TextBox2.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                TextBox3.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                txtLSStart.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                txtLSEnd.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
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
                ddlGLGameID.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
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

        public string GameName(string gameID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]=" + gameID ;

            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "0";
            }
            else
            {
                return lst[0].Game.ToString();
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


        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList6();
            TabOptionWebControls1.SelectIndex = 0;
        }

        public bool IsValidate(string str)
        {
            string validate = @"^\d+";
            return Regex.IsMatch(str, validate);
        }


        private void BindDataList6()
        {

            if (txtGLNumStart.Text != "" && txtGLNumEnd.Text != " ")
            {

                if (IsValidate(txtGLNumStart.Text) && IsValidate(txtGLNumEnd.Text))
                {

                    QueryParam qp = new QueryParam();
                    qp.PageIndex = AspNetPager2.CurrentPageIndex;
                    qp.PageSize = AspNetPager2.PageSize;
                    int RecordCount = 0;
                    DataSet ds = null;
                    ds = BusinessFacadeDLT.UserGLCount(ddlGLGameID.SelectedValue, txtGLNumStart.Text, txtGLNumEnd.Text, DateTime.Parse(TextBox2.Text), DateTime.Parse(TextBox3.Text), qp.PageIndex, qp.PageSize, ddlOrderType.SelectedValue);

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
            TabOptionWebControls1.SelectIndex = 0;
        }

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {

                Label lblZHJ = e.Row.FindControl("lblZHJ") as Label;
                Label lblZHD = e.Row.FindControl("lblZHD") as Label;

                Label lblYXJDS = e.Row.FindControl("lblYXJDS") as Label;

                //lblYXJDS.Text = BusinessFacadeDLT.YXAcceptOrder(lblYXJDS.Text, DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString();

                //lblYXJDS.Text = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["MSSql"], "BM_YXAcceptOrder1", lblYXJDS.Text, ddlGLGameID.SelectedValue, DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).ToString();

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

        protected void btnGL_Click(object sender, EventArgs e)
        {
            AspNetPager2.CurrentPageIndex = 1;
            BindDataList6();
            TabOptionWebControls1.SelectIndex = 0;
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
            sheet.SetColumnWidth(10, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("游戏");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("绑定手机");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("QQ");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("接单数");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("有效接单数");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("接单金额");
            rowtitle.CreateCell(7, CellType.STRING).SetCellValue("收入金额");
            rowtitle.CreateCell(8, CellType.STRING).SetCellValue("未接单时间");
            rowtitle.CreateCell(9, CellType.STRING).SetCellValue("未活跃时间");
            rowtitle.CreateCell(10, CellType.STRING).SetCellValue("备注");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(ddlGLGameID.SelectedItem.Text.ToString());
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["UID"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["BindMobile"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["QQ"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(Convert.ToString(row["ZJD"]));
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["ZYXJD"]));
                //newrow.CreateCell(5, CellType.STRING).SetCellValue(SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["MSSql"], "BM_YXAcceptOrder1", Convert.ToString(row["UserID"]), ddlGLGameID.SelectedValue, DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).ToString());
                newrow.CreateCell(6, CellType.STRING).SetCellValue(Convert.ToString(row["ZJE"]));
                newrow.CreateCell(7, CellType.STRING).SetCellValue(BusinessFacadeDLT.SRPriceAcceptOrder(Convert.ToString(row["UserID"]), DateTime.Parse(TextBox2.Text + " 00:00:00"), DateTime.Parse(TextBox3.Text + " 23:59:59")).Tables[0].Rows[0][0].ToString());
                newrow.CreateCell(8, CellType.STRING).SetCellValue(Convert.ToString(row["ZHJ"]));
                newrow.CreateCell(9, CellType.STRING).SetCellValue(Convert.ToString(row["ZHD"]));
                newrow.CreateCell(10, CellType.STRING).SetCellValue(Convert.ToString(row["Comment"]));
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

        protected void btnLSSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = BusinessFacadeDLT.GetDateList(DateTime.Parse(txtLSStart.Text), DateTime.Parse(txtLSEnd.Text));
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {
                Label lblStatDate = e.Row.FindControl("lblStatDate") as Label;//日期
                Label lblHYYH = e.Row.FindControl("lblHYYH") as Label;//活跃用户
                Label lblXZYH = e.Row.FindControl("lblXZYH") as Label;//新增用户
                Label lblBHYYH = e.Row.FindControl("lblBHYYH") as Label;//半活跃用户
                Label lblLSYH = e.Row.FindControl("lblLSYH") as Label;//流失用户
                Label lblLSL = e.Row.FindControl("lblLSL") as Label;//流失率

                lblHYYH.Text = BusinessFacadeDLT.ActivitytUser(Convert.ToDateTime(lblStatDate.Text)).Tables[0].Rows[0][0].ToString();
                lblXZYH.Text = BusinessFacadeDLT.NewAcceptUser(Convert.ToDateTime(lblStatDate.Text)).Tables[0].Rows[0][0].ToString();
                lblBHYYH.Text = BusinessFacadeDLT.HalfActivitytUser(Convert.ToDateTime(lblStatDate.Text)).Tables[0].Rows[0][0].ToString();
                lblLSYH.Text = BusinessFacadeDLT.LoseUser(Convert.ToDateTime(lblStatDate.Text)).Tables[0].Rows[0][0].ToString();

                decimal percent = Convert.ToDecimal(BusinessFacadeDLT.PercentActivitytUser(Convert.ToDateTime(lblStatDate.Text)).Tables[0].Rows[0][0].ToString());
                decimal lose= Convert.ToDecimal(lblLSYH.Text);

                lblLSL.Text = (Convert.ToDecimal((lose / percent).ToString("0.0000")) * 100).ToString("F2") + "%";


            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XZ")
            {
                string statDate = e.CommandArgument.ToString();
                DataSet ds = null;
                ds = BusinessFacadeDLT.NewAcceptUserStat(Convert.ToDateTime(statDate));

                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    Random rd = new Random();
                    int rd1 = rd.Next(111111, 999999);
                    string path = this.Server.MapPath("~\\Public\\Execl\\") + DateTime.Now.ToString("yyyyMMddhhmmss") + rd1.ToString() + ".xls";
                    if (!Directory.Exists(this.Server.MapPath("~\\Public\\Execl\\")))
                    {
                        Directory.CreateDirectory(this.Server.MapPath("~\\Public\\Execl\\"));
                    }
                    bool status = ExportXZUserDataExcel(ds, path);
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
            else if (e.CommandName == "BHY")
            {
                string statDate = e.CommandArgument.ToString();
                DataSet ds = null;
                ds = BusinessFacadeDLT.HalfActivitytUserStat(Convert.ToDateTime(statDate));

                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    Random rd = new Random();
                    int rd1 = rd.Next(111111, 999999);
                    string path = this.Server.MapPath("~\\Public\\Execl\\") + DateTime.Now.ToString("yyyyMMddhhmmss") + rd1.ToString() + ".xls";
                    if (!Directory.Exists(this.Server.MapPath("~\\Public\\Execl\\")))
                    {
                        Directory.CreateDirectory(this.Server.MapPath("~\\Public\\Execl\\"));
                    }
                    bool status = ExportUserDataExcel(ds, path);
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
                string statDate = e.CommandArgument.ToString();
                DataSet ds = null;
                ds = BusinessFacadeDLT.LoseUserStat(Convert.ToDateTime(statDate));

                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    Random rd = new Random();
                    int rd1 = rd.Next(111111, 999999);
                    string path = this.Server.MapPath("~\\Public\\Execl\\") + DateTime.Now.ToString("yyyyMMddhhmmss") + rd1.ToString() + ".xls";
                    if (!Directory.Exists(this.Server.MapPath("~\\Public\\Execl\\")))
                    {
                        Directory.CreateDirectory(this.Server.MapPath("~\\Public\\Execl\\"));
                    }
                    bool status = ExportUserDataExcel(ds, path);
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
        }


        private bool ExportUserDataExcel(DataSet ds, string path)
        {
            //创建标题行
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("用户分析报表");
            IRow rowtitle = sheet.CreateRow(0);

            //设置列宽
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("绑定手机");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                if (i == 65535)
                {
                    break;
                }
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["UID"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["BindMobile"]));
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


        private bool ExportXZUserDataExcel(DataSet ds, string path)
        {
            //创建标题行
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("用户分析报表");
            IRow rowtitle = sheet.CreateRow(0);

            //设置列宽
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 30 * 256);
            sheet.SetColumnWidth(2, 30 * 256);
            sheet.SetColumnWidth(3, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("绑定手机");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("QQ");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("游戏");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                if (i == 65535)
                {
                    break;
                }
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["UID"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["BindMobile"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["QQ"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(GameName(Convert.ToString(row["ZoneServerID"]).Substring(0, 3)));
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

    }
}
