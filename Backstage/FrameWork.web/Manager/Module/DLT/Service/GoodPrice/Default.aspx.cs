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

namespace DLT.Web.Module.DLT.GoodPrice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return confirm('您真的要进行批量调价吗？')");
                BindData();  
            }
        }

        private void BindData()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodPriceList", 
                ddlGameType.Text,ddlServerType.Text,ddlSTier.Text,ddlETier.Text,AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();//绑定 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();
            string BasePrice = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tsGameBasePrice set BasePrice = '" + BasePrice + "' where ID = " + ID);

            //Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView1.EditIndex = -1;
            BindData();//绑定数据
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();//绑定 
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tbUpRate.Text != "")
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodPriceUpdateBatch", ddlGameType.Text, ddlServerType.Text, ddlSTier.Text, ddlETier.Text, float.Parse(tbUpRate.Text.Trim()));
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');</script>");
                    BindData();
                }
            }
            else 
            {
                Response.Write("<script language='javascript'>alert('请输入调价比例！');</script>");
            }
        }

       
    }
}
