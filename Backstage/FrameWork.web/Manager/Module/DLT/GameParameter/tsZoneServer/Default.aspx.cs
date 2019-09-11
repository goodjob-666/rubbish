/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            区服汇总列表
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

namespace DLT.Web.Module.DLT.tsZoneServer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            List<tsZoneServerEntity> lst = BusinessFacadeDLT.tsZoneServerList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public string IsOnline(string isonline)
        {
            if (isonline == "True")
            {
                return "启用";
            }
            else
            {
                return "停用";
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
            string Code_Value = (string)Common.sink(Code_Input.UniqueID, MethodType.Post, 18, 0, DataType.Str);
            string GameID_Value = (string)Common.sink(GameID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Game_Value = (string)Common.sink(Game_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string ZoneID_Value = (string)Common.sink(ZoneID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Zone_Value = (string)Common.sink(Zone_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string ServerID_Value = (string)Common.sink(ServerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Server_Value = (string)Common.sink(Server_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string FactionID_Value = (string)Common.sink(FactionID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Faction_Value = (string)Common.sink(Faction_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string SpellFull_Value = (string)Common.sink(SpellFull_Input.UniqueID, MethodType.Post, 250, 0, DataType.Str);
            string SpellShort_Value = (string)Common.sink(SpellShort_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string IsOnline_Value = (string)Common.sink(IsOnline_Input.UniqueID, MethodType.Post, 1, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (Code_Value != string.Empty)
            {
                sb.AppendFormat(" AND Code like '%{0}%' ", Common.inSQL(Code_Value));
            }

            if (GameID_Value != string.Empty)
            {
                sb.AppendFormat(" AND GameID = {0} ", Convert.ToInt32(GameID_Value));
            }

            if (Game_Value != string.Empty)
            {
                sb.AppendFormat(" AND Game like '%{0}%' ", Common.inSQL(Game_Value));
            }

            if (ZoneID_Value != string.Empty)
            {
                sb.AppendFormat(" AND ZoneID = {0} ", Convert.ToInt32(ZoneID_Value));
            }

            if (Zone_Value != string.Empty)
            {
                sb.AppendFormat(" AND Zone like '%{0}%' ", Common.inSQL(Zone_Value));
            }

            if (ServerID_Value != string.Empty)
            {
                sb.AppendFormat(" AND ServerID = {0} ", Convert.ToInt32(ServerID_Value));
            }

            if (Server_Value != string.Empty)
            {
                sb.AppendFormat(" AND Server like '%{0}%' ", Common.inSQL(Server_Value));
            }

            if (FactionID_Value != string.Empty)
            {
                sb.AppendFormat(" AND FactionID = {0} ", Convert.ToInt32(FactionID_Value));
            }

            if (Faction_Value != string.Empty)
            {
                sb.AppendFormat(" AND Faction like '%{0}%' ", Common.inSQL(Faction_Value));
            }

            if (SpellFull_Value != string.Empty)
            {
                sb.AppendFormat(" AND SpellFull like '%{0}%' ", Common.inSQL(SpellFull_Value));
            }

            if (SpellShort_Value != string.Empty)
            {
                sb.AppendFormat(" AND SpellShort like '%{0}%' ", Common.inSQL(SpellShort_Value));
            }

            if (IsOnline_Value != string.Empty)
            {
                sb.AppendFormat(" AND IsOnline = {0} ", Convert.ToInt32(IsOnline_Value));
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
                    tsZoneServerEntity et = new tsZoneServerEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tsZoneServerInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
