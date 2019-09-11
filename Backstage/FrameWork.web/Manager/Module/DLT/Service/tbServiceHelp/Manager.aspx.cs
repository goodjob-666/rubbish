/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            tbServiceHelp管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/11/6 11:46:14
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

namespace DLT.Web.Module.DLT.tbServiceHelp
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
            tbServiceHelpEntity ut = BusinessFacadeDLT.tbServiceHelpDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加请求客服协助";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看请求客服协助";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改请求客服协助";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbServiceHelpInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "tbServiceHelp";
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
            bi.ButtonName = "tbServiceHelp";
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
        private void OnStartData(tbServiceHelpEntity ut)
        {
        tbServiceHelp_ODSerialNo_Input.Text = tbServiceHelp_ODSerialNo_Disp.Text = ut.ODSerialNo.ToString();
                tbServiceHelp_UserID_Input.Text = tbServiceHelp_UserID_Disp.Text = ut.UserID.ToString();
                tbServiceHelp_AcceptUserID_Input.Text = tbServiceHelp_AcceptUserID_Disp.Text = ut.AcceptUserID.ToString();
                tbServiceHelp_Content_Input.Text = tbServiceHelp_Content_Disp.Text = ut.Content.ToString();
                tbServiceHelp_IsDeal_Input.SelectedValue = Convert.ToInt32(ut.IsDeal).ToString();
                tbServiceHelp_IsDeal_Disp.Text = ut.IsDeal.ToString();
                tbServiceHelp_CreateDate_Input.Text = tbServiceHelp_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbServiceHelp_DealDate_Input.Text = tbServiceHelp_DealDate_Disp.Text = ut.DealDate.ToString();
                tbServiceHelp_DealCustomerID_Input.Text = tbServiceHelp_DealCustomerID_Disp.Text = ut.DealCustomerID.ToString();
                tbServiceHelp_Remark_Input.Text = tbServiceHelp_Remark_Disp.Text = ut.Remark.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbServiceHelp_ODSerialNo_Input.Visible = false;
        tbServiceHelp_UserID_Input.Visible = false;
        tbServiceHelp_AcceptUserID_Input.Visible = false;
        tbServiceHelp_Content_Input.Visible = false;
        tbServiceHelp_IsDeal_Input.Visible = false;
        tbServiceHelp_CreateDate_Input.Visible = false;
        tbServiceHelp_DealDate_Input.Visible = false;
        tbServiceHelp_DealCustomerID_Input.Visible = false;
        tbServiceHelp_Remark_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbServiceHelp_ODSerialNo_Disp.Visible = false;
        tbServiceHelp_UserID_Disp.Visible = false;
        tbServiceHelp_AcceptUserID_Disp.Visible = false;
        tbServiceHelp_Content_Disp.Visible = false;
        tbServiceHelp_IsDeal_Disp.Visible = false;
        tbServiceHelp_CreateDate_Disp.Visible = false;
        tbServiceHelp_DealDate_Disp.Visible = false;
        tbServiceHelp_DealCustomerID_Disp.Visible = false;
        tbServiceHelp_Remark_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tbServiceHelp_ODSerialNo_Value = (string)Common.sink(tbServiceHelp_ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            int tbServiceHelp_UserID_Value = (int)Common.sink(tbServiceHelp_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tbServiceHelp_AcceptUserID_Value = (int)Common.sink(tbServiceHelp_AcceptUserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tbServiceHelp_Content_Value = (string)Common.sink(tbServiceHelp_Content_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            
            bool tbServiceHelp_IsDeal_Value = Convert.ToBoolean(Common.sink(tbServiceHelp_IsDeal_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
            int tbServiceHelp_HelpType_Value = (int)(Common.sink(tbServiceHelp_HelpType_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
                
            
            DateTime? tbServiceHelp_CreateDate_Value = (DateTime?)Common.sink(tbServiceHelp_CreateDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            
            DateTime? tbServiceHelp_DealDate_Value = (DateTime?)Common.sink(tbServiceHelp_DealDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int tbServiceHelp_DealCustomerID_Value = (int)Common.sink(tbServiceHelp_DealCustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tbServiceHelp_Remark_Value = (string)Common.sink(tbServiceHelp_Remark_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            
            tbServiceHelpEntity ut = BusinessFacadeDLT.tbServiceHelpDisp(IDX);
            
            ut.ODSerialNo = tbServiceHelp_ODSerialNo_Value;
            ut.UserID = tbServiceHelp_UserID_Value;
            ut.AcceptUserID = tbServiceHelp_AcceptUserID_Value;
            ut.Content = tbServiceHelp_Content_Value;
            ut.IsDeal = tbServiceHelp_IsDeal_Value;
            ut.CreateDate = tbServiceHelp_CreateDate_Value;
            ut.DealDate = tbServiceHelp_DealDate_Value;
            ut.DealCustomerID = tbServiceHelp_DealCustomerID_Value;
            ut.Remark = tbServiceHelp_Remark_Value;
            ut.HelpType = tbServiceHelp_HelpType_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbServiceHelpInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加tbServiceHelp成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改tbServiceHelp成功!(ID:{0})",IDX);
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
