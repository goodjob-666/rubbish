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
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tsUser
{
    public partial class RelaUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RequestSQL();
            }
        }

        public string IsGoodUser(string ID)
        {

            string result = "普通用户";

            DataTable dt = BusinessFacadeDLT.IsGoodPost(ID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = "优质用户";
            }

            DataTable dt1 = BusinessFacadeDLT.IsGoodAccept(ID).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                result = "优质用户";
            }

            return result;
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
            DataTable dt = BusinessFacadeDLT.FTRightLock(id).Tables[0];
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

        private void BindDataList0(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 0, qp.PageIndex, qp.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        private void BindDataList1(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager2.CurrentPageIndex;
            qp.PageSize = AspNetPager2.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 1, qp.PageIndex, qp.PageSize);
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;
        }

        private void BindDataList2(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager3.CurrentPageIndex;
            qp.PageSize = AspNetPager3.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 2, qp.PageIndex, qp.PageSize);
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager3.RecordCount = RecordCount;
        }

        private void BindDataList3(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager4.CurrentPageIndex;
            qp.PageSize = AspNetPager4.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 3, qp.PageIndex, qp.PageSize);
            GridView4.DataSource = ds.Tables[0];
            GridView4.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager4.RecordCount = RecordCount;
        }

        private void BindDataList4(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager5.CurrentPageIndex;
            qp.PageSize = AspNetPager5.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 4, qp.PageIndex, qp.PageSize);
            GridView5.DataSource = ds.Tables[0];
            GridView5.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager5.RecordCount = RecordCount;
        }

        private void BindDataList5(string ID)
        {
            QueryParam qp = new QueryParam();
            //qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager6.CurrentPageIndex;
            qp.PageSize = AspNetPager6.PageSize;
            int RecordCount = 0;
            //DataSet ds = BusinessFacadeDLT.UserListByMAC(ID, qp.PageIndex, qp.PageSize);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_UserListByMAC", ID, 5, qp.PageIndex, qp.PageSize);
            GridView6.DataSource = ds.Tables[0];
            GridView6.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager6.RecordCount = RecordCount;
        }

        private void RequestSQL()
        {
            if (Request["IDLIST"] != null)
            {
                hidID.Value = Request["IDLIST"].ToString();

                object obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["MSSql"], CommandType.Text, "select UID from tsUser where ID = " + hidID.Value);
                if (obj != null)
                {
                    hidUID.Value = obj.ToString();
                }
                BindDataList0(hidID.Value);
                BindDataList1(hidID.Value);
                BindDataList2(hidID.Value);
                BindDataList3(hidID.Value);
                BindDataList4(hidID.Value);
                BindDataList5(hidID.Value);
            }
            else
            {
                Response.Write("<script language='javascript'>alert('用户ID获取出错，请重新执行操作！');</script>");
                return;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList0(hidID.Value);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList1(hidID.Value);
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            BindDataList2(hidID.Value);
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            BindDataList3(hidID.Value);
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void AspNetPager5_PageChanged(object sender, EventArgs e)
        {
            BindDataList4(hidID.Value);
        }



        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hidUID.Value != "")
                {
                    Label lblUID = e.Row.FindControl("lblUID") as Label;
                    if (lblUID.Text == hidUID.Value)
                    {
                        lblUID.Text = "<font style=\"color:red\">" + lblUID.Text + "</font>";
                    }
                }
            }
        }

        protected void AspNetPager6_PageChanged(object sender, EventArgs e)
        {
            BindDataList5(hidID.Value);
        }

    }
}
