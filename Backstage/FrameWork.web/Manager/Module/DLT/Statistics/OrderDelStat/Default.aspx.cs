using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.OrderDelStat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd 00:00:00");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59"); 
                BindDataList();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            DataSet ds = BusinessFacadeDLT.OrderDelStat(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), GetOpID(tbOPName.Text));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        public string GetOpLoginName(string OPID)
        {
            return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
        }

        public string GetOpID(string LoginName)
        {
            if (LoginName != "")
            {
                try
                {
                    return UserData.Get_sys_UserTable(LoginName).UserID.ToString();
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('输入的客服ID有误！');</script>");
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
