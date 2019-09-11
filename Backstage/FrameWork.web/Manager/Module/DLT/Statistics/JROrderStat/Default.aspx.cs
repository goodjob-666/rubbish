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

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.JROrderStat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGameList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd 00:00:00");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59"); 
                //BindDataList();
            }
        }

        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGLGameID.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }


        public string GetID(string UID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UID]='" + UID+"'";

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

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            string postUserID="";
            int IsGood = cbGood.Checked ? 1 : -1;

            if (txtPostUserID.Text != "")
            {
                if (GetID(txtPostUserID.Text) != "")
                {
                    postUserID = GetID(txtPostUserID.Text);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('输入的上家ID有误，请重新输入上家ID！');</script>");
                    return;
                }
            }
            //DataSet ds = BusinessFacadeDLT.JROrderStat(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlGLGameID.SelectedValue, postUserID);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_JROrderStat", DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), ddlGLGameID.SelectedValue, postUserID, IsGood);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

    }
}
