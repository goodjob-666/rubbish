/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            sys_PendingComment管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/5/23 2:08:31
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

namespace DLT.Web.Module.DLT.sys_PendingComment
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
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
            sys_PendingCommentEntity ut = BusinessFacadeDLT.sys_PendingCommentDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加sys_PendingComment";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看sys_PendingComment";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改sys_PendingComment";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.sys_PendingCommentInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    break;
                default :
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    break;
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "sys_PendingComment";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "sys_PendingComment";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(sys_PendingCommentEntity ut)
        {
        sys_PendingComment_P_PendingID_Input.Text = sys_PendingComment_P_PendingID_Disp.Text = ut.P_PendingID.ToString();
                sys_PendingComment_P_CommentPostID_Input.Text = sys_PendingComment_P_CommentPostID_Disp.Text = ut.P_CommentPostID.ToString();
                sys_PendingComment_P_CommentStauts_Input.Text = sys_PendingComment_P_CommentStauts_Disp.Text = ut.P_CommentStauts.ToString();
                sys_PendingComment_P_CommentContent_Input.Text = sys_PendingComment_P_CommentContent_Disp.Text = ut.P_CommentContent.ToString();
                sys_PendingComment_P_CommentRemarks_Input.Text = sys_PendingComment_P_CommentRemarks_Disp.Text = ut.P_CommentRemarks.ToString();
                sys_PendingComment_P_Pre_Input.Text = sys_PendingComment_P_Pre_Disp.Text = ut.P_Pre.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        sys_PendingComment_P_PendingID_Input.Visible = false;
        sys_PendingComment_P_CommentPostID_Input.Visible = false;
        sys_PendingComment_P_CommentStauts_Input.Visible = false;
        sys_PendingComment_P_CommentContent_Input.Visible = false;
        sys_PendingComment_P_CommentRemarks_Input.Visible = false;
        sys_PendingComment_P_Pre_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        sys_PendingComment_P_PendingID_Disp.Visible = false;
        sys_PendingComment_P_CommentPostID_Disp.Visible = false;
        sys_PendingComment_P_CommentStauts_Disp.Visible = false;
        sys_PendingComment_P_CommentContent_Disp.Visible = false;
        sys_PendingComment_P_CommentRemarks_Disp.Visible = false;
        sys_PendingComment_P_Pre_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int sys_PendingComment_P_PendingID_Value = (int)Common.sink(sys_PendingComment_P_PendingID_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            int sys_PendingComment_P_CommentPostID_Value = (int)Common.sink(sys_PendingComment_P_CommentPostID_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            int sys_PendingComment_P_CommentStauts_Value = (int)Common.sink(sys_PendingComment_P_CommentStauts_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string sys_PendingComment_P_CommentContent_Value = (string)Common.sink(sys_PendingComment_P_CommentContent_Input.UniqueID, MethodType.Post, 2147483647, 1, DataType.Str);
            string sys_PendingComment_P_CommentRemarks_Value = (string)Common.sink(sys_PendingComment_P_CommentRemarks_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string sys_PendingComment_P_Pre_Value = (string)Common.sink(sys_PendingComment_P_Pre_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            sys_PendingCommentEntity ut = BusinessFacadeDLT.sys_PendingCommentDisp(IDX);
            
            ut.P_PendingID = sys_PendingComment_P_PendingID_Value;
            ut.P_CommentPostID = sys_PendingComment_P_CommentPostID_Value;
            ut.P_CommentStauts = sys_PendingComment_P_CommentStauts_Value;
            ut.P_CommentContent = sys_PendingComment_P_CommentContent_Value;
            ut.P_CommentRemarks = sys_PendingComment_P_CommentRemarks_Value;
            ut.P_Pre = sys_PendingComment_P_Pre_Value;
            
            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
            Int32 rInt = BusinessFacadeDLT.sys_PendingCommentInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加sys_PendingComment成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改sys_PendingComment成功!(ID:{0})",IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
        }
    }
}
