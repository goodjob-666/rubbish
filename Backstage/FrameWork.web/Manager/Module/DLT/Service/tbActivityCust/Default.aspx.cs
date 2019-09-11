/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            tbActivity列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2016/8/22 16:48:55
     History:
*********************************************************************************/
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

namespace DLT.Web.Module.DLT.tbActivityCust
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList1()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms1;
            qp.PageIndex = AspNetPager2.CurrentPageIndex;
            qp.PageSize = AspNetPager2.PageSize;
            int RecordCount = 0;

            DataSet ds = BusinessFacadeDLT.ActivityAllOrderSelect(qp.PageIndex, qp.PageSize, qp.Where);

            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {
                Label lblOrderStartDate = e.Row.FindControl("lblOrderStartDate") as Label;
                Label lblOrderIsPub = e.Row.FindControl("lblOrderIsPub") as Label;
                HiddenField hfDate = e.Row.FindControl("hfDate") as HiddenField;
                HiddenField hfChannel = e.Row.FindControl("hfChannel") as HiddenField;

                HiddenField hfAcceptUserID = e.Row.FindControl("hfAcceptUserID") as HiddenField;

                HiddenField hfActivityID = e.Row.FindControl("hfActivityID") as HiddenField;

                HiddenField hfFlag = e.Row.FindControl("hfFlag") as HiddenField;

                Label lblOrderSum = e.Row.FindControl("lblOrderSum") as Label;

                Label lblSendDate1 = e.Row.FindControl("lblSendDate1") as Label;

                if (hfFlag.Value == "0")
                {
                    lblSendDate1.Text = "已删除";
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
                    case "12":
                        if (lblOrderIsPub.Text != "优质")
                        {
                            lblOrderIsPub.Text = "<span style='color:red'>" + lblOrderIsPub.Text + "</span>";
                        }
                        break;
                }

                string OrderSum = BusinessFacadeDLT.GetLevelOrderActivityList(1, 1000000, " and a.ActivityID=" + hfActivityID.Value + " and AcceptUserID=" + hfAcceptUserID.Value).Tables[0].Rows.Count.ToString();

                lblOrderSum.Text = OrderSum == "1" ? "" : "（" + OrderSum + "）";
            }
        }


        private string BindGameList(string GameID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]=" + GameID;
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            return lst[0].Game;
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

       

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    tbActivityEntity et = new tbActivityEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    
                    //先判断订单是否为已发送红包订单
                    tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(IDX);
                    if (ut.SendDate.HasValue)
                    {
                        Response.Write("<script language='javascript'>alert('此活动为已完成活动，无法执行删除操作！');</script>");
                        return;
                    }
                    else
                    {
                        BusinessFacadeDLT.tbActivityInsertUpdateDelete(et);

                        //删除属于这个活动的订单

                        BusinessFacadeDLT.DeleteActivityOrder(IDX);
                    }
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {
                Label lblUserType = e.Row.FindControl("lblUserType") as Label;

                Label lblGameID = e.Row.FindControl("lblGameID") as Label;

                if (lblGameID.Text.ToString().IndexOf(',') > 0)
                {
                    string s = "";
                    string[] arrGame = lblGameID.Text.Split(',');
                    for (int i = 0; i < arrGame.Length; i++)
                    {
                        s += BindGameList(arrGame[i].ToString()) + "、";
                    }
                    lblGameID.Text = s.TrimEnd('、');
                }
                else
                {
                    lblGameID.Text = BindGameList(lblGameID.Text);
                }

                Label lblChannel = e.Row.FindControl("lblChannel") as Label;
                Label lblOrderCount = e.Row.FindControl("lblOrderCount") as Label;

                Label lblPrice = e.Row.FindControl("lblPrice") as Label;
                Label lblPirce2 = e.Row.FindControl("lblPirce2") as Label;
                Label lblPrice3 = e.Row.FindControl("lblPrice3") as Label;

                HiddenField hfID = e.Row.FindControl("hfID") as HiddenField;




                if (lblUserType.Text == "10")
                {
                    lblUserType.Text = "下家";
                }
                else
                {
                    lblUserType.Text = "上家";
                }

                

                if (lblChannel.Text == "10")
                {
                    lblChannel.Text = "内部";
                    lblPrice.Text = lblPrice.Text;
                    lblPirce2.Visible = false;
                    lblPrice3.Visible = false;
                }
                else if (lblChannel.Text == "11")
                {
                    lblChannel.Text = "公共";
                    lblPirce2.Text = lblPirce2.Text;
                    lblPrice.Visible = false;
                    lblPrice3.Visible = false;
                }
                else if (lblChannel.Text == "13")
                {
                    lblChannel.Text = "优质";
                    lblPrice3.Text = lblPrice3.Text;
                    lblPrice.Visible = false;
                    lblPirce2.Visible = false;
                }
                else if (lblChannel.Text == "12")
                {
                    lblChannel.Text = "内部、公共";
                    lblPrice.Text = lblPrice.Text + "（内），";
                    lblPirce2.Text = lblPirce2.Text + "（公）";
                }
                else if (lblChannel.Text == "14")
                {
                    lblChannel.Text = "内部、优质";
                    lblPrice.Text = lblPrice.Text + "（内），";
                    lblPrice3.Text = lblPrice3.Text + "（优）";
                }
                else if (lblChannel.Text == "15")
                {
                    lblChannel.Text = "公共、优质";
                    lblPirce2.Text = lblPirce2.Text + "（公），";
                    lblPrice3.Text = lblPrice3.Text + "（优）";
                }
                else if (lblChannel.Text == "16")
                {
                    lblChannel.Text = "内部、公共、优质";
                    lblPrice.Text = lblPrice.Text + "（内），";
                    lblPirce2.Text = lblPirce2.Text + "（公），";
                    lblPrice3.Text = lblPrice3.Text + "（优）";
                }

                lblOrderCount.Text = BusinessFacadeDLT.GetLevelOrderActivityList(1, 1000000, " and a.ActivityID=" + hfID.Value).Tables[1].Rows[0][0].ToString();


            }
        }

       

        public string GetID(string UID)
        {
            if (UID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [UID]='" + UID + "'";
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                if (lst.Count > 0)
                {
                    return lst[0].ID.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (gtxtSerialNo.Text != string.Empty)
            {
                sb.AppendFormat(" AND a.SerialNo='{0}' ", Common.inSQL(gtxtSerialNo.Text));
            }

            if (gtxtActivityID.Text != string.Empty)
            {
                sb.AppendFormat(" AND z.ID='{0}' ", Common.inSQL(gtxtActivityID.Text));
            }

            if (gtxtUserID.Text != string.Empty)
            {

                if (GetID(gtxtUserID.Text.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.UserID = {0} ", Common.inSQL(GetID(gtxtUserID.Text.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('发布者ID输入错误！');</script>");
                    return;
                }
                
            }

            if (gtxtAcceptUserID.Text != string.Empty)
            {
                if (GetID(gtxtAcceptUserID.Text.Trim()) != "")
                {
                    sb.AppendFormat(" AND a.AcceptUserID = {0} ", Common.inSQL(GetID(gtxtAcceptUserID.Text.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('用户编码输入错误！');</script>");
                    return;
                }
                
            }

            ViewState["SearchTerms1"] = sb.ToString();
            BindDataList1();
            TabOptionWebControls1.SelectIndex = 3;
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList1();
        }

    }
}
