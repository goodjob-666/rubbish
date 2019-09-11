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

namespace DLT.Web.Module.DLT.tbEvaluate
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList1()
        {
                DataSet ds = BusinessFacadeDLT.UpdateOrderEvaluate(txtOrder.Text,"", "0","");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList1();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateEvaluateComment")
            {
                string oid = e.CommandArgument.ToString();
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                TextBox txtComment = (TextBox)row.FindControl("txtComment");
                Label lblDirect=(Label)row.FindControl("lblDirect");
                DataSet ds = BusinessFacadeDLT.UpdateOrderEvaluate(oid, txtComment.Text, "1", lblDirect.Text);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    string titleMessage = "用户备注信息更改成功，更改操作员ID："+Common.Get_UserID.ToString();
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改评价成功！');</script>");
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
            {
                Label lblDirectType = e.Row.FindControl("lblDirectType") as Label;
                if (lblDirectType.Text == "10")
                {
                    lblDirectType.Text = "对接单者的评价";
                }
                else
                {
                    lblDirectType.Text = "对发单者的评价";
                }
            }
        }

    }
}
