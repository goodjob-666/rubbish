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
using System.Text.RegularExpressions;
using System.IO;
using Aliyun.OpenServices.OpenStorageService;

namespace DaiLianTong.Web.Module.DaiLianTong.Order
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
                S_dtDate_Input.Text = (DateTime.Now.AddMonths(-3)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtFZStart.Text = (DateTime.Now.AddMonths(-1)).Date.ToString("yyyy-MM-dd");
                txtFZEnd.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtLockStart.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtLockEnd.Text = (DateTime.Now.AddDays(3)).Date.ToString("yyyy-MM-dd");
                OnStart();
                Button2.Attributes.Add("onclick", "return confirm('您真的要强制完单吗？')");
                Button6.Attributes.Add("onclick", "return confirm('您真的要给该用户增加跟踪记录吗？')");
                cbReport.Attributes.Add("onclick", "return myConfirm(this);");
                cbReport1.Attributes.Add("onclick", "return myConfirm1(this);");
                BindSearchType();
                TabOptionWebControls1.SelectIndex = 1;
                //处理请求客服协助过来的
                if (Request["SerialNo"] != null)
                {
                    string SerialNo = Request["SerialNo"].ToString();
                    TabOptionWebControls1.SelectIndex = 2;
                    View_OrderInfo(SerialNo, 1);
                    BindDataList();
                }
                else if (Request["Actor"] != null)
                {
                    string Actor = Request["Actor"].ToString();
                    S_dtDate_Input.Text = (DateTime.Now.AddMonths(-3)).Date.ToString("yyyy-MM-dd");
                    ddlKeyword.SelectedValue = "角色名";
                    //string tmpStr = "";
                    //char[] charStr = Actor.ToCharArray();
                    ////韩文转unicode
                    //for (int i = 0; i < charStr.Length; i++)
                    //{
                    //    if (IsValidKorean(charStr[i].ToString()))
                    //    {
                    //        tmpStr += Regex.Unescape(charStr[i].ToString());
                    //    }
                    //    else
                    //    {
                    //        tmpStr += charStr[i].ToString();
                    //    }
                    //}
                    ddlGame.SelectedValue = Request["GameID"].ToString();
                    SearchText_Input.Text = Actor;
                    E_Status.SelectedValue = "-1";
                    ddlCancelStatus.SelectedValue = "-1";
                    AspNetPager1.CurrentPageIndex = 1;
                    BindDataList();
                    TabOptionWebControls1.SelectIndex = 0;
                }
            }

            if (FrameWorkPermission.CheckButtonPermission(PopedomType.Orderby))
            {
                TabOptionItem5.Visible = true;
                TabOptionItem4.Visible = true;

            }
            else
            {
                TabOptionItem5.Visible = false;
                TabOptionItem4.Visible = false;

            }
        }

        public bool IsValidKorean(string korean)
        {
            //Regex regex = new Regex(@"^.[\uac00-\ud7af\u1100-\u11FF\u3130-\u318f]+$");
            //Regex regex = new Regex(@"^.[\uac00-\ud7af\u1100-\u11FF\u3130-\u318f]+$");
            //return regex.IsMatch(korean);
            return Regex.IsMatch(korean, @"^[\uac00-\ud7ff]+$");
        }

        public string SActor()
        {
            return tbDataActorName.Text;
        }
        public string GameID()
        {
            return ddlGame.SelectedValue;
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        /// 
        public string IsCustomerID(int CustomerID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [CustomerID]=" + CustomerID.ToString();

            List<tbAppointArbitrationEntity> lst = BusinessFacadeDLT.tbAppointArbitrationList(qp, out RecordCount);

            if (lst.Count > 0)
            {
                return lst[0].UserID.ToString();
            }
            else
            {
                return "-1";
            }


        }

        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            if (ddlCancelStatus.SelectedValue == "14")
            {
                qp.PageIndex = AspNetPager2.CurrentPageIndex;
                qp.PageSize = AspNetPager2.PageSize;
            }
            else
            {
                qp.PageIndex = AspNetPager1.CurrentPageIndex;
                qp.PageSize = AspNetPager1.PageSize;
            }
            int RecordCount = 0;
            DataSet ds = null;

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

            if (ddlKeyword.Text == "角色名")
            {
                string tmpStr = "";
                char[] charStr = keyText.ToCharArray();
                //韩文转unicode
                for (int i = 0; i < charStr.Length; i++)
                {
                    if (IsValidKorean(charStr[i].ToString()))
                    {
                        tmpStr += Chinese2Unicode(charStr[i].ToString());
                    }
                    else
                    {
                        tmpStr += charStr[i].ToString();
                    }
                }
                keyText = tmpStr;
            }

            string appointUser = "";

            //判断是否规则外后台用户
            if (
                (AllRuleOut().IndexOf(BusinessFacade.sys_UserDisp(Common.Get_UserID).U_LoginName) == -1) &&
                (cbGood.Checked == false)
                )
            {
                //判断当前判单客服是否有被指定固定上家
                if (IsCustomerID(Common.Get_UserID) != "-1")
                {
                    string[] arr = null;
                    string[] arr1 = null;
                    string s = "";

                    if (IsCustomerID(Common.Get_UserID).IndexOf(',') > 0)
                    {
                        arr = IsCustomerID(Common.Get_UserID).ToString().Split(',');
                    }
                    else
                    {
                        arr = new string[] { IsCustomerID(Common.Get_UserID).ToString() };
                    }

                    if (AllAppointArbitration().IndexOf(',') > 0)
                    {
                        arr1 = AllAppointArbitration().Split(',');
                    }
                    else
                    {
                        arr1 = new string[] { AllAppointArbitration() };
                    }


                    ArrayList arrSysParam = new ArrayList();

                    for (int z = 0; z < arr1.Length; z++)
                    {
                        arrSysParam.Add(arr1[z]);
                    }

                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arrSysParam.Contains(arr[j]))
                        {
                            arrSysParam.Remove(arr[j]);
                        }
                    }

                    for (int k = 0; k < arrSysParam.Count; k++)
                    {
                        s += arrSysParam[k].ToString() + ",";
                    }

                    if (s != "")
                    {
                        appointUser = s.Substring(0, s.Length - 1);
                    }
                    else
                    {
                        appointUser = "";
                    }

                }
                else
                {
                    appointUser = AllAppointArbitration();
                }
            }

            string isPub = "";

            if (cbGood.Checked)
            {
                isPub = "2";
            }

            if (ddlCancelStatus.SelectedValue == "15")
            {
                //按完成时间排序,存储过程排序按照完成时间
                ds = BusinessFacadeDLT.OrderSelect(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "1", ddlGame.SelectedValue, appointUser, isPub);
            }
            else
            {
                ds = BusinessFacadeDLT.OrderSelect(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "0", ddlGame.SelectedValue, appointUser, isPub);
            }

            if (ddlCancelStatus.SelectedValue == "14")
            {
                GridView1.Visible = false;
                AspNetPager1.Visible = false;
                GridView2.DataSource = ds.Tables[0];
                GridView2.DataBind();
                GridView2.Visible = true;
                AspNetPager2.Visible = true;
                if (int.Parse(ds.Tables[1].Rows[0][0].ToString()) > 1000)
                {
                    RecordCount = 1000;
                }
                else
                {
                    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                }
                lblJRCount.Text = "<font style=\"font-weight:bold\">&nbsp;当前介入订单总数(大于2小时)：" + ds.Tables[1].Rows[0][0].ToString() + "&nbsp;&nbsp;实际介入订单总数：" + ds.Tables[2].Rows[0][0].ToString() + "</font>";
                this.AspNetPager2.RecordCount = RecordCount;
            }
            else
            {
                GridView2.Visible = false;
                AspNetPager2.Visible = false;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView1.Visible = true;
                AspNetPager1.Visible = true;
                RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                lblJRCount.Text = "";
                this.AspNetPager1.RecordCount = RecordCount;
            }

        }

        public string AllRuleOut()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where ID = 1030";

            List<tsSysParamEntity> lst = BusinessFacadeDLT.tsSysParamList(qp, out RecordCount);
            return lst[0].Value;
        }

        public string AllAppointArbitration()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where ID = 1027";

            List<tsSysParamEntity> lst = BusinessFacadeDLT.tsSysParamList(qp, out RecordCount);
            return lst[0].Value;
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


        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OrderDetail")
            {
                string SerialNo = e.CommandArgument.ToString();
                if (SerialNo == "")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int index = row.RowIndex;
                    SerialNo = GridView3.Rows[index].Cells[2].Text;
                }
                if (SerialNo == "")
                {
                    Response.Write("<script language='javascript'>alert('一次只能查看一个订单详情，请不要勾选多个查看！');</script>");
                    return;
                }
                else
                {
                    /*更新首查*/
                    // BusinessFacadeDLT.MarkFirstViewOrder(SerialNo, Common.Get_UserID);
                    TabOptionWebControls1.SelectIndex = 2;
                    View_OrderInfo(SerialNo, 1);
                    BindDataList1();
                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OrderDetail")
            {
                string SerialNo = e.CommandArgument.ToString();
                if (SerialNo == "")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int index = row.RowIndex;
                    SerialNo = GridView2.Rows[index].Cells[2].Text;
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
            BindGameList();
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
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            BindDataList1();
            TabOptionWebControls1.SelectIndex = 4;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlKeyword.SelectedValue == "订单号")
            {
                string titleMessage = "订单号:" + SearchText_Input.Text + "执行查询!";
                EventMessage.EventWriteDB(1, titleMessage);
            }

            if (ddlCancelStatus.SelectedValue != "14")
            {
                if (SearchText_Input.Text == "" && ddlKeyword.SelectedValue != "QQ号")
                {
                    TabOptionWebControls1.SelectIndex = 1;
                    Response.Write("<script language='javascript'>alert('请输入搜索关键字内容！');</script>");
                    return;
                }
                else
                {
                    AspNetPager1.CurrentPageIndex = 1;
                    BindDataList();
                    TabOptionWebControls1.SelectIndex = 0;
                }
            }
            else
            {
                if (ddlKeyword.SelectedValue == "订单标题" || ddlKeyword.SelectedValue == "用户编码" || ddlKeyword.SelectedValue == "订单金额等于" || ddlKeyword.SelectedValue == "订单金额大于等于" || ddlKeyword.SelectedValue == "发单数小于" || ddlKeyword.SelectedValue == "总保证金大于")
                {
                    TabOptionWebControls1.SelectIndex = 1;
                    Response.Write("<script language='javascript'>alert('暂不允许以此条件进行查询！');</script>");
                    return;
                }
                else
                {
                    AspNetPager1.CurrentPageIndex = 1;
                    BindDataList();
                    TabOptionWebControls1.SelectIndex = 0;
                }
            }
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

        private string Chinese2Unicode(string strChinese)
        {
            string strUnicodes = string.Empty;
            foreach (char item in strChinese.ToCharArray())
            {
                strUnicodes += "\\u" + ((int)item).ToString("x"); //16进制
            }
            return strUnicodes;
        }

        /// <summary>
        /// 单个订单查询
        /// </summary>
        /// <param name="SerialNo"></param>
        /// <param name="iType"></param>
        private void View_OrderInfo(string SerialNo, int iType)
        {
            lblUpdateComment.Text = "";
            DataSet ds = null;
            DisScreen.Attributes.Add("onclick", "window.open('OrderProgress.aspx?SerialNo=" + SerialNo + "','_blank')");

            int IsHisOrder = 0;
            if (cbHisOrder.Checked)
            {
                IsHisOrder = 1;
            }
            ds = BusinessFacadeDLT.GetOrder(SerialNo, IsHisOrder);

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

            switch (ds.Tables[0].Rows[0]["IsPub"].ToString())
            {
                case "0":
                    lblIsPub.Text = "内部";
                    break;
                case "1":
                    lblIsPub.Text = "公共";
                    break;
                case "2":
                    lblIsPub.Text = "优质";
                    break;
            }

            //2016-04-24 更新客服看卡密

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

            //设置首查人后面组长名字显示
            if (U_FirstOPName_Txt.Text != "" && U_FirstOPName_Txt.Text != "0")
            {
                string sysUser = GetSysUserInfo(int.Parse(ds.Tables[0].Rows[0]["FirstCustomerID"].ToString()));
                switch (sysUser)
                {
                    case "1":
                        U_FirstOPName_Txt.Text += " (彭)";
                        break;
                    case "2":
                        U_FirstOPName_Txt.Text += " (浣)";
                        break;
                    default:
                        break;
                }
            }

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

            lbUserID.Text = lblPostTrackUserID.Text = tbCreateOpID.Text;
            lbUserDesc.Text = "[发单者]";
            //BindDataList3();

            tbAcceptOpID.Text = ds.Tables[0].Rows[0]["AcceptID"].ToString();

            lbUserID1.Text = lblAcceptTrackUserID.Text = tbAcceptOpID.Text;

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

            TextBox1.Text = GetComment(lbUserID.Text);
            TextBox2.Text = GetComment(lbUserID1.Text);



            U_AcceptUser_Txt.Text = ds.Tables[0].Rows[0]["AccepLoginID"].ToString() + "/" + ds.Tables[0].Rows[0]["AcceptUser"].ToString();
            U_AccContactway_Txt.Text = ds.Tables[0].Rows[0]["AccContactway"].ToString();
            if (tbAcceptOpID.Text != "")
            {
                U_AccOrderInfo_Txt.Text = "【总接：" + ds.Tables[0].Rows[0]["AcceptCount"].ToString() + " 总撤：" + ds.Tables[0].Rows[0]["AcceptCancelCount"].ToString() + " 介入撤：" + ds.Tables[0].Rows[0]["AcceptCancel"].ToString() + " 协商撤：" + ds.Tables[0].Rows[0]["AcceptConsultCancel"].ToString() + "】";
            }
            tbComment.Text = Unicode2Chinese(ds.Tables[0].Rows[0]["BackComment"].ToString());
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

            //超时时间计算
            if (U_BeginTime_Txt.Text != "")
            {
                lblOverTime.Text = Convert.ToDateTime(U_BeginTime_Txt.Text).AddHours(int.Parse(U_TimeLimit_Txt.Text)).ToString("yyyy/MM/dd HH:mm:ss");
            }

            lblPostStatus.Text = " | " + XQStatus(tbUserID.Text);
            lblAcceptStatus.Text = " | " + XQStatus(tbAcceptUserID.Text);

            //上家举报
            ReportStatus(SerialNo, int.Parse(tbUserID.Text));

            //下家举报
            if (tbAcceptUserID.Text != "0")
            {
                cbReport1.Visible = true;
                lblReport1.Visible = true;

                ReportStatus1(SerialNo, int.Parse(tbAcceptUserID.Text));
            }
            else
            {
                cbReport1.Visible = false;
                lblReport1.Visible = false;
            }

            lblGoodPost.Text = GoodPost(tbUserID.Text);
            lblGoodAccept.Text = GoodAccept(tbAcceptUserID.Text);

            BindPostMacList();
            BindAcceptMacList();

            ViewState["SearchTerms"] = " and a.ODSerialNo = '" + SerialNo + "'";
            BindIframe();
            BindIframe1();
            BindIframe2();
        }



        private string GetSysUserInfo(int OPID)
        {
            DataSet ds = BusinessFacadeDLT.GetSysUserInfo(OPID);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["U_SGroupID"].ToString();
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
            catch
            {
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


        protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
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
                        DataIDX = DataBinder.Eval(e.Row.DataItem, "SerialNo").ToString();
                        TableCell cell = new TableCell();
                        cell.Width = Unit.Pixel(5);
                        cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                        e.Row.Cells.AddAt(0, cell);
                    }
                }
            }
        }

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

            if (cbDelRemark.Checked)
            {
                if (txtDelRemark.Text == "")
                {
                    Response.Write("<script language='javascript'>alert('删除原因不能为空！');</script>");
                    return;
                }
            }

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

                    if (cbDelRemark.Checked)
                    {
                        //添加删除原因
                        BusinessFacadeDLT.OrderDeleteAddRemark(IDX, txtDelRemark.Text);
                    }



                    //删除订单
                    DataSet ds = BusinessFacadeDLT.OrderDelete(IDX, UserData.GetUserDate.UserID);

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

        public void BindIframe()
        {
            this.framelist.Attributes.Add("src ", "OrderMessage.aspx?SerialNo=" + U_SerialNo_Txt.Text + "&PostID=" + tbCreateOpID.Text);
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
                lblUpdateComment.Text = "已修改";
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

        protected void cbReport_CheckedChanged(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "" && tbUserID.Text != "")
            {
                if (cbReport.Checked)
                {
                    //插入举报信息
                    tbPostReportEntity ut = BusinessFacadeDLT.tbPostReportDisp(0);

                    ut.SerialNo = U_SerialNo_Txt.Text;
                    ut.UserID = int.Parse(tbUserID.Text);
                    ut.ReportCustomerID = Common.Get_UserID;
                    ut.CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    ut.DataTable_Action_ = DataTable_Action.Insert;
                    Int32 rInt = BusinessFacadeDLT.tbPostReportInsertUpdateDelete(ut);
                    if (rInt > 0)
                    {
                        Response.Write("<script language='javascript'>alert('设置成功！');</script>");
                        BindDataList();
                        cbReport.Enabled = true;
                    }
                }
            }
        }

        protected void cbReport1_CheckedChanged(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "" && tbUserID.Text != "")
            {
                if (cbReport1.Checked)
                {
                    //插入举报信息
                    tbPostReportEntity ut = BusinessFacadeDLT.tbPostReportDisp(0);

                    ut.SerialNo = U_SerialNo_Txt.Text;
                    ut.UserID = int.Parse(tbAcceptUserID.Text);
                    ut.ReportCustomerID = Common.Get_UserID;
                    ut.CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    ut.Remark = "1";
                    ut.DataTable_Action_ = DataTable_Action.Insert;
                    Int32 rInt = BusinessFacadeDLT.tbPostReportInsertUpdateDelete(ut);
                    if (rInt > 0)
                    {
                        Response.Write("<script language='javascript'>alert('设置成功！');</script>");
                        BindDataList();
                        cbReport1.Enabled = true;
                    }
                }
            }
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


        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tmpstr = DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString();

                if (tmpstr != "0")
                {
                    e.Row.ForeColor = Color.MediumVioletRed;
                }


                Label lblFirstDate = e.Row.FindControl("lblFirstDate") as Label;

                Label lblDateSpan = e.Row.FindControl("lblDateSpan") as Label;

                if (lblFirstDate.Text != "")
                {
                    DateTime startTime = Convert.ToDateTime(lblFirstDate.Text);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    lblDateSpan.Text = Math.Floor(ts.TotalHours).ToString();
                }

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tmpstr = DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString();

                if (tmpstr != "0")
                {
                    e.Row.ForeColor = Color.MediumVioletRed;
                }


                Label lblFirstDate = e.Row.FindControl("lblFirstDate") as Label;

                Label lblDateSpan = e.Row.FindControl("lblDateSpan") as Label;

                if (lblFirstDate.Text != "")
                {
                    DateTime startTime = Convert.ToDateTime(lblFirstDate.Text);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    lblDateSpan.Text = Math.Floor(ts.TotalHours).ToString();
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

        public string ReportDeal(string serialNo)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [SerialNo]='" + serialNo + "'";
            List<tbPostReportEntity> lst = BusinessFacadeDLT.tbPostReportList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                return lst[0].Status.ToString();
            }
            else
            {
                return "";
            }
        }


        public void ReportStatus(string serialNo, int userID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [SerialNo]='" + serialNo + "' and UserID=" + userID.ToString();
            List<tbPostReportEntity> lst = BusinessFacadeDLT.tbPostReportList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                cbReport.Checked = true;
                cbReport.Enabled = false;
                if (lst[0].Status.ToString() == "1")
                {
                    lblReport.Text = "【举报已处理！】";
                }
                else
                {
                    lblReport.Text = "";
                }
            }
            else
            {
                cbReport.Checked = false;
                cbReport.Enabled = true;
                lblReport.Text = "";
            }
        }

        public void ReportStatus1(string serialNo, int userID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [SerialNo]='" + serialNo + "' and UserID=" + userID.ToString();
            List<tbPostReportEntity> lst = BusinessFacadeDLT.tbPostReportList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                cbReport1.Checked = true;
                cbReport1.Enabled = false;
                if (lst[0].Status.ToString() == "1")
                {
                    lblReport1.Text = "【举报已处理！】";
                }
                else
                {
                    lblReport1.Text = "";
                }
            }
            else
            {
                cbReport1.Checked = false;
                cbReport1.Enabled = true;
                lblReport1.Text = "";
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

        public string GetComment(string UID)
        {
            if (UID != "")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [UID]='" + UID + "'";
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].Comment;
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

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "" && lbUserID.Text != "")
            {
                DataSet ds = BusinessFacadeDLT.UpdateUserComment(TextBox1.Text, lbUserID.Text);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            if (U_SerialNo_Txt.Text != "" && lbUserID1.Text != "")
            {
                DataSet ds = BusinessFacadeDLT.UpdateUserComment(TextBox2.Text, lbUserID1.Text);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改备注成功！');</script>");
                }
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

        protected void Button9_Click(object sender, EventArgs e)
        {
            //提醒补全信息
            BusinessFacadeDLT.LevelOrderMarkColor(U_SerialNo_Txt.Text, Common.Get_UserID.ToString());
            Response.Write("<script language='javascript'>alert('提醒上家补全信息成功!');</script>");
            View_OrderInfo(U_SerialNo_Txt.Text, 1);
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

        public string RightLock(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1005 and Kind=" + status;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
        }

        public string GoodPost(string userID)
        {
            string result = "";

            DataTable dt = BusinessFacadeDLT.IsGoodPost(userID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = "优质上家";
            }

            return result;
        }

        public string GoodAccept(string userID)
        {
            string result = "";

            DataTable dt = BusinessFacadeDLT.IsGoodAccept(userID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string level = dt.Rows[0]["ApplyTier"].ToString();
                switch (level)
                {
                    case "10":
                        level = "青铜";
                        break;
                    case "11":
                        level = "白银";
                        break;
                    case "12":
                        level = "黄金";
                        break;
                    case "13":
                        level = "白金";
                        break;
                    case "14":
                        level = "钻石";
                        break;
                    case "15":
                        level = "大师";
                        break;
                    case "16":
                        level = "王者";
                        break;
                }

                result = level + "优质下家";
            }

            return result;
        }

        protected void btnSeeAccPwd_Click(object sender, EventArgs e)
        {
            if (FrameWorkPermission.CheckButtonPermission(PopedomType.Print))
            {
                if (U_SerialNo_Txt.Text != "")
                {
                    DataTable dt = BusinessFacadeDLT.SearchAccPwd(U_SerialNo_Txt.Text, Common.Get_UserID).Tables[0];
                    if (dt != null)
                    {
                        if (dt.Rows[0][0].ToString() != "-1")
                        {
                            string titleMessage = "订单:" + U_SerialNo_Txt.Text + "查询角色帐号密码成功！";
                            EventMessage.EventWriteDB(1, titleMessage);
                            lblGameAcc.Text = "帐号：" + dt.Rows[0][0].ToString() + "，密码：" + dt.Rows[0][1].ToString();
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('抱歉，权限不够！');</script>");
                            return;
                        }
                    }

                }
                else
                {
                    Response.Write("<script language='javascript'>alert('请先执行订单查询!');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('抱歉，权限不够！');</script>");
                return;
            }

        }


        private void BindSearchType()
        {

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = BusinessFacadeDLT.sys_StatisticalGroupingList(qp, out RecordCount);
            foreach (sys_StatisticalGroupingEntity var in lst)
            {
                DropDownList1.Items.Add(new ListItem(var.S_Name, var.S_ID.ToString()));
            }
        }

        //protected void btnReport_Click(object sender, EventArgs e)
        //{
        //    //插入举报信息
        //    tbPostReportEntity ut = BusinessFacadeDLT.tbPostReportDisp(0);

        //    ut.SerialNo = U_SerialNo_Txt.Text;
        //    ut.UserID = int.Parse(tbUserID.Text);
        //    ut.ReportCustomerID = Common.Get_UserID;
        //    ut.CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        //    ut.DataTable_Action_ = DataTable_Action.Insert;

        //    Int32 rInt = BusinessFacadeDLT.tbPostReportInsertUpdateDelete(ut);
        //    if (rInt > 0)
        //    {
        //        Response.Write("<script language='javascript'>alert('举报上家成功!');</script>");
        //        btnReport.Text = "已举报-未处理";
        //        btnReport.Enabled = false;
        //    }
        //    else
        //    {
        //        Response.Write("<script language='javascript'>alert('举报上家失败!');</script>");
        //    }
        //}


        protected void Button10_Click(object sender, EventArgs e)
        {
            AspNetPager3.CurrentPageIndex = 1;
            BindDataList1();
            TabOptionWebControls1.SelectIndex = 4;
        }

        private void BindDataList1()
        {

            QueryParam qp = new QueryParam();

            qp.PageIndex = AspNetPager3.CurrentPageIndex;
            qp.PageSize = AspNetPager3.PageSize;

            int RecordCount = 0;
            DataSet ds = null;

            string customerID = "";

            if (txtServiceLoginID.Text != "")
            {
                if (UserData.Get_sys_UserTable1(txtServiceLoginID.Text) != null)
                {
                    customerID = UserData.Get_sys_UserTable1(txtServiceLoginID.Text).UserID.ToString();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('客服登录ID输入有误，请重新输入!');</script>");
                    return;
                }
            }

            ds = BusinessFacadeDLT.OrderGroup(DateTime.Parse(txtFZStart.Text), DateTime.Parse(txtFZEnd.Text), customerID, DropDownList1.SelectedValue, qp.PageIndex, qp.PageSize);
            GridView3.Visible = false;
            AspNetPager3.Visible = false;
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;
            AspNetPager3.Visible = true;
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager3.RecordCount = RecordCount;
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            //插入数据库的同时插入阿里云OSS图片云存储
            if (!fileup.HasFile)
            {
                Response.Write("<script language='javascript'>alert('请先选择一个要上传的图片!');</script>");
                return;
            }

            if (!FileCheck(Path.GetExtension(fileup.FileName)))
            {
                Response.Write("<script language='javascript'>alert('请不要上传其它类型的文件，只能上传图片!');</script>");
                return;
            }
            string fullName = "";

            //后台图片特别命名，前面加web
            fullName = "Progress/" + DateTime.Now.ToString("yyyyMMdd") + "/" + "web_" + U_SerialNo_Txt.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(fileup.FileName);

            ObjectMetadata metadata = new ObjectMetadata();
            // 可以设定自定义的metadata。
            metadata.ContentType = fileup.PostedFile.ContentType;
            OssClient ossClient = new OssClient("5rjhbrqIfj2qjKdp", "bRpbO9TpUPVL2Vokv1AYr4meTPaMir");
            using (var fs = fileup.PostedFile.InputStream)
            {
                var ret = ossClient.PutObject("dltfile01", fullName, fs, metadata);
                //插入数据库

                BusinessFacadeDLT.AddLevelOrderProgress("10012", U_SerialNo_Txt.Text, UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName, "http://img001.dailiantong.com/" + fullName);

                Response.Write("<script language='javascript'>alert('客服图片上传成功!');</script>");
            }
        }

        private bool FileCheck(string ext)
        {
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".jpeg", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            int j = 0;
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (ext == allowExtension[i])
                {
                    return true;
                }
                else
                {
                    j++;
                }
            }
            if (j > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
