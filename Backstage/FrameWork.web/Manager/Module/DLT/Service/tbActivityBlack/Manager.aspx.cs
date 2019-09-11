/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            tbActivityBlack管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2016/8/30 14:54:12
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

namespace DLT.Web.Module.DLT.tbActivityBlack
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
            tbActivityBlackEntity ut = BusinessFacadeDLT.tbActivityBlackDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加平台活动黑名单";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看平台活动黑名单";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改平台活动黑名单";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbActivityBlackInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "tbActivityBlack";
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
            bi.ButtonName = "tbActivityBlack";
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
        private void OnStartData(tbActivityBlackEntity ut)
        {
                tbActivityBlack_UserID_Input.Text = tbActivityBlack_UserID_Disp.Text = ut.UserID.ToString();
                if (tbActivityBlack_UserID_Input.Text == "0")
                {
                    tbActivityBlack_UserID_Input.Text = "";
                }
                tbActivityBlack_CreateDate_Input.Text = tbActivityBlack_CreateDate_Disp.Text = ut.CreateDate.ToString();
                tbActivityBlack_Comment_Input.Text = tbActivityBlack_Comment_Disp.Text = ut.Comment.ToString();
                tbActivityBlack_CustomerID_Input.Text = tbActivityBlack_CustomerID_Disp.Text = ut.CustomerID.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tbActivityBlack_UserID_Input.Visible = false;
        tbActivityBlack_CreateDate_Input.Visible = false;
        tbActivityBlack_Comment_Input.Visible = false;
        tbActivityBlack_CustomerID_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tbActivityBlack_UserID_Disp.Visible = false;
        tbActivityBlack_CreateDate_Disp.Visible = false;
        tbActivityBlack_Comment_Disp.Visible = false;
        tbActivityBlack_CustomerID_Disp.Visible = false;
        
        }

        public string GetID(string UID)
        {
            if (UID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [UID]='" + UID + "'";
                List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
                if (lst.Count > 0)
                {
                    return lst[0].ID.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public string IsInBlack(string UserID)
        {
            if (UserID != "0")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where UserID=" + UserID;
                List<tbActivityBlackEntity> lst = BusinessFacadeDLT.tbActivityBlackList(qp, out RecordCount);
                if (lst.Count > 0)
                {
                    return "-1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "-1";
            }
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string tbActivityBlack_UserID_Value = (string)Common.sink(tbActivityBlack_UserID_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);
            
            DateTime? tbActivityBlack_CreateDate_Value = (DateTime?)Common.sink(tbActivityBlack_CreateDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);
                
            string tbActivityBlack_Comment_Value = (string)Common.sink(tbActivityBlack_Comment_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);

            int tbActivityBlack_CustomerID_Value = (int)Common.sink(tbActivityBlack_CustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);



            tbActivityBlackEntity ut = BusinessFacadeDLT.tbActivityBlackDisp(IDX);


            if (tbActivityBlack_UserID_Value.Trim() != string.Empty)
            {
                if (GetID(tbActivityBlack_UserID_Value.Trim()) != "")
                {
                    ut.UserID = int.Parse(GetID(tbActivityBlack_UserID_Value.Trim()));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('不存在此用户ID，请重新输入用户ID');</script>");
                    return;
                }
            }

            if(IsInBlack(GetID(tbActivityBlack_UserID_Value.Trim()))=="-1")
            {
                Response.Write("<script language='javascript'>alert('此用户已存在于黑名单！请不要重复添加！');</script>");
                return;
            }


            ut.CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ut.Comment = tbActivityBlack_Comment_Value;
            ut.CustomerID = Common.Get_UserID;

            
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
            Int32 rInt = BusinessFacadeDLT.tbActivityBlackInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加tbActivityBlack成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改tbActivityBlack成功!(ID:{0})",IDX);
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
