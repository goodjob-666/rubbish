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

namespace DLT.Web.Module.DLT.WithDrawDetail
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

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = "";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        public string BankType(string banktype)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1003 and Kind=" + banktype;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        public string Status(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1015 and Kind=" + status;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

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

            int isGood = 10;

            if (cbGood.Checked)
            {
                isGood = 11;
            }
            else
            {
                isGood = 10;
            }

            DataSet ds = BusinessFacadeDLT.WithdrawDeposit(qp.PageIndex, qp.PageSize, qp.Where,0,1,isGood);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
            string SPayOut = ds.Tables[2].Rows[0][0].ToString();
            string SFee = ds.Tables[2].Rows[0][1].ToString();
            string SRealPay=ds.Tables[2].Rows[0][2].ToString();
            if (ddlType.SelectedValue == "12")
            {
                lbStatistics.InnerText = "当前查询条件下总提现金额：" + SPayOut + "元；总提现手续费：" + SFee + "元；";
            }
            else
            {
                lbStatistics.InnerText = "当前查询条件下总提现金额：" + SPayOut + "元；总提现手续费：" + SFee + "元；总实际打款金额：" + SRealPay + "元；";
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

        private void SearchSQL()
        {
            StringBuilder sb = new StringBuilder();

            if (txtUserID.Text != string.Empty)
            {
                //UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName
                if (UserData.Get_sys_UserTable1(txtUserID.Text) != null)
                {
                    int id = UserData.Get_sys_UserTable1(txtUserID.Text).UserID;
                    if (id != 0)
                    {
                        sb.AppendFormat(" AND a.customerID = {0} ", Common.inSQL(id.ToString()));
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('财务人员ID输入错误！');</script>");
                    return;
                }

            }

            if (ddlType.SelectedValue == "11")
            {
                sb.AppendFormat(" AND a.Status=11");
            }
            else if (ddlType.SelectedValue == "12")
            {
                sb.AppendFormat(" AND a.Status=12");
            }

            sb.AppendFormat(" AND a.RemitDate between '{0} 00:00:00.000' and '{1} 23:59:59.999' ", S_dtDate_Input.Text, E_dtDate_Input.Text);


            ViewState["SearchTerms"] = sb.ToString();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {


            SearchSQL();
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
            ISheet sheet = workbook.CreateSheet("提现报表");
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
            sheet.SetColumnWidth(9, 30 * 256);
            sheet.SetColumnWidth(9, 30 * 256);


            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("提现流水");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("客户编号");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("客户名称");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("提现金额");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("打款金额");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("手续费");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("银行");
            rowtitle.CreateCell(7, CellType.STRING).SetCellValue("户名");
            rowtitle.CreateCell(8, CellType.STRING).SetCellValue("账号");
            rowtitle.CreateCell(9, CellType.STRING).SetCellValue("提现日期");
            rowtitle.CreateCell(10, CellType.STRING).SetCellValue("状态");
            rowtitle.CreateCell(11, CellType.STRING).SetCellValue("银行流水");//银行流水
            rowtitle.CreateCell(12, CellType.STRING).SetCellValue("打款日期");//打款日期
            rowtitle.CreateCell(13, CellType.STRING).SetCellValue("财务人员");//打款日期

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["SerialNo"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["UID"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Convert.ToString(row["NickName"]));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["Bal"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(Convert.ToString(float.Parse(row["Bal"].ToString()) - float.Parse(row["Fee"].ToString())));
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["Fee"]));
                switch (row["BankID"].ToString())
                {
                    case "10":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("支付宝");
                        break;
                    case "11":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("财付通");
                        break;
                    case "12":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("中国工商银行");
                        break;
                    case "13":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("中国农业银行");
                        break;
                    case "14":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("中国建设银行");
                        break;
                    case "15":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("中国交通银行");
                        break;
                    case "16":
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("中国邮政储蓄");
                        break;
                    default:
                        newrow.CreateCell(6, CellType.STRING).SetCellValue("其它银行");
                        break;
                }
                newrow.CreateCell(7, CellType.STRING).SetCellValue(Convert.ToString(row["BankUser"]));
                newrow.CreateCell(8, CellType.STRING).SetCellValue(Convert.ToString(row["BankAcc"]));
                newrow.CreateCell(9, CellType.STRING).SetCellValue(Convert.ToString(row["ApplyDate"]));
                switch (row["Status"].ToString())
                {
                    case "10":
                        newrow.CreateCell(10, CellType.STRING).SetCellValue("提现处理中");
                        break;
                    case "11":
                        newrow.CreateCell(10, CellType.STRING).SetCellValue("提现完成");
                        break;
                    case "12":
                        newrow.CreateCell(10, CellType.STRING).SetCellValue("提现撤消");
                        break;
                }
                newrow.CreateCell(11, CellType.STRING).SetCellValue(Convert.ToString(row["BankSerialNo"]));
                newrow.CreateCell(12, CellType.STRING).SetCellValue(Convert.ToString(row["RemitDate"]));
                newrow.CreateCell(13, CellType.STRING).SetCellValue(txtUserID.Text);
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
            SearchSQL();
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;

            int isGood = 10;

            if (cbGood.Checked)
            {
                isGood = 11;
            }
            else
            {
                isGood = 10;
            }

            DataSet ds = BusinessFacadeDLT.WithdrawDeposit(qp.PageIndex, qp.PageSize, qp.Where, 0, 1,isGood);
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
