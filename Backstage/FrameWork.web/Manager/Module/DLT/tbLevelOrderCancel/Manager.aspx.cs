/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            代练撤销管理
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

namespace DLT.Web.Module.DLT.tbLevelOrderCancel
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
            tbLevelOrderCancelEntity ut = BusinessFacadeDLT.tbLevelOrderCancelDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加代练撤销";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看代练撤销";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改代练撤销";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbLevelOrderCancelInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "代练撤销";
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
            bi.ButtonName = "代练撤销";
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
        private void OnStartData(tbLevelOrderCancelEntity ut)
        {
        tbLevelOrderCancel_ODSerialNo_Input.Text = tbLevelOrderCancel_ODSerialNo_Disp.Text = ut.ODSerialNo.ToString();
                tbLevelOrderCancel_UserID_Input.Text = tbLevelOrderCancel_UserID_Disp.Text = ut.UserID.ToString();
                tbLevelOrderCancel_CreateDate_Input.Text = tbLevelOrderCancel_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbLevelOrderCancel_PayLevelBal_Input.Text = tbLevelOrderCancel_PayLevelBal_Disp.Text = ut.PayLevelBal.ToString();
                tbLevelOrderCancel_RepEnsureBal_Input.Text = tbLevelOrderCancel_RepEnsureBal_Disp.Text = ut.RepEnsureBal.ToString();
                tbLevelOrderCancel_Status_Input.Text = tbLevelOrderCancel_Status_Disp.Text = ut.Status.ToString();
                tbLevelOrderCancel_Comment_Input.Text = tbLevelOrderCancel_Comment_Disp.Text = ut.Comment.ToString();
                tbLevelOrderCancel_AcceptCount_Input.Text = tbLevelOrderCancel_AcceptCount_Disp.Text = ut.AcceptCount.ToString();
                tbLevelOrderCancel_PublishCount_Input.Text = tbLevelOrderCancel_PublishCount_Disp.Text = ut.PublishCount.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbLevelOrderCancel_ODSerialNo_Input.Visible = false;
        tbLevelOrderCancel_UserID_Input.Visible = false;
        tbLevelOrderCancel_CreateDate_Input.Visible = false;
        tbLevelOrderCancel_PayLevelBal_Input.Visible = false;
        tbLevelOrderCancel_RepEnsureBal_Input.Visible = false;
        tbLevelOrderCancel_Status_Input.Visible = false;
        tbLevelOrderCancel_Comment_Input.Visible = false;
        tbLevelOrderCancel_AcceptCount_Input.Visible = false;
        tbLevelOrderCancel_PublishCount_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbLevelOrderCancel_ODSerialNo_Disp.Visible = false;
        tbLevelOrderCancel_UserID_Disp.Visible = false;
        tbLevelOrderCancel_CreateDate_Disp.Visible = false;
        tbLevelOrderCancel_PayLevelBal_Disp.Visible = false;
        tbLevelOrderCancel_RepEnsureBal_Disp.Visible = false;
        tbLevelOrderCancel_Status_Disp.Visible = false;
        tbLevelOrderCancel_Comment_Disp.Visible = false;
        tbLevelOrderCancel_AcceptCount_Disp.Visible = false;
        tbLevelOrderCancel_PublishCount_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tbLevelOrderCancel_ODSerialNo_Value = (string)Common.sink(tbLevelOrderCancel_ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            int tbLevelOrderCancel_UserID_Value = (int)Common.sink(tbLevelOrderCancel_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            DateTime tbLevelOrderCancel_CreateDate_Value = (DateTime)Common.sink(tbLevelOrderCancel_CreateDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);
            double tbLevelOrderCancel_PayLevelBal_Value = (double)Common.sink(tbLevelOrderCancel_PayLevelBal_Input.UniqueID, MethodType.Post, 19, 1, DataType.Double);
            double tbLevelOrderCancel_RepEnsureBal_Value = (double)Common.sink(tbLevelOrderCancel_RepEnsureBal_Input.UniqueID, MethodType.Post, 19, 1, DataType.Double);
            
                    Int16 tbLevelOrderCancel_Status_Value = Convert.ToInt16(Common.sink(tbLevelOrderCancel_Status_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            string tbLevelOrderCancel_Comment_Value = (string)Common.sink(tbLevelOrderCancel_Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            int tbLevelOrderCancel_AcceptCount_Value = (int)Common.sink(tbLevelOrderCancel_AcceptCount_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            int tbLevelOrderCancel_PublishCount_Value = (int)Common.sink(tbLevelOrderCancel_PublishCount_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            tbLevelOrderCancelEntity ut = BusinessFacadeDLT.tbLevelOrderCancelDisp(IDX);
            
            ut.ODSerialNo = tbLevelOrderCancel_ODSerialNo_Value;
            ut.UserID = tbLevelOrderCancel_UserID_Value;
            ut.CreateDate = tbLevelOrderCancel_CreateDate_Value;
            ut.PayLevelBal = tbLevelOrderCancel_PayLevelBal_Value;
            ut.RepEnsureBal = tbLevelOrderCancel_RepEnsureBal_Value;
            ut.Status = tbLevelOrderCancel_Status_Value;
            ut.Comment = tbLevelOrderCancel_Comment_Value;
            ut.AcceptCount = tbLevelOrderCancel_AcceptCount_Value;
            ut.PublishCount = tbLevelOrderCancel_PublishCount_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbLevelOrderCancelInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加代练撤销成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改代练撤销成功!(ID:{0})",IDX);
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
