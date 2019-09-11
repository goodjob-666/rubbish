/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            操作日志列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2014/8/5 13:39:35
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

namespace DLT.Web.Module.DLT.tlOperate
{
    public partial class Default : System.Web.UI.Page
    {
        public string UserID_Value;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    RequestSQL();
                }
                else
                {
                    TabOptionWebControls1.SelectIndex = 1;
                }
                //BindDataList();
                CreateDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                EndCreateDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindOPTypeList();
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
            DataSet ds = BusinessFacadeDLT.OperateList(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public void BindOPTypeList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1012";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlOPType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public string OPType(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1012 and Kind=" + type;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

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
                    ViewState["SearchTerms"] = " ";
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
            UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OPType_Value = (string)Common.sink(ddlOPType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string OPLog_Value = (string)Common.sink(OPLog_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(CreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(EndCreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UserID = '{0}' ", Common.inSQL(UserID_Value));
            }

            if (OPType_Value != string.Empty)
            {
                sb.AppendFormat(" AND OPType = {0} ", Convert.ToInt32(OPType_Value));
            }

            if (OPLog_Value != string.Empty)
            {
                sb.AppendFormat(" AND OPLog like '%{0}%' ", Common.inSQL(OPLog_Value));
            }
            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND IP like '{0}' ", Common.inSQL(IP_Value));
            }
            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and a.CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and a.CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and a.CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", CreateDate_Input.Text, EndCreateDate_Input.Text));
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }


        private void RequestSQL()
        {
            string RequestID_Value = "";
            if (Request["ID"] != null)
            {
                RequestID_Value = Request["ID"].ToString();
            }
            UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string OPType_Value = (string)Common.sink(ddlOPType.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string OPLog_Value = (string)Common.sink(OPLog_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IP_Value = (string)Common.sink(IP_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(CreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(EndCreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

            StringBuilder sb = new StringBuilder();

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UID = '{0}' ", Common.inSQL(UserID_Value));
                RequestID_Value = "";
            }

            if (RequestID_Value != string.Empty)
            {
                sb.AppendFormat(" AND B.ID ={0} ", Convert.ToInt32(RequestID_Value));
            }

            if (OPType_Value != string.Empty)
            {
                sb.AppendFormat(" AND OPType = {0} ", Convert.ToInt32(OPType_Value));
            }

            if (OPLog_Value != string.Empty)
            {
                sb.AppendFormat(" AND OPLog like '%{0}%' ", Common.inSQL(OPLog_Value));
            }
            if (IP_Value != string.Empty)
            {
                sb.AppendFormat(" AND IP like '{0}' ", Common.inSQL(IP_Value));
            }
            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and a.CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and a.CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and a.CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", CreateDate_Input.Text, EndCreateDate_Input.Text));
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
                    tlOperateEntity et = new tlOperateEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tlOperateInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
