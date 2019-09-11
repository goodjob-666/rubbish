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

namespace DLT.Web.Module.DLT.UserBalDetail
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindChangeType();
                //BindDataList();
            }
        }

        public void BindChangeType()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1008";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlChangeType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

       

        private void BindDataList()
        {
            int userID = 0;
            if (txtUserID.Text != "")
            {
                userID = Convert.ToInt32(txtUserID.Text);
            }

            string where = "";
            if (txtNickName.Text != "")
            {
                where = string.Format(" and NickName = '{0}'", Common.Base64Encode(Common.inSQL(txtNickName.Text.Trim().Replace("'", "''"))));
                
            }

            QueryParam qp1 = new QueryParam();
            qp1.PageIndex = AspNetPager1.CurrentPageIndex;
            qp1.PageSize = AspNetPager1.PageSize;
            int RC = 0;
            DataSet ds = BusinessFacadeDLT.UserMoneyChangeList(userID, DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), int.Parse(ddlChangeType.SelectedValue), "", qp1.PageIndex, qp1.PageSize, where);
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            RC = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RC;
            lblTotalRecharge.Text = "当前查询条件下总金额：" + ds.Tables[2].Rows[0][0].ToString() + "元";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }
    }
}
