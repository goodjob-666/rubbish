/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            代练订单角色资料管理
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

namespace DLT.Web.Module.DLT.tbLevelOrderInfo
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
            tbLevelOrderInfoEntity ut = BusinessFacadeDLT.tbLevelOrderInfoDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加代练订单角色资料";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看代练订单角色资料";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改代练订单角色资料";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbLevelOrderInfoInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "代练订单角色资料";
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
            bi.ButtonName = "代练订单角色资料";
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
        private void OnStartData(tbLevelOrderInfoEntity ut)
        {
        tbLevelOrderInfo_ODSerialNo_Input.Text = tbLevelOrderInfo_ODSerialNo_Disp.Text = ut.ODSerialNo.ToString();
                tbLevelOrderInfo_GameAcc_Input.Text = tbLevelOrderInfo_GameAcc_Disp.Text = ut.GameAcc.ToString();
                tbLevelOrderInfo_GamePass_Input.Text = tbLevelOrderInfo_GamePass_Disp.Text = ut.GamePass.ToString();
                tbLevelOrderInfo_Actor_Input.Text = tbLevelOrderInfo_Actor_Disp.Text = ut.Actor.ToString();
                tbLevelOrderInfo_CurrInfo_Input.Text = tbLevelOrderInfo_CurrInfo_Disp.Text = ut.CurrInfo.ToString();
                tbLevelOrderInfo_Require_Input.Text = tbLevelOrderInfo_Require_Disp.Text = ut.Require.ToString();
                tbLevelOrderInfo_Comment_Input.Text = tbLevelOrderInfo_Comment_Disp.Text = ut.Comment.ToString();
                tbLevelOrderInfo_ChangePassCount_Input.Text = tbLevelOrderInfo_ChangePassCount_Disp.Text = ut.ChangePassCount.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbLevelOrderInfo_ODSerialNo_Input.Visible = false;
        tbLevelOrderInfo_GameAcc_Input.Visible = false;
        tbLevelOrderInfo_GamePass_Input.Visible = false;
        tbLevelOrderInfo_Actor_Input.Visible = false;
        tbLevelOrderInfo_CurrInfo_Input.Visible = false;
        tbLevelOrderInfo_Require_Input.Visible = false;
        tbLevelOrderInfo_SecPic_Input.Visible = false;
        tbLevelOrderInfo_Comment_Input.Visible = false;
        tbLevelOrderInfo_ChangePassCount_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbLevelOrderInfo_ODSerialNo_Disp.Visible = false;
        tbLevelOrderInfo_GameAcc_Disp.Visible = false;
        tbLevelOrderInfo_GamePass_Disp.Visible = false;
        tbLevelOrderInfo_Actor_Disp.Visible = false;
        tbLevelOrderInfo_CurrInfo_Disp.Visible = false;
        tbLevelOrderInfo_Require_Disp.Visible = false;
        tbLevelOrderInfo_SecPic_Disp.Visible = false;
        tbLevelOrderInfo_Comment_Disp.Visible = false;
        tbLevelOrderInfo_ChangePassCount_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tbLevelOrderInfo_ODSerialNo_Value = (string)Common.sink(tbLevelOrderInfo_ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string tbLevelOrderInfo_GameAcc_Value = (string)Common.sink(tbLevelOrderInfo_GameAcc_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tbLevelOrderInfo_GamePass_Value = (string)Common.sink(tbLevelOrderInfo_GamePass_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tbLevelOrderInfo_Actor_Value = (string)Common.sink(tbLevelOrderInfo_Actor_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tbLevelOrderInfo_CurrInfo_Value = (string)Common.sink(tbLevelOrderInfo_CurrInfo_Input.UniqueID, MethodType.Post, 512, 1, DataType.Str);
            string tbLevelOrderInfo_Require_Value = (string)Common.sink(tbLevelOrderInfo_Require_Input.UniqueID, MethodType.Post, 1024, 1, DataType.Str);
            
            string tbLevelOrderInfo_Comment_Value = (string)Common.sink(tbLevelOrderInfo_Comment_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            int tbLevelOrderInfo_ChangePassCount_Value = (int)Common.sink(tbLevelOrderInfo_ChangePassCount_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            tbLevelOrderInfoEntity ut = BusinessFacadeDLT.tbLevelOrderInfoDisp(IDX);
            
            ut.ODSerialNo = tbLevelOrderInfo_ODSerialNo_Value;
            ut.GameAcc = tbLevelOrderInfo_GameAcc_Value;
            ut.GamePass = tbLevelOrderInfo_GamePass_Value;
            ut.Actor = tbLevelOrderInfo_Actor_Value;
            ut.CurrInfo = tbLevelOrderInfo_CurrInfo_Value;
            ut.Require = tbLevelOrderInfo_Require_Value;
            ut.Comment = tbLevelOrderInfo_Comment_Value;
            ut.ChangePassCount = tbLevelOrderInfo_ChangePassCount_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbLevelOrderInfoInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加代练订单角色资料成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改代练订单角色资料成功!(ID:{0})",IDX);
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
