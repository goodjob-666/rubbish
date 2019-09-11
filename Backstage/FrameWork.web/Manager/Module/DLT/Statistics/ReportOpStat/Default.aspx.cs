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
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.ReportOpStat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSearchType();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd 00:00:00");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59"); 
                BindDataList();
            }
        }

        private void BindSearchType()
        {

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = BusinessFacadeDLT.sys_StatisticalGroupingList(qp, out RecordCount);
            foreach (sys_StatisticalGroupingEntity var in lst)
            {
                DropDownList2.Items.Add(new ListItem(var.S_Name, var.S_ID.ToString()));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {

            if (tbOPName.Text != string.Empty)
            {
                //UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName
                if (UserData.Get_sys_UserTable1(tbOPName.Text) != null)
                {
                    int id = UserData.Get_sys_UserTable1(tbOPName.Text).UserID;
                    if (id != 0)
                    {
                        DataSet ds = BusinessFacadeDLT.OrderPostStat(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), id.ToString(), DropDownList2.SelectedValue);
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('客服登录ID输入错误！');</script>");
                    return;
                }

            }
            else
            {
                DataSet ds = BusinessFacadeDLT.OrderPostStat(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), tbOPName.Text, DropDownList2.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }


        public string DealCustomerID(string OPID)
        {
            if (DropDownList2.SelectedValue != "0")
            {
                if (OPID != "0")
                {
                    return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return OPID;
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

    }
}
