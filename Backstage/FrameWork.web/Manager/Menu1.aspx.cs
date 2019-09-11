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
using System.Text;
using FrameWork.Components;

namespace FrameWork.web
{
    public partial class Menu1 : System.Web.UI.Page
    {
        public StringBuilder sb_FramesetRows = new StringBuilder();
        public StringBuilder sb_HTMLSrc = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            OnStart();
        }

        private void OnStart()
        {
            ArrayList lst = BusinessFacade.sys_Module_List();
            int i = 1;
            foreach (sys_ModuleTable var in lst)
            {
                ArrayList lst2 = BusinessFacade.GetPermissionModuleSub(var.ModuleID);
                if (lst2.Count > 0)
                {
                    if (i == 1)
                        sb_FramesetRows.Append("21,*");
                    else
                        sb_FramesetRows.Append(",21,0");

                    sb_HTMLSrc.AppendFormat("<frame name={0}menubarbutton_{1}{0} target={0}pagemain{0} scrolling={0}no{0} noresize src={0}Menu1_Button.aspx?APCatalogueID={1}&OrderNo={2}&APCatCName={3}{0}>{4}<frame name={0}menubar_{1}{0} target={0}pagemain{0} scrolling={0}auto{0} noresize src={0}Menu1_Disp.aspx?ModuleID={5}&OrderNo={2}{0} STYLE={0}border-width:1; border-bottom-style:solid{0}>{4}", "\"", var.ModuleID, i, var.M_CName, "\n",var.ModuleID);

                    i++;
                }
            }

        }
    }
}
