using System;
using System.Collections;
using System.Configuration;
using System.Data;
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

namespace DLT.Web.Module.DLT.GoodAccept
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
                BindData1();
            }
        }

        private void OnStart()
        {
            string ID = Request.QueryString["ID"].ToString();
            hiddenID.Value = ID;
        }

        private void BindData1()
        {
            int RecordCount = 0;
            AspNetPager1.PageSize = 10;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptOrderList", hiddenID.Value,AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData1();
        }

        public string Unicode2Chinese(string strUnicode)
        {
            strUnicode = strUnicode.Replace(@"\", "%");
            return Microsoft.JScript.GlobalObject.unescape(strUnicode);
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
