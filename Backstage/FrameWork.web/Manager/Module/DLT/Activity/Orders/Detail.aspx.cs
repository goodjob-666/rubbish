using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
using System.Data.SqlClient;

namespace DLT.Web.Module.DLT.Activity.Orders
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataList();
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

                    ViewState["sortOrderfld"] = "CreateDate";

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
            string SeriaNo = Request.QueryString["SeriaNo"].ToString();

            string Amounts = Request.QueryString["Amounts"].ToString();

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "HT_OrderListDetail", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, " where ODSeriaNo='" + SeriaNo + "'", Orderfld, OrderType);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            int RecordCount = int.Parse(ds.Tables[1].Rows[0][1].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

            string str = ds.Tables[2].Rows[0][0].ToString();
            if (str != null && str != "")
            {
                double money = Convert.ToDouble(str);
                Label1.Text = "共" + Amounts + "元，已抢走" + money + "元";
            }
            else
            {
                Label1.Text = "共" + Amounts + "元，已抢走0元";
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
            BindDataList();
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
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
    }
}
