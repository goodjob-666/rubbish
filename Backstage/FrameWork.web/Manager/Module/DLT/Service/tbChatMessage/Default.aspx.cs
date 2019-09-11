/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            tbChatMessage列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2015/2/5 星期四 9:28:00
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
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
using DLT.Data;
using FrameWork;
using FrameWork.Components;


namespace DLT.Web.Module.DLT.tbChatMessage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
                CreateDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                EndCreateDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
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
            DataSet ds = ChatMessageList(qp.PageIndex, qp.PageSize, qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }


        private DataSet ChatMessageList(int PageIndex, int PageSize, string Where)
        {
            DataSet ds = null;
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["DLTChat"]))
            {
                ds = SqlHelper.ExecuteDataset(Conn.ConnectionString, "BM_ChatMessageList", PageIndex, PageSize, Where);
            }
            return ds;
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
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string UID_Value = (string)Common.sink(UID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string NickName_Value = (string)Common.sink(NickName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string IconIndex_Value = (string)Common.sink(IconIndex_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string ChatType_Value = (string)Common.sink(ChatType_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string TargetID_Value = (string)Common.sink(TargetID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(CreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(EndCreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);


            StringBuilder sb = new StringBuilder();

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.UserID = {0} ", Convert.ToInt32(UserID_Value));
            }

            if (UID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.UID like '%{0}%' ", Common.inSQL(UID_Value));
            }

            if (NickName_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.NickName like '%{0}%' ", Common.inSQL(NickName_Value.Replace("'", "''")));
            }

            if (IconIndex_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.IconIndex = {0} ", Convert.ToInt32(IconIndex_Value));
            }

            if (ChatType_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.ChatType = {0} ", Convert.ToInt32(ChatType_Value));
            }

            if (TargetID_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.TargetID like '%{0}%' ", Common.inSQL(TargetID_Value));
            }

            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND a.Comment like '%{0}%' ", Common.inSQL(Comment_Value));
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
                    tbChatMessageEntity et = new tbChatMessageEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbChatMessageInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        private Int32 tbChatMessageInsertUpdateDelete(tbChatMessageEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["DLTChat"]))
            {
                SqlCommand cmd = new SqlCommand("dbo.tbChatMessage_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = fam.UserID;  //UserID
                cmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = fam.UID;  //UID
                cmd.Parameters.Add("@NickName", SqlDbType.VarChar).Value = fam.NickName;  //NickName
                cmd.Parameters.Add("@IconIndex", SqlDbType.Int).Value = fam.IconIndex;  //IconIndex
                cmd.Parameters.Add("@ChatType", SqlDbType.Int).Value = fam.ChatType;  //ChatType
                cmd.Parameters.Add("@TargetID", SqlDbType.NChar).Value = fam.TargetID;  //TargetID
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = fam.Comment;  //Comment
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = fam.CreateDate;  //CreateDate
                if (fam.BeginTime.HasValue)
                    cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = fam.BeginTime;  //BeginTime
                else
                    cmd.Parameters.Add("@BeginTime", SqlDbType.DateTime).Value = DBNull.Value;  //BeginTime
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }
    }
}
