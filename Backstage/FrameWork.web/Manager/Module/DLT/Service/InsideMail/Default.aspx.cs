using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.InsideMail
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-30)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
        }

        private void BindData1()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_SendMailList", 
                DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text),
                AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BindData1();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (
                (txtTitle.Text.Trim() == "") || (txtBody.Text.Trim() == "") || (txtUIDList.Text.Trim() == "")
            )
            {
                Response.Write("<script language:javascript>javascript:window:alert('输入不完整!');</script>");
            }
            else
            {
                string SendToUserList = "";
                if (ddlSendType.Text == "11")
                {
                    SendToUserList = txtUIDList.Text.Replace("\r\n", ",");
                }

                object obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["MSSql"], "BM_SendMailAdd",
                    txtTitle.Text.Trim(), txtBody.Text.Trim(), ddlSendType.Text, SendToUserList,Common.Get_UserID);
                int result = int.Parse(obj.ToString());
                if (result == 1)
                {
                    Response.Write("<script language:javascript>javascript:window:alert('添加站内信成功!');</script>");
                    txtTitle.Text = "";
                    txtBody.Text = "";
                    txtUIDList.Text = "";
                    BindData1();
                }
                else if (result == -1)
                {
                    Response.Write("<script language:javascript>javascript:window:alert('添加站内信失败：目标用户无效!');</script>");
                }

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int result = 0;
            if (e.CommandName == "Cancel")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                object obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["MSSql"],"BM_SendMailCancel",ID);
                result = int.Parse(obj.ToString());
                if (result == 1)
                {
                    EventMessage.EventWriteDB(1, "操作站内信撤回");
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                    BindData1();
                }
            }
        }

        private void BindData2()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_SendMailList_Search",
                txtUID.Text.Trim(),
                AspNetPager2.CurrentPageIndex, AspNetPager2.PageSize);
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            BindData2();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData1();
        }
    }
}
