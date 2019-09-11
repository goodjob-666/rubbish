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
    public partial class Reparation : System.Web.UI.Page
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
            hiddenID.Value = ID;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                "select b.UID,a.EnsureMoney from tbGoodAccept a left join tsUser b on a.UserID = b.ID where a.ID = " + ID);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                lbGoodAccept.Text = dt.Rows[0]["UID"].ToString();
                lbEnsureMoney.Text = dt.Rows[0]["EnsureMoney"].ToString();
            }
        }

        protected void BtClose0_Click(object sender, EventArgs e)
        {
            if ((txtGoodPublish.Text != "") && (txtODSerialNo.Text != "") && (txtReson.Text != ""))
            {
                string ID = hiddenID.Value;
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_GoodAcceptReparation", Common.Get_UserID, ID, lbGoodAccept.Text,
                    txtGoodPublish.Text.Trim(), lbEnsureMoney.Text, txtODSerialNo.Text.Trim(), txtReson.Text.Trim());
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    int Result = int.Parse(dt.Rows[0]["Result"].ToString());
                    string Err = dt.Rows[0]["Err"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + Err + "');window.parent.hidePopWin(true);</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('输入错误.')</script>");
            }
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }
    }
}
