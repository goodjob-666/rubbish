/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            sys_LoginAuthorize管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/6/30 23:12:10
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
using System.Collections.Generic;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;

namespace DLT.Web.Module.DLT.sys_LoginAuthorize
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
                //if (CMD == "Edit")
                //{
                //    sys_LoginAuthorize_L_MAC_Input.Attributes.Add("ReadOnly", "ReadOnly");
                //}
            }
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            sys_LoginAuthorizeEntity ut = BusinessFacadeDLT.sys_LoginAuthorizeDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加登录授权";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看登录授权";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改登录授权";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.sys_LoginAuthorizeInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("[" + UserData.GetUserDate.U_LoginName + "]删除IP【" + sys_LoginAuthorize_L_MAC_Input.Text.Trim() + "】,状态：" + LoinAuthorizeType(sys_LoginAuthorize_L_Status_Input.Text.ToString()) + ",时间范围：(" + sys_LoginAuthorize_L_StartDate_Input.Text + ")至(" + sys_LoginAuthorize_L_EndDate_Input.Text + "),备注：" + sys_LoginAuthorize_L_Remark_Input.Text + ",删除登录授权成功!(ID:{0})", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
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
            bi.ButtonName = "登录授权";
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
            bi.ButtonName = "登录授权";
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
        private void OnStartData(sys_LoginAuthorizeEntity ut)
        {
            sys_LoginAuthorize_L_Status_Input.SelectedValue = LoinAuthorizeType(ut.L_Status.ToString());
            sys_LoginAuthorize_L_CreateDate_Input.Text = sys_LoginAuthorize_L_CreateDate_Disp.Text = ut.L_CreateDate.ToString();
            sys_LoginAuthorize_L_StartDate_Input.Text = ut.L_StartDate.ToString();
            sys_LoginAuthorize_L_EndDate_Input.Text = ut.L_EndDate.ToString();
            sys_LoginAuthorize_L_Remark_Input.Text = sys_LoginAuthorize_L_Remark_Disp.Text = ut.L_Remark.ToString();
            sys_LoginAuthorize_L_IP_Input.Text = sys_LoginAuthorize_L_IP_Disp.Text = ut.L_IP.ToString();
            sys_LoginAuthorize_L_MAC_Input.Text = sys_LoginAuthorize_L_MAC_Disp.Text = ut.L_MAC.ToString();
            sys_LoginAuthorize_L_BC1_Input.Text = sys_LoginAuthorize_L_BC1_Disp.Text = ut.L_BC1.ToString();
            sys_LoginAuthorize_L_BC2_Input.Text = sys_LoginAuthorize_L_BC2_Disp.Text = ut.L_BC2.ToString();
            sys_LoginAuthorize_L_BC3_Input.Text = sys_LoginAuthorize_L_BC3_Disp.Text = ut.L_BC3.ToString();

        }

        public string LoinAuthorizeType(string typeid)
        {
            string typeName = "";
            switch (typeid)
            {
                case "0":
                    typeName = "禁用";
                    break;
                case "1":
                    typeName = "启用";
                    break;
            }
            return typeName;
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            sys_LoginAuthorize_L_Status_Input.Visible = false;
            sys_LoginAuthorize_L_CreateDate_Input.Visible = false;
            sys_LoginAuthorize_L_StartDate_Input.Visible = false;
            sys_LoginAuthorize_L_EndDate_Input.Visible = false;
            sys_LoginAuthorize_L_Remark_Input.Visible = false;
            sys_LoginAuthorize_L_IP_Input.Visible = false;
            sys_LoginAuthorize_L_MAC_Input.Visible = false;
            sys_LoginAuthorize_L_BC1_Input.Visible = false;
            sys_LoginAuthorize_L_BC2_Input.Visible = false;
            sys_LoginAuthorize_L_BC3_Input.Visible = false;

        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            sys_LoginAuthorize_L_Status_Disp.Visible = false;
            sys_LoginAuthorize_L_CreateDate_Disp.Visible = false;
            sys_LoginAuthorize_L_Remark_Disp.Visible = false;
            sys_LoginAuthorize_L_IP_Disp.Visible = false;
            sys_LoginAuthorize_L_MAC_Disp.Visible = false;
            sys_LoginAuthorize_L_BC1_Disp.Visible = false;
            sys_LoginAuthorize_L_BC2_Disp.Visible = false;
            sys_LoginAuthorize_L_BC3_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            int sys_LoginAuthorize_L_Status_Value = (int)Common.sink(sys_LoginAuthorize_L_Status_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            DateTime? sys_LoginAuthorize_L_CreateDate_Value = (DateTime?)Common.sink(sys_LoginAuthorize_L_CreateDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            DateTime? sys_LoginAuthorize_L_StartDate_Value = (DateTime?)Common.sink(sys_LoginAuthorize_L_StartDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            DateTime? sys_LoginAuthorize_L_EndDate_Value = (DateTime?)Common.sink(sys_LoginAuthorize_L_EndDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string sys_LoginAuthorize_L_Remark_Value = (string)Common.sink(sys_LoginAuthorize_L_Remark_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            string sys_LoginAuthorize_L_IP_Value = (string)Common.sink(sys_LoginAuthorize_L_IP_Input.UniqueID, MethodType.Post, 40, 0, DataType.Str);
            string sys_LoginAuthorize_L_MAC_Value = (string)Common.sink(sys_LoginAuthorize_L_MAC_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            int sys_LoginAuthorize_L_BC1_Value = (int)Common.sink(sys_LoginAuthorize_L_BC1_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);

            DateTime? sys_LoginAuthorize_L_BC2_Value = (DateTime?)Common.sink(sys_LoginAuthorize_L_BC2_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            string sys_LoginAuthorize_L_BC3_Value = (string)Common.sink(sys_LoginAuthorize_L_BC3_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            sys_LoginAuthorizeEntity ut = BusinessFacadeDLT.sys_LoginAuthorizeDisp(IDX);

            ut.L_Status = sys_LoginAuthorize_L_Status_Value;
            ut.L_CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ut.L_StartDate = sys_LoginAuthorize_L_StartDate_Value;
            ut.L_EndDate = sys_LoginAuthorize_L_EndDate_Value;
            ut.L_Remark = sys_LoginAuthorize_L_Remark_Value;
            ut.L_IP = sys_LoginAuthorize_L_IP_Value;
            ut.L_MAC = sys_LoginAuthorize_L_MAC_Value.Trim();
            ut.L_BC1 = sys_LoginAuthorize_L_BC1_Value;
            ut.L_BC2 = sys_LoginAuthorize_L_BC2_Value;
            ut.L_BC3 = UserData.GetUserDate.U_LoginName;

            if (sys_LoginAuthorize_L_StartDate_Value.ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('开始时间不能为空');</script>");
                return;
            }

            if (sys_LoginAuthorize_L_EndDate_Value.ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('结束时间不能为空');</script>");
                return;
            }

            if (sys_LoginAuthorize_L_MAC_Value.Trim() == "")
            {
                Response.Write("<script language='javascript'>alert('IP地址不能为空');</script>");
                return;
            }
            else
            {
                if (CMD == "New")
                {
                    QueryParam qp = new QueryParam();
                    qp.Where = " where 1=1 and L_MAC='" + sys_LoginAuthorize_L_MAC_Value.Trim() + "'";
                    qp.PageIndex = 1;
                    qp.PageSize = 1;
                    int RecordCount = 0;
                    List<sys_LoginAuthorizeEntity> lst = BusinessFacadeDLT.sys_LoginAuthorizeList(qp, out RecordCount);
                    if (RecordCount > 0)
                    {
                        Response.Write("<script language='javascript'>alert('IP地址已存在，请在列表页面搜索此IP地址后更改！');</script>");
                        return;
                    }
                    else
                    {
                        ut.DataTable_Action_ = DataTable_Action.Insert;
                    }
                }
                else if (CMD == "Edit")
                {
                    DataSet dsIP = BusinessFacadeDLT.UpdateIP(sys_LoginAuthorize_L_MAC_Value.Trim());
                    ut.DataTable_Action_ = DataTable_Action.Update;
                }
                
                else
                {
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                }
                Int32 rInt = BusinessFacadeDLT.sys_LoginAuthorizeInsertUpdateDelete(ut);
                if (rInt > 0)
                {
                    string OpTxt = string.Format("[" + UserData.GetUserDate.U_LoginName + "]增加IP【" + sys_LoginAuthorize_L_MAC_Value.Trim() + "】,状态：" + LoinAuthorizeType(sys_LoginAuthorize_L_Status_Value.ToString()) + ",时间范围：(" + sys_LoginAuthorize_L_StartDate_Value + ")至(" + sys_LoginAuthorize_L_EndDate_Value + "),备注：" + sys_LoginAuthorize_L_Remark_Value + ",新增登录授权成功!(ID:{0})", rInt);
                    if (ut.DataTable_Action_ == DataTable_Action.Update)
                        OpTxt = string.Format("[" + UserData.GetUserDate.U_LoginName + "]修改IP【" + sys_LoginAuthorize_L_MAC_Value.Trim() + "】,状态：" + LoinAuthorizeType(sys_LoginAuthorize_L_Status_Value.ToString()) + ",时间范围：(" + sys_LoginAuthorize_L_StartDate_Value + ")至(" + sys_LoginAuthorize_L_EndDate_Value + "),备注：" + sys_LoginAuthorize_L_Remark_Value + ",修改登录授权成功!(ID:{0})", IDX);
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
}
