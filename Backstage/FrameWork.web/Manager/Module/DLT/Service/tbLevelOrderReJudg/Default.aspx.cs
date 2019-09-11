/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            tbLevelOrderReJudg列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2015/11/28 18:10:17
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
using System.Drawing;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tbLevelOrderReJudg
{
    public partial class Default : System.Web.UI.Page
    {
        public string FrameSerialNo = "";
        public string PostID = "";
        public string TrackPostID = "";
        public string TrackAcceptID = "";
        public string RejudgSerialNo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSearchType();
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    divAddOrder.Visible = true;
                }
                else
                {
                    divAddOrder.Visible = false;
                }
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
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.LevelOrderJudgList(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public string SActor()
        {
            return tbDataActorName.Text;
        }

        private void BindSearchType()
        {

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = BusinessFacadeDLT.sys_StatisticalGroupingList(qp, out RecordCount);
            foreach (sys_StatisticalGroupingEntity var in lst)
            {
                DropDownList2.Items.Add(new ListItem(var.S_Name, var.S_ID.ToString()));
            }
        }

        private string GameAccReplace(string gameAcc)
        {
            if (gameAcc.Length > 4)
            {
                int length = gameAcc.Length;
                string str = gameAcc.Substring(0, 2);
                for (int i = 0; i < length - 4; i++)
                {
                    str += "*";
                }
                str += gameAcc.Substring(gameAcc.Length - 2, 2);
                return str;
            }
            else
            {
                return gameAcc;
            }
        }

        public string OrderTitle(string SerialNo)
        {
            if (SerialNo != "")
            {
                return BusinessFacadeDLT.OrderTitle(SerialNo).Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        public string ReJudgCount(string SerialNo)
        {
            if (SerialNo != "")
            {
                return BusinessFacadeDLT.LevelOrderJudgCount(SerialNo).Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    e.Row.Cells[6].Visible = true;
                    GridView1.Columns[6].Visible = true;
                }
                else
                {
                    e.Row.Cells[6].Visible = false;
                    GridView1.Columns[6].Visible = false;
                }

                CheckBox cbIsDeal = (CheckBox)e.Row.FindControl("cbIsDeal");
                HiddenField hf = (HiddenField)e.Row.FindControl("hfIsDeal");

                if (hf.Value == "1")
                {
                    cbIsDeal.Checked = true;
                }
                else
                {
                    cbIsDeal.Checked = false;
                }

                string tmpstr = DataBinder.Eval(e.Row.DataItem, "MarkColor").ToString();

                if (tmpstr == "1")
                {
                    e.Row.ForeColor = Color.MediumVioletRed;
                }



            }

        }

        protected void cbIsDeal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbIsDeal = (CheckBox)sender;
            string ID = cbIsDeal.ValidationGroup;

            if (cbIsDeal.Checked)
            {
                BusinessFacadeDLT.UpdateRejudgColor(ID, 1);
            }
            else
            {
                BusinessFacadeDLT.UpdateRejudgColor(ID, 0);
            }
            BindDataList();
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }

        public string MyJudgStatus(string SerialNo)
        {
            if (SerialNo != "")
            {
                string result = BusinessFacadeDLT.LevelOrderMyJudgStatus(SerialNo, Common.Get_UserID).Tables[0].Rows[0][0].ToString();
                if(result=="1")
                {
                    return "未判决";
                }
                else
                {
                    return "已判决";
                }
            }
            else
            {
                return "";
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
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ODSerialNo_Value = (string)Common.sink(ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string CustomerID_Value = (string)Common.sink(CustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Reason_Value = (string)Common.sink(Reason_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (ODSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND ODSerialNo = '{0}' ", Common.inSQL(ODSerialNo_Value));
            }

            if (CustomerID_Value != string.Empty)
            {
                sb.AppendFormat(" AND CustomerID = {0} ", Convert.ToInt32(CustomerID_Value));
            }

            if (Reason_Value != string.Empty)
            {
                sb.AppendFormat(" AND Reason like '%{0}%' ", Common.inSQL(Reason_Value));
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
            //string DataIDX = "";
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            //    {
            //        //Button2.Visible = true;
            //        ////增加check列头全选
            //        //TableCell cell = new TableCell();
            //        //cell.Width = Unit.Pixel(5);
            //        //cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
            //        //e.Row.Cells.AddAt(0, cell);
            //    }

            //    //foreach (TableCell var in e.Row.Cells)
            //    //{
            //    //    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
            //    //    {
            //    //        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
            //    //        if (Colume == Orderfld)
            //    //        {

            //    //            LinkButton l = (LinkButton)var.Controls[0];
            //    //            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
            //    //            //Image Img = new Image();
            //    //            //SortDirection a = GridView1.SortDirection;
            //    //            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
            //    //            //var.Controls.Add(Img);
            //    //        }
            //    //    }
            //    //}
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
                    tbLevelOrderReJudgEntity et = new tbLevelOrderReJudgEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbLevelOrderReJudgInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (U_SerialNo_Txt.Text != "")
                {
                    if ((float.Parse(tbPayout.Text.Trim()) > (float.Parse(U_Ensure1_Txt.Text.Trim()) + float.Parse(U_Ensure2_Txt.Text.Trim()))) || float.Parse(tbInCome.Text.Trim()) > float.Parse(U_Bal_Txt.Text.Trim()))
                    {
                        Response.Write("<script language='javascript'>alert('发表判决意见失败！请设置正确的金额，看清楚括号内的限制提示!');</script>");
                        return;
                    }

                    if ((float.Parse(tbPayout.Text.Trim()) < 0 || float.Parse(tbInCome.Text.Trim()) < 0))
                    {
                        Response.Write("<script language='javascript'>alert('发表判决意见失败！请设置正确的金额，看清楚括号内的限制提示!');</script>");
                        return;
                    }

                    string reason = "后台仲裁处理,发单者支付代练费：" + float.Parse(tbInCome.Text.Trim()).ToString() + "元，接单者赔偿保证金：" + float.Parse(tbPayout.Text.Trim()).ToString() + "元。<br />";
                    reason += "[后台客服] "+txtJudgReason.Text;
                    
                    BusinessFacadeDLT.AddLevelOrderReJudg(U_SerialNo_Txt.Text,reason,Common.Get_UserID);

                    Response.Write("<script language='javascript'>alert('发表判决意见成功！);</script>");
                    LinkButton6_Click(null,null);
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('保证金或代练费只能为数字！');</script>");
                return;
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OrderDetail")
            {
                string SerialNo = RejudgSerialNo = e.CommandArgument.ToString();
                //if (SerialNo == "")
                //{
                //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //    int index = row.RowIndex;
                //    SerialNo = GridView1.Rows[index].Cells[2].Text;
                //}
                if (SerialNo == "")
                {
                    Response.Write("<script language='javascript'>alert('一次只能查看一个订单详情，请不要勾选多个查看！');</script>");
                    return;
                }
                else
                {
                    TabOptionWebControls1.SelectIndex = 2;
                    View_OrderInfo(SerialNo, 1);
                }
            }
        }

        private void View_OrderInfo(string SerialNo, int iType)
        {
            DataSet ds = null;
            DisScreen.Attributes.Add("onclick", "window.open('../tbLevelOrder/OrderProgress.aspx?SerialNo=" + SerialNo + "','_blank')");

            int IsHisOrder = 0;

            ds = BusinessFacadeDLT.GetOrder(SerialNo, IsHisOrder);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = BusinessFacadeDLT.GetOrder(SerialNo, 1);
            }


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
            lblGameAcc.Text = GameAccReplace(ds.Tables[0].Rows[0]["GameAcc"].ToString());
            if (ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
            {
                U_EndTime_Txt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"].ToString()).Year != 1900 ? ds.Tables[0].Rows[0]["EndDate"].ToString() : "";
            }
            else
            {
                U_EndTime_Txt.Text = "";
            }
            tbDataActorName.Text = ds.Tables[0].Rows[0]["Actor"].ToString();
            U_ActorName_Txt.Text = Unicode2ChineseActor(ds.Tables[0].Rows[0]["Actor"].ToString());
            U_CurrInfo_Txt.Text = ds.Tables[0].Rows[0]["CurrInfo"].ToString();
            U_Require_Txt.Text = ds.Tables[0].Rows[0]["Require"].ToString();
            U_PublishUser_Txt.Text = ds.Tables[0].Rows[0]["PublishUser"].ToString();
            tbCreateOpID.Text = PostID = ds.Tables[0].Rows[0]["PubID"].ToString();
            U_ActorCount.Text = "【" + ds.Tables[0].Rows[0]["ActorCount"].ToString() + "】";
            tbUserID.Text = TrackPostID = ds.Tables[0].Rows[0]["UserID"].ToString();
            tbAcceptUserID.Text = TrackAcceptID = ds.Tables[0].Rows[0]["AcceptUserID"].ToString();
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
                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["FirstDate"].ToString()).Year != 1900)
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

            //是否显示重判分析备注
            ReJudgComment(SerialNo);

            //判断是否发表过评论

            string result = BusinessFacadeDLT.LevelOrderMyJudgStatus(SerialNo, Common.Get_UserID).Tables[0].Rows[0][0].ToString();
            if (result=="1")
            {
                Panel1.Visible = true;
                divReJudgList.Visible = false;
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
                    string Limit1 = "(支付金额不能超过" + U_Bal_Txt.Text + "元)";
                    string Limit2 = "(支付金额不能超过" + (float.Parse(U_Ensure1_Txt.Text) + float.Parse(U_Ensure2_Txt.Text)).ToString() + "元)";
                    tbPayout.Text = "0";
                    tbInCome.Text = "0";
                    lbMes1.Text = "接单者愿意赔偿保证金：";
                    lbMes2.Text = "元 "+ Limit2;
                    lbMes3.Text = "  发单者需要支付代练费：";
                    lbMes4.Text = "元 " + Limit1;
                    div1.Style["float"] = "left";
                    div2.Style["float"] = "right";
                }
                
            }
            else
            {
                DataBindReJudgList(SerialNo);
                Panel1.Visible = false;
                divReJudgList.Visible = true;
                lb_Title3.Visible = false;
                lb_Title3.Text = "";
            }
            cbCancel.Checked = LockCancelStatus(SerialNo) == "1" ? true : false;
            /*lb_Title4.Visible = true;
            lb_Title4.Text = "交互留言";*/

            //绑定是否需要客服协助
            DataSet dsHelpService = BusinessFacadeDLT.GetServiceHelp(SerialNo);
            if (dsHelpService != null)
            {
                if (dsHelpService.Tables[0].Rows.Count > 0)
                {
                    cbServiceHelp.Checked = true;
                    ddlServiceHelp.Value = dsHelpService.Tables[0].Rows[0]["HelpType"].ToString();
                    txtServiceHelp.Text = dsHelpService.Tables[0].Rows[0]["Content"].ToString();
                    if (dsHelpService.Tables[0].Rows[0]["IsDeal"].ToString() == "False")
                    {
                        lblServiceHelpStatus.Text = "【客服未处理！】";

                    }
                    else
                    {
                        lblServiceHelpStatus.Text = "【客服已处理！】";
                    }
                    lblServiceHelpStatus.Visible = true;
                }
                else
                {
                    cbServiceHelp.Checked = false;
                    ddlServiceHelp.Value = "0";
                    txtServiceHelp.Text = "通知上家补全证据";
                    lblServiceHelpStatus.Visible = false;
                }
            }
            else
            {
                cbServiceHelp.Checked = false;
                ddlServiceHelp.Value = "0";
                txtServiceHelp.Text = "通知上家补全证据";
                lblServiceHelpStatus.Visible = false;
            }

            //超时时间计算
            if (U_BeginTime_Txt.Text != "")
            {
                lblOverTime.Text = Convert.ToDateTime(U_BeginTime_Txt.Text).AddHours(int.Parse(U_TimeLimit_Txt.Text)).ToString("yyyy/MM/dd HH:mm:ss");
            }

            //订单变色处理列表
            DataTable dtLevelOrderColor = BusinessFacadeDLT.LevelOrderMarkColorList(SerialNo).Tables[0];
            if (dtLevelOrderColor.Rows.Count > 0)
            {
                string strColor = "";
                for (int k = 0; k < dtLevelOrderColor.Rows.Count; k++)
                {
                    strColor += dtLevelOrderColor.Rows[k]["CreateDate"].ToString() + "&nbsp;&nbsp;" + ColorCustomerID(dtLevelOrderColor.Rows[k]["CustomerID"].ToString()) + "<br/>";
                }
                lblInfoList.Text = strColor;
            }
            else
            {
                lblInfoList.Text = "";
            }

            BindPostMacList();
            BindAcceptMacList();

            ViewState["SearchTerms"] = " and a.ODSerialNo = '" + SerialNo + "'";
            BindIframe();
            BindIframe1();
            BindIframe2();
        }

        private void BindPostMacList()
        {
            DataSet dsMACList = BusinessFacadeDLT.GetUserLoginMACList(int.Parse(tbUserID.Text));

            lblPostUserList.Text = "<a href=\"../../Service/tsUser/Default.aspx?IDLIST=" + tbUserID.Text + "\" target=\"_blank\">查询关联账号</a> 【" + dsMACList.Tables[1].Rows[0][0].ToString() + "】";

            //DataSet dsHDList = BusinessFacadeDLT.GetUserLoginHDList(int.Parse(tbUserID.Text));

            //lblPostUserList.Text = "<a href=\"../../Service/tsUser/Default.aspx?IDLIST1=" + tbUserID.Text + "\" target=\"_blank\">查询关联账号</a> 【" + dsHDList.Tables[1].Rows[0][0].ToString() + "】";
        }

        private void BindAcceptMacList()
        {
            DataSet dsMACList = BusinessFacadeDLT.GetUserLoginMACList(int.Parse(tbAcceptUserID.Text));

            lblAcceptUserList.Text = "<a href=\"../../Service/tsUser/Default.aspx?IDLIST=" + tbAcceptUserID.Text + "\" target=\"_blank\">查询关联账号</a> 【" + dsMACList.Tables[1].Rows[0][0].ToString() + "】";

            //DataSet dsHDList = BusinessFacadeDLT.GetUserLoginHDList(int.Parse(tbAcceptUserID.Text));

            //lblAcceptUserList.Text = "<a href=\"../../Service/tsUser/Default.aspx?IDLIST1=" + tbAcceptUserID.Text + "\" target=\"_blank\">查询关联账号</a> 【" + dsHDList.Tables[1].Rows[0][0].ToString() + "】";
        }


        public string Unicode2Chinese(string strUnicode)
        {
            strUnicode = strUnicode.Replace(@"\", "%");
            return Microsoft.JScript.GlobalObject.unescape(strUnicode);
        }

        public string Unicode2ChineseActor(string strUnicode)
        {
            //strUnicode = strUnicode.Replace(@"\", "%");
            //return Microsoft.JScript.GlobalObject.unescape(strUnicode);

            strUnicode = strUnicode.Replace(@"\", "%");
            return Microsoft.JScript.GlobalObject.unescape(strUnicode);
        }


        public void DataBindReJudgList(string SerialNo)
        {
            QueryParam qp = new QueryParam();
            qp.Where = " and ODSerialNo='" + SerialNo + "'";
            qp.PageIndex = AspNetPager10.CurrentPageIndex;
            qp.PageSize = 50;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.LevelOrderJudgListByID(qp.PageIndex, qp.PageSize, qp.Where, DropDownList2.SelectedValue);
            Repeater2.DataSource = ds.Tables[0];
            Repeater2.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager10.RecordCount = RecordCount;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindReJudgList(U_SerialNo_Txt.Text);
        }

        public string GetOpLoginName(string OPID)
        {
            return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
        }

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

        protected void Button8_Click(object sender, EventArgs e)
        {
            //插入需要客服协助数据

            if (cbServiceHelp.Checked)
            {
                if (txtServiceHelp.Text != "")
                {

                    BusinessFacadeDLT.InsertServiceHelp(U_SerialNo_Txt.Text, int.Parse(tbUserID.Text), int.Parse(tbAcceptUserID.Text), txtServiceHelp.Text, int.Parse(ddlServiceHelp.Value));
                    Response.Write("<script language='javascript'>alert('增加请求客服协助成功!');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('请求客服协助内容不能为空！');</script>");
                    return;
                }
            }
            else
            {
                //取消此订单客服协助
                BusinessFacadeDLT.DeleteServiceHelp(U_SerialNo_Txt.Text);
                Response.Write("<script language='javascript'>alert('取消请求客服协助成功!');</script>");

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                //tbLevelOrderMessageEntity ut = BusinessFacadeDLT.tbLevelOrderMessageDisp(0);
                //ut.UserID = 10012;/*USR201305030006*/
                //ut.MsgType = 12;
                //ut.ODSerialNo = U_SerialNo_Txt.Text;
                //ut.CreateDate = DateTime.Now;
                //ut.Msg = tbMessage.Text;
                if ((U_SerialNo_Txt.Text != "") && (tbMessage.Text != ""))
                {
                    //插入留言
                    /*USR201305030006*/

                    BusinessFacadeDLT.InsertMessage(10012, 12, U_SerialNo_Txt.Text, DateTime.Now, "[后台客服]" + tbMessage.Text);

                    //ut.Msg = "[后台客服]" + ut.Msg;
                    //ut.DataTable_Action_ = DataTable_Action.Insert;
                    //Int32 rInt = BusinessFacadeDLT.tbLevelOrderMessageInsertUpdateDelete(ut);
                    //if (rInt > 0)
                    //{
                    FrameSerialNo = U_SerialNo_Txt.Text;
                    PostID = tbCreateOpID.Text;
                    BindIframe();
                    tbMessage.Text = "";
                    //}
                }
            }
        }

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

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "")
            {
                DataSet ds = BusinessFacadeDLT.AddUserTrackInfo(tbUserID.Text, tbTrackInfo.Text, int.Parse(ddlScore.Text), Common.Get_UserID,U_SerialNo_Txt.Text);
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
                DataSet ds = BusinessFacadeDLT.AddUserTrackInfo(tbAcceptUserID.Text, tbTrackInfo1.Text, int.Parse(ddlScore1.Text), Common.Get_UserID,U_SerialNo_Txt.Text);
                //BindDataList4();
                BindIframe2();
                ddlScore1.Text = "0";
                tbTrackInfo1.Text = "";
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //提醒补全信息
            BusinessFacadeDLT.LevelOrderMarkColor(U_SerialNo_Txt.Text, Common.Get_UserID.ToString());
            Response.Write("<script language='javascript'>alert('提醒上家补全信息成功!');</script>");
            View_OrderInfo(U_SerialNo_Txt.Text, 1);
        }

        protected void cbCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCancel.Checked)
            {
                DataSet ds = BusinessFacadeDLT.SetOrderCancelStatus(U_SerialNo_Txt.Text, 1);
            }
            else
            {
                DataSet ds = BusinessFacadeDLT.SetOrderCancelStatus(U_SerialNo_Txt.Text, 0);
            }
            Response.Write("<script language='javascript'>alert('设置成功！');</script>");
            BindIframe();
            BindDataList();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if ((U_SerialNo_Txt.Text != "") && (tbComment.Text != ""))
            {
                string Comment = tbComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                DataSet ds = BusinessFacadeDLT.UpdateComment(U_SerialNo_Txt.Text, Comment);
                Response.Write("<script language='javascript'>alert('修改成功！');</script>");
            }
        }

        protected void btnReJudgComment_Click(object sender, EventArgs e)
        {
            string Comment = tbReJudgComment.Text + "\n" + DateTime.Now.ToString() + " " + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
            DataSet ds = BusinessFacadeDLT.UpdateRejudgComment(U_SerialNo_Txt.Text, Comment);
            Response.Write("<script language='javascript'>alert('修改成功！');</script>");
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

        public void BindIframe()
        {
            this.framelist.Attributes.Add("src ", "JudgOrderMessage.aspx?SerialNo=" + U_SerialNo_Txt.Text + "&PostID=" + tbCreateOpID.Text);
            this.framelist.Attributes.Add("width ", "100%");
            this.framelist.Attributes.Add("onload ", "this.height=30");
        }

        public void BindIframe1()
        {
            this.framelist1.Attributes.Add("src ", "../tbLevelOrder/PostTrack.aspx?TrackPostID=" + tbUserID.Text);
            this.framelist1.Attributes.Add("width ", "100%");
            this.framelist1.Attributes.Add("onload ", "this.height=30");
        }

        public void BindIframe2()
        {
            this.framelist2.Attributes.Add("src ", "../tbLevelOrder/AcceptTrack.aspx?TrackAcceptID=" + tbAcceptUserID.Text);
            this.framelist2.Attributes.Add("width ", "100%");
            this.framelist2.Attributes.Add("onload ", "this.height=30");
        }

        public string ColorCustomerID(string OPID)
        {
            if (OPID != "")
            {
                return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
            }
            else
            {
                return "";
            }
        }

        private string LockCancelStatus(string SerialNo)
        {
            DataSet ds = BusinessFacadeDLT.LockCancelStatus(SerialNo);
            if (ds != null && ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["LockCancel"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
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

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            string result = BusinessFacadeDLT.AddOrderJudg(txtOrder.Text).Tables[0].Rows[0][0].ToString();
            if (result == "-1")
            {
                Response.Write("<script language='javascript'>alert('添加失败！该订单已添加为重判订单!');</script>");
                return;
            }
            else if (result == "1")
            {
                Response.Write("<script language='javascript'>alert('添加成功!');</script>");
                BindDataList();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('添加失败！该订单不符合重判条件!');</script>");
                return;
            }
        }

        private void ReJudgComment(string SerialNo)
        {
            QueryParam qp = new QueryParam();
            qp.Where = " Where 1=1 AND ODSerialNo = '" + SerialNo + "'";
            DataSet ds = BusinessFacadeDLT.LevelOrderJudgList(1, 1, qp.Where);

            tbReJudgComment.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

            if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
            {
                tbReJudgComment.Enabled = true;
                btnReJudgComment.Visible = true;
            }
            else
            {
                tbReJudgComment.Enabled = false;
                btnReJudgComment.Visible = false;
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item||e.Item.ItemType== ListItemType.AlternatingItem)
            {
                Panel panel2 = e.Item.FindControl("Panel2") as Panel;
                CheckBox cbColor = e.Item.FindControl("cbColor") as CheckBox;
                HiddenField hfColor = (HiddenField)e.Item.FindControl("hfColor");

                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    panel2.Visible = true;
                    cbColor.Visible = true;
                }
                else
                {
                    panel2.Visible = false;
                    cbColor.Visible = false;
                }

                if (hfColor.Value == "1")
                {
                    cbColor.Checked = true;
                    if ((e.Item.ItemIndex + 1) != AspNetPager10.RecordCount)
                    {
                        ((HtmlControl)e.Item.FindControl("row")).Style["Color"] = "#FF0000";
                    }
                    else
                    {
                        cbColor.Visible = false;
                        panel2.Visible = false;
                    }
                }
                else
                {
                    cbColor.Checked = false;
                }


            }
        }

        protected void cbColor_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbColor = (CheckBox)sender;
            string ID = cbColor.ValidationGroup;
            if (cbColor.Checked)
            {
                BusinessFacadeDLT.UpdateRejudgColor(ID, 1);
            }
            else
            {
                BusinessFacadeDLT.UpdateRejudgColor(ID, 0);
            }
            DataBindReJudgList(U_SerialNo_Txt.Text);
            Panel1.Visible = false;
            divReJudgList.Visible = true;
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }
    }
}
