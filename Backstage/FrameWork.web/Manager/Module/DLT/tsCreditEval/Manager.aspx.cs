/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            信用评价管理
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

namespace DLT.Web.Module.DLT.tsCreditEval
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
            tsCreditEvalEntity ut = BusinessFacadeDLT.tsCreditEvalDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加信用评价";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看信用评价";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改信用评价";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsCreditEvalInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "信用评价";
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
            bi.ButtonName = "信用评价";
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
        private void OnStartData(tsCreditEvalEntity ut)
        {
        tsCreditEval_UserID_Input.Text = tsCreditEval_UserID_Disp.Text = ut.UserID.ToString();
                tsCreditEval_EvalDirect_Input.Text = tsCreditEval_EvalDirect_Disp.Text = ut.EvalDirect.ToString();
                tsCreditEval_Beautifully_Input.Text = tsCreditEval_Beautifully_Disp.Text = ut.Beautifully.ToString();
                tsCreditEval_Good_Input.Text = tsCreditEval_Good_Disp.Text = ut.Good.ToString();
                tsCreditEval_Normal_Input.Text = tsCreditEval_Normal_Disp.Text = ut.Normal.ToString();
                tsCreditEval_Poor_Input.Text = tsCreditEval_Poor_Disp.Text = ut.Poor.ToString();
                tsCreditEval_Score_Input.Text = tsCreditEval_Score_Disp.Text = ut.Score.ToString();
                tsCreditEval_Level_Input.Text = tsCreditEval_Level_Disp.Text = ut.Level.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tsCreditEval_UserID_Input.Visible = false;
        tsCreditEval_EvalDirect_Input.Visible = false;
        tsCreditEval_Beautifully_Input.Visible = false;
        tsCreditEval_Good_Input.Visible = false;
        tsCreditEval_Normal_Input.Visible = false;
        tsCreditEval_Poor_Input.Visible = false;
        tsCreditEval_Score_Input.Visible = false;
        tsCreditEval_Level_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tsCreditEval_UserID_Disp.Visible = false;
        tsCreditEval_EvalDirect_Disp.Visible = false;
        tsCreditEval_Beautifully_Disp.Visible = false;
        tsCreditEval_Good_Disp.Visible = false;
        tsCreditEval_Normal_Disp.Visible = false;
        tsCreditEval_Poor_Disp.Visible = false;
        tsCreditEval_Score_Disp.Visible = false;
        tsCreditEval_Level_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tsCreditEval_UserID_Value = (int)Common.sink(tsCreditEval_UserID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            
                    Int16 tsCreditEval_EvalDirect_Value = Convert.ToInt16(Common.sink(tsCreditEval_EvalDirect_Input.UniqueID, MethodType.Post, 1, 1, DataType.Int));
                
            int tsCreditEval_Beautifully_Value = (int)Common.sink(tsCreditEval_Beautifully_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tsCreditEval_Good_Value = (int)Common.sink(tsCreditEval_Good_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tsCreditEval_Normal_Value = (int)Common.sink(tsCreditEval_Normal_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            int tsCreditEval_Poor_Value = (int)Common.sink(tsCreditEval_Poor_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            Int64 tsCreditEval_Score_Value = (Int64)Common.sink(tsCreditEval_Score_Input.UniqueID, MethodType.Post, 19, 0, DataType.Long);
            int tsCreditEval_Level_Value = (int)Common.sink(tsCreditEval_Level_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            tsCreditEvalEntity ut = BusinessFacadeDLT.tsCreditEvalDisp(IDX);
            
            ut.UserID = tsCreditEval_UserID_Value;
            ut.EvalDirect = tsCreditEval_EvalDirect_Value;
            ut.Beautifully = tsCreditEval_Beautifully_Value;
            ut.Good = tsCreditEval_Good_Value;
            ut.Normal = tsCreditEval_Normal_Value;
            ut.Poor = tsCreditEval_Poor_Value;
            ut.Score = tsCreditEval_Score_Value;
            ut.Level = tsCreditEval_Level_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tsCreditEvalInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加信用评价成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改信用评价成功!(ID:{0})",IDX);
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
