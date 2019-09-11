using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.DLT.Service.tbLevelOrderHis
{
    public partial class AcceptTrack : System.Web.UI.Page
    {
        public string trackAcceptID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["TrackAcceptID"] != null)
                {
                    trackAcceptID = Request.QueryString["TrackAcceptID"].ToString();
                    BindDataList4();
                }
            }
        }

        public string GetOPLoginID(string firstCustomerID)
        {
            if (firstCustomerID != "")
            {
                if (firstCustomerID != "0")
                {
                    return UserData.Get_sys_UserTable(int.Parse(firstCustomerID)).U_LoginName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return firstCustomerID;
            }

        }

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            BindDataList4();
        }

        private void BindDataList4()
        {
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.GetUserTrackInfo(Request.QueryString["TrackAcceptID"].ToString(), AspNetPager4.CurrentPageIndex, AspNetPager4.PageSize);
            GridView5.DataSource = ds;
            GridView5.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager4.RecordCount = RecordCount;
        }
    }
}
