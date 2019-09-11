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

namespace DLT.Web.Module.DLT.btRecharge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindDataList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TabOptionWebControls1.SelectIndex = 1;
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
            DataSet ds = BusinessFacadeDLT.GetRecharge(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
            lblTotalRecharge.Text = "当前查询条件下总充值金额：" + ds.Tables[2].Rows[0][0].ToString()+"元";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string vcSerialNo_Value = (string)Common.sink(vcSerialNo_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string vcUserID_Value = (string)Common.sink(vcUserID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string nmBal_Input_Value = (string)Common.sink(nmBal_Input.UniqueID, MethodType.Post, 10, 0, DataType.Double).ToString();
            string vcExChargeNo_Value = (string)Common.sink(vcExChargeNo_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string vcNickName_Value = (string)Common.sink(vcNickName_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
          
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();

            if (vcSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND SerialNo ='{0}' ", Common.inSQL(vcSerialNo_Value));
            }

            if (nmBal_Input_Value != string.Empty && nmBal_Input_Value!="0")
            {
                sb.AppendFormat(" AND Bal like '%{0}%' ", Common.inSQL(nmBal_Input_Value));
            }

            if (vcUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UserID = {0} ", Common.inSQL(vcUserID_Value));
            }

            if (vcNickName_Value != string.Empty)
            {
                sb.AppendFormat(" AND NickName = '{0}' ", Common.Base64Encode(Common.inSQL(vcNickName_Value.Trim().Replace("'", "''"))));
            }

            if (vcExChargeNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND ExChargeNo = '{0}' ", Common.inSQL(vcExChargeNo_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and a.CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and a.CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and a.CreateDate between '{0} 00:00:00.000' and '{1} 23:59:59.999' ", S_dtDate_Input.Text, E_dtDate_Input.Text));
            }
            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
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
            ISheet sheet = workbook.CreateSheet("充值报表");
            IRow rowtitle = sheet.CreateRow(0);


            //设置列宽
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 30 * 256);
            sheet.SetColumnWidth(2, 30 * 256);
            sheet.SetColumnWidth(3, 30 * 256);
            sheet.SetColumnWidth(4, 30 * 256);
            sheet.SetColumnWidth(5, 30 * 256);
            sheet.SetColumnWidth(6, 30 * 256);

            //创建列
            rowtitle.CreateCell(0, CellType.STRING).SetCellValue("流水号");
            rowtitle.CreateCell(1, CellType.STRING).SetCellValue("用户ID");
            rowtitle.CreateCell(2, CellType.STRING).SetCellValue("昵称");
            rowtitle.CreateCell(3, CellType.STRING).SetCellValue("时间");
            rowtitle.CreateCell(4, CellType.STRING).SetCellValue("充值金额");
            rowtitle.CreateCell(5, CellType.STRING).SetCellValue("来源流水号");
            rowtitle.CreateCell(6, CellType.STRING).SetCellValue("备注");

            DataTable dt = ds.Tables[0];
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                IRow newrow = sheet.CreateRow(i);
                newrow.CreateCell(0, CellType.STRING).SetCellValue(Convert.ToString(row["SerialNo"]));
                newrow.CreateCell(1, CellType.STRING).SetCellValue(Convert.ToString(row["UserID"]));
                newrow.CreateCell(2, CellType.STRING).SetCellValue(Common.Base64Decode(row["NickName"].ToString()));
                newrow.CreateCell(3, CellType.STRING).SetCellValue(Convert.ToString(row["CreateDate"]));
                newrow.CreateCell(4, CellType.STRING).SetCellValue(SaveTwoPointer(row["Bal"].ToString()));
                newrow.CreateCell(5, CellType.STRING).SetCellValue(Convert.ToString(row["ExChargeNo"]));
                newrow.CreateCell(6, CellType.STRING).SetCellValue(Convert.ToString(row["Comment"]));
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


        protected void Button3_Click(object sender, EventArgs e)
        {
            string vcSerialNo_Value = (string)Common.sink(vcSerialNo_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string vcUserID_Value = (string)Common.sink(vcUserID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string nmBal_Input_Value = (string)Common.sink(nmBal_Input.UniqueID, MethodType.Post, 4, 0, DataType.Double).ToString();
            string vcExChargeNo_Value = (string)Common.sink(vcExChargeNo_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string vcNickName_Value = (string)Common.sink(vcNickName_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);

            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();

            if (vcSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND SerialNo like '%{0}%' ", Common.inSQL(vcSerialNo_Value));
            }

           

            if (nmBal_Input_Value != string.Empty && nmBal_Input_Value != "0")
            {
                sb.AppendFormat(" AND Bal like '%{0}%' ", Common.inSQL(nmBal_Input_Value));
            }

            if (vcUserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UserID = {0} ", Common.inSQL(vcUserID_Value));
            }

            if (vcNickName_Value != string.Empty)
            {
                sb.AppendFormat(" AND NickName = '{0}' ", Common.Base64Encode(Common.inSQL(vcNickName_Value.Trim().Replace("'", "''"))));
            }

            if (vcExChargeNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND ExChargeNo like '%{0}%' ", Common.inSQL(vcExChargeNo_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and a.CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and a.CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and a.CreateDate between '{0} 00:00:00.000' and '{1} 23:59:59.999' ", S_dtDate_Input.Text, E_dtDate_Input.Text));
            }

            QueryParam qp = new QueryParam();
            qp.Where = sb.ToString();
            qp.PageIndex = 1;
            qp.PageSize = 60000;
            DataSet ds = BusinessFacadeDLT.GetRecharge(qp.PageIndex, qp.PageSize, qp.Where);
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
