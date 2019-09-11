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
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DaiLianTong.Web.Module.DaiLianTong.tbUserOrder
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-1)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDataList();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            DataSet ds = null;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int pageSize = AspNetPager1.PageSize;
            ds = BusinessFacadeDLT.UserOrderList(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), txtServiceLoginID.Text, pageIndex,pageSize);
            int RecordCount = 0;
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtServiceLoginID.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入客服登录ID！');</script>");
                return;
            }
            else
            {
                BindDataList();
            }
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

                    ViewState["sortOrderfld"] = "vcSerialNo";

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
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //string DataIDX = "";
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            //    {
            //        Button3.Visible = true;
            //        //增加check列头全选
            //        TableCell cell = new TableCell();
            //        cell.Width = Unit.Pixel(5);
            //        cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
            //        e.Row.Cells.AddAt(0, cell);
            //    }

            //    foreach (TableCell var in e.Row.Cells)
            //    {
            //        if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
            //        {
            //            string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
            //            if (Colume == Orderfld)
            //            {

            //                LinkButton l = (LinkButton)var.Controls[0];
            //                l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
            //                //Image Img = new Image();
            //                //SortDirection a = GridView1.SortDirection;
            //                //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
            //                //var.Controls.Add(Img);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            //    {
            //        //增加行选项
            //        if (e.Row.DataItem != null)
            //        {
            //            DataIDX = DataBinder.Eval(e.Row.DataItem, "SerialNo").ToString();
            //            TableCell cell = new TableCell();
            //            cell.Width = Unit.Pixel(5);
            //            cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
            //            e.Row.Cells.AddAt(0, cell);
            //        }
            //    }
            //}
        }
        #endregion


        public string GetOpLoginID(string customerid)
        {
            if (customerid != "0" && customerid != "")
            {
                return UserData.Get_sys_UserTable(int.Parse(customerid)).U_LoginName;
            }
            else
            {
                return "";
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tmpstr = DataBinder.Eval(e.Row.DataItem, "UID").ToString();

                if (tmpstr == "USR201305030006")
                {
                    e.Row.ForeColor = Color.MediumVioletRed;
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tmpstr = DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString();

                if (tmpstr != "0")
                {
                    e.Row.ForeColor = Color.MediumVioletRed;
                }
            }
        }

        public string CancelStatus(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1014 and Kind=" + type;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
        }

        public string GetOPLoginID(string firstCustomerID)
        {
            if (firstCustomerID != "")
            {
                if (firstCustomerID != "0")
                {
                    return UserData.Get_sys_UserTable(int.Parse(firstCustomerID)).U_LoginName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return firstCustomerID;
            }

        }

        public string Status(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1013 and Kind=" + type;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        public string AcceptUserID(string acceptuserid)
        {
            if (acceptuserid != "0" && acceptuserid != "")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [ID]=" + acceptuserid;
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].Nickname;
            }
            else
            {
                return "";
            }
        }

    }
}
