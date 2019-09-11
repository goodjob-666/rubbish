using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using System.Data;
using System.Data.SqlClient;

namespace FrameWork.web.Manager.Module.DLT.Service.tbActivity
{
    public partial class ActivityOrder : System.Web.UI.Page
    {
        string ActivityID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["ActivityID"] != null)
                {
                    BindGameList();
                    ActivityID = Request.QueryString["ActivityID"].ToString();
                    BindDataList(ActivityID);
                    DisDeleteBtn(ActivityID);
                    
                }
            }
        }


        /// <summary>
        /// 绑定订单状态
        /// </summary>
        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            //qp.Where = " Where [Key]=1013";
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGame.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }

        private void BindDataList(string activityID)
        {
            QueryParam qp = new QueryParam();

            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;

            int RecordCount = 0;

            DataSet ds = null;

            if (ddlGame.SelectedValue != "-1")
            {
                activityID += " and left(a.ZoneServerID,3)=" + ddlGame.SelectedValue+" ";
            }
            

            ds = BusinessFacadeDLT.ActivityOrderSelect(qp.PageIndex, qp.PageSize, activityID);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView1.Visible = true;
            AspNetPager1.Visible = true;
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;

        }

        private void DisDeleteBtn(string activityID)
        {
            tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(int.Parse(activityID));
            if (ut.SendDate.HasValue)
            {
                Button3.Visible = false;
            }
            else
            {
                Button3.Visible = true;
            }
        }

        public string AcceptUserID(string acceptuserid)
        {
            if (acceptuserid != "0")
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

        public string SaveTwoPointer(string price)
        {
            return Math.Round(decimal.Parse(price), 2).ToString();
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
        public string Status(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1013 and Kind=" + type;

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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList(Request.QueryString["ActivityID"].ToString());
        }

        public string AccountRela(string SerialNo)
        {
            DataSet ds = BusinessFacadeDLT.AccountRela(SerialNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return "<span style='color:red'>是</span>";
            }
            else
            {
                return "否";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {
                Label lblOrderStartDate = e.Row.FindControl("lblOrderStartDate") as Label;
                Label lblOrderIsPub = e.Row.FindControl("lblOrderIsPub") as Label;
                HiddenField hfDate = e.Row.FindControl("hfDate") as HiddenField;
                HiddenField hfChannel = e.Row.FindControl("hfChannel") as HiddenField;

                HiddenField hfAcceptUserID = e.Row.FindControl("hfAcceptUserID") as HiddenField;

                HiddenField hfUserID = e.Row.FindControl("hfUserID") as HiddenField;

                HiddenField hfActivityID = e.Row.FindControl("hfActivityID") as HiddenField;

                Label lblOrderSum = e.Row.FindControl("lblOrderSum") as Label;

                Label lblSerialNo = e.Row.FindControl("lblSerialNo") as Label;


                if (BusinessFacadeDLT.ActivityOrderRela(int.Parse(hfUserID.Value), hfActivityID.Value).Tables[0].Rows.Count > 0)
                {
                    lblSerialNo.Text = "<span style='color:red'>" + lblSerialNo.Text + "</span>";
                }


                if (hfDate.Value == "0")
                {
                    lblOrderStartDate.Text = "<span style='color:red'>" + lblOrderStartDate.Text + "</span>";
                }

                switch (hfChannel.Value)
                {
                    case "10":
                        if (lblOrderIsPub.Text != "内部")
                        {
                            lblOrderIsPub.Text = "<span style='color:red'>" + lblOrderIsPub.Text + "</span>";
                        }
                        break;
                    case "11":
                        if (lblOrderIsPub.Text != "公共")
                        {
                            lblOrderIsPub.Text = "<span style='color:red'>" + lblOrderIsPub.Text + "</span>";
                        }
                        break;
                }

                string OrderSum = BusinessFacadeDLT.GetLevelOrderActivityList(1, 1000000, " and a.ActivityID=" + hfActivityID.Value + " and AcceptUserID=" + hfAcceptUserID.Value).Tables[0].Rows.Count.ToString();


                lblOrderSum.Text = OrderSum == "1" ? "" : "<span style='color:red'>（" + OrderSum + "）</span>";

                //lblOrderSum.Text = OrderSum == "1" ? "" : "<script type='text/javascript'>function()</script> <a href=\"../../service/tbLevelOrder/default.aspx?SerialNo=" + lblSerialNo.Text + "\" target=\"_blank\">(" + OrderSum + ")</a>";
            }
        }

        #region "排序"
 

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
            string DataIDX = "";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button3.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));

                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    if (e.Row.DataItem != null)
                    {
                        DataIDX = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                        TableCell cell = new TableCell();
                        cell.Width = Unit.Pixel(5);
                        cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                        e.Row.Cells.AddAt(0, cell);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button3_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            string IDX = "";

            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                IDX = Checkbox_Value_Array[i];
                if (IDX != "")
                {
                    DataSet ds = BusinessFacadeDLT.OrderActivityDelete(IDX);
                }
            }

            Response.Write("<script language='javascript'>alert('订单删除成功！');window.parent.ld(1);</script>");

            BindDataList(Request.QueryString["ActivityID"].ToString());

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindDataList(Request.QueryString["ActivityID"].ToString());
        }

        protected void ddlGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataList(Request.QueryString["ActivityID"].ToString());
        }

    }
}
