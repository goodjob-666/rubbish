/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            财务每日数据管理
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

namespace DLT.Web.Module.DLT.tbFinancialDay
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
            tbFinancialDayEntity ut = BusinessFacadeDLT.tbFinancialDayDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加财务每日数据";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看财务每日数据";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改财务每日数据";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbFinancialDayInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "财务每日数据";
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
            bi.ButtonName = "财务每日数据";
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
        private void OnStartData(tbFinancialDayEntity ut)
        {
        tbFinancialDay_TotalBal_Input.Text = tbFinancialDay_TotalBal_Disp.Text = ut.TotalBal.ToString();
                tbFinancialDay_TotalFreeze_Input.Text = tbFinancialDay_TotalFreeze_Disp.Text = ut.TotalFreeze.ToString();
                tbFinancialDay_TotalWithDraw_Input.Text = tbFinancialDay_TotalWithDraw_Disp.Text = ut.TotalWithDraw.ToString();
                tbFinancialDay_TotalOperate_Input.Text = tbFinancialDay_TotalOperate_Disp.Text = ut.TotalOperate.ToString();
                tbFinancialDay_CreateDate_Input.Text = tbFinancialDay_CreateDate_Disp.Text = ut.CreateDate.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbFinancialDay_TotalBal_Input.Visible = false;
        tbFinancialDay_TotalFreeze_Input.Visible = false;
        tbFinancialDay_TotalWithDraw_Input.Visible = false;
        tbFinancialDay_TotalOperate_Input.Visible = false;
        tbFinancialDay_CreateDate_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbFinancialDay_TotalBal_Disp.Visible = false;
        tbFinancialDay_TotalFreeze_Disp.Visible = false;
        tbFinancialDay_TotalWithDraw_Disp.Visible = false;
        tbFinancialDay_TotalOperate_Disp.Visible = false;
        tbFinancialDay_CreateDate_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            double tbFinancialDay_TotalBal_Value = (double)Common.sink(tbFinancialDay_TotalBal_Input.UniqueID, MethodType.Post, 19, 1, DataType.Double);
            double tbFinancialDay_TotalFreeze_Value = (double)Common.sink(tbFinancialDay_TotalFreeze_Input.UniqueID, MethodType.Post, 19, 1, DataType.Double);
            double tbFinancialDay_TotalWithDraw_Value = (double)Common.sink(tbFinancialDay_TotalWithDraw_Input.UniqueID, MethodType.Post, 19, 1, DataType.Double);
            double tbFinancialDay_TotalOperate_Value = (double)Common.sink(tbFinancialDay_TotalOperate_Input.UniqueID, MethodType.Post, 19, 0, DataType.Double);
            
                    DateTime? tbFinancialDay_CreateDate_Value = (DateTime?)Common.sink(tbFinancialDay_CreateDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            tbFinancialDayEntity ut = BusinessFacadeDLT.tbFinancialDayDisp(IDX);
            
            ut.TotalBal = tbFinancialDay_TotalBal_Value;
            ut.TotalFreeze = tbFinancialDay_TotalFreeze_Value;
            ut.TotalWithDraw = tbFinancialDay_TotalWithDraw_Value;
            ut.TotalOperate = tbFinancialDay_TotalOperate_Value;
            ut.CreateDate = tbFinancialDay_CreateDate_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbFinancialDayInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加财务每日数据成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改财务每日数据成功!(ID:{0})",IDX);
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
