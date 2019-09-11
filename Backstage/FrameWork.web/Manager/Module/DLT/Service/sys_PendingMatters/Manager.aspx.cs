/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            sys_PendingMatters管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/5/20 18:51:40
     History:
*********************************************************************************/
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
using FrameWork.WebControls;

namespace DLT.Web.Module.DLT.sys_PendingMatters
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = "New";
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                OnStart();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加客服待办事项";
                    Hidden_Disp();
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    break;
            }
        }



        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            sys_PendingMatters_P_Type_Disp.Visible = false;
            sys_PendingMatters_P_UserID_Disp.Visible = false;
            sys_PendingMatters_P_Contact_Disp.Visible = false;
            sys_PendingMatters_P_OrderNum_Disp.Visible = false;
            sys_PendingMatters_P_CreateDate_Disp.Visible = false;
            sys_PendingMatters_P_ReplyDate_Disp.Visible = false;
            sys_PendingMatters_P_Content_Disp.Visible = false;
            sys_PendingMatters_P_PostID_Disp.Visible = false;
            sys_PendingMatters_P_ReplyID_Disp.Visible = false;
            sys_PendingMatters_P_ReContent_Disp.Visible = false;
            sys_PendingMatters_P_IsDeal_Disp.Visible = false;
            sys_PendingMatters_P_Pre1_Disp.Visible = false;
            sys_PendingMatters_P_Pre2_Disp.Visible = false;
            sys_PendingMatters_P_Pre3_Disp.Visible = false;
            sys_PendingMatters_P_Pre4_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int sys_PendingMatters_P_Type_Value = (int)Common.sink(ddlPendingMattersType.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            string sys_PendingMatters_P_UserID_Value = (string)Common.sink(sys_PendingMatters_P_UserID_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string sys_PendingMatters_P_Contact_Value = (string)Common.sink(sys_PendingMatters_P_Contact_Input.UniqueID, MethodType.Post, 300, 0, DataType.Str);
            string sys_PendingMatters_P_OrderNum_Value = (string)Common.sink(sys_PendingMatters_P_OrderNum_Input.UniqueID, MethodType.Post, 250, 0, DataType.Str);
            DateTime sys_PendingMatters_P_CreateDate_Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime? sys_PendingMatters_P_ReplyDate_Value = (DateTime?)Common.sink(sys_PendingMatters_P_ReplyDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            string sys_PendingMatters_P_Content_Value = (string)Common.sink(sys_PendingMatters_P_Content_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            int sys_PendingMatters_P_PostID_Value = Common.Get_UserID;
            int sys_PendingMatters_P_ReplyID_Value = (int)Common.sink(sys_PendingMatters_P_ReplyID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string sys_PendingMatters_P_ReContent_Value = (string)Common.sink(sys_PendingMatters_P_ReContent_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            int sys_PendingMatters_P_IsDeal_Value = (int)Common.sink(sys_PendingMatters_P_IsDeal_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int sys_PendingMatters_P_Pre1_Value = (int)Common.sink(sys_PendingMatters_P_Pre1_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string sys_PendingMatters_P_Pre2_Value = (string)Common.sink(sys_PendingMatters_P_Pre2_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            
            DateTime? sys_PendingMatters_P_Pre3_Value = (DateTime?)Common.sink(sys_PendingMatters_P_Pre3_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            string sys_PendingMatters_P_Pre4_Value = (string)Common.sink(sys_PendingMatters_P_Pre4_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            sys_PendingMattersEntity ut = BusinessFacadeDLT.sys_PendingMattersDisp(IDX);

            if (sys_PendingMatters_P_Content_Value == "")
            {
                Response.Write("<script language='javascript'>alert('待办事项内容不能为空！');</script>");
                return;
            }
            
            ut.P_Type = sys_PendingMatters_P_Type_Value;
            ut.P_UserID = sys_PendingMatters_P_UserID_Value;
            ut.P_Contact = sys_PendingMatters_P_Contact_Value;
            ut.P_OrderNum = sys_PendingMatters_P_OrderNum_Value;
            ut.P_CreateDate = sys_PendingMatters_P_CreateDate_Value;
            ut.P_ReplyDate = sys_PendingMatters_P_ReplyDate_Value;
            ut.P_Content = sys_PendingMatters_P_Content_Value;
            ut.P_PostID = sys_PendingMatters_P_PostID_Value;
            ut.P_ReplyID = sys_PendingMatters_P_ReplyID_Value;
            ut.P_ReContent = sys_PendingMatters_P_ReContent_Value;
            ut.P_IsDeal = sys_PendingMatters_P_IsDeal_Value;
            ut.P_Pre1 = sys_PendingMatters_P_Pre1_Value;
            ut.P_Pre2 = sys_PendingMatters_P_Pre2_Value;
            ut.P_Pre3 = sys_PendingMatters_P_Pre3_Value;
            ut.P_Pre4 = sys_PendingMatters_P_Pre4_Value;
            ut.DataTable_Action_ = DataTable_Action.Insert;


            Int32 rInt = BusinessFacadeDLT.sys_PendingMattersInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                this.sys_PendingMatters_P_UserID_Input.Text = "";
                this.sys_PendingMatters_P_Contact_Input.Text = "";
                this.sys_PendingMatters_P_OrderNum_Input.Text = "";
                this.sys_PendingMatters_P_Content_Input.Text = "";
                Response.Write("<script language='javascript'>alert('客服待处理事项添加成功！');</script>");

            }
        }
    }
}
