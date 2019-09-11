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

namespace DaiLianTong.Web.Module.DaiLianTong.tbLevelOrderDel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                OnStart();
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
            if (ddlKeyword.Text == "删除客服")
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

            string delType = "0";

            if (ddlDelType.SelectedValue == "无限制")
            {
                delType = "0";
            }
            else if (ddlDelType.SelectedValue == "客服删除")
            {
                delType = "2";
            }
            else
            {
                delType = "1";
            }

            if (ddlKeyword.Text == "订单标题" || ddlKeyword.Text == "角色名")
            {
                keyText = keyText.Replace("'", "''");
            }


            if (ddlCancelStatus.SelectedValue == "15")
            {
                //按完成时间排序,存储过程排序按照完成时间
                ds = BusinessFacadeDLT.OrderSelectDel(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "1", delType, ddlGame.SelectedValue);
            }
            else
            {
                ds = BusinessFacadeDLT.OrderSelectDel(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlKeyword.Text, keyText, E_Status.Text, ddlCancelStatus.Text, cbHisOrder.Checked, qp.PageIndex, qp.PageSize, "0", delType, ddlGame.SelectedValue);
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
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
                /*更新首查*/
                BusinessFacadeDLT.MarkFirstViewOrder(SerialNo, Common.Get_UserID);
                TabOptionWebControls1.SelectIndex = 2;
                View_OrderInfo(SerialNo, 1);
                BindDataList();
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
            string delType = "0";

            if (ddlDelType.SelectedValue == "无限制")
            {
                delType = "0";
            }
            else if (ddlDelType.SelectedValue == "客服删除")
            {
                delType = "2";
            }
            else
            {
                delType = "1";
            }

            DataSet ds = null;
            ds = BusinessFacadeDLT.GetOrderDel(SerialNo, delType);

            lb_Title2.Text = "订单详情";
            U_SerialNo_Txt.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            U_CreateDate_Txt.Text = ds.Tables[0].Rows[0]["CreateDate"].ToString();
            U_GameServer_Txt.Text = ds.Tables[0].Rows[0]["GameServer"].ToString();
            U_Title_Txt.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            U_Bal_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Price"]).ToString("0.00");
            U_Ensure1_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Ensure1"]).ToString("0.00");
            U_Ensure2_Txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["Ensure2"]).ToString("0.00");
            U_TimeLimit_Txt.Text = ds.Tables[0].Rows[0]["TimeLimit"].ToString();
            U_ActorName_Txt.Text = ds.Tables[0].Rows[0]["Actor"].ToString();
            U_CurrInfo_Txt.Text = ds.Tables[0].Rows[0]["CurrInfo"].ToString();
            U_Require_Txt.Text = ds.Tables[0].Rows[0]["Require"].ToString();
            U_PublishUser_Txt.Text = ds.Tables[0].Rows[0]["PublishUser"].ToString();
            lblPostID.Text = ds.Tables[0].Rows[0]["UID"].ToString();

            U_ActorCount.Text = "【" + ds.Tables[0].Rows[0]["ActorCount"].ToString() + "】";

            U_PubContactway_Txt.Text = ds.Tables[0].Rows[0]["PubContactway"].ToString();
            U_PubOrderInfo_Txt.Text = "【总发：" + ds.Tables[0].Rows[0]["PubCount"].ToString() + " 总撤：" + ds.Tables[0].Rows[0]["PubCancelCount"].ToString() + " 介入撤：" + ds.Tables[0].Rows[0]["PubCancel"].ToString() + " 协商撤：" + ds.Tables[0].Rows[0]["PubConsultCancel"].ToString() + "】";
           
            ViewState["SearchTerms"] = " and a.ODSerialNo = '" + SerialNo + "'";

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
            //string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            //string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            //string IDX = "";
            //string Err_Value = "";
            //for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            //{
            //    IDX = Checkbox_Value_Array[i];
            //    if (IDX != "")
            //    {
            //        if (cbSetRightLock.Checked)
            //        {
            //            //同时打开此发单用户的发单权限
            //            string userID = BusinessFacadeDLT.GetOrderDel(IDX, 0).Tables[0].Rows[0]["UserID"].ToString();
            //            BusinessFacadeDLT.SetUserLock(int.Parse(userID), 10, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), DateTime.Parse(DateTime.Now.AddYears(10).ToString("yyyy-MM-dd HH:mm:ss")), "客服还原订单同时打开权限", 0);
            //        }

            //        //还原订单
            //        DataSet ds = BusinessFacadeDLT.OrderDelete(IDX,UserData.GetUserDate.UserID);

            //        if (ds != null)
            //        {
            //            if (ds.Tables[0].Rows[0][0].ToString() != "1")
            //            {
            //                if (Err_Value != "")
            //                {
            //                    Err_Value += ",";
            //                }
            //                Err_Value += IDX;
            //                Checkbox_Value = Checkbox_Value.Replace(IDX + ",", "");
            //                Checkbox_Value = Checkbox_Value.Replace(IDX, "");
            //            }
            //        }
            //    }
            //}


            //if (Err_Value != "")
            //{
            //    EventMessage.MessageBox(1, "批量删除结果", string.Format("批量删除({0})成功!", Checkbox_Value) + "<br />" + string.Format("批量删除({0})失败!", Err_Value), Icon_Type.Alert, Common.GetHomeBaseUrl("default.aspx"));
            //}
            //else
            //{
            //    EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
            //}
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




        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('OrderProgress.aspx?SerialNo=" + U_SerialNo_Txt.Text + "','_blank')</script>");
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

    }
}
