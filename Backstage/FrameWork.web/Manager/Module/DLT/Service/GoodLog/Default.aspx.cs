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

namespace DLT.Web.Module.DLT.GoodLog
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 优质区日志
        /// </summary>
        private void BindData5()
        {
            int RecordCount = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodLogList", txtUID8.Text.Trim(),
                AspNetPager5.CurrentPageIndex, AspNetPager5.PageSize);
            GridView5.DataSource = ds.Tables[0];
            GridView5.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager5.RecordCount = RecordCount;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            BindData5();
        }

        protected void AspNetPager5_PageChanged(object sender, EventArgs e)
        {
            BindData5();
        }
    }
}
