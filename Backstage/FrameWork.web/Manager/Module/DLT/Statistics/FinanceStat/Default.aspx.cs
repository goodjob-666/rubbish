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
using System.Drawing;
using dotnetCHARTING;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.Finance
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input_1.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input1.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDataList();
                BindDataList1();
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
        
        private void BindDataList()
        {
            DataSet ds = BusinessFacadeDLT.FinanceTotal();
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

        private void BindDataList1()
        {
            DataSet ds = BusinessFacadeDLT.FinanceStatWDRC(DateTime.Parse(S_dtDate_Input_1.Text + " 00:00:00"), DateTime.Parse(E_dtDate_Input1.Text + " 23:59:59"));
            DataTable dt = ds.Tables[0];
            int RCCount = 0;
            double RCPrice = 0;
            int WDActualCount = 0;
            double WDActualPrice = 0;

            int WDApplyCount = 0;
            double WDApplyPrice = 0;
            double WDFee = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["RCCount"] != null && row["RCCount"].ToString() != "")
                {
                    RCCount = RCCount + Convert.ToInt32(row["RCCount"]);
                }
                if (row["RCPrice"] != null && row["RCPrice"].ToString() != "")
                {
                    RCPrice = RCPrice + Convert.ToDouble(row["RCPrice"]);
                }
                if (row["WDActualCount"] != null && row["WDActualCount"].ToString() != "")
                {
                    WDActualCount = WDActualCount + Convert.ToInt32(row["WDActualCount"]);
                }
                if (row["WDActualPrice"] != null && row["WDActualPrice"].ToString() != "")
                {
                    WDActualPrice = WDActualPrice + Convert.ToDouble(row["WDActualPrice"]);
                }
                if (row["WDApplyCount"] != null && row["WDApplyCount"].ToString() != "")
                {
                    WDApplyCount = WDApplyCount + Convert.ToInt32(row["WDApplyCount"]);
                }
                if (row["WDApplyPrice"] != null && row["WDApplyPrice"].ToString() != "")
                {
                    WDApplyPrice = WDApplyPrice + Convert.ToDouble(row["WDApplyPrice"]);
                }
                if (row["WDFee"] != null && row["WDFee"].ToString() != "")
                {
                    WDFee = WDFee + Convert.ToDouble(row["WDFee"]);
                }
            }

            DataRow row1 = dt.NewRow();
            row1["WDStatDate"] = "合计";
            row1["RCCount"] = RCCount;
            row1["RCPrice"] = RCPrice;
            row1["WDActualCount"] = WDActualCount;
            row1["WDActualPrice"] = WDActualPrice;
            row1["WDApplyCount"] = WDApplyCount;
            row1["WDApplyPrice"] = WDApplyPrice;
            row1["WDFee"] = WDFee;
            dt.Rows.Add(row1);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public string StatDate(string statdate)
        {
            if (statdate == "1900-01-01")
            {
                return "合计";
            }
            else
            {
                return statdate;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindDataList1();
        }
    }
}
