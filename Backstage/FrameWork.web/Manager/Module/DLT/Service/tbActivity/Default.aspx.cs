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

namespace DLT.Web.Module.DLT.tbActivity
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnSendPrice.Attributes.Add("onclick", "return confirm('【提醒】充值会产生用户金额变动！确定往此活动中所有符合条件的订单用户进行充值吗？')");
                S_dtDate_Input.Text = (DateTime.Now.AddMonths(-3)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindGame();
                BindDataList();

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
            int RecordCount = 0;
            List<tbActivityEntity> lst = BusinessFacadeDLT.tbActivityList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

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

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
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



        private void BindGame()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            //qp.Where = " Where [Key]=1013";
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGameID.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
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
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Title_Value = (string)Common.sink(Title_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string UserType_Value = ddlUserType.SelectedValue;
            string GameID_Value = ddlGameID.SelectedValue;


            string Channel_Value = ddlChannel.SelectedValue;

            string Status_Value = (string)Common.sink(Status_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 2048, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (Title_Value != string.Empty)
            {
                sb.AppendFormat(" AND Title like '%{0}%' ", Common.inSQL(Title_Value));
            }

            if (UserType_Value != "-1")
            {
                sb.AppendFormat(" AND UserType = {0} ", Convert.ToInt32(UserType_Value));
            }

            if (GameID_Value != "-1")
            {
                sb.AppendFormat(" AND GameID = {0} ", Convert.ToInt32(GameID_Value));
            }



            if (Channel_Value != "-1")
            {
                sb.AppendFormat(" AND Channel = {0} ", Convert.ToInt32(Channel_Value));
            }



            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (S_dtDate_Input.Text!="" && E_dtDate_Input.Text!="")
            {
                sb.AppendFormat(string.Format(" and StartDate > '{0} 00:00:00' and EndDate < '{1} 23:59:59' ", S_dtDate_Input.Text, E_dtDate_Input.Text));
            }


            ViewState["SearchTerms"] = sb.ToString();
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

                    ViewState["sortOrderfld"] = "ID";

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
            Int32 DataIDX = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button2.Visible = true;
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
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (hfID.Value != "")
            {
                tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(int.Parse(hfID.Value));
                string Comment = txtComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                ut.Comment = Comment;
                ut.DataTable_Action_ = DataTable_Action.Update;
                BusinessFacadeDLT.tbActivityInsertUpdateDelete(ut);
                lblUpdateComment.Text = "已修改";
                Response.Write("<script language='javascript'>alert('修改成功！');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一个具体活动！');</script>");
                return;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActivityDetail")
            {
                string ID = e.CommandArgument.ToString();
                if (ID == "")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int index = row.RowIndex;
                    ID = GridView1.Rows[index].Cells[2].Text;
                }
                if (ID == "")
                {
                    Response.Write("<script language='javascript'>alert('一次只能查看一个订单详情，请不要勾选多个查看！');</script>");
                    return;
                }
                else
                {
                    TabOptionWebControls1.SelectIndex = 2;
                    ViewActivity(ID);
                    //BindDataList();
                }
            }
        }

        private void ViewActivity(string ID)
        {
            tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(int.Parse(ID));
            hfID.Value = ut.ID.ToString();
            lblTitle.Text = ut.Title;

            lblGameID.Text = ut.GameID.ToString();

            batchA.Attributes.Add("href", "javascript:showPopWin('提现处理','BatchAddOrder.aspx?ID=" + ID + "',700, 850, AlertMessageBox,false)");

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
                lblGameID.Text = BindGameList(ut.GameID.ToString());
            }           

            lblUserType.Text = ut.UserType.ToString() == "10" ? "下家" : "上家";
            switch(ut.Channel.ToString())
            {
                case "10":
                    lblChannel.Text = "内部频道";
                    lblPrice.Text = hfP1.Value = ut.Price.ToString();   
                    break;
                case "11":
                    lblChannel.Text = "公共频道";
                    lblPrice.Text = hfP2.Value = ut.Pirce2.ToString();
                    break;
                case "13":
                    lblChannel.Text = "优质频道";
                    lblPrice.Text = hfP3.Value = ut.Price3.ToString();
                    break;
                case "14":
                    lblChannel.Text = "内部频道、优质频道";
                    lblPrice.Text = "内部：" + ut.Price.ToString() + "，优质：" + ut.Price3.ToString();
                    hfP1.Value = ut.Price.ToString();
                    hfP3.Value = ut.Price3.ToString();
                    break;
                case "15":
                    lblChannel.Text = "公共频道、优质频道";
                    lblPrice.Text = "公共：" + ut.Pirce2.ToString() + "，优质：" + ut.Price3.ToString();
                    hfP2.Value = ut.Pirce2.ToString();
                    hfP3.Value = ut.Price3.ToString();
                    break;
                case "16":
                    lblChannel.Text = "内部频道、公共频道、优质频道";
                    lblPrice.Text = "内部：" + ut.Price.ToString() + "，公共：" + ut.Pirce2.ToString() + "，优质：" + ut.Price3.ToString();
                    hfP1.Value = ut.Price.ToString();
                    hfP2.Value = ut.Pirce2.ToString();
                    hfP3.Value = ut.Price3.ToString();
                    break;
                default:
                    lblChannel.Text = "内部频道、公共频道";
                    lblPrice.Text = "内部："+ut.Price.ToString()+"，公共："+ut.Pirce2.ToString();
                    hfP1.Value = ut.Price.ToString();
                    hfP2.Value = ut.Pirce2.ToString();
                    break;
            }
            
            lblStartDate.Text = ut.StartDate.ToString();
            lblCreateDate.Text = ut.CreateDate.ToString();
            lblEndDate.Text = ut.EndDate.ToString();
            lblSendDate.Text = ut.SendDate.ToString();
            txtComment.Text = ut.Comment;

            lblCount.Text = BusinessFacadeDLT.GetLevelOrderActivityList(1, 1000000, " and a.ActivityID=" + hfID.Value).Tables[1].Rows[0][0].ToString();


            if (ut.SendDate.HasValue)
            {
                divInput.Visible = false;
            }
            else
            {
                divInput.Visible = true;
            }

            BindIframe();
            BindIframe1();

        }

        public void BindIframe()
        {
            this.framelist.Attributes.Add("src ", "ActivityOrder.aspx?ActivityID=" + hfID.Value.ToString());
            this.framelist.Attributes.Add("width ", "100%");
            this.framelist.Attributes.Add("onload ", "this.height=30");
        }

        public void BindIframe1()
        {
            this.framelist1.Attributes.Add("src ", "ActivityOrderDel.aspx?ActivityID=" + hfID.Value.ToString());
            this.framelist1.Attributes.Add("width ", "100%");
            this.framelist1.Attributes.Add("onload ", "this.height=30");
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (hfID.Value != "")
            {
                if (txtOrderNum.Text == "")
                {
                    Response.Write("<script language='javascript'>alert('请输入要添加进活动的订单号！');</script>");
                    return;
                }
                else
                {

                    DataSet ds1 = BusinessFacadeDLT.IsActivityBlack(txtOrderNum.Text);

                    if (ds1.Tables[0].Rows[0][0].ToString() == "1")
                    {

                        DataSet ds = BusinessFacadeDLT.AddActivityOrder(hfID.Value.ToString(), txtOrderNum.Text);

                        string result = ds.Tables[0].Rows[0][0].ToString();
                        if (result == "-1")
                        {
                            Response.Write("<script language='javascript'>alert('添加失败！该订单已添加为此活动订单!');</script>");
                            return;
                        }
                        else if (result == "1")
                        {
                            txtOrderNum.Text = "";
                            Response.Write("<script language='javascript'>alert('添加成功!');</script>");
                            BindDataList();
                        }
                        else if (result == "-2")
                        {
                            Response.Write("<script language='javascript'>alert('添加失败！该订单不属于此活动的游戏类型!');</script>");
                            return;
                        }
                        else if (result == "-3")
                        {
                            Response.Write("<script language='javascript'>alert('添加失败！该订单已存在此活动已删除订单列表里!');</script>");
                            return;
                        }
                        else if (result == "-4")
                        {
                            Response.Write("<script language='javascript'>alert('添加成功！【提示】该订单已存在于其它活动！');</script>");
                            BindDataList();
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('添加失败！系统不存在该订单号!');</script>");
                            return;

                        }
                    }
                    else
                    {
                        string js = string.Format("document.getElementById('{0}').value=confirm('该订单有发单者或接单者存在于活动黑名单，是否继续添加?');document.getElementById('{1}').click();", hid.ClientID, btnHid.ClientID);
                        ClientScript.RegisterStartupScript(GetType(), "confirm", js, true);
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一个具体活动！');</script>");
                return;
            }
            
        }


        protected void btnHid_Click(object sender, EventArgs e)
        {
            string result1 = hid.Value.ToLower() == "true" ? "是" : "否";
            if (result1 == "是")
            {
                // 进行数据的更新
                DataSet ds = BusinessFacadeDLT.AddActivityOrder(hfID.Value.ToString(), txtOrderNum.Text);

                string result = ds.Tables[0].Rows[0][0].ToString();
                if (result == "-1")
                {
                    Response.Write("<script language='javascript'>alert('添加失败！该订单已添加为此活动订单!');</script>");
                    return;
                }
                else if (result == "1")
                {
                    Response.Write("<script language='javascript'>alert('添加成功!');</script>");
                    BindDataList();
                    txtOrderNum.Text = "";
                }
                else if (result == "-2")
                {
                    Response.Write("<script language='javascript'>alert('添加失败！该订单不属于此活动的游戏类型!');</script>");
                    return;
                }
                else if (result == "-3")
                {
                    Response.Write("<script language='javascript'>alert('添加失败！该订单已存在此活动已删除订单列表里!');</script>");
                    return;
                }
                else if (result == "-4")
                {
                    Response.Write("<script language='javascript'>alert('添加成功！【提示】该订单已存在于其它活动！');</script>");
                    BindDataList();
                }
                else if (result == "-5")
                {
                    Response.Write("<script language='javascript'>alert('添加失败！该订单的发单者或接单者为活动黑名单用户!');</script>");
                    return;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('添加失败！系统不存在该订单号!');</script>");
                    return;

                }
            }
        }

        protected void btnSendPrice_Click1(object sender, EventArgs e)
        {
            int result = 0;
            string err = "";
            //给符合条件的所有订单进行充值操作
            if (hfID.Value != "")
            {
                if (txtSendComment.Text != "")
                {
                    DataTable dt = BusinessFacadeDLT.GetLevelOrderActivityList(1, 1000000, " and a.ActivityID=" + hfID.Value).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //检查红包是否超限
                        DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_ActivityRedPaperCheck", hfID.Value);
                        DataTable dt2 = ds.Tables[0];
                        if (dt != null)
                        {
                            result = int.Parse(dt2.Rows[0]["Result"].ToString());
                            err = dt2.Rows[0]["Err"].ToString();
                            //Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                        }
                        if (result == 1)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string odserialno = dt.Rows[i]["ODSerialNo"].ToString();

                                if (lblUserType.Text == "下家")
                                {
                                    //调用存储过程给每个用户充值
                                    //if (lblChannel.Text == "内部频道、公共频道")
                                    if (lblChannel.Text.IndexOf("、") > -1)
                                    {
                                        if (dt.Rows[i]["IsPub"].ToString() == "0")
                                        {
                                            //内部频道价格
                                            if (hfP1.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["AcceptUserID"].ToString()), 23, decimal.Parse(hfP1.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                        else if (dt.Rows[i]["IsPub"].ToString() == "1")
                                        {   //公共频道价格
                                            if (hfP2.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["AcceptUserID"].ToString()), 23, decimal.Parse(hfP2.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                        else if (dt.Rows[i]["IsPub"].ToString() == "2")
                                        {
                                            //优质频道价格
                                            if (hfP3.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["AcceptUserID"].ToString()), 23, decimal.Parse(hfP3.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["AcceptUserID"].ToString()), 23, decimal.Parse(lblPrice.Text), /*hfID.Value*/odserialno, txtSendComment.Text);
                                    }
                                }
                                else
                                {
                                    //if (lblChannel.Text == "内部频道、公共频道")
                                    if (lblChannel.Text.IndexOf("、") > -1)
                                    {
                                        if (dt.Rows[i]["IsPub"].ToString() == "0")
                                        {
                                            //内部频道价格
                                            if (hfP1.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["UserID"].ToString()), 23, decimal.Parse(hfP1.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                        else if (dt.Rows[i]["IsPub"].ToString() == "1")
                                        {
                                            //公共频道价格
                                            if (hfP2.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["UserID"].ToString()), 23, decimal.Parse(hfP2.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                        else if (dt.Rows[i]["IsPub"].ToString() == "1")
                                        {
                                            //优质频道价格
                                            if (hfP3.Value != "")
                                            {
                                                BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["UserID"].ToString()), 23, decimal.Parse(hfP3.Value), /*hfID.Value*/odserialno, txtSendComment.Text);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        BusinessFacadeDLT.UserMoneyChange(int.Parse(dt.Rows[i]["UserID"].ToString()), 23, decimal.Parse(lblPrice.Text), /*hfID.Value*/odserialno, txtSendComment.Text);
                                    }
                                }
                            }
                            //更新活动为已完成充值状态

                            tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(int.Parse(hfID.Value));

                            string Comment = "返利备注：" + txtSendComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;

                            ut.SendDate = Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));

                            ut.Comment = Comment;

                            ut.DataTable_Action_ = DataTable_Action.Update;

                            BusinessFacadeDLT.tbActivityInsertUpdateDelete(ut);


                            divInput.Visible = false;
                            Response.Write("<script language='javascript'>alert('活动内订单充值成功！');</script>");
                            return;
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('" + err +"');</script>");
                            return; 
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('当前活动暂无订单，无法进行充值操作！');</script>");
                        return;
                    }


                }
                else
                {
                    Response.Write("<script language='javascript'>alert('请先选择一个具体活动！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('返利备注不能为空！请输入返利备注！');</script>");
                return;
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

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (txtOrderComment.Text != "")
            {
                if (hfID.Value != "")
                {
                    DataSet ds1 = BusinessFacadeDLT.ActivityOrderSelect(1, 1000000, hfID.Value);
                    string Comment = txtOrderComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        BusinessFacadeDLT.UpdateActivityOrderComment(ds1.Tables[0].Rows[i]["SerialNo"].ToString(), Comment);
                    }
                    lblUpdateComment.Text = "已修改";
                    Response.Write("<script language='javascript'>alert('本活动底下所有订单备注修改成功！');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('请先选择一个具体的活动！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('订单备注不能为空！请输入订单备注！');</script>");
                return;
            }
        }
    }
}
