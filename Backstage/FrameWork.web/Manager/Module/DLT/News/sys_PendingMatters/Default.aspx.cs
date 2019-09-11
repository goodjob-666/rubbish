/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            sys_PendingMatters列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2015/5/20 18:51:40
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
using System.Text.RegularExpressions;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.sys_PendingMatters
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                P_CreateDate_Input.Text = (DateTime.Now.AddDays(-14)).Date.ToString("yyyy-MM-dd");
                P_CreateDate_Input_E.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDataList();
            }
        }

        public string PendingType(string typeid)
        {
            string typeName = "";
            switch (typeid)
            {
                case "1":
                    typeName = "客服部";
                    break;
                case "2":
                    typeName = "介入部";
                    break;
                case "3":
                    typeName = "投诉";
                    break;
                case "4":
                    typeName = "其它";
                    break;
            }
            return typeName;
        }

        public string FomartContent(string content)
        {
            string str="";
            str=LostHTML(content);
            if(str.Length>10)
            {
                str=str.Substring(0,10)+"...";
            }
            return str;
        }

        public string LostHTML(string Htmlstring)
        {
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        public string DealType(string typeid)
        {
            string typeName = "";
            switch (typeid)
            {
                case "0":
                    typeName = "未处理";
                    break;
                case "1":
                    typeName = "处理中";
                    break;
                case "2":
                    typeName = "待确定";
                    break;
                case "3":
                    typeName = "已处理";
                    break;
                
            }
            return typeName;
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
            List<sys_PendingMattersEntity> lst = BusinessFacadeDLT.sys_PendingMattersList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
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
            string P_Type_Value = (string)Common.sink(ddlPendingMattersType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string P_UserID_Value = (string)Common.sink(P_UserID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string P_Contact_Value = (string)Common.sink(P_Contact_Input.UniqueID, MethodType.Post, 300, 0, DataType.Str);
            string P_OrderNum_Value = (string)Common.sink(P_OrderNum_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string P_Content_Value = (string)Common.sink(P_Content_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            string P_PostID_Value = (string)Common.sink(P_PostID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string P_ReplyID_Value = (string)Common.sink(P_ReplyID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string P_ReContent_Value = (string)Common.sink(P_ReContent_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            string P_IsDeal_Value = (string)Common.sink(P_IsDeal_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string P_Pre1_Value = (string)Common.sink(P_Pre1_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string P_Pre2_Value = (string)Common.sink(P_Pre2_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);

            DateTime? P_CreateDate_Input_Value = (DateTime?)Common.sink(P_CreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? P_CreateDate_Input_E_Value = (DateTime?)Common.sink(P_CreateDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            string P_Pre4_Value = (string)Common.sink(P_Pre4_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (P_PostID_Value != "")
            {
                if (UserData.Get_sys_UserTable1(P_PostID_Value) != null)
                {
                    P_PostID_Value = UserData.Get_sys_UserTable1(P_PostID_Value).UserID.ToString();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('记录客服ID输入错误！');</script>");
                    return;
                }
            }
            if (P_ReplyID_Value != "")
            {
                if (UserData.Get_sys_UserTable1(P_ReplyID_Value) != null)
                {
                    P_ReplyID_Value = UserData.Get_sys_UserTable1(P_ReplyID_Value).UserID.ToString();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('回复客服ID输入错误！');</script>");
                    return;
                }
            }

            if (P_Type_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Type = {0} ", Convert.ToInt32(P_Type_Value));
            }

            if (P_UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_UserID like '%{0}%' ", Common.inSQL(P_UserID_Value));
            }

            if (P_Contact_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Contact like '%{0}%' ", Common.inSQL(P_Contact_Value));
            }

            if (P_OrderNum_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_OrderNum like '%{0}%' ", Common.inSQL(P_OrderNum_Value));
            }

            if (P_Content_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Content like '%{0}%' ", Common.inSQL(P_Content_Value));
            }

            if (P_PostID_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_PostID = {0} ", Convert.ToInt32(P_PostID_Value));
            }

            if (P_ReplyID_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_ReplyID = {0} ", Convert.ToInt32(P_ReplyID_Value));
            }

            if (P_ReContent_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_ReContent like '%{0}%' ", Common.inSQL(P_ReContent_Value));
            }

            if (P_IsDeal_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_IsDeal = {0} ", Convert.ToInt32(P_IsDeal_Value));
            }

            if (P_Pre1_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Pre1 = {0} ", Convert.ToInt32(P_Pre1_Value));
            }

            if (P_Pre2_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Pre2 like '%{0}%' ", Common.inSQL(P_Pre2_Value));
            }


            if (P_Pre4_Value != string.Empty)
            {
                sb.AppendFormat(" AND P_Pre4 like '%{0}%' ", Common.inSQL(P_Pre4_Value));
            }


            if (P_CreateDate_Input_Value.HasValue && P_CreateDate_Input_E_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and P_CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", P_CreateDate_Input_Value.Value.Date.ToShortDateString(), P_CreateDate_Input_E_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and P_CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", P_CreateDate_Input_Value.Value.Date.ToShortDateString(), P_CreateDate_Input_E_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and P_CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", P_CreateDate_Input.Text, P_CreateDate_Input_E.Text));
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

                    ViewState["sortOrderfld"] = "P_ID";

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
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "P_ID"));
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
                    sys_PendingMattersEntity et = new sys_PendingMattersEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.P_ID = IDX;
                    BusinessFacadeDLT.sys_PendingMattersInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
