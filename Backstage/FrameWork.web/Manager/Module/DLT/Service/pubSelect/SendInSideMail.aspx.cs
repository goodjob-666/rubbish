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

namespace DLT.Web.Module.DLT.pubSelect
{
    public partial class SendInSideMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
                BtClose0.Attributes.Add("onclick", "return   confirm('您确定发送站内信给该用户吗？')");
            }

        }

        private void OnStart()
        {
            string UID = Request.QueryString["UID"].ToString();
            hiddenUID.Value = UID;
        }

        protected void BtClose0_Click(object sender, EventArgs e)
        {
            if (tbMailBody.Text.Trim() != "")
            {
                string UID = hiddenUID.Value;
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "Comm_MailAdd", "代练通客服发送给您的站内信", tbMailBody.Text.Trim(), 11, hiddenUID.Value, 0, 1);
                Response.Write("<script language='javascript'>window.parent.hidePopWin(false);</script>");
            }
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
