/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            题库管理
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
using System.Collections.Generic;

namespace DLT.Web.Module.DLT.Activity.Questions
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
                BindDifficultyList();
                BindSubjectList();
                OnStart();
            }
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            tbQuestionsEntity ut = BusinessFacadeDLT.tbQuestionsDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加题库";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看题库";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改题库";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbQuestionsInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else
                    {
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
            bi.ButtonName = "题库";
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
            bi.ButtonName = "题库";
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
        private void OnStartData(tbQuestionsEntity ut)
        {
            txtTitle_Input.Text = lblTitle_Disp.Text = ut.Title;
            txtA_Input.Text = lblA_Disp.Text = ut.A;
            txtB_Input.Text = lblB_Disp.Text = ut.B;
            txtC_Input.Text = lblC_Disp.Text = ut.C;
            txtD_Input.Text = lblD_Disp.Text = ut.D;
           
            ddlAnswer.SelectedValue = lblAnswer_Disp.Text = ut.Answer;
            lblDifficulty_Disp.Text = DifficultyList(ut.Difficulty);
            lblSubject_Disp.Text = SubjectList(ut.SubjectType);

            ddlDifficulty.SelectedValue = ut.Difficulty.ToString();
            ddlSubject.SelectedValue = ut.SubjectType.ToString();
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            txtTitle_Input.Visible = false;
            txtA_Input.Visible = false;
            txtB_Input.Visible = false;
            txtC_Input.Visible = false;
            txtD_Input.Visible = false;
            ddlDifficulty.Visible = false;
            txtTitle_Input.Visible = false;
            ddlSubject.Visible = false;
            ddlAnswer.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            lblTitle_Disp.Visible = false;
            lblA_Disp.Visible = false;
            lblB_Disp.Visible = false;
            lblC_Disp.Visible = false;
            lblD_Disp.Visible = false;
            lblAnswer_Disp.Visible = false;
            lblSubject_Disp.Visible = false;
            lblDifficulty_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string Title_Value = (string)Common.sink(txtTitle_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string a = (string)Common.sink(txtA_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string b = (string)Common.sink(txtB_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string c = (string)Common.sink(txtC_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string d = (string)Common.sink(txtD_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);

            string Difficulty_Value = (string)Common.sink(ddlDifficulty.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Subject_Value = (string)Common.sink(ddlSubject.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            string Answer_Value = (string)Common.sink(ddlAnswer.UniqueID, MethodType.Post, 5, 0, DataType.Str);
            tbQuestionsEntity ut = BusinessFacadeDLT.tbQuestionsDisp(IDX);

            ut.ID = IDX;
            ut.Title = Title_Value;
            ut.A = a;
            ut.B = b;
            ut.C = c;
            ut.D = d;
            ut.Answer = ddlAnswer.SelectedValue;
            ut.Difficulty = Convert.ToInt32(ddlDifficulty.SelectedValue);
            ut.SubjectType = Convert.ToInt32(ddlSubject.SelectedValue);

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
            Int32 rInt = BusinessFacadeDLT.tbQuestionsInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加题库成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改题库成功!(ID:{0})", IDX);
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

        private string DifficultyList(int id)
        {
            string str = "";
            List<tbDifficultyEntity> lst;
            if (ViewState["DifficultyList"] != null)
            {
                lst = ViewState["DifficultyList"] as List<tbDifficultyEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 100;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbDifficultyList(qp, out RecordCount, null);
                ViewState["DifficultyList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbDifficultyEntity item in lst)
                {
                    if (item.ID == id)
                    {
                        str = item.DifficultyName;
                        break;
                    }
                }
            }
            return str;
        }


        private string SubjectList(int id)
        {
            string str = "";
            List<tbSubjectEntity> lst;
            if (ViewState["SubjectList"] != null)
            {
                lst = ViewState["SubjectList"] as List<tbSubjectEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbSubjectList(qp, out RecordCount, null);
                ViewState["SubjectList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbSubjectEntity item in lst)
                {
                    if (item.ID == id)
                    {
                        str = item.Name;
                        break;
                    }
                }
            }
            return str;
        }


        private void BindDifficultyList()
        {
            List<tbDifficultyEntity> lst;
            if (ViewState["DifficultyList"] != null)
            {
                lst = ViewState["DifficultyList"] as List<tbDifficultyEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 100;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbDifficultyList(qp, out RecordCount, null);
                ViewState["DifficultyList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbDifficultyEntity var in lst)
                {
                    ddlDifficulty.Items.Add(new ListItem(var.DifficultyName, var.ID.ToString()));
                }
            }
        }


        private void BindSubjectList()
        {
            List<tbSubjectEntity> lst;
            if (ViewState["SubjectList"] != null)
            {
                lst = ViewState["SubjectList"] as List<tbSubjectEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbSubjectList(qp, out RecordCount, null);
                ViewState["SubjectList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbSubjectEntity var in lst)
                {
                    ddlSubject.Items.Add(new ListItem(var.Name, var.ID.ToString()));
                }
            }
        }
    }
}
