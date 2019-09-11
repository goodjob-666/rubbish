/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            订单交互留言管理
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

namespace DLT.Web.Module.DLT.tbLevelOrderMessage
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
            tbLevelOrderMessageEntity ut = BusinessFacadeDLT.tbLevelOrderMessageDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加订单交互留言";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看订单交互留言";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改订单交互留言";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbLevelOrderMessageInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "订单交互留言";
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
            bi.ButtonName = "订单交互留言";
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
        private void OnStartData(tbLevelOrderMessageEntity ut)
        {
                tbLevelOrderMessage_ODSerialNo_Input.Text = tbLevelOrderMessage_ODSerialNo_Disp.Text = ut.ODSerialNo.ToString();
                tbLevelOrderMessage_UserID_Input.Text = tbLevelOrderMessage_UserID_Disp.Text = ut.UserID.ToString();
                tbLevelOrderMessage_MsgType_Input.Text = tbLevelOrderMessage_MsgType_Disp.Text = ut.MsgType.ToString();
                tbLevelOrderMessage_Msg_Input.Text = tbLevelOrderMessage_Msg_Disp.Text = ut.Msg.ToString();
                tbLevelOrderMessage_CreateDate_Input.Text = tbLevelOrderMessage_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbLevelOrderMessage_IsRead_Input.SelectedValue = Convert.ToInt32(ut.IsRead).ToString();
                tbLevelOrderMessage_IsRead_Disp.Text = ut.IsRead.ToString();
                tbLevelOrderMessage_IsRead2_Input.SelectedValue = Convert.ToInt32(ut.IsRead2).ToString();
                tbLevelOrderMessage_IsRead2_Disp.Text = ut.IsRead2.ToString();

                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbLevelOrderMessage_ODSerialNo_Input.Visible = false;
        tbLevelOrderMessage_UserID_Input.Visible = false;
        tbLevelOrderMessage_MsgType_Input.Visible = false;
        tbLevelOrderMessage_Msg_Input.Visible = false;
        tbLevelOrderMessage_CreateDate_Input.Visible = false;
        tbLevelOrderMessage_IsRead_Input.Visible = false;
        tbLevelOrderMessage_IsRead2_Input.Visible = false;

        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbLevelOrderMessage_ODSerialNo_Disp.Visible = false;
        tbLevelOrderMessage_UserID_Disp.Visible = false;
        tbLevelOrderMessage_MsgType_Disp.Visible = false;
        tbLevelOrderMessage_Msg_Disp.Visible = false;
        tbLevelOrderMessage_CreateDate_Disp.Visible = false;
        tbLevelOrderMessage_IsRead_Disp.Visible = false;
        tbLevelOrderMessage_IsRead2_Disp.Visible = false;

        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tbLevelOrderMessage_ODSerialNo_Value = (string)Common.sink(tbLevelOrderMessage_ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            int tbLevelOrderMessage_UserID_Value = (int)Common.sink(tbLevelOrderMessage_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    Int16 tbLevelOrderMessage_MsgType_Value = Convert.ToInt16(Common.sink(tbLevelOrderMessage_MsgType_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            string tbLevelOrderMessage_Msg_Value = (string)Common.sink(tbLevelOrderMessage_Msg_Input.UniqueID, MethodType.Post, 1024, 1, DataType.Str);
            DateTime tbLevelOrderMessage_CreateDate_Value = (DateTime)Common.sink(tbLevelOrderMessage_CreateDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);
            
                    bool tbLevelOrderMessage_IsRead_Value = Convert.ToBoolean(Common.sink(tbLevelOrderMessage_IsRead_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
                
            
                    bool tbLevelOrderMessage_IsRead2_Value = Convert.ToBoolean(Common.sink(tbLevelOrderMessage_IsRead2_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
                

            tbLevelOrderMessageEntity ut = BusinessFacadeDLT.tbLevelOrderMessageDisp(IDX);
            
            ut.ODSerialNo = tbLevelOrderMessage_ODSerialNo_Value;
            ut.UserID = tbLevelOrderMessage_UserID_Value;
            ut.MsgType = tbLevelOrderMessage_MsgType_Value;
            ut.Msg = tbLevelOrderMessage_Msg_Value;
            ut.CreateDate = tbLevelOrderMessage_CreateDate_Value;
            ut.IsRead = tbLevelOrderMessage_IsRead_Value;
            ut.IsRead2 = tbLevelOrderMessage_IsRead2_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbLevelOrderMessageInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加订单交互留言成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改订单交互留言成功!(ID:{0})",IDX);
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
