/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            用户管理
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

namespace DLT.Web.Module.DLT.tsUser
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
            BindLoginModel();
            BindIsOnline();
            BindStatus();
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加用户";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看用户";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改用户";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsUserInsertUpdateDelete(ut) > 0)
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
        /// 绑定登录模式
        /// </summary>
        private void BindLoginModel()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1000";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                ddlLoginModel.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        /// <summary>
        /// 绑定是否在线
        /// </summary>
        private void BindIsOnline()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1001";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                ddlIsOnline.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        /// <summary>
        /// 绑定用户状态
        /// </summary>
        private void BindStatus()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1002";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                ddlStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "用户";
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
            bi.ButtonName = "用户";
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
        private void OnStartData(tsUserEntity ut)
        {

            tsUser_ID_Input.Text = tsUser_ID_Disp.Text = ut.ID.ToString();
            tsUser_UID_Input.Text = tsUser_UID_Disp.Text = ut.UID.ToString();
            tsUser_Nickname_Input.Text = tsUser_Nickname_Disp.Text = ut.Nickname.ToString();
            tsUser_LoginID_Input.Text = tsUser_LoginID_Disp.Text = ut.LoginID.ToString();
            tsUser_Pass_Input.Text = tsUser_Pass_Disp.Text = ut.Pass.ToString();
            tsUser_Email_Input.Text = tsUser_Email_Disp.Text = ut.Email.ToString();
            tsUser_QQ_Input.Text = tsUser_QQ_Disp.Text = ut.QQ.ToString();
            tsUser_Mobile_Input.Text = tsUser_Mobile_Disp.Text = ut.Mobile.ToString();
            tsUser_Question_Input.Text = tsUser_Question_Disp.Text = ut.Question.ToString();
            tsUser_Answer_Input.Text = tsUser_Answer_Disp.Text = ut.Answer.ToString();
            tsUser_BindMobile_Input.Text = tsUser_BindMobile_Disp.Text = ut.BindMobile.ToString();

            tsUser_PayPass_Input.Text = tsUser_PayPass_Disp.Text = ut.PayPass.ToString();

            ddlLoginModel.SelectedValue = ut.LoginMode.ToString();
            tsUser_LoginMode_Disp.Text = ddlLoginModel.SelectedItem.Text;

            ddlIsOnline.SelectedValue = ut.IsOnline.ToString();
            tsUser_IsOnline_Disp.Text = ddlIsOnline.SelectedItem.Text;

            tsUser_HaveSubUser_Input.SelectedValue = Convert.ToInt32(ut.HaveSubUser).ToString();

            tsUser_HaveSubUser_Disp.Text = tsUser_HaveSubUser_Input.SelectedItem.Text;

            tsUser_IconIndex_Input.Text = tsUser_IconIndex_Disp.Text = ut.IconIndex.ToString();
            tsUser_CreateDate_Input.Text = tsUser_CreateDate_Disp.Text = ut.CreateDate.ToString();
            tsUser_LoginDate_Input.Text = tsUser_LoginDate_Disp.Text = ut.LoginDate.ToString();


            ddlStatus.SelectedValue = ut.Status.ToString();

            tsUser_Status_Disp.Text = ddlStatus.SelectedItem.Text;


            tsUser_Sign_Input.Text = tsUser_Sign_Disp.Text = ut.Sign.ToString();
            tsUser_Comment_Input.Text = tsUser_Comment_Disp.Text = ut.Comment.ToString();

        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tsUser_UID_Input.Visible = false;
            tsUser_ID_Input.Visible = false;
            tsUser_Nickname_Input.Visible = false;
            tsUser_LoginID_Input.Visible = false;
            tsUser_Pass_Input.Visible = false;
            tsUser_Email_Input.Visible = false;
            tsUser_QQ_Input.Visible = false;
            tsUser_Mobile_Input.Visible = false;
            tsUser_Question_Input.Visible = false;
            tsUser_Answer_Input.Visible = false;
            tsUser_BindMobile_Input.Visible = false;
            tsUser_PayPass_Input.Visible = false;
            ddlLoginModel.Visible = false;
            ddlIsOnline.Visible = false;
            tsUser_HaveSubUser_Input.Visible = false;
            tsUser_IconIndex_Input.Visible = false;
            tsUser_CreateDate_Input.Visible = false;
            tsUser_LoginDate_Input.Visible = false;
            ddlStatus.Visible = false;
            tsUser_Sign_Input.Visible = false;
            tsUser_Comment_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tsUser_UID_Disp.Visible = false;
            tsUser_ID_Disp.Visible = false;
            tsUser_Nickname_Disp.Visible = false;
            tsUser_LoginID_Disp.Visible = false;
            tsUser_Pass_Disp.Visible = false;
            tsUser_Email_Disp.Visible = false;
            tsUser_QQ_Disp.Visible = false;
            tsUser_Mobile_Disp.Visible = false;
            tsUser_Question_Disp.Visible = false;
            tsUser_Answer_Disp.Visible = false;
            tsUser_BindMobile_Disp.Visible = false;
            tsUser_PayPass_Disp.Visible = false;
            tsUser_LoginMode_Disp.Visible = false;
            tsUser_IsOnline_Disp.Visible = false;
            tsUser_HaveSubUser_Disp.Visible = false;
            tsUser_IconIndex_Disp.Visible = false;
            tsUser_CreateDate_Disp.Visible = false;
            tsUser_LoginDate_Disp.Visible = false;
            tsUser_Status_Disp.Visible = false;
            tsUser_Sign_Disp.Visible = false;
            tsUser_Comment_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string tsUser_UID_Value = (string)Common.sink(tsUser_UID_Input.UniqueID, MethodType.Post, 24, 1, DataType.Str);
            string tsUser_Nickname_Value = (string)Common.sink(tsUser_Nickname_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string tsUser_LoginID_Value = (string)Common.sink(tsUser_LoginID_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Pass_Value = (string)Common.sink(tsUser_Pass_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Email_Value = (string)Common.sink(tsUser_Email_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_QQ_Value = (string)Common.sink(tsUser_QQ_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Mobile_Value = (string)Common.sink(tsUser_Mobile_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Question_Value = (string)Common.sink(tsUser_Question_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_Answer_Value = (string)Common.sink(tsUser_Answer_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);
            string tsUser_BindMobile_Value = (string)Common.sink(tsUser_BindMobile_Input.UniqueID, MethodType.Post, 128, 0, DataType.Str);
            string tsUser_PayPass_Value = (string)Common.sink(tsUser_PayPass_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);

            Int16 tsUser_LoginMode_Value = Convert.ToInt16(Common.sink(ddlLoginModel.UniqueID, MethodType.Post, 1, 1, DataType.Int));


            Int16 tsUser_IsOnline_Value = Convert.ToInt16(Common.sink(ddlIsOnline.UniqueID, MethodType.Post, 1, 1, DataType.Int));


            bool tsUser_HaveSubUser_Value = Convert.ToBoolean(Common.sink(tsUser_HaveSubUser_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));

            int tsUser_IconIndex_Value = (int)Common.sink(tsUser_IconIndex_Input.UniqueID, MethodType.Post, 10, 1, DataType.Int);
            DateTime tsUser_CreateDate_Value = (DateTime)Common.sink(tsUser_CreateDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);

            DateTime? tsUser_LoginDate_Value = (DateTime?)Common.sink(tsUser_LoginDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            Int16 tsUser_Status_Value = Convert.ToInt16(Common.sink(ddlStatus.UniqueID, MethodType.Post, 1, 1, DataType.Int));

            string tsUser_Sign_Value = (string)Common.sink(tsUser_Sign_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            string tsUser_Comment_Value = (string)Common.sink(tsUser_Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            tsUserEntity ut = BusinessFacadeDLT.tsUserDisp(IDX);

            ut.UID = tsUser_UID_Value;
            ut.Nickname = tsUser_Nickname_Value;
            ut.LoginID = tsUser_LoginID_Value;
            ut.Pass = tsUser_Pass_Value;
            ut.Email = tsUser_Email_Value;
            ut.QQ = tsUser_QQ_Value;
            ut.Mobile = tsUser_Mobile_Value;
            ut.Question = tsUser_Question_Value;
            ut.Answer = tsUser_Answer_Value;
            ut.BindMobile = tsUser_BindMobile_Value;
            ut.PayPass = tsUser_PayPass_Value;
            ut.LoginMode = tsUser_LoginMode_Value;
            ut.IsOnline = tsUser_IsOnline_Value;
            ut.HaveSubUser = tsUser_HaveSubUser_Value;
            ut.IconIndex = tsUser_IconIndex_Value;
            ut.CreateDate = tsUser_CreateDate_Value;
            ut.LoginDate = tsUser_LoginDate_Value;
            ut.Status = tsUser_Status_Value;
            ut.Sign = tsUser_Sign_Value;
            ut.Comment = tsUser_Comment_Value;

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
            Int32 rInt = BusinessFacadeDLT.tsUserInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加用户成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改用户成功!(ID:{0})", IDX);
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
