using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using System.Data;
using System.Text;
using System.Configuration;

namespace DLT.Web.Module.DLT.Activity.Finance
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TabOptionWebControls1.SelectIndex = 1;
                BindActivity();

                DateTime curTime = DateTime.Now;
                int month = curTime.Month;
                int year = curTime.Year;
                S_dtDate_Input.Text = year + "-" + month + "-" + "01" + " 00:00:00";
                E_dtDate_Input.Text = curTime.Date.ToString("yyyy-MM-dd") + " 23:59:59";
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
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            DataSet ds = BusinessFacadeDLT.UserReport(qp,SearchTerms1);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);

            
            lblBaoMing.Text = ds.Tables[2].Rows[0][0].ToString();
            lblJieSuan.Text = ds.Tables[2].Rows[0][1].ToString();
            lblTotalMoney.Text = ds.Tables[2].Rows[0][2].ToString();
            lblRoleNameCount.Text = ds.Tables[2].Rows[0][3].ToString();
            lblTotalNum.Text = ds.Tables[2].Rows[0][4].ToString();
            lblTotalWinNum.Text = ds.Tables[2].Rows[0][5].ToString();

            try
            {
                lblLv.Text = (Convert.ToDouble(lblTotalWinNum.Text) / Convert.ToDouble(lblTotalNum.Text)).ToString("F2");
                lblProfit.Text = (Convert.ToDouble(lblJieSuan.Text) / Convert.ToDouble(lblBaoMing.Text)).ToString("F2");
            }
            catch (Exception)
            {
                
                
            }
            
            Panel1.Visible = true;
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
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 查询条件1
        /// </summary>
        private string SearchTerms1
        {
            get
            {
                if (ViewState["SearchTerms1"] == null)
                    ViewState["SearchTerms1"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms1"];
            }
            set { ViewState["SearchTerms1"] = value; }
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

        /// <summary>
        /// 绑定活动
        /// </summary>
        private void BindActivity()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            qp.Orderfld = "Sort";
            int RecordCount = 0;
            qp.Where = " Where 1=1";
            List<tsActivityEntity> lst = BusinessFacadeDLT.tsActivityList(qp, out RecordCount);
            foreach (tsActivityEntity var in lst)
            {
                ddlActivity.Items.Add(new ListItem(var.Name, var.ID.ToString()));
            }
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UID_Value = (string)Common.sink(UID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string ActivityID = (string)Common.sink(ddlActivity.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string S_Date = (string)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);   //开始时间
            string E_Date = (string)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);   //结束时间

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            if (UID_Value != string.Empty)
            {
                sb.AppendFormat(" and UserID= (select ID from dbo.act_User where uid ='{0}') ", Common.inSQL(UID_Value));
                sb1.AppendFormat(" and UserID= (select ID from dbo.act_User where uid ='{0}') ", Common.inSQL(UID_Value));
            }

            if (ActivityID != string.Empty)
            {
                sb.AppendFormat(" and RelaSerialNo in (select SeriaNo from dbo.act_Order where ActivityID={0}) ", ActivityID);
                sb1.AppendFormat(" and ActivityID={0}", ActivityID);
            }
           

            if (S_Date != string.Empty)
            {
                sb.AppendFormat(" AND ChangeDate >= '{0}' ", S_Date);
                sb1.AppendFormat(" AND StartDate >= '{0}' ", S_Date);
            }

            if (E_Date != string.Empty)
            {
                sb.AppendFormat(" AND ChangeDate <= '{0}' ", E_Date);
                sb1.AppendFormat(" AND StartDate <= '{0}' ", E_Date);
            }

            ViewState["SearchTerms"] = sb.ToString();
            ViewState["SearchTerms1"] = sb1.ToString();

            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }
     

        #region "排序"
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

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "TotalBal";

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
        #endregion

      

    }
}