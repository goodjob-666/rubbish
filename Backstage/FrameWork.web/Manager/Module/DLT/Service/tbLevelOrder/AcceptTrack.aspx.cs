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

namespace FrameWork.web.Manager.Module.DLT.Service.tbLevelOrder
{
    public partial class AcceptTrack : System.Web.UI.Page
    {
        public string trackAcceptID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["TrackAcceptID"] != null)
                {
                    trackAcceptID = Request.QueryString["TrackAcceptID"].ToString();
                    BindDataList4();
                }
            }
        }


        protected void GridView5_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string DataIDX = "";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.A))
                {
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.A))
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

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            BindDataList4();
        }

        private void BindDataList4()
        {
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.GetUserTrackInfo(Request.QueryString["TrackAcceptID"].ToString(), AspNetPager4.CurrentPageIndex, AspNetPager4.PageSize);
            GridView5.DataSource = ds;
            GridView5.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager4.RecordCount = RecordCount;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.A)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            if (Checkbox_Value != "")
            {
                string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
                for (int i = 0; i < Checkbox_Value_Array.Length; i++)
                {
                    BusinessFacadeDLT.DeleteUserTrack(Checkbox_Value_Array[i].ToString());
                }

                string titleMessage = "用户:" + trackAcceptID.ToString() + "-删除跟踪信息!";
                EventMessage.EventWriteDB(1, titleMessage);
                Response.Write("<script language='javascript'>alert('删除成功！');</script>");
                BindDataList4();

            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择一条记录！');</script>");
            }
        }



    }
}
