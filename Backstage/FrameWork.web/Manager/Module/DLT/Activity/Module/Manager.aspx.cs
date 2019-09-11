using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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

namespace DLT.Web.Module.DLT.Activity.Module
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
            tsModuleEntity ut = null;
            if (CMD != "New")
            {
                ut = BusinessFacadeDLT.tsModuleDisp(IDX);
                OnStartData(ut);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加游戏";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看游戏";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改游戏";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsModuleInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "活动";
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
            bi.ButtonName = "活动";
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
        private void OnStartData(tsModuleEntity ut)
        {
           
            tsGame_IsOnline_Disp.Text = ut.Enable == true ? "可用" : "禁用";
            tsGame_IsOnline_Input.SelectedValue = ut.Enable == true ? "1" : "0";
            ddlSort.SelectedValue = lblSort.Text = ut.Sort.ToString();

            txtTitle.Text = lblTitle.Text = ut.Title;
            tsModule_Description_Disp.Text = tsModule_Description_Input.Text = ut.Description;
            tsModule_Comment_Disp.Text = tsModule_Comment_Input.Text = ut.Comment;
        }
      

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tsGame_IsOnline_Input.Visible = false;
            ddlSort.Visible = false;
            txtTitle.Visible = false;
            tsModule_Comment_Input.Visible = false;
            tsModule_Description_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tsGame_IsOnline_Disp.Visible = false;
            lblSort.Visible = false;
            lblTitle.Visible = false;
            tsModule_Description_Disp.Visible = false;
            tsModule_Comment_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string tsModule_Title_Value = (string)Common.sink(txtTitle.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string tsModule_Description_Value = (string)Common.sink(tsModule_Description_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string tsModule_Comment_Value = (string)Common.sink(tsModule_Comment_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);

            bool tsGame_IsOnline_Value = Convert.ToBoolean(Common.sink(tsGame_IsOnline_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));

            tsModuleEntity ut = BusinessFacadeDLT.tsModuleDisp(IDX);
            ut.ID = IDX;
            ut.Title = tsModule_Title_Value;
            ut.Description = tsModule_Description_Value;
            ut.Comment = tsModule_Comment_Value;
            ut.Sort = Convert.ToInt32(ddlSort.SelectedValue);
            ut.Enable = tsGame_IsOnline_Value;
           
            string filename = "";
            bool b = false;
       
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
            Int32 rInt = BusinessFacadeDLT.tsModuleInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加模式成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改模式成功!(ID:{0})", IDX);
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