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
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.PubSelect
{
    public partial class More : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int userId = int.Parse(Request.QueryString["ID"]);
                //string uid=Request.QueryString["UID"];
                //txt_Uid_Input.Text = uid;
                //DataSet dsByWeek = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GetUserPostByWeek", userId,
                //  DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(ddlGame.SelectedValue));
                //string str = "";
                //int num = dsByWeek.Tables[0].Rows.Count;
                //for (int i = 0; i < num; i++)
                //{
                //    if (i < 7)
                //    {
                //        str += dsByWeek.Tables[0].Rows[i][0].ToString() + "：" + dsByWeek.Tables[0].Rows[i][1].ToString() + "<br />";
                //    }
                //}

                //lblWeek.Text = str;
                //if (num > 7)
                //{
                //    lblWeek.Text = str + "<a href=\"javascript:showPopWin(\"近15天内符合条件的订单\",\"OrderList.aspx?ID=" + userId + "\",1080, 550, null,false)\">更多</a>";
                //}


            }
        }

        

    }
}
