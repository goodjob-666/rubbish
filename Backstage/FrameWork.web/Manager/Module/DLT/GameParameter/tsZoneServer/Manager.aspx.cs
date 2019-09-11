/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            区服汇总管理
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

namespace DLT.Web.Module.DLT.tsZoneServer
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
            tsZoneServerEntity ut = BusinessFacadeDLT.tsZoneServerDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            { 
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加区服汇总";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看区服汇总";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改区服汇总";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsZoneServerInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "区服汇总";
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
            bi.ButtonName = "区服汇总";
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
        private void OnStartData(tsZoneServerEntity ut)
        {
        tsZoneServer_Code_Input.Text = tsZoneServer_Code_Disp.Text = ut.Code.ToString();
                tsZoneServer_GameID_Input.Text = tsZoneServer_GameID_Disp.Text = ut.GameID.ToString();
                tsZoneServer_Game_Input.Text = tsZoneServer_Game_Disp.Text = ut.Game.ToString();
                tsZoneServer_ZoneID_Input.Text = tsZoneServer_ZoneID_Disp.Text = ut.ZoneID.ToString();
                tsZoneServer_Zone_Input.Text = tsZoneServer_Zone_Disp.Text = ut.Zone.ToString();
                tsZoneServer_ServerID_Input.Text = tsZoneServer_ServerID_Disp.Text = ut.ServerID.ToString();
                tsZoneServer_Server_Input.Text = tsZoneServer_Server_Disp.Text = ut.Server.ToString();
                tsZoneServer_FactionID_Input.Text = tsZoneServer_FactionID_Disp.Text = ut.FactionID.ToString();
                tsZoneServer_Faction_Input.Text = tsZoneServer_Faction_Disp.Text = ut.Faction.ToString();
                tsZoneServer_SpellFull_Input.Text = tsZoneServer_SpellFull_Disp.Text = ut.SpellFull.ToString();
                tsZoneServer_SpellShort_Input.Text = tsZoneServer_SpellShort_Disp.Text = ut.SpellShort.ToString();
                tsZoneServer_IsOnline_Input.SelectedValue = Convert.ToInt32(ut.IsOnline).ToString();
                tsZoneServer_IsOnline_Disp.Text = ut.IsOnline.ToString();
                
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
        tsZoneServer_Code_Input.Visible = false;
        tsZoneServer_GameID_Input.Visible = false;
        tsZoneServer_Game_Input.Visible = false;
        tsZoneServer_ZoneID_Input.Visible = false;
        tsZoneServer_Zone_Input.Visible = false;
        tsZoneServer_ServerID_Input.Visible = false;
        tsZoneServer_Server_Input.Visible = false;
        tsZoneServer_FactionID_Input.Visible = false;
        tsZoneServer_Faction_Input.Visible = false;
        tsZoneServer_SpellFull_Input.Visible = false;
        tsZoneServer_SpellShort_Input.Visible = false;
        tsZoneServer_IsOnline_Input.Visible = false;
        
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
        tsZoneServer_Code_Disp.Visible = false;
        tsZoneServer_GameID_Disp.Visible = false;
        tsZoneServer_Game_Disp.Visible = false;
        tsZoneServer_ZoneID_Disp.Visible = false;
        tsZoneServer_Zone_Disp.Visible = false;
        tsZoneServer_ServerID_Disp.Visible = false;
        tsZoneServer_Server_Disp.Visible = false;
        tsZoneServer_FactionID_Disp.Visible = false;
        tsZoneServer_Faction_Disp.Visible = false;
        tsZoneServer_SpellFull_Disp.Visible = false;
        tsZoneServer_SpellShort_Disp.Visible = false;
        tsZoneServer_IsOnline_Disp.Visible = false;
        
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        
            string tsZoneServer_Code_Value = (string)Common.sink(tsZoneServer_Code_Input.UniqueID, MethodType.Post, 18, 1, DataType.Str);
            int tsZoneServer_GameID_Value = (int)Common.sink(tsZoneServer_GameID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsZoneServer_Game_Value = (string)Common.sink(tsZoneServer_Game_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            int tsZoneServer_ZoneID_Value = (int)Common.sink(tsZoneServer_ZoneID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsZoneServer_Zone_Value = (string)Common.sink(tsZoneServer_Zone_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            int tsZoneServer_ServerID_Value = (int)Common.sink(tsZoneServer_ServerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsZoneServer_Server_Value = (string)Common.sink(tsZoneServer_Server_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            int tsZoneServer_FactionID_Value = (int)Common.sink(tsZoneServer_FactionID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tsZoneServer_Faction_Value = (string)Common.sink(tsZoneServer_Faction_Input.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            string tsZoneServer_SpellFull_Value = (string)Common.sink(tsZoneServer_SpellFull_Input.UniqueID, MethodType.Post, 250, 0, DataType.Str);
            string tsZoneServer_SpellShort_Value = (string)Common.sink(tsZoneServer_SpellShort_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            
                    bool tsZoneServer_IsOnline_Value = Convert.ToBoolean(Common.sink(tsZoneServer_IsOnline_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));
                
            tsZoneServerEntity ut = BusinessFacadeDLT.tsZoneServerDisp(IDX);
            
            ut.Code = tsZoneServer_Code_Value;
            ut.GameID = tsZoneServer_GameID_Value;
            ut.Game = tsZoneServer_Game_Value;
            ut.ZoneID = tsZoneServer_ZoneID_Value;
            ut.Zone = tsZoneServer_Zone_Value;
            ut.ServerID = tsZoneServer_ServerID_Value;
            ut.Server = tsZoneServer_Server_Value;
            ut.FactionID = tsZoneServer_FactionID_Value;
            ut.Faction = tsZoneServer_Faction_Value;
            ut.SpellFull = tsZoneServer_SpellFull_Value;
            ut.SpellShort = tsZoneServer_SpellShort_Value;
            ut.IsOnline = tsZoneServer_IsOnline_Value;
            
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
            Int32 rInt = BusinessFacadeDLT.tsZoneServerInsertUpdateDelete(ut);
            if ( rInt> 0)
            {
                string OpTxt = string.Format("增加区服汇总成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改区服汇总成功!(ID:{0})",IDX);
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
