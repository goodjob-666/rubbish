/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            tbFeedBack列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2016/5/24 16:25:16
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

namespace DLT.Web.Module.DLT.tbFeedBack
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TabOptionWebControls1.SelectIndex = 1;
                CreateDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                CreateDate_Input_E.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
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
            List<tbFeedBackEntity> lst = BusinessFacadeDLT.tbFeedBackList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
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
                if (lst.Count > 0)
                {
                    return lst[0].UID;
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


        public string NickName(string id)
        {
            if (ID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where ID=" + id;

                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].Nickname;
            }
            else
            {
                return "";
            }

        }
        public string Mobile(string id)
        {
            if (ID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where ID=" + id;

                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].QQ;
            }
            else
            {
                return "";
            }

        }

        public string BindMobile(string id)
        {
            if (ID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where ID=" + id;

                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                return lst[0].BindMobile;
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


        protected void cbIsDeal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbIsDeal = (CheckBox)sender;
            string id = cbIsDeal.ValidationGroup;

            if (cbIsDeal.Checked)
            {
                BusinessFacadeDLT.UpdateFeedBackMark(id, 11);
                BindDataList();
                Response.Write("<script language='javascript'>alert('标记成功!');</script>");
            }
            else
            {
                BusinessFacadeDLT.UpdateFeedBackMark(id, 10);
                BindDataList();
                Response.Write("<script language='javascript'>alert('取消标记成功!');</script>");
            }
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string Source_Value = (string)Common.sink(Source_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string Feedback_Value = (string)Common.sink(Feedback_Input.UniqueID, MethodType.Post, 2048, 0, DataType.Str);


            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(CreateDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(CreateDate_Input_E.UniqueID, MethodType.Post, 255, 0, DataType.Dat);

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
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }

            if (Source_Value != string.Empty)
            {
                sb.AppendFormat(" AND Source like '%{0}%' ", Common.inSQL(Source_Value));
            }

            if (Feedback_Value != string.Empty)
            {
                sb.AppendFormat(" AND Feedback like '%{0}%' ", Common.inSQL(Feedback_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                sb.AppendFormat(string.Format(" and CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", CreateDate_Input.Text, CreateDate_Input_E.Text));
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
                    tbFeedBackEntity et = new tbFeedBackEntity();
                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbFeedBackInsertUpdateDelete(et);
                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateComment")
            {
                string id = e.CommandArgument.ToString();

                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                DataSet ds = BusinessFacadeDLT.UpdateFeedBackComment(txtComment.Text,id, Common.Get_UserID);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户反馈备注信息更改成功，更改操作员ID：" + Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户反馈信息修改成功！');</script>");
                }
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow|| e.Row.RowType== DataControlRowType.Separator)
            {
                CheckBox cbIsDeal = (CheckBox)e.Row.FindControl("cbIsDeal");
                HiddenField hf = (HiddenField)e.Row.FindControl("hfIsDeal");

                if (hf.Value != "11")
                {
                    cbIsDeal.Checked = false;
                }
                else
                {
                    cbIsDeal.Checked = true;
                    e.Row.ForeColor = Color.MediumVioletRed;
                }

            }
        }
    }
}
