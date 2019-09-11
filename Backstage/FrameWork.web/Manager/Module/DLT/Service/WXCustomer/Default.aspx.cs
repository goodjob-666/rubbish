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

namespace DLT.Web.Module.DLT.WXCustomer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGameList();
            }
        }

        public string GetCustTypeName(string a)
        {
            string rt = "";
            switch (a)
            {
                case "0": rt = "所有客户"; break;
                case "1": rt = "新客户"; break;
                case "2": rt = "老客户"; break;
            }
            return rt;
        }

        public string GetIsCloseName(string a)
        {
            string rt = "";
            switch (a)
            {
                case "0": rt = ""; break;
                case "1": rt = "停用"; break;
                case "2": rt = "停用"; break;
            }
            return rt;
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

        private void BindData1()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_WXMailList",
                ddlGLGameID.SelectedValue, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BindData1();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData1();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData1();//绑定 
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData1();//绑定 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();
            string IsClose = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlIsClose")).SelectedValue;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tsWXCustomer set IsClose = '" + IsClose + "' where ID = " + ID);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView1.EditIndex = -1;
            BindData1();//绑定数据
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DC")
            {
                string ID = e.CommandArgument.ToString();
                DataSet ds = null;
                ds = ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_WXCustomerExport", ID);

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
            ISheet sheet = workbook.CreateSheet("微信客服绑定");
            IRow rowtitle = sheet.CreateRow(0);

            //设置列宽
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 30 * 256);
            sheet.SetColumnWidth(2, 30 * 256);
            sheet.SetColumnWidth(3, 30 * 256);
            sheet.SetColumnWidth(4, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("手机");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("QQ");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("绑定手机");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("微信绑定时间");

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
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["Mobile"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["QQ"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["BindMobile"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(Convert.ToString(row["BindDate"]));
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
