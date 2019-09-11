/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            子用户管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2014/8/5 13:39:35
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

namespace DLT.Web.Module.DLT.tsSubUser
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
            tsSubUserEntity ut = BusinessFacadeDLT.tsSubUserDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加子用户";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看子用户";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改子用户";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsSubUserInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "子用户";
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
            bi.ButtonName = "子用户";
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
        private void OnStartData(tsSubUserEntity ut)
        {
        tsSubUser_UserID_Input.Text = tsSubUser_UserID_Disp.Text = ut.UserID.ToString();
                tsSubUser_LoginID_Input.Text = tsSubUser_LoginID_Disp.Text = ut.LoginID.ToString();
                tsSubUser_SubUserName_Input.Text = tsSubUser_SubUserName_Disp.Text = ut.SubUserName.ToString();
                tsSubUser_Pass_Input.Text = tsSubUser_Pass_Disp.Text = ut.Pass.ToString();
                tsSubUser_CreateDate_Input.Text = tsSubUser_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tsSubUser_Comment_Input.Text = tsSubUser_Comment_Disp.Text = ut.Comment.ToString();
                tsSubUser_Token_Input.Text = tsSubUser_Token_Disp.Text = ut.Token.ToString();
                tsSubUser_LiveTime_Input.Text = tsSubUser_LiveTime_Disp.Text = ut.LiveTime.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tsSubUser_UserID_Input.Visible = false;
        tsSubUser_LoginID_Input.Visible = false;
        tsSubUser_SubUserName_Input.Visible = false;
        tsSubUser_Pass_Input.Visible = false;
        tsSubUser_CreateDate_Input.Visible = false;
        tsSubUser_Comment_Input.Visible = false;
        tsSubUser_Token_Input.Visible = false;
        tsSubUser_LiveTime_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tsSubUser_UserID_Disp.Visible = false;
        tsSubUser_LoginID_Disp.Visible = false;
        tsSubUser_SubUserName_Disp.Visible = false;
        tsSubUser_Pass_Disp.Visible = false;
        tsSubUser_CreateDate_Disp.Visible = false;
        tsSubUser_Comment_Disp.Visible = false;
        tsSubUser_Token_Disp.Visible = false;
        tsSubUser_LiveTime_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tsSubUser_UserID_Value = (int)Common.sink(tsSubUser_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsSubUser_LoginID_Value = (string)Common.sink(tsSubUser_LoginID_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsSubUser_SubUserName_Value = (string)Common.sink(tsSubUser_SubUserName_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string tsSubUser_Pass_Value = (string)Common.sink(tsSubUser_Pass_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            DateTime tsSubUser_CreateDate_Value = (DateTime)Common.sink(tsSubUser_CreateDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);
            string tsSubUser_Comment_Value = (string)Common.sink(tsSubUser_Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            string tsSubUser_Token_Value = (string)Common.sink(tsSubUser_Token_Input.UniqueID, MethodType.Post, 64, 0, DataType.Str);
            
                    DateTime? tsSubUser_LiveTime_Value = (DateTime?)Common.sink(tsSubUser_LiveTime_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            tsSubUserEntity ut = BusinessFacadeDLT.tsSubUserDisp(IDX);
            
            ut.UserID = tsSubUser_UserID_Value;
            ut.LoginID = tsSubUser_LoginID_Value;
            ut.SubUserName = tsSubUser_SubUserName_Value;
            ut.Pass = tsSubUser_Pass_Value;
            ut.CreateDate = tsSubUser_CreateDate_Value;
            ut.Comment = tsSubUser_Comment_Value;
            ut.Token = tsSubUser_Token_Value;
            ut.LiveTime = tsSubUser_LiveTime_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tsSubUserInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加子用户成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改子用户成功!(ID:{0})",IDX);
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
