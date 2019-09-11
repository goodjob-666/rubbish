/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            银行账户管理
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

namespace DLT.Web.Module.DLT.tsBank
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
            tsBankEntity ut = BusinessFacadeDLT.tsBankDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加银行账户";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看银行账户";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改银行账户";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsBankInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "银行账户";
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
            bi.ButtonName = "银行账户";
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
        private void OnStartData(tsBankEntity ut)
        {
        tsBank_UserID_Input.Text = tsBank_UserID_Disp.Text = ut.UserID.ToString();
                tsBank_BankID_Input.Text = tsBank_BankID_Disp.Text = ut.BankID.ToString();
                tsBank_BankUser_Input.Text = tsBank_BankUser_Disp.Text = ut.BankUser.ToString();
                tsBank_BankAcc_Input.Text = tsBank_BankAcc_Disp.Text = ut.BankAcc.ToString();
                tsBank_BankAddr_Input.Text = tsBank_BankAddr_Disp.Text = ut.BankAddr.ToString();
                tsBank_IsDefault_Input.SelectedValue = Convert.ToInt32(ut.IsDefault).ToString();
                tsBank_IsDefault_Disp.Text = ut.IsDefault.ToString();
                tsBank_Comment_Input.Text = tsBank_Comment_Disp.Text = ut.Comment.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tsBank_UserID_Input.Visible = false;
        tsBank_BankID_Input.Visible = false;
        tsBank_BankUser_Input.Visible = false;
        tsBank_BankAcc_Input.Visible = false;
        tsBank_BankAddr_Input.Visible = false;
        tsBank_IsDefault_Input.Visible = false;
        tsBank_Comment_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tsBank_UserID_Disp.Visible = false;
        tsBank_BankID_Disp.Visible = false;
        tsBank_BankUser_Disp.Visible = false;
        tsBank_BankAcc_Disp.Visible = false;
        tsBank_BankAddr_Disp.Visible = false;
        tsBank_IsDefault_Disp.Visible = false;
        tsBank_Comment_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tsBank_UserID_Value = (int)Common.sink(tsBank_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    Int16 tsBank_BankID_Value = Convert.ToInt16(Common.sink(tsBank_BankID_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            string tsBank_BankUser_Value = (string)Common.sink(tsBank_BankUser_Input.UniqueID, MethodType.Post, 100, 1, DataType.Str);
            string tsBank_BankAcc_Value = (string)Common.sink(tsBank_BankAcc_Input.UniqueID, MethodType.Post, 100, 1, DataType.Str);
            string tsBank_BankAddr_Value = (string)Common.sink(tsBank_BankAddr_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            
                    bool tsBank_IsDefault_Value = Convert.ToBoolean(Common.sink(tsBank_IsDefault_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            string tsBank_Comment_Value = (string)Common.sink(tsBank_Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            tsBankEntity ut = BusinessFacadeDLT.tsBankDisp(IDX);
            
            ut.UserID = tsBank_UserID_Value;
            ut.BankID = tsBank_BankID_Value;
            ut.BankUser = tsBank_BankUser_Value;
            ut.BankAcc = tsBank_BankAcc_Value;
            ut.BankAddr = tsBank_BankAddr_Value;
            ut.IsDefault = tsBank_IsDefault_Value;
            ut.Comment = tsBank_Comment_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tsBankInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加银行账户成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改银行账户成功!(ID:{0})",IDX);
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
