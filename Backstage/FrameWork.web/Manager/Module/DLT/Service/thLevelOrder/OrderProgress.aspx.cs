using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.DaiLianTong.BizManager.OrderHis
{
    public partial class OrderProgress : System.Web.UI.Page
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
            string SerialNo = Request.QueryString["SerialNo"].ToString();
            DataSet ds = BusinessFacadeDLT.GetOrderProgress(SerialNo);
            string tmpstr = "";
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (ds.Tables[0].Rows[i]["Source"].ToString() == "11")
                {
                    tmpstr += "<div style=\"text-align:center;color:Red;\"><span>";
                }
                else
                {
                    tmpstr += "<div style=\"text-align:center;color:Blue;\"><span>";
                }
                tmpstr += "µÚ " + (i + 1).ToString() + " ÕÅ£º " + ds.Tables[0].Rows[i]["Comment"].ToString() + "     " + ds.Tables[0].Rows[i]["CreateDate"].ToString() + "      [" + ds.Tables[0].Rows[i]["Fromer"].ToString() + "]</span></div>";
                tmpstr += "<br />";
                tmpstr += "<div style=\"text-align:center\"><a href='" + ds.Tables[0].Rows[i]["Img"].ToString() + "'><img src='" + ds.Tables[0].Rows[i]["Img"].ToString() + "' width=\"800px\" height=\"600px\"/></a></div>";
                tmpstr += "<br />\n<hr />";

            }
            divpic.InnerHtml = tmpstr;
        }

    }
}
