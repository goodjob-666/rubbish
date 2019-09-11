/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            代练进度管理
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

namespace DLT.Web.Module.DLT.tbLevelOrderProgress
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
            tbLevelOrderProgressEntity ut = BusinessFacadeDLT.tbLevelOrderProgressDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加代练进度";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看代练进度";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改代练进度";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbLevelOrderProgressInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "代练进度";
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
            bi.ButtonName = "代练进度";
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
        private void OnStartData(tbLevelOrderProgressEntity ut)
        {
        tbLevelOrderProgress_UserID_Input.Text = tbLevelOrderProgress_UserID_Disp.Text = ut.UserID.ToString();
                tbLevelOrderProgress_ODSerialNo_Input.Text = tbLevelOrderProgress_ODSerialNo_Disp.Text = ut.ODSerialNo.ToString();
                tbLevelOrderProgress_CreateDate_Input.Text = tbLevelOrderProgress_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbLevelOrderProgress_Img_Input.Text = tbLevelOrderProgress_Img_Disp.Text = ut.Img.ToString();
                tbLevelOrderProgress_Comment_Input.Text = tbLevelOrderProgress_Comment_Disp.Text = ut.Comment.ToString();
                tbLevelOrderProgress_Source_Input.Text = tbLevelOrderProgress_Source_Disp.Text = ut.Source.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbLevelOrderProgress_UserID_Input.Visible = false;
        tbLevelOrderProgress_ODSerialNo_Input.Visible = false;
        tbLevelOrderProgress_CreateDate_Input.Visible = false;
        tbLevelOrderProgress_Img_Input.Visible = false;
        tbLevelOrderProgress_Comment_Input.Visible = false;
        tbLevelOrderProgress_Source_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbLevelOrderProgress_UserID_Disp.Visible = false;
        tbLevelOrderProgress_ODSerialNo_Disp.Visible = false;
        tbLevelOrderProgress_CreateDate_Disp.Visible = false;
        tbLevelOrderProgress_Img_Disp.Visible = false;
        tbLevelOrderProgress_Comment_Disp.Visible = false;
        tbLevelOrderProgress_Source_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tbLevelOrderProgress_UserID_Value = (int)Common.sink(tbLevelOrderProgress_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tbLevelOrderProgress_ODSerialNo_Value = (string)Common.sink(tbLevelOrderProgress_ODSerialNo_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            DateTime tbLevelOrderProgress_CreateDate_Value = (DateTime)Common.sink(tbLevelOrderProgress_CreateDate_Input.UniqueID, MethodType.Post, 20, 1, DataType.Dat);
            string tbLevelOrderProgress_Img_Value = (string)Common.sink(tbLevelOrderProgress_Img_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string tbLevelOrderProgress_Comment_Value = (string)Common.sink(tbLevelOrderProgress_Comment_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            
                    Int16 tbLevelOrderProgress_Source_Value = Convert.ToInt16(Common.sink(tbLevelOrderProgress_Source_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            tbLevelOrderProgressEntity ut = BusinessFacadeDLT.tbLevelOrderProgressDisp(IDX);
            
            ut.UserID = tbLevelOrderProgress_UserID_Value;
            ut.ODSerialNo = tbLevelOrderProgress_ODSerialNo_Value;
            ut.CreateDate = tbLevelOrderProgress_CreateDate_Value;
            ut.Img = tbLevelOrderProgress_Img_Value;
            ut.Comment = tbLevelOrderProgress_Comment_Value;
            ut.Source = tbLevelOrderProgress_Source_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tbLevelOrderProgressInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加代练进度成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改代练进度成功!(ID:{0})",IDX);
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
