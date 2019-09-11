/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            系统公告管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2016/8/22 14:33:20
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

namespace DLT.Web.Module.DLT.tsNotice
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
            tsNoticeEntity ut = BusinessFacadeDLT.tsNoticeDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加系统公告";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看系统公告";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改系统公告";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsNoticeInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "系统公告";
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
            bi.ButtonName = "系统公告";
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
        private void OnStartData(tsNoticeEntity ut)
        {
            tsNotice_Title_Input.Text = tsNotice_Title_Disp.Text = ut.Title.ToString();
            tsNotice_Body_Input.Text = tsNotice_Body_Disp.Text = ut.Body.ToString();
            tsNotice_Url_Input.Text = tsNotice_Url_Disp.Text = ut.Url.ToString();

            tsNotice_PubDate_Input.Text = tsNotice_PubDate_Disp.Text = ut.PubDate.ToString();
            tsNotice_StartDate_Input.Text = tsNotice_StartDate_Disp.Text = ut.StartDate.ToString();
            tsNotice_EndDate_Input.Text = tsNotice_EndDate_Disp.Text = ut.EndDate.ToString();





            tsNotice_Enable_Input.SelectedValue = Convert.ToInt32(ut.Enable).ToString();
            tsNotice_Enable_Disp.Text = ut.Enable.ToString();

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tsNotice_Title_Input.Visible = false;
            tsNotice_Body_Input.Visible = false;
            tsNotice_Url_Input.Visible = false;
            tsNotice_PubDate_Input.Visible = false;
            tsNotice_StartDate_Input.Visible = false;
            tsNotice_EndDate_Input.Visible = false;
            tsNotice_Enable_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tsNotice_Title_Disp.Visible = false;
            tsNotice_Body_Disp.Visible = false;
            tsNotice_Url_Disp.Visible = false;
            tsNotice_PubDate_Disp.Visible = false;
            tsNotice_StartDate_Disp.Visible = false;
            tsNotice_EndDate_Disp.Visible = false;
            tsNotice_Enable_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string tsNotice_Title_Value = (string)Common.sink(tsNotice_Title_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            string tsNotice_Body_Value = (string)Common.sink(tsNotice_Body_Input.UniqueID, MethodType.Post, 4000, 1, DataType.Str);
            string tsNotice_Url_Value = (string)Common.sink(tsNotice_Url_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            DateTime tsNotice_PubDate_Value = (DateTime)Common.sink(tsNotice_PubDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);

            DateTime? tsNotice_StartDate_Value = (DateTime?)Common.sink(tsNotice_StartDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            DateTime? tsNotice_EndDate_Value = (DateTime?)Common.sink(tsNotice_EndDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            bool tsNotice_Enable_Value = Convert.ToBoolean(Common.sink(tsNotice_Enable_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));

            tsNoticeEntity ut = BusinessFacadeDLT.tsNoticeDisp(IDX);

            ut.Title = tsNotice_Title_Value;
            ut.Body = tsNotice_Body_Value;
            ut.Url = tsNotice_Url_Value;
            ut.PubDate = tsNotice_PubDate_Value;
            ut.StartDate = tsNotice_StartDate_Value;
            ut.EndDate = tsNotice_EndDate_Value;
            ut.Enable = tsNotice_Enable_Value;

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
            Int32 rInt = BusinessFacadeDLT.tsNoticeInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加系统公告成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改系统公告成功!(ID:{0})", IDX);
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
