/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            sys_News管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2015/1/17 星期六 17:32:45
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

namespace DLT.Web.Module.DLT.sys_News
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
                BindNewsType();
                OnStart();
                
            }
        }

        public void BindNewsType()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1021";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlNewsType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

        public string GetNewsType(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1021 and Kind=" + type;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            sys_NewsEntity ut = BusinessFacadeDLT.sys_NewsDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加新闻公告";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看新闻公告";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改新闻公告";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.sys_NewsInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "sys_News";
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
            bi.ButtonName = "sys_News";
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
        private void OnStartData(sys_NewsEntity ut)
        {
                ddlNewsType.SelectedValue = ut.N_TypeID.ToString();
                if (ut.N_TypeID.ToString() != "0")
                {
                    sys_News_N_TypeID_Disp.Text = GetNewsType(ut.N_TypeID.ToString());
                }
                else
                {
                    sys_News_N_TypeID_Disp.Text = "";
                }
                sys_News_N_Title_Input.Text = sys_News_N_Title_Disp.Text = ut.N_Title.ToString();
                sys_News_N_Author_Input.Text = sys_News_N_Author_Disp.Text = ut.N_Author.ToString();
                sys_News_N_CreateDate_Input.Text = sys_News_N_CreateDate_Disp.Text = ut.N_CreateDate.ToString();
                sys_News_N_Click_Input.Text = sys_News_N_Click_Disp.Text = ut.N_Click.ToString();
                sys_News_N_Content_Input.Text = sys_News_N_Content_Disp.Text = ut.N_Content.ToString();
                sys_News_N_Remarks_Input.Text = sys_News_N_Remarks_Disp.Text = ut.N_Remarks.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ddlNewsType.Visible = false;
        sys_News_N_Title_Input.Visible = false;
        sys_News_N_Author_Input.Visible = false;
        sys_News_N_CreateDate_Input.Visible = false;
        sys_News_N_Click_Input.Visible = false;
        sys_News_N_Content_Input.Visible = false;
        sys_News_N_Remarks_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        sys_News_N_TypeID_Disp.Visible = false;
        sys_News_N_Title_Disp.Visible = false;
        sys_News_N_Author_Disp.Visible = false;
        sys_News_N_CreateDate_Disp.Visible = false;
        sys_News_N_Click_Disp.Visible = false;
        sys_News_N_Content_Disp.Visible = false;
        sys_News_N_Remarks_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            int sys_News_N_TypeID_Value = (int)Common.sink(ddlNewsType.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string sys_News_N_Title_Value = (string)Common.sink(sys_News_N_Title_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string sys_News_N_Author_Value = (string)Common.sink(sys_News_N_Author_Input.UniqueID, MethodType.Post, 30, 0, DataType.Str);

            DateTime? sys_News_N_CreateDate_Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                
            int sys_News_N_Click_Value = (int)Common.sink(sys_News_N_Click_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string sys_News_N_Content_Value = (string)Common.sink(sys_News_N_Content_Input.UniqueID, MethodType.Post, 2147483647, 0, DataType.Str);
            string sys_News_N_Remarks_Value = (string)Common.sink(sys_News_N_Remarks_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str);
            sys_NewsEntity ut = BusinessFacadeDLT.sys_NewsDisp(IDX);
            
            ut.N_TypeID = sys_News_N_TypeID_Value;
            ut.N_Title = sys_News_N_Title_Value;
            ut.N_Author = sys_News_N_Author_Value;
            ut.N_CreateDate = sys_News_N_CreateDate_Value;
            ut.N_Click = sys_News_N_Click_Value;
            ut.N_Content = sys_News_N_Content_Value;
            ut.N_Remarks = sys_News_N_Remarks_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.sys_NewsInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加sys_News成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改sys_News成功!(ID:{0})",IDX);
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
