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
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.IO;

namespace DLT.Web.Module.DLT.BankTransferDetail
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDataList();
            }

        }

        private void BindDataList()
        {
                int RecordCount = 0;
                QueryParam qp = new QueryParam();
                qp.PageIndex = AspNetPager1.CurrentPageIndex;
                qp.PageSize = AspNetPager1.PageSize;
                DataSet ds = BusinessFacadeDLT.BankTransferDetailList(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text),ddlType.SelectedValue,txtTypeKeywords.Text,ddlResult.SelectedValue,qp.PageIndex,qp.PageSize);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                string SPayOut = ds.Tables[2].Rows[0][0].ToString();
                lbStatistics.InnerText = "当前查询条件下总汇款金额：" + SPayOut + "元";
                this.AspNetPager1.RecordCount = RecordCount;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        /// <summary>
        /// 生成Excel的方法
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="path">Excel存在服务器的相对地址</param>
        /// <returns></returns>
        private bool ExportExcel(DataSet ds, string path)
        {
            //创建标题行
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("网银汇款报表");
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


            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("银行名称");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("银行姓名");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("银行帐号");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("汇款金额");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("银行流水号");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("处理日期");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("结果");
            rowtitle.CreateCell(7, CellType.STRING).SetCellValue("关联流水号");
            rowtitle.CreateCell(8, CellType.STRING).SetCellValue("打款银行帐号");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["BankName"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["BankUser"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["BankAcc"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["PayBal"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(Convert.ToString(row["BankSerialNo"]));
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["ProcessDate"]));
                newrow.CreateCell(6, CellType.STRING).SetCellValue(Convert.ToString(row["Result"]));
                newrow.CreateCell(7, CellType.STRING).SetCellValue(Convert.ToString(row["RelaSerialNo"]));
                newrow.CreateCell(8, CellType.STRING).SetCellValue(Convert.ToString(row["RemitBankAcc"]));
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


        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = BusinessFacadeDLT.BankTransferDetailList(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text),ddlType.SelectedValue,txtTypeKeywords.Text,ddlResult.SelectedValue,1,99999);
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

    }
}
