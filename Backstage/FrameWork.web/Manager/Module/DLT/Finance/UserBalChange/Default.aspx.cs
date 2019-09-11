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

namespace DLT.Web.Module.DLT.UserBalChange
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDataList();
            }
            
        }

        private void BindDataList()
        {
            int userId = 0;

            if (txtUserID1.Text != "")
            {
                userId = Convert.ToInt32(txtUserID1.Text);
            }

            QueryParam qp1 = new QueryParam();
            qp1.PageIndex = AspNetPager1.CurrentPageIndex;
            qp1.PageSize = AspNetPager1.PageSize;
            int RC = 0;
            DataSet ds = BusinessFacadeDLT.UserMoneyChangeList(userId, DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), 21, "", qp1.PageIndex, qp1.PageSize, " and SUBSTRING(Comment,1,3)='[后台' ");
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RC = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RC;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where UID='" + txtUserID.Text + "'";
            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                int userID = lst[0].ID;
                //判断提现资金是否大于可用资金 BM_UserMoneyChangeJudge
                string result = BusinessFacadeDLT.UserMoneyChangeJudge(userID, decimal.Parse(txtChangeBal.Text)).Tables[0].Rows[0][0].ToString();
                if (result == "1")
                {
                    //判断当前客服当天操作资金是否已超过系统设置最大值
                    string result1 = BusinessFacadeDLT.ServiceMaxPrice(UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName,1,decimal.Parse(txtChangeBal.Text)).Tables[0].Rows[0][0].ToString();
                    if (result1 == "1")
                    {
                        BusinessFacadeDLT.UserMoneyChange(userID, 21, decimal.Parse(txtChangeBal.Text), txtRealSerialno.Text, "[后台调整]-客服：" + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName + "-理由：" + txtComent.Text);
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户资金调整成功！');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户资金调整失败，已超过该财务帐号当天最大调整资金限度！');</script>");
                    }
                }
                else if (result == "-1")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('可用资金不足以调整，用户有正在提现资金，请撤销用户提现资金再作调整！');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('可用资金不足以调整！');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('输入的用户ID有错！');</script>");
            }           
        }
    }
}
