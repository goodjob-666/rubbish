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
using System.Diagnostics;

namespace FrameWork.web.Manager
{
    public partial class menu3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Stopwatch st = new Stopwatch();
            //st.Start();
            Treehtml.Text = FrameWork.FrameWorkMenuTree.GetMenuTree();
            //Response.Write((double)st.ElapsedMilliseconds/1000);
        }
    }
}
