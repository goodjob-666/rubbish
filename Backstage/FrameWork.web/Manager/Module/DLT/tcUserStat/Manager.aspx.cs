/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            用户统计数据管理
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

namespace DLT.Web.Module.DLT.tcUserStat
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
            tcUserStatEntity ut = BusinessFacadeDLT.tcUserStatDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加用户统计数据";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看用户统计数据";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改用户统计数据";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tcUserStatInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else
                    {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    break;
                default:
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
            bi.ButtonName = "用户统计数据";
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
            bi.ButtonName = "用户统计数据";
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
        private void OnStartData(tcUserStatEntity ut)
        {
            tcUserStat_UserID_Input.Text = tcUserStat_UserID_Disp.Text = ut.UserID.ToString();
            tcUserStat_PubCount_Input.Text = tcUserStat_PubCount_Disp.Text = ut.PubCount.ToString();
            tcUserStat_PubCancel_Input.Text = tcUserStat_PubCancel_Disp.Text = ut.PubCancel.ToString();
            tcUserStat_PubConsultCancel_Input.Text = tcUserStat_PubConsultCancel_Disp.Text = ut.PubConsultCancel.ToString();
            tcUserStat_AcceptCount_Input.Text = tcUserStat_AcceptCount_Disp.Text = ut.AcceptCount.ToString();
            tcUserStat_AcceptCancel_Input.Text = tcUserStat_AcceptCancel_Disp.Text = ut.AcceptCancel.ToString();
            tcUserStat_AcceptConsultCancel_Input.Text = tcUserStat_AcceptConsultCancel_Disp.Text = ut.AcceptConsultCancel.ToString();
            tcUserStat_OnlineMin_Input.Text = tcUserStat_OnlineMin_Disp.Text = ut.OnlineMin.ToString();

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tcUserStat_UserID_Input.Visible = false;
            tcUserStat_PubCount_Input.Visible = false;
            tcUserStat_PubCancel_Input.Visible = false;
            tcUserStat_PubConsultCancel_Input.Visible = false;
            tcUserStat_AcceptCount_Input.Visible = false;
            tcUserStat_AcceptCancel_Input.Visible = false;
            tcUserStat_AcceptConsultCancel_Input.Visible = false;
            tcUserStat_OnlineMin_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tcUserStat_UserID_Disp.Visible = false;
            tcUserStat_PubCount_Disp.Visible = false;
            tcUserStat_PubCancel_Disp.Visible = false;
            tcUserStat_PubConsultCancel_Disp.Visible = false;
            tcUserStat_AcceptCount_Disp.Visible = false;
            tcUserStat_AcceptCancel_Disp.Visible = false;
            tcUserStat_AcceptConsultCancel_Disp.Visible = false;
            tcUserStat_OnlineMin_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            int tcUserStat_UserID_Value = (int)Common.sink(tcUserStat_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_PubCount_Value = (int)Common.sink(tcUserStat_PubCount_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_PubCancel_Value = (int)Common.sink(tcUserStat_PubCancel_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_PubConsultCancel_Value = (int)Common.sink(tcUserStat_PubConsultCancel_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_AcceptCount_Value = (int)Common.sink(tcUserStat_AcceptCount_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_AcceptCancel_Value = (int)Common.sink(tcUserStat_AcceptCancel_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tcUserStat_AcceptConsultCancel_Value = (int)Common.sink(tcUserStat_AcceptConsultCancel_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            Int64 tcUserStat_OnlineMin_Value = (Int64)Common.sink(tcUserStat_OnlineMin_Input.UniqueID, MethodType.Post, 19, 0, DataType.Long);
           
            tcUserStatEntity ut = BusinessFacadeDLT.tcUserStatDisp(IDX);

            ut.UserID = tcUserStat_UserID_Value;
            ut.PubCount = tcUserStat_PubCount_Value;
            ut.PubCancel = tcUserStat_PubCancel_Value;
            ut.PubConsultCancel = tcUserStat_PubConsultCancel_Value;
            ut.AcceptCount = tcUserStat_AcceptCount_Value;
            ut.AcceptCancel = tcUserStat_AcceptCancel_Value;
            ut.AcceptConsultCancel = tcUserStat_AcceptConsultCancel_Value;
            ut.OnlineMin = tcUserStat_OnlineMin_Value;

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
            Int32 rInt = BusinessFacadeDLT.tcUserStatInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加用户统计数据成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改用户统计数据成功!(ID:{0})", IDX);
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
