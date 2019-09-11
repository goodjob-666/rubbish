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

namespace DaiLianTong.Web.Module.DaiLianTong.OrderHis
{
    public partial class Default : System.Web.UI.Page
    {
        public string FrameSerialNo = "";
        public string PostID = "";
        public string TrackPostID = "";
        public string TrackAcceptID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-30)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtLockStart.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtLockEnd.Text = (DateTime.Now.AddDays(3)).Date.ToString("yyyy-MM-dd");
                OnStart();
                Button2.Attributes.Add("onclick", "return   confirm('您真的要强制完单吗？')");
                Button6.Attributes.Add("onclick", "return   confirm('您真的要给该用户增加跟踪记录吗？')");
                //BindDataList();
                TabOptionWebControls1.SelectIndex = 1;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds=null;

            string keyText = "";
            if (ddlKeyword.Text == "首查" || ddlKeyword.Text == "客服")
            {
                if (UserData.Get_sys_UserTable1(SearchText_Input.Text) != null)
                {
                    keyText = UserData.Get_sys_UserTable1(SearchText_Input.Text).UserID.ToString();
                }
                else
                {
                    keyText = "0";
                }
            }
            else
            {
                keyText = SearchText_Input.Text;
            }

            if (ddlKeyword.Text == "订单标题" || ddlKeyword.Text == "角色名")
            {
                keyText = keyText.Replace("'", "''");
            }

            if (ddlCancelStatus.SelectedValue == "15")
            {
                //按完成时间排序,存储过程排序按照完成时间
                ds = BusinessFacadeDLT.OrderSelectHis(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "1",ddlGame.SelectedValue);
            }
            else
            {
                ds = BusinessFacadeDLT.OrderSelectHis(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "0",ddlGame.SelectedValue);
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            if (ddlCancelStatus.SelectedValue == "14")
            {
                if (int.Parse(ds.Tables[1].Rows[0][0].ToString()) > 500)
                {
                    RecordCount = 500;
                }
                else
                {
                    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                }
                lblJRCount.Text = "<font style=\"font-weight:bold\">&nbsp;当前介入订单总数：" + ds.Tables[1].Rows[0][0].ToString()+"</font>";
            }
            else
            {
                RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                lblJRCount.Text = "";
            }
            this.AspNetPager1.RecordCount = RecordCount;
        }


        public string SaveTwoPointer(string price)
        {
            return Math.Round(decimal.Parse(price), 2).ToString();
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OrderDetail")
            {
                string SerialNo = e.CommandArgument.ToString();
                if (SerialNo == "")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int index = row.RowIndex;
                    SerialNo = GridView1.Rows[index].Cells[2].Text;
                }
                if (SerialNo == "")
                {
                    Response.Write("<script language='javascript'>alert('一次只能查看一个订单详情，请不要勾选多个查看！');</script>");
                    return;
                }
                else
                {
                    /*更新首查*/
                    BusinessFacadeDLT.MarkFirstViewOrder(SerialNo, Common.Get_UserID);
                    TabOptionWebControls1.SelectIndex = 2;
                    View_OrderInfo(SerialNo, 1);
                    BindDataList();
                }
            }
        }

        private void OnStart()
        {
            BindStatusList();
            BindSCancelList();
        }

        /// <summary>
        /// 绑定订单状态
        /// </summary>
        private void BindStatusList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1013";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                E_Status.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        /// <summary>
        /// 绑定撤销状态
        /// </summary>
        private void BindSCancelList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1014";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                ddlCancelStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
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
            TabOptionWebControls1.SelectIndex = 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        /// <summary>
        /// 单个订单查询
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <param name="iType"></param>
        private void View_OrderInfo(string SerialNo, int iType)
        {
            DataSet ds = null;


            int IsHisOrder = 0;
             if (cbHisOrder.Checked)
             {
                 IsHisOrder = 1;
             }
             ds = BusinessFacadeDLT.GetOrderHis(SerialNo, IsHisOrder);

            lb_Title2.Text = "订单详情";
            U_SerialNo_Txt.Text = FrameSerialNo = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            U_CreateDate_Txt.Text = ds.Tables[0].Rows[0]["CreateDate"].ToString();
            U_GameServer_Txt.Text = ds.Tables[0].Rows[0]["GameServer"].ToString();
            U_Title_Txt.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            U_Bal_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Price"]).ToString("0.00");
            U_Ensure1_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Ensure1"]).ToString("0.00");
            U_Ensure2_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Ensure2"]).ToString("0.00");
            U_TimeLimit_Txt.Text = ds.Tables[0].Rows[0]["TimeLimit"].ToString();
            U_LeaveTime_Txt.Text = ds.Tables[0].Rows[0]["LeaveTime"].ToString();
            U_BeginTime_Txt.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
            if (ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
            {
                U_EndTime_Txt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"].ToString()).Year != 1900 ? ds.Tables[0].Rows[0]["EndDate"].ToString() : "";
            }
            else
            {
                U_EndTime_Txt.Text = "";
            }
            U_ActorName_Txt.Text = ds.Tables[0].Rows[0]["Actor"].ToString();
            U_CurrInfo_Txt.Text = ds.Tables[0].Rows[0]["CurrInfo"].ToString();
            U_Require_Txt.Text = ds.Tables[0].Rows[0]["Require"].ToString();
            U_PublishUser_Txt.Text = ds.Tables[0].Rows[0]["PublishUser"].ToString();
            tbCreateOpID.Text = PostID = ds.Tables[0].Rows[0]["PubID"].ToString();
            U_ActorCount.Text = "【" + ds.Tables[0].Rows[0]["ActorCount"].ToString() + "】";
            tbUserID.Text = TrackPostID = ds.Tables[0].Rows[0]["UserID"].ToString();
            tbAcceptUserID.Text = TrackAcceptID =ds.Tables[0].Rows[0]["AcceptUserID"].ToString();
            if (ds.Tables[0].Rows[0]["appointUserID"].ToString() == "0" || ds.Tables[0].Rows[0]["appointUserID"].ToString() == "" || ds.Tables[0].Rows[0]["appointUserID"].ToString() == "NULL")
            {
                lblZD.Text = "";
            }
            else
            {
                lblZD.Text = GetUID(ds.Tables[0].Rows[0]["appointUserID"].ToString());
            }

            cbLook.Checked = ds.Tables[0].Rows[0]["CustomerID"].ToString() != "0" ? true : false;

            U_FirstOPName_Txt.Text = ds.Tables[0].Rows[0]["FirstCustomerID"].ToString() != "0" ? UserData.Get_sys_UserTable(int.Parse(ds.Tables[0].Rows[0]["FirstCustomerID"].ToString())).U_LoginName : "";

            if (ds.Tables[0].Rows[0]["FirstDate"] != null && ds.Tables[0].Rows[0]["FirstDate"].ToString() != "NULL" && ds.Tables[0].Rows[0]["FirstDate"].ToString() != "")
            {
                if(Convert.ToDateTime(ds.Tables[0].Rows[0]["FirstDate"].ToString()).Year != 1900)
                {
                    U_TrackTime_Txt.Text = ds.Tables[0].Rows[0]["FirstDate"].ToString();
                }
                else
                {
                    U_TrackTime_Txt.Text = "";
                }
            }

            lbUserID.Text = tbCreateOpID.Text;
            lbUserDesc.Text = "[发单者]";
            //BindDataList3();

            tbAcceptOpID.Text = ds.Tables[0].Rows[0]["AcceptID"].ToString();

            lbUserID1.Text = tbAcceptOpID.Text;

            lbUserDesc1.Text = "[接单者]";
            //BindDataList4();

            U_PubContactway_Txt.Text = ds.Tables[0].Rows[0]["PubContactway"].ToString();
            U_PubOrderInfo_Txt.Text = "【总发：" + ds.Tables[0].Rows[0]["PubCount"].ToString() + " 总撤：" + ds.Tables[0].Rows[0]["PubCancelCount"].ToString() + " 介入撤：" + ds.Tables[0].Rows[0]["PubCancel"].ToString() + " 协商撤：" + ds.Tables[0].Rows[0]["PubConsultCancel"].ToString() + "】";
           
            //判断发单人是否被禁止权限

            //DataTable dt = BusinessFacadeDLT.PubHaveRightLock(tbUserID.Text).Tables[0];

            //if (dt.Rows.Count>0)
            //{
            //    lblRightLock.Text = "—【发单人已被禁止发单】";
            //}
            
            U_AcceptUser_Txt.Text = ds.Tables[0].Rows[0]["AccepLoginID"].ToString() + "/" + ds.Tables[0].Rows[0]["AcceptUser"].ToString();
            U_AccContactway_Txt.Text = ds.Tables[0].Rows[0]["AccContactway"].ToString();
            if (tbAcceptOpID.Text != "")
            {
                U_AccOrderInfo_Txt.Text = "【总接：" + ds.Tables[0].Rows[0]["AcceptCount"].ToString() + " 总撤：" + ds.Tables[0].Rows[0]["AcceptCancelCount"].ToString() + " 介入撤：" + ds.Tables[0].Rows[0]["AcceptCancel"].ToString() + " 协商撤：" + ds.Tables[0].Rows[0]["AcceptConsultCancel"].ToString() + "】";
            }
            tbComment.Text = ds.Tables[0].Rows[0]["BackComment"].ToString();
            string status = ds.Tables[0].Rows[0]["Status"].ToString();
            string cancelStatus = ds.Tables[0].Rows[0]["CancelStatus"].ToString();
            hfCancelStatus.Value = cancelStatus;
            if ((status == "16") && ((cancelStatus == "14") || (cancelStatus == "11")))
            {
                Panel1.Visible = true;
                lb_Title3.Visible = true;
                lb_Title3.Text = "订单仲裁";
                DataSet ds2 = BusinessFacadeDLT.OrderCancel(SerialNo);
                if ((ds2 != null) && (ds2.Tables[0].Rows.Count != 0))
                {
                    string CreateDate = ds2.Tables[0].Rows[0]["CreateDate"].ToString();
                    float payLevelBal = float.Parse(ds2.Tables[0].Rows[0]["PayLevelBal"].ToString());
                    float repEnsureBal = float.Parse(ds2.Tables[0].Rows[0]["RepEnsureBal"].ToString());

                    string Limit1 = "(支付金额不能超过" + U_Bal_Txt.Text + "元)";
                    string Limit2 = "(支付金额不能超过" + (float.Parse(U_Ensure1_Txt.Text) + float.Parse(U_Ensure2_Txt.Text)).ToString() + "元)";

                    tbPayout.Text = repEnsureBal.ToString();
                    tbInCome.Text = payLevelBal.ToString();

                    lbMes1.Text = "接单者需要赔偿保证金：";
                    lbMes2.Text = "元 " + Limit2;
                    lbMes3.Text = "  发单者愿意支付代练费：";
                    lbMes4.Text = "元 " + Limit1;
                    div1.Style["float"] = "left";
                    div2.Style["float"] = "right";

                }
                else
                {
                    tbPayout.Text = "0";
                    tbInCome.Text = "0";
                    lbMes1.Text = "接单者愿意赔偿保证金：";
                    lbMes2.Text = "元 ";
                    lbMes3.Text = "  发单者需要支付代练费：";
                    lbMes4.Text = "元 ";
                    div1.Style["float"] = "left";
                    div2.Style["float"] = "right";
                }
            }
            else
            {
                Panel1.Visible = false;
                lb_Title3.Visible = false;
                lb_Title3.Text = "";
            }
            /*lb_Title4.Visible = true;
            lb_Title4.Text = "交互留言";*/
            ViewState["SearchTerms"] = " and a.ODSerialNo = '" + SerialNo + "'";
            BindIframe();
            BindIframe1();
            BindIframe2();
        }


        /// <summary>
        /// 强制完单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (U_SerialNo_Txt.Text != "")
                {
                    if ((float.Parse(tbPayout.Text.Trim()) > (float.Parse(U_Ensure1_Txt.Text.Trim()) + float.Parse(U_Ensure2_Txt.Text.Trim()))) || float.Parse(tbInCome.Text.Trim()) > float.Parse(U_Bal_Txt.Text.Trim()))
                    {
                        EventMessage.MessageBox(1, "操作失败", "订单:" + U_SerialNo_Txt.Text + "强制完单失败！请设置正确的金额，看清楚括号内的限制提示!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                        return;
                    }

                    if ((float.Parse(tbPayout.Text.Trim()) < 0 || float.Parse(tbInCome.Text.Trim()) < 0))
                    {
                        EventMessage.MessageBox(1, "操作失败", "订单:" + U_SerialNo_Txt.Text + "强制完单失败！请输入正数金额，看清楚括号内的限制提示!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                        return;
                    }

                    DataSet ds = BusinessFacadeDLT.OrderForceOver(U_SerialNo_Txt.Text, float.Parse(tbInCome.Text.Trim()), float.Parse(tbPayout.Text.Trim()));
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {

                            string titleMessage = "订单:" + U_SerialNo_Txt.Text + "强制完单成功-" + hfCancelStatus.Value + "!";
                            EventMessage.EventWriteDB(1, titleMessage);
                            Response.Write("<script language='javascript'>alert('强制完单成功！');</script>");
                            BindDataList();
                            TabOptionWebControls1.SelectIndex = 0;
                        }
                        else if (ds.Tables[0].Rows[0][0].ToString() == "-2")
                        {
                            string titleMessage = "订单:" + U_SerialNo_Txt.Text + "强制完单失败-" + hfCancelStatus.Value + "!";
                            EventMessage.EventWriteDB(1, titleMessage);
                            Response.Write("<script language='javascript'>alert('订单不符合完单条件：订单状态已变化，无法修改！');</script>");
                            BindDataList();
                            TabOptionWebControls1.SelectIndex = 0;
                        }
                        else
                        {
                            string titleMessage = "订单:" + U_SerialNo_Txt.Text + "强制完单失败-" + hfCancelStatus.Value + "!";
                            EventMessage.EventWriteDB(1, titleMessage);
                            Response.Write("<script language='javascript'>alert('订单不符合完单条件：订单异常,不能操作！');</script>");
                            BindDataList();
                            TabOptionWebControls1.SelectIndex = 0;
                        }
                    }
                }
            }
            catch {
                Response.Write("<script language='javascript'>alert('保证金或代练费只能为数字！');</script>");   
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
                    if (e.Row.DataItem != null)
                    {
                        DataIDX = DataBinder.Eval(e.Row.DataItem, "SerialNo").ToString();
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
            string Err_Value = "";
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                IDX = Checkbox_Value_Array[i];
                if (IDX != "")
                {
                    //if (cbSetRightLock.Checked)
                    //{
                    //    //同时封禁此发单用户的发单权限
                    //    string userID = BusinessFacadeDLT.GetOrder(IDX, 0).Tables[0].Rows[0]["UserID"].ToString();
                    //    BusinessFacadeDLT.SetUserLock(int.Parse(userID), 10, DateTime.Parse(txtLockStart.Text + " 00:00:00"), DateTime.Parse(txtLockEnd.Text + " 23:59:59"), "因发布代练需求之外的广告订单，暂封停发单功能！请遵守发单者协议。", 1);
                    //}

                    //删除订单
                    DataSet ds = BusinessFacadeDLT.OrderDelete(IDX,UserData.GetUserDate.UserID);

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() != "1")
                        {
                            if (Err_Value != "")
                            {
                                Err_Value += ",";
                            }
                            Err_Value += IDX;
                            Checkbox_Value = Checkbox_Value.Replace(IDX + ",", "");
                            Checkbox_Value = Checkbox_Value.Replace(IDX, "");
                        }
                    }
                }
            }


            if (Err_Value != "")
            {
                EventMessage.MessageBox(1, "批量删除结果", string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value), Icon_Type.Alert, Common.GetHomeBaseUrl("default.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
            }
        }


        /// <summary>
        /// 交互留言
        /// </summary>
        //private void BindDataList2()
        //{
        //    QueryParam qp = new QueryParam();
        //    qp.Where = SearchTerms;
        //    qp.PageIndex = AspNetPager2.CurrentPageIndex;
        //    qp.PageSize = AspNetPager2.PageSize;
        //    int RecordCount = 0;
        //    DataSet ds = BusinessFacadeDLT.LevelOrderMessage(qp.PageIndex, qp.PageSize, qp.Where);
        //    GridView3.DataSource = ds.Tables[0];
        //    GridView3.DataBind();
        //    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        //    this.AspNetPager2.RecordCount = RecordCount;
        //}

        public string GetUserID(string userid)
        {
            if (userid == tbCreateOpID.Text)
            {
                return userid = userid + "[发单者]";
            }
            else
                return userid;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        //protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        //{
        //    BindDataList2();
        //}

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                tbLevelOrderMessageEntity ut = BusinessFacadeDLT.tbLevelOrderMessageDisp(0);
                ut.UserID = 10012;/*USR201305030006*/
                ut.MsgType = 12;
                ut.ODSerialNo = U_SerialNo_Txt.Text;
                ut.CreateDate = DateTime.Now;
                ut.Msg = tbMessage.Text;
                if ((ut.ODSerialNo != "") && (ut.Msg != ""))
                {
                    ut.Msg = "[后台客服]" + ut.Msg;
                    ut.DataTable_Action_ = DataTable_Action.Insert;
                    Int32 rInt = BusinessFacadeDLT.tbLevelOrderMessageInsertUpdateDelete(ut);
                    if (rInt > 0)
                    {
                        FrameSerialNo = U_SerialNo_Txt.Text;
                        PostID = tbCreateOpID.Text;
                        BindIframe();
                        tbMessage.Text = "";
                    }
                }
            }
        }

        public void BindIframe()
        {
            this.framelist.Attributes.Add("src ", "OrderMessage.aspx?SerialNo=" + FrameSerialNo + "&PostID=" + PostID);
            this.framelist.Attributes.Add("width ", "100%");
            this.framelist.Attributes.Add("onload ", "this.height=30");
        }

        public void BindIframe1()
        {
            this.framelist1.Attributes.Add("src ", "PostTrack.aspx?TrackPostID=" + tbUserID.Text);
            this.framelist1.Attributes.Add("width ", "100%");
            this.framelist1.Attributes.Add("onload ", "this.height=30");
        }

        public void BindIframe2()
        {
            this.framelist2.Attributes.Add("src ", "AcceptTrack.aspx?TrackAcceptID=" + tbAcceptUserID.Text);
            this.framelist2.Attributes.Add("width ", "100%");
            this.framelist2.Attributes.Add("onload ", "this.height=30");
        }


        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            if ((U_SerialNo_Txt.Text != "") && (tbComment.Text != ""))
            {
                string Comment = tbComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                DataSet ds = BusinessFacadeDLT.UpdateComment(U_SerialNo_Txt.Text, Comment);
                Response.Write("<script language='javascript'>alert('修改成功！');</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                Response.Write("<script>window.open('OrderProgress.aspx?SerialNo=" + U_SerialNo_Txt.Text + "','_blank')</script>");
            }
        }

        //protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        //{
        //    BindDataList3();
        //}

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                View_OrderInfo(U_SerialNo_Txt.Text, 1);
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一个订单！');</script>");
                TabOptionWebControls1.SelectIndex = 1;

            }
        }

        public string GetOpLoginID(string customerid)
        {
            if (customerid != "0")
            {
                return UserData.Get_sys_UserTable(int.Parse(customerid)).U_LoginName;
            }
            else
            {
                return "";
            }
        }

        //跟踪记录 发单者
        //private void BindDataList3()
        //{
        //    int RecordCount = 0;
        //    DataSet ds = BusinessFacadeDLT.GetUserTrackInfo(tbUserID.Text, AspNetPager3.CurrentPageIndex, AspNetPager3.PageSize);
        //    GridView4.DataSource = ds;
        //    GridView4.DataBind();
        //    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        //    this.AspNetPager3.RecordCount = RecordCount;
        //}

        //跟踪记录 接单者
        //private void BindDataList4()
        //{
        //    int RecordCount = 0;
        //    DataSet ds = BusinessFacadeDLT.GetUserTrackInfo(tbAcceptUserID.Text, AspNetPager4.CurrentPageIndex, AspNetPager4.PageSize);
        //    GridView5.DataSource = ds;
        //    GridView5.DataBind();
        //    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        //    this.AspNetPager4.RecordCount = RecordCount;
        //}

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                lbUserID.Text = tbCreateOpID.Text;
                lbUserDesc.Text = "[发单者]";
                BindIframe1();
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                lbUserID1.Text = tbAcceptOpID.Text;
                lbUserDesc1.Text = "[接单者]";
                BindIframe2();
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

        protected void cbLook_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLook.Checked)
            {
                DataSet ds = BusinessFacadeDLT.MarkLookOrder(U_SerialNo_Txt.Text, Common.Get_UserID, 11);
            }
            else
            {
                DataSet ds = BusinessFacadeDLT.MarkLookOrder(U_SerialNo_Txt.Text, 0, 10);
            }
            Response.Write("<script language='javascript'>alert('设置成功！');</script>");
            BindDataList();
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

                if (ddlCancelStatus.SelectedValue == "14")
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    GridView1.Columns[2].Visible = false;
                    GridView1.Columns[3].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[10].Visible = false;
                }
                else
                {
                    e.Row.Cells[3].Visible = true;
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[11].Visible = true;
                    GridView1.Columns[2].Visible = true;
                    GridView1.Columns[3].Visible = true;
                    GridView1.Columns[5].Visible = true;
                    GridView1.Columns[6].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[10].Visible = true;
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

        public string UIDPost(string UID)
        {
            if (UID == tbCreateOpID.Text)
            {
                return UID + "[发单者]";
            }
            else
            {
                return UID;
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

        public string GetUID(string ID)
        {
            if (ID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [ID]=" + ID;
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].UID;
            }
            else
            {
                return "";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                DataSet ds = BusinessFacadeDLT.AddUserTrackInfo(tbUserID.Text, tbTrackInfo.Text, int.Parse(ddlScore.Text), Common.Get_UserID, U_SerialNo_Txt.Text);
                //BindDataList3();
                BindIframe1();
                ddlScore.Text = "0";
                tbTrackInfo.Text = "";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                DataSet ds = BusinessFacadeDLT.AddUserTrackInfo(tbAcceptUserID.Text, tbTrackInfo1.Text, int.Parse(ddlScore1.Text), Common.Get_UserID, U_SerialNo_Txt.Text);
                //BindDataList4();
                BindIframe2();
                ddlScore1.Text = "0";
                tbTrackInfo1.Text = "";
            }
        }

    }
}
