/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            服务器管理
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

namespace DLT.Web.Module.DLT.tsServer
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
        /// 绑定游戏列表
        /// </summary>
        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;

            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGame.Items.Add(new ListItem(var.Game, var.ID.ToString()));
            }
            ddlGame_SelectedIndexChanged(null, null);
        }
        
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {

            BindGameList();
            tsServerEntity ut = null;
            if (CMD != "New") {
                ut = BusinessFacadeDLT.tsServerDisp(IDX);
                OnStartData(ut);
            }
           
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加服务器";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看服务器";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改服务器";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsServerInsertUpdateDelete(ut) > 0)
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
        /// 绑定游戏列表
        /// </summary>
        private void BindZoneList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;

            List<tsZoneEntity> lst = BusinessFacadeDLT.tsZoneList(qp, out RecordCount);
            foreach (tsZoneEntity var in lst)
            {

                ddlZone.Items.Add(new ListItem(var.Zone, var.ID.ToString()));
            }

        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "服务器";
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
            bi.ButtonName = "服务器";
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
        private void OnStartData(tsServerEntity ut)
        {
            ddlZone.SelectedValue = ut.ZoneID.ToString();
            tsServer_ZoneID_Disp.Text = ddlZone.SelectedItem.Text;
            tsServer_Server_Input.Text = tsServer_Server_Disp.Text = ut.Server.ToString();
            DropDownList1.SelectedItem.Text = lblSort.Text = ut.Sort.ToString();
            
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        ddlZone.Visible = false;
        tsServer_Server_Input.Visible = false;
        DropDownList1.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tsServer_ZoneID_Disp.Visible = false;
        tsServer_Server_Disp.Visible = false;
        lblSort.Visible = false;
       
        }

        protected void ddlGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlGame.SelectedValue != "")
            {
                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                qp.Where = string.Format(" Where GameID = {0} ", "'" + this.ddlGame.SelectedValue + "'");
                int RecordCount = 0;
                ddlZone.Items.Clear();
                List<tsZoneEntity> lst = BusinessFacadeDLT.tsZoneList(qp, out RecordCount);
                foreach (tsZoneEntity var in lst)
                {
                    ddlZone.Items.Add(new ListItem(var.Zone, var.ID.ToString()));
                }
            }
            else
            {
                BindZoneList();
            }
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            int tsServer_ZoneID_Value = (int)Common.sink(ddlZone.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsServer_Server_Value = (string)Common.sink(tsServer_Server_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            tsServerEntity ut = BusinessFacadeDLT.tsServerDisp(IDX);
            
            ut.ZoneID = tsServer_ZoneID_Value;
            ut.Server = tsServer_Server_Value;
            ut.Sort = Convert.ToInt32(DropDownList1.SelectedValue);
            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
                Int32 result = BusinessFacadeDLT.tsServerInsertUpdateDelete(ut);
                if (result > 0)
                {
                    string OpTxt = string.Format("增加服务器成功!(ID:{0})", result);
                    EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                }
                else
                {
                    EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", result), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                }
            }
            else
            {
                if (CMD == "Edit")
                {
                    ut.DataTable_Action_ = DataTable_Action.Update;
                }
                else
                {
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                }
                Int32 rInt = BusinessFacadeDLT.tsServerInsertUpdateDelete(ut);
                if (rInt > 0)
                {
                    string OpTxt = string.Format("增加服务器成功!(ID:{0})", rInt);
                    if (ut.DataTable_Action_ == DataTable_Action.Update)
                        OpTxt = string.Format("修改服务器成功!(ID:{0})", IDX);
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
