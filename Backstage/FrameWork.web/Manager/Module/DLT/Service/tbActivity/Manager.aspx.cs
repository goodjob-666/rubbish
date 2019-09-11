/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            tbActivity管理
     Author:									
            DDBuildTools
            http://DDBuildTools.supesoft.com
     Finish DateTime:
            2016/8/22 16:48:55
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

namespace DLT.Web.Module.DLT.tbActivity
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
                BindGameList();
                OnStart();
            }
        }


        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                cbGame.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(IDX);
            OnStartData(ut);
            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加平台活动";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看平台活动";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改平台活动";
                    Hidden_Disp();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbActivityInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
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
            bi.ButtonName = "tbActivity";
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
            bi.ButtonName = "tbActivity";
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
        private void OnStartData(tbActivityEntity ut)
        {
            tbActivity_Title_Input.Text = tbActivity_Title_Disp.Text = ut.Title.ToString();
            ddlUserType.SelectedValue = tbActivity_UserType_Disp.Text = ut.UserType.ToString();

            if (ut.GameID.ToString().IndexOf(',') > 0)
            {
                string[] arr = ut.GameID.ToString().Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    cbGame.SelectedValue = arr[i].ToString();
                }
            }
            else
            {
                cbGame.SelectedValue = tbActivity_GameID_Disp.Text = ut.GameID.ToString();
            }

            tbActivity_StartDate_Input.Text = tbActivity_StartDate_Disp.Text = ut.StartDate.ToString();
            tbActivity_EndDate_Input.Text = tbActivity_EndDate_Disp.Text = ut.EndDate.ToString();
            if (ut.Channel.ToString() == "10")
            {
                cbChannel.SelectedValue = "10";
            }
            else if (ut.Channel.ToString() == "11")
            {
                cbChannel.SelectedValue = "11";
            }
            else
            {
                foreach (ListItem li in cbChannel.Items)
                {

                  li.Selected = true;
                }
            }

            //cbChannel.SelectedValue = tbActivity_Channel_Disp.Text = ut.Channel.ToString();
            tbActivity_Price_Input.Text = tbActivity_Price_Disp.Text = ut.Price.ToString() == "0" ? "" : ut.Price.ToString();
            tbActivity_SendDate_Input.Text = tbActivity_SendDate_Disp.Text = ut.SendDate.ToString();
            tbActivity_Status_Input.Text = tbActivity_Status_Disp.Text = ut.Status.ToString();
            tbActivity_Comment_Input.Text = tbActivity_Comment_Disp.Text = ut.Comment.ToString();
            tbActivity_Price1_Input.Text = tbActivity_Pirce2_Disp.Text = ut.Pirce2.ToString() == "0" ? "" : ut.Pirce2.ToString(); ;
            tbActivity_CreateDate_Input.Text = tbActivity_CreateDate_Disp.Text = ut.CreateDate.ToString();
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            tbActivity_Title_Input.Visible = false;
            ddlUserType.Visible = false;
            cbGame.Visible = false;
            tbActivity_StartDate_Input.Visible = false;
            tbActivity_EndDate_Input.Visible = false;
            cbChannel.Visible = false;
            tbActivity_Price_Input.Visible = false;
            tbActivity_SendDate_Input.Visible = false;
            tbActivity_Status_Input.Visible = false;
            tbActivity_Comment_Input.Visible = false;
            tbActivity_Price1_Input.Visible = false;
            tbActivity_CreateDate_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            tbActivity_Title_Disp.Visible = false;
            tbActivity_UserType_Disp.Visible = false;
            tbActivity_GameID_Disp.Visible = false;
            tbActivity_StartDate_Disp.Visible = false;
            tbActivity_EndDate_Disp.Visible = false;
            tbActivity_Channel_Disp.Visible = false;
            tbActivity_Price_Disp.Visible = false;
            tbActivity_SendDate_Disp.Visible = false;
            tbActivity_Status_Disp.Visible = false;
            tbActivity_Comment_Disp.Visible = false;
            tbActivity_Pirce2_Disp.Visible = false;
            tbActivity_CreateDate_Disp.Visible = false;

        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {


            string s = "";
            int v = 11;
            string str = "";

            foreach (ListItem li in cbChannel.Items)
            {
                if (li.Selected) s += li.Value + ",";
            }

            s = s.TrimEnd(',');


            foreach (ListItem li in cbGame.Items)
            {
                if (li.Selected) str += li.Value + ",";
            }

            str = str.TrimEnd(',');

            if (s.IndexOf(",") > 0)
            {
                if (s.IndexOf("10") > -1)
                {
                    if (tbActivity_Price_Input.Text == "")
                    {
                        Response.Write("<script language='javascript'>alert('请输入内部频道红包价格！');</script>");
                        return;
                    }
                }

                if (s.IndexOf("11") > -1)
                {
                    if (tbActivity_Price1_Input.Text == "")
                    {
                        Response.Write("<script language='javascript'>alert('请输入公共频道红包价格！');</script>");
                        return;
                    }
                }

                if (s.IndexOf("13") > -1)
                {
                    if (tbActivity_Price2_Input.Text == "")
                    {
                        Response.Write("<script language='javascript'>alert('请输入优质频道红包价格！');</script>");
                        return;
                    }
                }

                /*
                if (tbActivity_Price_Input.Text == "")
                {
                    Response.Write("<script language='javascript'>alert('请输入内部频道红包价格！');</script>");
                    return;
                }
                if (tbActivity_Price1_Input.Text == "")
                {
                    Response.Write("<script language='javascript'>alert('请输入公共频道红包价格！');</script>");
                    return;
                }
                */
                if (s == "10,11")
                {
                    v = 12;
                }
                else if (s == "10,13")
                {
                    v = 14;
                }
                else if (s == "11,13")
                {
                    v = 15;
                }
                else if (s == "10,11,13")
                {
                    v = 16;
                }
            }
            else
            {
                if (s != "")
                {
                    v = int.Parse(s);
                    if (v == 10)
                    {
                        if (tbActivity_Price_Input.Text == "")
                        {
                            Response.Write("<script language='javascript'>alert('请输入内部频道红包价格！');</script>");
                            return;
                        }

                    }
                    else if (v == 11)
                    {
                        if (tbActivity_Price1_Input.Text == "")
                        {
                            Response.Write("<script language='javascript'>alert('请输入公共频道红包价格！');</script>");
                            return;
                        }
                    }
                    else
                    {
                        if (tbActivity_Price2_Input.Text == "")
                        {
                            Response.Write("<script language='javascript'>alert('请输入优质频道红包价格！');</script>");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('请至少选择一个用户频道！');</script>");
                    return;
                }
            }
            if (tbActivity_StartDate_Input.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入活动开始时间！');</script>");
                return;
            }

            if (tbActivity_EndDate_Input.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入活动结束时间！');</script>");
                return;
            }


            string tbActivity_Title_Value = (string)Common.sink(tbActivity_Title_Input.UniqueID, MethodType.Post, 256, 1, DataType.Str);


            DateTime? tbActivity_StartDate_Value = (DateTime?)Common.sink(tbActivity_StartDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            DateTime? tbActivity_EndDate_Value = (DateTime?)Common.sink(tbActivity_EndDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);


            //double tbActivity_Price_Value = (double)Common.sink(tbActivity_Price_Input.UniqueID, MethodType.Post, 19, 0, DataType.Double);
            //double tbActivity_Pirce2_Value = (double)Common.sink(tbActivity_Price1_Input.UniqueID, MethodType.Post, 19, 0, DataType.Double);

            DateTime? tbActivity_SendDate_Value = (DateTime?)Common.sink(tbActivity_SendDate_Input.UniqueID, MethodType.Post, 50, 0, DataType.Dat);

            int tbActivity_Status_Value = (int)Common.sink(tbActivity_Status_Input.UniqueID, MethodType.Post, 10, 0, DataType.Int);
            string tbActivity_Comment_Value = (string)Common.sink(tbActivity_Comment_Input.UniqueID, MethodType.Post, 2048, 0, DataType.Str);




            tbActivityEntity ut = BusinessFacadeDLT.tbActivityDisp(IDX);

            ut.Title = tbActivity_Title_Value;
            ut.UserType = int.Parse(ddlUserType.SelectedValue);
            ut.GameID = str;
            ut.StartDate = tbActivity_StartDate_Value;
            ut.EndDate = tbActivity_EndDate_Value;
            ut.Channel = v;
            if (tbActivity_Price_Input.Text == "")
            {
                ut.Price = 0F;
            }
            else
            {
                ut.Price = float.Parse(tbActivity_Price_Input.Text);
            }
            if (tbActivity_Price1_Input.Text == "")
            {
                ut.Pirce2 = 0F;
            }
            else
            {
                ut.Pirce2 = float.Parse(tbActivity_Price1_Input.Text);
            }
            if (tbActivity_Price2_Input.Text == "")
            {
                ut.Price3 = 0F;
            }
            else
            {
                ut.Price3 = float.Parse(tbActivity_Price2_Input.Text);
            }
            ut.SendDate = tbActivity_SendDate_Value;
            ut.Status = tbActivity_Status_Value;
            ut.Comment = tbActivity_Comment_Value;
            ut.CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));

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
            Int32 rInt = BusinessFacadeDLT.tbActivityInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加tbActivity成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改tbActivity成功!(ID:{0})", IDX);
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
