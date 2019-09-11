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

namespace DLT.Web.Module.DLT.InsideMail
{
    public partial class MailDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            string ID = Request.QueryString["ID"].ToString();
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], CommandType.Text, 
                "select b.Title,b.Body from tbSendMail a left join tsMail b on a.MailID = b.ID where a.ID = " + ID);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                lbTitle.Text = dt.Rows[0]["Title"].ToString();
                txtBody.Text = dt.Rows[0]["Body"].ToString();
            }
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
