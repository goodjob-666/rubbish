/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            tbPostReport列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2015/12/23 15:35:26
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
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tbPostReport
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //BindDataList();
                //Button1_Click(null, null);
                TabOptionWebControls1.SelectIndex = 1;

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
            List<tbPostReportEntity> lst = BusinessFacadeDLT.tbPostReportList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;

            //加载统计
            DataTable dt = BusinessFacadeDLT.PostReportCount(Convert.ToDateTime(S_dtDate_Input.Text+" 00:00:00"), Convert.ToDateTime(E_dtDate_Input.Text+ " 23:59:59")).Tables[0];

            lblReportCount.Text = "<font color='red'>总举报数：" + dt.Rows[0]["ZJBCount"].ToString() + " 总封号数：" + dt.Rows[0]["ZFHCount"].ToString() + " 举报上家数：" + dt.Rows[0]["ZJBSCount"].ToString() + " 封号上家数：" + dt.Rows[0]["ZFHSCount"].ToString() + " 举报下家数：" + dt.Rows[0]["ZJBXCount"].ToString() + " 封号下家数：" + dt.Rows[0]["ZFHXCount"].ToString() + "</font>";

        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbIsDeal = (CheckBox)e.Row.FindControl("cbIsDeal");
                HiddenField hf = (HiddenField)e.Row.FindControl("hfIsDeal");

                if (hf.Value != "1")
                {
                    cbIsDeal.Checked = false;
                    cbIsDeal.Enabled = true;
                }
                else
                {
                    cbIsDeal.Checked = true;
                    cbIsDeal.Enabled = false;
                }

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

        public string DealCustomerID(string OPID)
        {
            if (OPID != "0")
            {
                return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
            }
            else
            {
                return "";
            }
        }

        public string IsDown(string remark)
        {
            if (remark == "1")
            {
                return " (下家)";
            }
            else
            {
                return "";
            }
        }

        protected void cbIsDeal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbIsDeal = (CheckBox)sender;
            string serialNo = cbIsDeal.ValidationGroup;

            if (cbIsDeal.Checked)
            {
                BusinessFacadeDLT.UpdatePostReport(serialNo, 1, Common.Get_UserID.ToString());
                BindDataList();
                Response.Write("<script language='javascript'>alert('设置成功!');</script>");
            }
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

        public string UID(string ID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]=" + ID;
            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            return lst[0].UID;
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
            string SerialNo_Value = (string)Common.sink(SerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);

            string DealCustomerID_Value = (string)Common.sink(DealCustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);

            string Status_Value = (string)Common.sink(Status_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Remark_Value = (string)Common.sink(Remark_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);


            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (UserID_Value.Trim() != string.Empty)
            {
                if (GetID(UserID_Value.Trim()) != "")
                {
                    sb.AppendFormat(" AND UserID = {0} ", Common.inSQL(GetID(UserID_Value.Trim())));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此上家ID，请重新输入上家ID');</script>");
                    return;
                }
            }


            if (ReportCustomerID_Input.Text != string.Empty)
            {
                //UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName
                if (UserData.Get_sys_UserTable1(ReportCustomerID_Input.Text) != null)
                {
                    int id = UserData.Get_sys_UserTable1(ReportCustomerID_Input.Text).UserID;
                    if (id != 0)
                    {
                        sb.AppendFormat(" AND ReportCustomerID = {0} ", Common.inSQL(id.ToString()));
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('举报客服ID输入错误！');</script>");
                    return;
                }

            }

            if (SerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND SerialNo='{0}' ", Common.inSQL(SerialNo_Value));
            }

            if (DealCustomerID_Value != string.Empty)
            {
                sb.AppendFormat(" AND DealCustomerID = {0} ", Convert.ToInt32(DealCustomerID_Value));
            }


            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND Status = {0} ", Convert.ToInt32(Status_Value));
            }

            if (Remark_Value != string.Empty)
            {
                sb.AppendFormat(" AND Remark like '%{0}%' ", Common.inSQL(Remark_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", S_dtDate_Input.Text, E_dtDate_Input.Text));
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
                    tbPostReportEntity et = new tbPostReportEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbPostReportInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
