/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            tbPostReport管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/12/23 15:35:26
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

namespace DLT.Web.Module.DLT.tbPostReport
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
            tbPostReportEntity ut = BusinessFacadeDLT.tbPostReportDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加tbPostReport";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看tbPostReport";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改tbPostReport";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbPostReportInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "tbPostReport";
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
            bi.ButtonName = "tbPostReport";
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
        private void OnStartData(tbPostReportEntity ut)
        {
        tbPostReport_SerialNo_Input.Text = tbPostReport_SerialNo_Disp.Text = ut.SerialNo.ToString();
                tbPostReport_UserID_Input.Text = tbPostReport_UserID_Disp.Text = ut.UserID.ToString();
                tbPostReport_ReportCustomerID_Input.Text = tbPostReport_ReportCustomerID_Disp.Text = ut.ReportCustomerID.ToString();
                tbPostReport_CreateDate_Input.Text = tbPostReport_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbPostReport_DealCustomerID_Input.Text = tbPostReport_DealCustomerID_Disp.Text = ut.DealCustomerID.ToString();
                tbPostReport_DealDate_Input.Text = tbPostReport_DealDate_Disp.Text = ut.DealDate.ToString();
                tbPostReport_Status_Input.Text = tbPostReport_Status_Disp.Text = ut.Status.ToString();
                tbPostReport_Remark_Input.Text = tbPostReport_Remark_Disp.Text = ut.Remark.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbPostReport_SerialNo_Input.Visible = false;
        tbPostReport_UserID_Input.Visible = false;
        tbPostReport_ReportCustomerID_Input.Visible = false;
        tbPostReport_CreateDate_Input.Visible = false;
        tbPostReport_DealCustomerID_Input.Visible = false;
        tbPostReport_DealDate_Input.Visible = false;
        tbPostReport_Status_Input.Visible = false;
        tbPostReport_Remark_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbPostReport_SerialNo_Disp.Visible = false;
        tbPostReport_UserID_Disp.Visible = false;
        tbPostReport_ReportCustomerID_Disp.Visible = false;
        tbPostReport_CreateDate_Disp.Visible = false;
        tbPostReport_DealCustomerID_Disp.Visible = false;
        tbPostReport_DealDate_Disp.Visible = false;
        tbPostReport_Status_Disp.Visible = false;
        tbPostReport_Remark_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tbPostReport_SerialNo_Value = (string)Common.sink(tbPostReport_SerialNo_Input.UniqueID, MethodType.Post, 20, 1, DataType.Str);
            int tbPostReport_UserID_Value = (int)Common.sink(tbPostReport_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tbPostReport_ReportCustomerID_Value = (int)Common.sink(tbPostReport_ReportCustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    DateTime? tbPostReport_CreateDate_Value = (DateTime?)Common.sink(tbPostReport_CreateDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int tbPostReport_DealCustomerID_Value = (int)Common.sink(tbPostReport_DealCustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    DateTime? tbPostReport_DealDate_Value = (DateTime?)Common.sink(tbPostReport_DealDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            int tbPostReport_Status_Value = (int)Common.sink(tbPostReport_Status_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tbPostReport_Remark_Value = (string)Common.sink(tbPostReport_Remark_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            tbPostReportEntity ut = BusinessFacadeDLT.tbPostReportDisp(IDX);
            
            ut.SerialNo = tbPostReport_SerialNo_Value;
            ut.UserID = tbPostReport_UserID_Value;
            ut.ReportCustomerID = tbPostReport_ReportCustomerID_Value;
            ut.CreateDate = tbPostReport_CreateDate_Value;
            ut.DealCustomerID = tbPostReport_DealCustomerID_Value;
            ut.DealDate = tbPostReport_DealDate_Value;
            ut.Status = tbPostReport_Status_Value;
            ut.Remark = tbPostReport_Remark_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbPostReportInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加tbPostReport成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改tbPostReport成功!(ID:{0})",IDX);
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
