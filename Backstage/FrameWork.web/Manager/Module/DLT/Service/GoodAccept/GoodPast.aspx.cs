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
    public partial class GoodPast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
                BtClose0.Attributes.Add("onclick", "return   confirm('您确定要做此操作吗？')");
            }
        }

        private void OnStart()
        {
            string Flag = Request.QueryString["Flag"].ToString();
            string ID = Request.QueryString["ID"].ToString();
            HiddenFlag.Value = Flag;
            hiddenID.Value = ID;
        }

        protected void BtClose0_Click(object sender, EventArgs e)
        {
            string ID = hiddenID.Value;
            string Flag = HiddenFlag.Value;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptPast", Common.Get_UserID, ID, Flag, txtReson.Text.Trim());
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                Response.Write("<script language='javascript'>alert('" + dt.Rows[0]["Err"].ToString() + "');window.parent.hidePopWin(true);</script>");
            }
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
