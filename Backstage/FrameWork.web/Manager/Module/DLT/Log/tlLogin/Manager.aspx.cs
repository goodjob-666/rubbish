/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            登录日志管理
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

namespace DLT.Web.Module.DLT.tlLogin
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
            tlLoginEntity ut = BusinessFacadeDLT.tlLoginDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加登录日志";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看登录日志";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改登录日志";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tlLoginInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "登录日志";
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
            bi.ButtonName = "登录日志";
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
        private void OnStartData(tlLoginEntity ut)
        {
                tlLogin_UserID_Input.Text = tlLogin_UserID_Disp.Text = ut.UserID.ToString();
                tlLogin_SubUserID_Input.Text = tlLogin_SubUserID_Disp.Text = ut.SubUserID.ToString();
                tlLogin_LoginType_Input.Text = tlLogin_LoginType_Disp.Text = ut.LoginType.ToString();
                tlLogin_PCName_Input.Text = tlLogin_PCName_Disp.Text = ut.PCName.ToString();
                tlLogin_HD_Input.Text = tlLogin_HD_Disp.Text = ut.HD.ToString();
                tlLogin_Mac_Input.Text = tlLogin_Mac_Disp.Text = ut.Mac.ToString();
                tlLogin_IP_Input.Text = tlLogin_IP_Disp.Text = ut.IP.ToString();
                tlLogin_OS_Input.Text = tlLogin_OS_Disp.Text = ut.OS.ToString();
                tlLogin_LoginDate_Input.Text = tlLogin_LoginDate_Disp.Text = ut.LoginDate.ToString();
                tlLogin_LogoutDate_Input.Text = tlLogin_LogoutDate_Disp.Text = ut.LogoutDate.ToString();
                tlLogin_Status_Input.Text = tlLogin_Status_Disp.Text = ut.Status.ToString();
                tlLogin_Comment_Input.Text = tlLogin_Comment_Disp.Text = ut.Comment.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tlLogin_UserID_Input.Visible = false;
        tlLogin_SubUserID_Input.Visible = false;
        tlLogin_LoginType_Input.Visible = false;
        tlLogin_PCName_Input.Visible = false;
        tlLogin_HD_Input.Visible = false;
        tlLogin_Mac_Input.Visible = false;
        tlLogin_IP_Input.Visible = false;
        tlLogin_OS_Input.Visible = false;
        tlLogin_LoginDate_Input.Visible = false;
        tlLogin_LogoutDate_Input.Visible = false;
        tlLogin_Status_Input.Visible = false;
        tlLogin_Comment_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tlLogin_UserID_Disp.Visible = false;
        tlLogin_SubUserID_Disp.Visible = false;
        tlLogin_LoginType_Disp.Visible = false;
        tlLogin_PCName_Disp.Visible = false;
        tlLogin_HD_Disp.Visible = false;
        tlLogin_Mac_Disp.Visible = false;
        tlLogin_IP_Disp.Visible = false;
        tlLogin_OS_Disp.Visible = false;
        tlLogin_LoginDate_Disp.Visible = false;
        tlLogin_LogoutDate_Disp.Visible = false;
        tlLogin_Status_Disp.Visible = false;
        tlLogin_Comment_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tlLogin_UserID_Value = (int)Common.sink(tlLogin_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tlLogin_SubUserID_Value = (int)Common.sink(tlLogin_SubUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tlLogin_LoginType_Value = (int)Common.sink(tlLogin_LoginType_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            string tlLogin_PCName_Value = (string)Common.sink(tlLogin_PCName_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string tlLogin_HD_Value = (string)Common.sink(tlLogin_HD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string tlLogin_Mac_Value = (string)Common.sink(tlLogin_Mac_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string tlLogin_IP_Value = (string)Common.sink(tlLogin_IP_Input.UniqueID, MethodType.Post, 20, 1, DataType.Str);
            string tlLogin_OS_Value = (string)Common.sink(tlLogin_OS_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
            DateTime? tlLogin_LoginDate_Value = (DateTime?)Common.sink(tlLogin_LoginDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
            DateTime? tlLogin_LogoutDate_Value = (DateTime?)Common.sink(tlLogin_LogoutDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
            Int16 tlLogin_Status_Value = Convert.ToInt16(Common.sink(tlLogin_Status_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
                
            string tlLogin_Comment_Value = (string)Common.sink(tlLogin_Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            tlLoginEntity ut = BusinessFacadeDLT.tlLoginDisp(IDX);
            
            ut.UserID = tlLogin_UserID_Value;
            ut.SubUserID = tlLogin_SubUserID_Value;
            ut.LoginType = tlLogin_LoginType_Value;
            ut.PCName = tlLogin_PCName_Value;
            ut.HD = tlLogin_HD_Value;
            ut.Mac = tlLogin_Mac_Value;
            ut.IP = tlLogin_IP_Value;
            ut.OS = tlLogin_OS_Value;
            ut.LoginDate = tlLogin_LoginDate_Value;
            ut.LogoutDate = tlLogin_LogoutDate_Value;
            ut.Status = tlLogin_Status_Value;
            ut.Comment = tlLogin_Comment_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tlLoginInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加登录日志成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改登录日志成功!(ID:{0})",IDX);
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
