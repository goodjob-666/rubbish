using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrameWork.web.Manager.Module.DLT.Activity.Questions
{
    public partial class ShowImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url=Request.QueryString["ImageUrl"];
            Image1.ImageUrl = url;
        }
    }
}