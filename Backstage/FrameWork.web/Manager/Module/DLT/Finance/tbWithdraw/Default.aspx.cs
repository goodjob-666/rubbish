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
using DLT.Components;
using FrameWork;
using FrameWork.Components;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.Data.SqlClient;
using DLT.Data;

namespace DLT.Web.Module.DLT.tbWithdraw
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

                BindStatus();
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

        public string Status(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1015 and Kind=" + status;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
        }

        public void BindStatus()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1015 ";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                ddlStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public string IsLock(string uid)
        {

            DataSet ds = BusinessFacadeDLT.IsLockWithDraw(uid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return "禁止提现";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            SearchSQL();
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            int order = 0;
            if (ddlStatus.SelectedValue == "11")
            {
                order = 1;
            }

            int isGood = 10;

            if (cbGood.Checked)
            {
                isGood = 11;
            }
            else
            {
                isGood = 10;
            }

            DataSet ds = BusinessFacadeDLT.WithdrawDeposit(qp.PageIndex, qp.PageSize, qp.Where, int.Parse(ddlStatus.SelectedValue), order, isGood);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
            string SPayOut = ds.Tables[2].Rows[0][0].ToString();
            string SFee = ds.Tables[2].Rows[0][1].ToString();
            lbStatistics.InnerText = "当前查询条件下总实际提现金额：" + SPayOut + "元；总提现手续费：" + SFee + "元；";
        }

        public string SaveTwoPointer(string price)
        {
            return Math.Round(decimal.Parse(price), 2).ToString();
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
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchSQL();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        private void SearchSQL()
        {
            string vcSerialNo_Value = (string)Common.sink(SerialNo_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string vcUserID_Value = (string)Common.sink(UID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string vcNickName_Value = (string)Common.sink(NickName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string vcBankSerialNo_Value = (string)Common.sink(BankSerialNo_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string vcBankAcc_Input_Value = (string)Common.sink(BankAcc_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string vcBankAddr_Input_Value = (string)Common.sink(BankAddr_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string vcddlStatus_Input_Value = (string)Common.sink(ddlStatus.UniqueID, MethodType.Post, 50, 0, DataType.Str);
           
            //DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(S_dtDate_Input.UniqueID, MethodType.Get, 255, 0, DataType.Dat);
            //DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(E_dtDate_Input.UniqueID, MethodType.Get, 255, 0, DataType.Dat);
            DateTime? SRemit_dtDate_Input_Value = (DateTime?)Common.sink(SRemit_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? ERemit_dtDate_Input_Value = (DateTime?)Common.sink(ERemit_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();

            if (vcSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.SerialNo = '{0}' ", Common.inSQL(vcSerialNo_Value));
            }

            if (vcUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UserID = '{0}' ", Common.inSQL(vcUserID_Value));
            }

            if (vcNickName_Value != string.Empty)
            {
                sb.AppendFormat(" AND NickName = '{0}' ", Common.Base64Encode(Common.inSQL(vcNickName_Value.Trim().Replace("'", "''"))));
            }

            if (vcBankSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.BankSerialNo = '{0}' ", Common.inSQL(vcBankSerialNo_Value.Replace("'", "''")));
            }

            if (vcBankAcc_Input_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.BankAcc like '%{0}%' ", Common.inSQL(vcBankAcc_Input_Value));
            }

            if (vcBankAddr_Input_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.BankAddr like '%{0}%' ", Common.inSQL(vcBankAddr_Input_Value));
            }

            if (vcddlStatus_Input_Value != string.Empty)
            {
                if (vcddlStatus_Input_Value != "99" && vcddlStatus_Input_Value != "10" && vcddlStatus_Input_Value != "0")
                {
                    sb.AppendFormat(" AND a.Status = {0} ", Common.inSQL(vcddlStatus_Input_Value));
                }
            }

            if (vcSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(string.Format(" and a.ApplyDate between '2012-01-01 00:00:00.000' and '2020 23:59:59.999' ", DateTime.Parse(S_dtDate_Input.Text).ToString("yyyy-MM-dd"), DateTime.Parse(E_dtDate_Input.Text).ToString("yyyy-MM-dd")));
            }
            else
            {
                if (S_dtDate_Input.Text != "" && E_dtDate_Input.Text != "")
                {
                    sb.AppendFormat(string.Format(" and a.ApplyDate between '{0} 00:00:00.000' and '{1} 23:59:59.999' ", DateTime.Parse(S_dtDate_Input.Text).ToString("yyyy-MM-dd"), DateTime.Parse(E_dtDate_Input.Text).ToString("yyyy-MM-dd")));
                }
            }


            if (SRemit_dtDate_Input_Value.HasValue && ERemit_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and a.RemitDate between '{0} 00:00:00.000' and '{1} 23:59:59.999' ", SRemit_dtDate_Input_Value.Value.Date.ToString("yyyy-MM-dd"), ERemit_dtDate_Input_Value.Value.Date.ToString("yyyy-MM-dd")));
            }

            ViewState["SearchTerms"] = sb.ToString();
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
           

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("提现流水");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("用户编号");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("昵称");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("实际提现金额");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("手续费");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("提现日期");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("外部流水号");//银行流水
            rowtitle.CreateCell(7, CellType.STRING).SetCellValue("打款日期");//打款日期
            rowtitle.CreateCell(8, CellType.STRING).SetCellValue("状态");
            rowtitle.CreateCell(9, CellType.STRING).SetCellValue("备注");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["SerialNo"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["UserID"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Common.Base64Decode(row["NickName"].ToString()));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(SaveTwoPointer(row["Bal"].ToString()));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(SaveTwoPointer(row["Fee"].ToString()));
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["ApplyDate"]));

                newrow.CreateCell(6, CellType.STRING).SetCellValue(Convert.ToString(row["BankSerialNo"]));
                newrow.CreateCell(7, CellType.STRING).SetCellValue(Convert.ToString(row["RemitDate"]));
               
                switch (row["Status"].ToString())
                {
                    case "10":
                        newrow.CreateCell(8, CellType.STRING).SetCellValue("提现处理中");
                        break;
                    case "11":
                        newrow.CreateCell(8, CellType.STRING).SetCellValue("提现完成");
                        break;
                    case "12":
                        newrow.CreateCell(8, CellType.STRING).SetCellValue("提现撤消");
                        break;
                }
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
        /// 导出
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            SearchSQL();
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            int order = 0;
            if (ddlStatus.SelectedValue == "11")
            {
                order = 1;
            }

            int isGood = 10;

            if (cbGood.Checked)
            {
                isGood = 11;
            }
            else
            {
                isGood = 10;
            }

            DataSet ds = BusinessFacadeDLT.WithdrawDeposit(qp.PageIndex, qp.PageSize, qp.Where, int.Parse(ddlStatus.SelectedValue), order, isGood);


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


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == GridView1.EditIndex)
                {
                    DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    ddlStatus.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                }
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindDataList();//绑定 
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindDataList();//绑定 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string SerialNo = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();

            DropDownList ddlStatus = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlStatus");

            int status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (status == 14)         //撤销退回余额
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "HT_ReturnWithdraw", SerialNo, DateTime.Now);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    int state = Convert.ToInt32(dt.Rows[0]["State"]);
                    if (state == 1)
                    {
                        Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
                        GridView1.EditIndex = -1;
                        BindDataList();//绑定数据
                    }
                    else
                    {
                        string err = dt.Rows[0]["Err"].ToString();
                        Response.Write("<script language:javascript>javascript:window:alert('" + err + "');</script>");
                    }
                }
            }
            else
            {
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Status",ddlStatus.SelectedValue),
                    new SqlParameter("@SerialNo",SerialNo)
                };
                SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MsSql"], CommandType.Text,
                        "update dbo.tbWithdraw set Status=@Status where SerialNo = @SerialNo", pms);

                Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
                GridView1.EditIndex = -1;
                BindDataList();//绑定数据
            }
        }
    }
}
