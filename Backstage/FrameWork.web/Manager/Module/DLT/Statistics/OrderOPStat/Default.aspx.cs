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

using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.OrderOPStat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSearchType();
                //BindGameList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd 00:00:00");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59"); 
                BindDataList();
                BindNoGroupList();
                BindGroupList();
            }
        }

        private void BindSearchType()
        {

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = BusinessFacadeDLT.sys_StatisticalGroupingList(qp, out RecordCount);
            foreach (sys_StatisticalGroupingEntity var in lst)
            {
                DropDownList2.Items.Add(new ListItem(var.S_Name, var.S_ID.ToString()));
            }
        }

        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGLGameID.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            DataSet ds = BusinessFacadeDLT.OrderOPStat(DateTime.Parse(S_dtDate_Input.Text), DateTime.Parse(E_dtDate_Input.Text), tbOPName.Text,DropDownList2.SelectedValue);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        private void BindGroupList()
        {
            QueryParam qp = new QueryParam();
            int RecordCount = 0;
            List<sys_StatisticalGroupingEntity> lst = BusinessFacadeDLT.sys_StatisticalGroupingList(qp, out RecordCount);

            DropDownList1.DataSource = lst;
            DropDownList1.DataBind();
   
            //绑定右侧列表
            BindRListBox();
        }


        private void BindRListBox()
        {
            QueryParam qp = new QueryParam();
            int RecordCount = 0;
            qp.Where=" where 1=1 and U_SGroupID="+DropDownList1.SelectedValue;
            ArrayList lst = BusinessFacade.sys_UserList(qp, out RecordCount);

            ListBox2.DataSource = lst;
            ListBox2.DataBind();
        }

        private void BindNoGroupList()
        {
            QueryParam qp = new QueryParam();
            int RecordCount = 0;
            qp.Where = " WHERE 1=1 AND U_SGroupID=0";
            ArrayList lst = BusinessFacade.sys_UserList(qp, out RecordCount);

            ListBox1.DataSource = lst;
            ListBox1.DataBind();    
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            //保存待分组用户
            int count1 = ListBox1.Items.Count;

            for (int i = 0; i < count1; i++)
            {
                sys_UserTable ut = BusinessFacade.sys_UserDisp(int.Parse(ListBox1.Items[i].Value));
                ut.U_SGroupID = 0;
                ut.DB_Option_Action_ = "Update";
                int rInt = BusinessFacade.sys_UserInsertUpdate(ut);
            }

            //保存右边分组用户

            int count2 = ListBox2.Items.Count;

            for (int j = 0; j < count2; j++)
            {
                sys_UserTable ut = BusinessFacade.sys_UserDisp(int.Parse(ListBox2.Items[j].Value));
                ut.U_SGroupID = int.Parse(DropDownList1.SelectedValue);
                ut.DB_Option_Action_ = "Update";
                int rInt = BusinessFacade.sys_UserInsertUpdate(ut);
            }

            Response.Write("<script language='javascript'>alert('设置成功!');</script>");

        }

        //全部右移
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int count = ListBox1.Items.Count;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                ListItem item = ListBox1.Items[index];
                ListBox1.Items.Remove(item);
                ListBox2.Items.Add(item);
            }
            index++;
        }

        //全部左移
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            int count = ListBox2.Items.Count;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                ListItem item = ListBox2.Items[index];
                ListBox2.Items.Remove(item);
                ListBox1.Items.Add(item);
            }
            index++;
        }

        //单个或多个右移
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            int count = ListBox1.Items.Count;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                ListItem item = ListBox1.Items[index];
                if (ListBox1.Items[index].Selected == true)
                {

                    ListBox1.Items.Remove(item);
                    ListBox2.Items.Add(item);
                    index--;
                }
                index++;
            }
        }


        //单个或多个左移
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            int count = ListBox2.Items.Count;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                ListItem item = ListBox2.Items[index];
                if (ListBox2.Items[index].Selected == true)
                {

                    ListBox2.Items.Remove(item);
                    ListBox1.Items.Add(item);
                    index--;
                }
                index++;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRListBox();
        }
    }
}
