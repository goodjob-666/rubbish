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

namespace DLT.Web.Module.DLT.Activity.Exchange
{
    public partial class Exchange : System.Web.UI.Page
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
            string serialNo = Request.QueryString["SerialNo"].ToString();
            hiddenID.Value = serialNo;
        }

        protected void BtClose0_Click(object sender, EventArgs e)
        {
            string ID = hiddenID.Value;
            int result = BusinessFacadeDLT.UpdateExchangeStatus(txtReson.Text.Trim(), 1, ID);
            if (result > 0)
            {
                Response.Write("<script language='javascript'>alert('修改成功');window.parent.hidePopWin(true);</script>");
            }
            else {
                Response.Write("<script language='javascript'>alert('修改失败');window.parent.hidePopWin(true);</script>");
            }
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
