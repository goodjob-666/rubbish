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
    public partial class PostTrack : System.Web.UI.Page
    {
        public string trackPostID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["TrackPostID"] != null)
                {
                    trackPostID = Request.QueryString["TrackPostID"].ToString();
                    BindDataList3();
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

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            BindDataList3();
        }

        private void BindDataList3()
        {
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.GetUserTrackInfo(Request.QueryString["TrackPostID"].ToString(), AspNetPager3.CurrentPageIndex, AspNetPager3.PageSize);
            GridView4.DataSource = ds;
            GridView4.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager3.RecordCount = RecordCount;
        }



    }


}
