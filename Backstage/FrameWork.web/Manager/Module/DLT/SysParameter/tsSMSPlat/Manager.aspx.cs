/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            短信平台管理
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

namespace DLT.Web.Module.DLT.tsSMSPlat
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
        public void BindSendTypeList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1004";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlSendType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            BindSendTypeList();
            tsSMSPlatEntity ut = BusinessFacadeDLT.tsSMSPlatDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加短信平台";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看短信平台";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改短信平台";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsSMSPlatInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "短信平台";
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
            bi.ButtonName = "短信平台";
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
        private void OnStartData(tsSMSPlatEntity ut)
        {
            tsSMSPlat_PlatName_Input.Text = tsSMSPlat_PlatName_Disp.Text = ut.PlatName.ToString();
            tsSMSPlat_PostUrl_Input.Text = tsSMSPlat_PostUrl_Disp.Text = ut.PostUrl.ToString();
            tsSMSPlat_UserName_Input.Text = tsSMSPlat_UserName_Disp.Text = ut.UserName.ToString();
            tsSMSPlat_Password_Input.Text = tsSMSPlat_Password_Disp.Text = ut.Password.ToString();
            tsSMSPlat_AppID_Input.Text = tsSMSPlat_AppID_Disp.Text = ut.AppID.ToString();
            tsSMSPlat_SuccessKey_Input.Text = tsSMSPlat_SuccessKey_Disp.Text = ut.SuccessKey.ToString();
            ddlSendType.SelectedValue = ut.SmsStyle.ToString();
            tsSMSPlat_SmsStyle_Disp.Text = ddlSendType.SelectedItem.Text;
            tsSMSPlat_IsEnable_Input.SelectedValue = Convert.ToInt32(ut.IsEnable).ToString();
            tsSMSPlat_IsEnable_Disp.Text = ut.IsEnable.ToString();

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tsSMSPlat_PlatName_Input.Visible = false;
            tsSMSPlat_PostUrl_Input.Visible = false;
            tsSMSPlat_UserName_Input.Visible = false;
            tsSMSPlat_Password_Input.Visible = false;
            tsSMSPlat_AppID_Input.Visible = false;
            tsSMSPlat_SuccessKey_Input.Visible = false;
            ddlSendType.Visible = false;
            tsSMSPlat_IsEnable_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tsSMSPlat_PlatName_Disp.Visible = false;
            tsSMSPlat_PostUrl_Disp.Visible = false;
            tsSMSPlat_UserName_Disp.Visible = false;
            tsSMSPlat_Password_Disp.Visible = false;
            tsSMSPlat_AppID_Disp.Visible = false;
            tsSMSPlat_SuccessKey_Disp.Visible = false;
            tsSMSPlat_SmsStyle_Disp.Visible = false;
            tsSMSPlat_IsEnable_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string tsSMSPlat_PlatName_Value = (string)Common.sink(tsSMSPlat_PlatName_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            string tsSMSPlat_PostUrl_Value = (string)Common.sink(tsSMSPlat_PostUrl_Input.UniqueID, MethodType.Post, 250, 1, DataType.Str);
            string tsSMSPlat_UserName_Value = (string)Common.sink(tsSMSPlat_UserName_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string tsSMSPlat_Password_Value = (string)Common.sink(tsSMSPlat_Password_Input.UniqueID, MethodType.Post, 150, 0, DataType.Str);
            string tsSMSPlat_AppID_Value = (string)Common.sink(tsSMSPlat_AppID_Input.UniqueID, MethodType.Post, 150, 0, DataType.Str);
            string tsSMSPlat_SuccessKey_Value = (string)Common.sink(tsSMSPlat_SuccessKey_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);

            Int16 tsSMSPlat_SmsStyle_Value = Convert.ToInt16(Common.sink(ddlSendType.UniqueID, MethodType.Post, 1, 1, DataType.Int));


            bool tsSMSPlat_IsEnable_Value = Convert.ToBoolean(Common.sink(tsSMSPlat_IsEnable_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));

            tsSMSPlatEntity ut = BusinessFacadeDLT.tsSMSPlatDisp(IDX);

            ut.PlatName = tsSMSPlat_PlatName_Value;
            ut.PostUrl = tsSMSPlat_PostUrl_Value;
            ut.UserName = tsSMSPlat_UserName_Value;
            ut.Password = tsSMSPlat_Password_Value;
            ut.AppID = tsSMSPlat_AppID_Value;
            ut.SuccessKey = tsSMSPlat_SuccessKey_Value;
            ut.SmsStyle = tsSMSPlat_SmsStyle_Value;
            ut.IsEnable = tsSMSPlat_IsEnable_Value;

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
            Int32 rInt = BusinessFacadeDLT.tsSMSPlatInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加短信平台成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改短信平台成功!(ID:{0})", IDX);
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
