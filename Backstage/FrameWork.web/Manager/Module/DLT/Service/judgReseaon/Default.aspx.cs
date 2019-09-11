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

namespace DLT.Web.Module.DLT.JudgReseaon
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-3)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            if (txtServiceID.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入客服登录ID');</script>");
                return;
            }
            else
            {
                if (UserData.Get_sys_UserTable1(txtServiceID.Text) != null)
                {
                    QueryParam qp = new QueryParam();
                    qp.Where = " and a.E_U_LoginName='" + txtServiceID.Text + "' and a.E_DateTime between '" + S_dtDate_Input.Text + " 00:00:00' and '" + E_dtDate_Input.Text + " 23:59:59' ";
                    string where2 = " and t1.CreateDate between '" + S_dtDate_Input.Text + " 00:00:00' and '" + E_dtDate_Input.Text + " 23:59:59' ";
                    qp.PageIndex = AspNetPager1.CurrentPageIndex;
                    qp.PageSize = AspNetPager1.PageSize;
                    int RecordCount = 0;
                    DataSet ds = BusinessFacadeDLT.JugeReason(qp.PageIndex, qp.PageSize, qp.Where,where2);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    this.AspNetPager1.RecordCount = RecordCount;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('客服ID输入错误！');</script>");
                    return;
                }


            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
        }

        public string UserID(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UID]='" + id + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "0";
            }
            else
            {
                return lst[0].ID.ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void GridView4_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
