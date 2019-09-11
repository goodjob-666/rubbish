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

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;


namespace FrameWork.web
{
    public partial class _Default : System.Web.UI.Page
    {
        public string FrameName = FrameSystemInfo.GetSystemInfoTable.S_Name;
        public string FrameNameVer = FrameSystemInfo.GetSystemInfoTable.S_Version;
        public int MenuStyle = Common.MenuStyle;
        public string TabID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request["tab"] != null)
            {
                TabID = HttpContext.Current.Request["tab"].ToString();
            }
            if (!this.IsPostBack)
            {
                QueryParam qp = new QueryParam();
                qp.Where = " Where 1=1 and P_IsDeal=0 ";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                int RecordCount = 0;
                List<sys_PendingMattersEntity> lst = BusinessFacadeDLT.sys_PendingMattersList(qp, out RecordCount);

                QueryParam qp1 = new QueryParam();
                qp1.Where = " Where 1=1 and P_IsDeal=0 and P_Type=1 ";
                qp1.PageIndex = 1;
                qp1.PageSize = 1000;
                int RecordCount1 = 0;
                List<sys_PendingMattersEntity> lst1 = BusinessFacadeDLT.sys_PendingMattersList(qp1, out RecordCount1);

                QueryParam qp2 = new QueryParam();
                qp2.Where = " Where 1=1 and P_IsDeal=0 and P_Type=2 ";
                qp2.PageIndex = 1;
                qp2.PageSize = 1000;
                int RecordCount2 = 0;
                List<sys_PendingMattersEntity> lst2 = BusinessFacadeDLT.sys_PendingMattersList(qp2, out RecordCount2);

                QueryParam qp3 = new QueryParam();
                qp3.Where = " Where 1=1 and P_IsDeal=0 and P_Type=3 ";
                qp3.PageIndex = 1;
                qp3.PageSize = 1000;
                int RecordCount3 = 0;
                List<sys_PendingMattersEntity> lst3 = BusinessFacadeDLT.sys_PendingMattersList(qp3, out RecordCount3);

                QueryParam qp4 = new QueryParam();
                qp4.Where = " Where 1=1 and P_IsDeal=0 and P_Type=4 ";
                qp4.PageIndex = 1;
                qp4.PageSize = 1000;
                int RecordCount4 = 0;
                List<sys_PendingMattersEntity> lst4 = BusinessFacadeDLT.sys_PendingMattersList(qp4, out RecordCount4);

                QueryParam qp5 = new QueryParam();
                qp5.Where = " Where 1=1 and P_IsDeal=2 ";
                qp5.PageIndex = 1;
                qp5.PageSize = 1000;
                int RecordCount5 = 0;
                List<sys_PendingMattersEntity> lst5 = BusinessFacadeDLT.sys_PendingMattersList(qp5, out RecordCount5);

                QueryParam qp6 = new QueryParam();
                qp6.Where = " Where 1=1 and P_IsDeal=0 and P_Type=5 ";
                qp6.PageIndex = 1;
                qp6.PageSize = 1000;
                int RecordCount6 = 0;
                List<sys_PendingMattersEntity> lst6 = BusinessFacadeDLT.sys_PendingMattersList(qp6, out RecordCount6);

                lblPendingCount.Text = "总:" + RecordCount.ToString() + " 客服部:" + RecordCount1.ToString() + " 介入部:" + RecordCount2.ToString() + " 投诉:" + RecordCount3.ToString() + " 盗号纠纷单:" + RecordCount6.ToString() + " 其它:" + RecordCount4.ToString() + " 待确定:" + RecordCount5.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            QueryParam qp = new QueryParam();
            qp.Where = " Where 1=1 and P_IsDeal=0 ";
            qp.PageIndex = 1;
            qp.PageSize = 1000;
            int RecordCount = 0;
            List<sys_PendingMattersEntity> lst = BusinessFacadeDLT.sys_PendingMattersList(qp, out RecordCount);

            QueryParam qp1 = new QueryParam();
            qp1.Where = " Where 1=1 and P_IsDeal=0 and P_Type=1 ";
            qp1.PageIndex = 1;
            qp1.PageSize = 1000;
            int RecordCount1 = 0;
            List<sys_PendingMattersEntity> lst1 = BusinessFacadeDLT.sys_PendingMattersList(qp1, out RecordCount1);

            QueryParam qp2 = new QueryParam();
            qp2.Where = " Where 1=1 and P_IsDeal=0 and P_Type=2 ";
            qp2.PageIndex = 1;
            qp2.PageSize = 1000;
            int RecordCount2 = 0;
            List<sys_PendingMattersEntity> lst2 = BusinessFacadeDLT.sys_PendingMattersList(qp2, out RecordCount2);

            QueryParam qp3 = new QueryParam();
            qp3.Where = " Where 1=1 and P_IsDeal=0 and P_Type=3 ";
            qp3.PageIndex = 1;
            qp3.PageSize = 1000;
            int RecordCount3 = 0;
            List<sys_PendingMattersEntity> lst3 = BusinessFacadeDLT.sys_PendingMattersList(qp3, out RecordCount3);

            QueryParam qp4 = new QueryParam();
            qp4.Where = " Where 1=1 and P_IsDeal=0 and P_Type=4 ";
            qp4.PageIndex = 1;
            qp4.PageSize = 1000;
            int RecordCount4 = 0;
            List<sys_PendingMattersEntity> lst4 = BusinessFacadeDLT.sys_PendingMattersList(qp4, out RecordCount4);

            QueryParam qp5 = new QueryParam();
            qp5.Where = " Where 1=1 and P_IsDeal=2 ";
            qp5.PageIndex = 1;
            qp5.PageSize = 1000;
            int RecordCount5 = 0;
            List<sys_PendingMattersEntity> lst5 = BusinessFacadeDLT.sys_PendingMattersList(qp5, out RecordCount5);

            QueryParam qp6 = new QueryParam();
            qp6.Where = " Where 1=1 and P_IsDeal=0 and P_Type=5 ";
            qp6.PageIndex = 1;
            qp6.PageSize = 1000;
            int RecordCount6 = 0;
            List<sys_PendingMattersEntity> lst6 = BusinessFacadeDLT.sys_PendingMattersList(qp6, out RecordCount6);

            lblPendingCount.Text = "总:" + RecordCount.ToString() + " 客服部:" + RecordCount1.ToString() + " 介入部:" + RecordCount2.ToString() + " 投诉:" + RecordCount3.ToString() + " 盗号纠纷单:" + RecordCount6.ToString() + " 其它:" + RecordCount4.ToString() + " 待确定:" + RecordCount5.ToString();
        }
    }
}
