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
using FrameWork.Components;
namespace FrameWork.web
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sys_FrameWorkInfoTable si = FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo;
            SystemName.Text = FrameSystemInfo.FrameWorkVerName;
            if (si.S_Licensed == "")
                Licensed_Txt.Text = string.Format("<a href='{0}' target=_blank><font color=red>ÔÚÏßÉêÇë×¢²á</font></a>", si.S_RegsionUrl);
            else
                Licensed_Txt.Text = string.Format("<a href='{1}?S_Licensed={0}' target=_blank>{0}</a>", si.S_Licensed, si.S_CheckLicensed);
        }
    }
}
