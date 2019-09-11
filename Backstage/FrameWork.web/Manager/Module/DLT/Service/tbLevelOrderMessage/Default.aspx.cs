/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            订单交互留言列表
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
using System.Text.RegularExpressions;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tbLevelOrderMessage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindDataList();
                MsgTypeTypeList();
                TabOptionWebControls1.SelectIndex = 1;

                //给开始时间和结束时间加上默认时间
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public string Unicode2Chinese(string strUnicode)
        {
            strUnicode=strUnicode.Replace(@"\","%");
            return Microsoft.JScript.GlobalObject.unescape(strUnicode);
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
            DataSet ds = BusinessFacadeDLT.LevelOrderMessage(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
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




        public string MsgType(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1018 and Kind=" + type;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        public void MsgTypeTypeList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1018";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlMessageType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }


        public string IsRead(string isread)
        {
            if (isread == "True")
            {
                return "已读";
            }
            else
            {
                return "未读";
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
            string ODSerialNo_Value = (string)Common.sink(ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string MsgType_Value = (string)Common.sink(ddlMessageType.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Msg_Value = (string)Common.sink(Msg_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);

            string IsRead_Value = (string)Common.sink(IsRead_Input.UniqueID, MethodType.Post, 1, 0, DataType.Str);
            string IsRead2_Value = (string)Common.sink(IsRead2_Input.UniqueID, MethodType.Post, 1, 0, DataType.Str);
            string V1ID_Value = (string)Common.sink(V1ID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);

            string startDate_Value = (string)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            startDate_Value = startDate_Value + " 00:00:00";
            string endDate_Value = (string)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            endDate_Value = endDate_Value + " 23:59:59";
            StringBuilder sb = new StringBuilder();

            if (ODSerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND ODSerialNo = '{0}' ", Common.inSQL(ODSerialNo_Value));
            }

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND B.UID = '{0}' ", Common.inSQL(UserID_Value));
            }

            if (MsgType_Value != string.Empty)
            {
                sb.AppendFormat(" AND MsgType = {0} ", Convert.ToInt32(MsgType_Value));
            }

            if (Msg_Value != string.Empty)
            {
                sb.AppendFormat(" AND Msg like '%{0}%' ", Common.inSQL(Msg_Value));
            }

            if (CheckBox1.Checked)
            {
                sb.AppendFormat(" AND MsgType =11 AND patindex('%[0-9][0-9][0-9][0-9][0-9]%',Msg) >0 ", Common.inSQL(Msg_Value));
            }


            if (IsRead_Value != string.Empty)
            {
                sb.AppendFormat(" AND IsRead = {0} ", Convert.ToInt32(IsRead_Value));
            }

            if (IsRead2_Value != string.Empty)
            {
                sb.AppendFormat(" AND IsRead2 = {0} ", Convert.ToInt32(IsRead2_Value));
            }

            if (V1ID_Value != string.Empty)
            {
                sb.AppendFormat(" AND V1ID = {0} ", Convert.ToInt32(V1ID_Value));
            }

            if (startDate_Value != string.Empty) {
                sb.AppendFormat(" AND A.CreateDate>='{0}' ", startDate_Value);
            }

            if (endDate_Value != string.Empty)
            {
                sb.AppendFormat(" AND A.CreateDate<='{0}' ", endDate_Value);
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
                    tbLevelOrderMessageEntity et = new tbLevelOrderMessageEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbLevelOrderMessageInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }
    }
}
