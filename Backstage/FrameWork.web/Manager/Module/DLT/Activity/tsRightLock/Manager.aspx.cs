/********************************************************************************
     File:																
            Manager.aspx.cs                         
     Description:
            权限锁定管理
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
using System.Text;

namespace DLT.Web.Module.DLT.Activity.tsRightLock
{
    public partial class Manager : System.Web.UI.Page
    {
        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["ID"].ToString());
            if (!IsPostBack)
            {
                OnStart1();

                BindDataList();

                OnStart();
            }
        }

        #region 查看权限锁定
        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UserID]='" + id.ToString() + "'";
            List<tsRightLockEntity> lst = BusinessFacadeDLT.tsRightLockList(qp, out RecordCount);

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].LockType == 10)   //禁止登录
                {
                    ddlDisRemit.SelectedValue = "1";
                    tbDisRemitReason.Text = lst[i].Notice;
                    S_DisRemit_dtDate_Input.Text = DateTime.Parse(lst[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    E_DisRemit_dtDate_Input.Text = DateTime.Parse(lst[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (lst[i].LockType == 11)   //禁止下注
                {
                    ddlPubDis.SelectedValue = "1";
                    txtPubDisReason.Text = lst[i].Notice;
                    S_PubDis_dtDate_Input.Text = DateTime.Parse(lst[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    E_PubDis_dtDate_Input.Text = DateTime.Parse(lst[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (lst[i].LockType == 14)   //禁止兑换
                {
                    ddlExchange.SelectedValue = "1";
                    txtExchange.Text = lst[i].Notice;
                    S_Exchange_dtDate_Input.Text = DateTime.Parse(lst[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    E_Exchange_dtDate_Input.Text = DateTime.Parse(lst[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (lst[i].LockType == 15)   //禁止赠送
                {
                    ddlGive.SelectedValue = "1";
                    txtGive.Text = lst[i].Notice;
                    S_Give_dtDate_Input.Text = DateTime.Parse(lst[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    E_Give_dtDate_Input.Text = DateTime.Parse(lst[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (lst[i].LockType == 16)   //禁止获赠
                {
                    ddlAccept.SelectedValue = "1";
                    txtAccept.Text = lst[i].Notice;
                    S_Accept_dtDate_Input.Text = DateTime.Parse(lst[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    E_Accept_dtDate_Input.Text = DateTime.Parse(lst[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            vcUserID_Disp.Text = UserUID(id.ToString());
            TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看权限锁定";


            //获取用户备注
            string comment = GetUserComment(id.ToString());
            txtUserComment1.Text = comment;

            //获取最后对用户编辑的客服及时间
            DataTable dtLastEdit = BusinessFacadeDLT.RightLockLastOPID(UserUID(id.ToString())).Tables[0];
            if (dtLastEdit.Rows.Count > 0)
            {
                string opID = dtLastEdit.Rows[0][0].ToString();
                string opdatetime = dtLastEdit.Rows[0][1].ToString();
                lblLastOpID.Text = opID + " 时间：" + opdatetime;
            }

            //动态生成控件并赋值
            BindActivity(lst);
        }


        /// <summary>
        /// 绑定活动
        /// </summary>
        private void BindActivity(List<tsRightLockEntity> lst)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            qp.Orderfld = "Sort";
            int RecordCount = 0;
            qp.Where = " Where 1=1";
            List<tsActivityEntity> lst1 = BusinessFacadeDLT.tsActivityList(qp, out RecordCount);
            CreateNum(lst, lst1);
            CreateMoney(lst, lst1);
        }

        private void CreateNum(List<tsRightLockEntity> lst1, List<tsActivityEntity> lst)
        {
            foreach (tsActivityEntity var in lst)
            {

                HtmlTableRow htr = new HtmlTableRow();   //创建一行

                //创建第一列
                HtmlTableCell htc1 = new HtmlTableCell();
                string project = "项目：" + var.Name;
                htc1.InnerHtml = project;
                htr.Cells.Add(htc1);


                //创建第二列
                HtmlTableCell htc2 = new HtmlTableCell();
                Label lb1 = new Label();
                lb1.Text = "次数：";

                TextBox tb = new TextBox();
                tb.Width = 50;
                tb.ID = "txtNum" + var.ID.ToString() + var.ModuleID.ToString();
                htc2.Controls.Add(lb1);
                htc2.Controls.Add(tb);
                htr.Cells.Add(htc2);

                //创建第三列
                HtmlTableCell htc3 = new HtmlTableCell();
                Label lb2 = new Label();
                lb2.Text = "范围：";

                TextBox tb1 = new TextBox();
                tb1.ID = "S_Num_dtDate_Input" + var.ID.ToString() + var.ModuleID.ToString();
                tb1.CssClass = "Wdate";
                tb1.Attributes.Add("onclick", "WdatePicker()");
                tb1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})");
                tb1.Width = 150;
                tb1.Columns = 10;

                Label lb3 = new Label();
                lb3.Text = "~";

                TextBox tb2 = new TextBox();
                tb2.ID = "E_Num_dtDate_Input" + var.ID.ToString() + var.ModuleID.ToString();
                tb2.CssClass = "Wdate";
                tb2.Attributes.Add("onclick", "WdatePicker()");
                tb2.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})");
                tb2.Width = 150;
                tb2.Columns = 10;
                htc3.Controls.Add(lb2);
                htc3.Controls.Add(tb1);
                htc3.Controls.Add(lb3);
                htc3.Controls.Add(tb2);

                Label lb4 = new Label();
                lb4.Text = "快速设置：";

                DropDownList ddl = new DropDownList();
                ddl.Items.Clear();
                ddl.ID = "ddlNumSelectDate" + var.ID.ToString() + var.ModuleID.ToString();
                ddl.Attributes.Add("onchange", "SetDate('" + tb1.ID + "','" + tb2.ID + "','" + ddl.ID + "')");
                ddl.Items.Add(new ListItem("请选择", "-1"));
                ddl.Items.Add(new ListItem("3天", "1"));
                ddl.Items.Add(new ListItem("7天", "2"));
                ddl.Items.Add(new ListItem("1月", "3"));
                ddl.Items.Add(new ListItem("3年", "4"));
                ddl.Items.Add(new ListItem("清空", "5"));
                htc3.Controls.Add(lb4);
                htc3.Controls.Add(ddl);
                htr.Cells.Add(htc3);

                //创建第四列
                HtmlTableCell htc4 = new HtmlTableCell();
                Label lb5 = new Label();
                lb5.Text = "备注：";

                TextBox tb3 = new TextBox();
                tb3.ID = "NumRemark" + var.ID.ToString() + var.ModuleID.ToString();
                tb3.Width = 200;
                htc4.Controls.Add(lb5);
                htc4.Controls.Add(tb3);

                for (int i = 0; i < lst1.Count; i++)
                {
                    if (lst1[i].LockType == 12 && lst1[i].ActivityID == var.ID && lst1[i].ModuleID == var.ModuleID)
                    {
                        if (!string.IsNullOrEmpty(lst1[i].Condition))
                        {
                            tb.Text = lst1[i].Condition;
                            tb1.Text = lst1[i].StartDate.ToString() == "" ? "" : DateTime.Parse(lst1[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            tb2.Text = lst1[i].EndDate.ToString() == "" ? "" : DateTime.Parse(lst1[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            tb3.Text = lst1[i].Notice;
                        }
                        break;
                    }
                }


                htr.Cells.Add(htc4);
                Table1.Controls.Add(htr);
            }
        }

        private void CreateMoney(List<tsRightLockEntity> lst1, List<tsActivityEntity> lst)
        {
            foreach (tsActivityEntity var in lst)
            {
                HtmlTableRow htr = new HtmlTableRow();   //创建一行

                //创建第一列
                HtmlTableCell htc1 = new HtmlTableCell();
                string project = "项目：" + var.Name;
                htc1.InnerHtml = project;
                htr.Cells.Add(htc1);


                //创建第二列
                HtmlTableCell htc2 = new HtmlTableCell();
                Label lb1 = new Label();
                lb1.Text = "金额：";

                TextBox tb = new TextBox();
                tb.Width = 50;
                tb.ID = "txtsMoney" + var.ID.ToString() + var.ModuleID.ToString();

                Label lb6 = new Label();
                lb6.Text = "~";

                TextBox tb6 = new TextBox();
                tb6.Width = 50;
                tb6.ID = "txteMoney" + var.ID.ToString() + var.ModuleID.ToString();

                htc2.Controls.Add(lb1);
                htc2.Controls.Add(tb);
                htc2.Controls.Add(lb6);
                htc2.Controls.Add(tb6);
                htr.Cells.Add(htc2);

                //创建第三列
                HtmlTableCell htc3 = new HtmlTableCell();
                Label lb2 = new Label();
                lb2.Text = "范围：";

                TextBox tb1 = new TextBox();
                tb1.ID = "S_Money_dtDate_Input" + var.ID.ToString() + var.ModuleID.ToString();
                tb1.CssClass = "Wdate";
                tb1.Attributes.Add("onclick", "WdatePicker()");
                tb1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})");
                tb1.Width = 150;
                tb1.Columns = 10;

                Label lb3 = new Label();
                lb3.Text = "~";

                TextBox tb2 = new TextBox();
                tb2.ID = "E_Money_dtDate_Input" + var.ID.ToString() + var.ModuleID.ToString();
                tb2.CssClass = "Wdate";
                tb2.Attributes.Add("onclick", "WdatePicker()");
                tb2.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})");
                tb2.Width = 150;
                tb2.Columns = 10;
                htc3.Controls.Add(lb2);
                htc3.Controls.Add(tb1);
                htc3.Controls.Add(lb3);
                htc3.Controls.Add(tb2);

                Label lb4 = new Label();
                lb4.Text = "快速设置：";

                DropDownList ddl = new DropDownList();
                ddl.Items.Clear();
                ddl.ID = "ddlMoneySelectDate" + var.ID.ToString() + var.ModuleID.ToString();
                ddl.Attributes.Add("onchange", "SetDate('" + tb1.ID + "','" + tb2.ID + "','" + ddl.ID + "')");
                ddl.Items.Add(new ListItem("请选择", "-1"));
                ddl.Items.Add(new ListItem("3天", "1"));
                ddl.Items.Add(new ListItem("7天", "2"));
                ddl.Items.Add(new ListItem("1月", "3"));
                ddl.Items.Add(new ListItem("3年", "4"));
                ddl.Items.Add(new ListItem("清空", "5"));
                htc3.Controls.Add(lb4);
                htc3.Controls.Add(ddl);
                htr.Cells.Add(htc3);

                //创建第四列
                HtmlTableCell htc4 = new HtmlTableCell();
                Label lb5 = new Label();
                lb5.Text = "备注：";

                TextBox tb3 = new TextBox();
                tb3.ID = "MoneyRemark" + var.ID.ToString() + var.ModuleID.ToString();
                tb3.Width = 200;
                htc4.Controls.Add(lb5);
                htc4.Controls.Add(tb3);

                for (int i = 0; i < lst1.Count; i++)
                {
                    if (lst1[i].LockType == 13 && lst1[i].ActivityID == var.ID && lst1[i].ModuleID == var.ModuleID)
                    {
                        if (!string.IsNullOrEmpty(lst1[i].Condition) && lst1[i].Condition.Trim() != "|")
                        {
                            string[] arr = lst1[i].Condition.Split('|');
                            tb.Text = arr[0];
                            tb6.Text = arr[1];
                            tb1.Text = lst1[i].StartDate.ToString() == "" ? "" : DateTime.Parse(lst1[i].StartDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            tb2.Text = lst1[i].EndDate.ToString() == "" ? "" : DateTime.Parse(lst1[i].EndDate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            tb3.Text = lst1[i].Notice;
                        }
                        break;
                    }
                }


                htr.Cells.Add(htc4);
                Table2.Controls.Add(htr);
            }
        }


        public string GetUserComment(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]='" + id + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "";
            }
            else
            {
                return lst[0].Comment.ToString();
            }
        }

        public string UserID(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UID]='" + id + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "0";
            }
            else
            {
                return lst[0].ID.ToString();
            }

        }

        public string UserUID(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]='" + id + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "0";
            }
            else
            {
                return lst[0].UID.ToString();
            }

        }


        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
                1005	用户权限锁定类别	10	禁止登录
                1005	用户权限锁定类别	11	禁止下注
                1005	用户权限锁定类别	12	限定次数
                1005	用户权限锁定类别	13	限定报名金额
                1005	用户权限锁定类别	14	禁止兑换
                1005	用户权限锁定类别	15	禁止赠送
                1005	用户权限锁定类别	16	禁止获赠
           */
            DateTime curDate = DateTime.Now;
            //禁止登录
            DateTime sDisRemitDate = S_DisRemit_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(S_DisRemit_dtDate_Input.Text.Trim());
            DateTime eDisRemitDate = E_DisRemit_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(E_DisRemit_dtDate_Input.Text.Trim());
            BusinessFacadeDLT.SetUserLock(id, 10, sDisRemitDate, eDisRemitDate, tbDisRemitReason.Text.Trim(), 0, "", Convert.ToInt32(ddlDisRemit.SelectedValue),0);
            //禁止下注
            DateTime sPubDisDate = S_PubDis_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(S_PubDis_dtDate_Input.Text.Trim());
            DateTime ePubDisDate = E_PubDis_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(E_PubDis_dtDate_Input.Text.Trim());
            BusinessFacadeDLT.SetUserLock(id, 11, sPubDisDate, ePubDisDate, txtPubDisReason.Text.Trim(), 0, "", Convert.ToInt32(ddlPubDis.SelectedValue),0);

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            qp.Orderfld = "Sort";
            int RecordCount = 0;
            qp.Where = " Where 1=1";
            List<tsActivityEntity> lst = BusinessFacadeDLT.tsActivityList(qp, out RecordCount);
            foreach (tsActivityEntity var in lst)
            {
                //限定次数
                string num = replace(this.Request.Form["ctl00$PageBody$txtNum" + var.ID.ToString() + var.ModuleID.ToString()].ToString());
                string startDate = replace(this.Request.Form["ctl00$PageBody$S_Num_dtDate_Input" + var.ID + var.ModuleID.ToString()].ToString());
                DateTime sDate = startDate == "" ? curDate : DateTime.Parse(startDate);
                string endDate = replace(this.Request.Form["ctl00$PageBody$E_Num_dtDate_Input" + var.ID + var.ModuleID.ToString()].ToString());
                DateTime eDate = endDate == "" ? curDate : DateTime.Parse(endDate);
                string remark = replace(this.Request.Form["ctl00$PageBody$NumRemark" + var.ID + var.ModuleID.ToString()].ToString());
                BusinessFacadeDLT.SetUserLock(id, 12, sDate, eDate, remark, var.ID, num, 1,var.ModuleID);

                //限定报名金额
                string sMoney = replace(this.Request.Form["ctl00$PageBody$txtsMoney" + var.ID + var.ModuleID.ToString()].ToString());
                string eMoney = replace(this.Request.Form["ctl00$PageBody$txteMoney" + var.ID + var.ModuleID.ToString()].ToString());
                string startDate1 = replace(this.Request.Form["ctl00$PageBody$S_Money_dtDate_Input" + var.ID + var.ModuleID.ToString()].ToString());
                DateTime sDate1 = startDate1 == "" ? curDate : DateTime.Parse(startDate1);
                string endDate1 = replace(this.Request.Form["ctl00$PageBody$E_Money_dtDate_Input" + var.ID + var.ModuleID.ToString()].ToString());
                DateTime eDate1 = endDate1 == "" ? curDate : DateTime.Parse(endDate1);
                string remark1 = replace(this.Request.Form["ctl00$PageBody$MoneyRemark" + var.ID + var.ModuleID.ToString()].ToString());
                BusinessFacadeDLT.SetUserLock(id, 13, sDate1, eDate1, remark1, var.ID, sMoney + "|" + eMoney, 1,var.ModuleID);
            }


            //禁止兑换
            DateTime sExchangeDate = S_Exchange_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(S_Exchange_dtDate_Input.Text.Trim());
            DateTime eExchangeDate = E_Exchange_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(E_Exchange_dtDate_Input.Text.Trim());
            BusinessFacadeDLT.SetUserLock(id, 14, sExchangeDate, eExchangeDate, txtExchange.Text.Trim(), 0, "", Convert.ToInt32(ddlExchange.SelectedValue),0);

            //禁止赠送
            DateTime sGiveDate = S_Give_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(S_Give_dtDate_Input.Text.Trim());
            DateTime eGiveDate = E_Give_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(E_Give_dtDate_Input.Text.Trim());
            BusinessFacadeDLT.SetUserLock(id, 15, sGiveDate, eGiveDate, txtGive.Text.Trim(), 0, "", Convert.ToInt32(ddlGive.SelectedValue),0);

            //禁止获赠
            DateTime sAcceptDate = S_Accept_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(S_Accept_dtDate_Input.Text.Trim());
            DateTime eAcceptDate = E_Accept_dtDate_Input.Text.Trim() == "" ? curDate : DateTime.Parse(E_Accept_dtDate_Input.Text.Trim());
            BusinessFacadeDLT.SetUserLock(id, 16, sAcceptDate, eAcceptDate, txtAccept.Text.Trim(), 0, "", Convert.ToInt32(ddlAccept.SelectedValue),0);

            //保存用户备注
            string UID = UserUID(id.ToString());
            DataSet ds = BusinessFacadeDLT.UpdateUserComment(txtUserComment1.Text, UID);
            string titleMessage = "用户" + UID + "权限信息更改成功，更改操作员ID：" + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
            EventMessage.EventWriteDB(1, titleMessage);
            Response.Write("<script language='javascript'>alert('保存成功！');window.location.href='../User/Default.aspx';</script>");


        }

        private string replace(string val)
        {
            return val.Replace(",", "");
        }

        
        #endregion

        #region 自动权限锁定
        /// <summary>
        /// 根据ID得到系统参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string SysParamList(string id)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]='" + id + "'";

            List<tsSysParamEntity> lst = BusinessFacadeDLT.tsSysParamList(qp, out RecordCount);
            if (lst.Count == 0)
            {
                return "";
            }
            else
            {
                return lst[0].Value.ToString();
            }
        }


        private void OnStart1()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            string DateArea = SysParamList("1000");
            string[] DateAreas = DateArea.Split(',');
            for (int i = 0; i < DateAreas.Length; i++)
            {
                string[] area = DateAreas[i].Split('|');
                string s = area[0];
                string e = area[1];
                HtmlTableRow htr = new HtmlTableRow();   //创建一行

                //创建第三列
                HtmlTableCell htc3 = new HtmlTableCell();
                Label lb2 = new Label();
                lb2.Text = "时间区间：";

                TextBox tb1 = new TextBox();
                tb1.ID = "S_Area_dtDate_Input" + s;
                tb1.CssClass = "Wdate";
                tb1.Attributes.Add("onclick", "WdatePicker()");
                tb1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'HH:mm:ss'})");
                tb1.Width = 150;
                tb1.Columns = 10;
                tb1.Text = s;

                Label lb3 = new Label();
                lb3.Text = "~";

                TextBox tb2 = new TextBox();
                tb2.ID = "E_Area_dtDate_Input" + e;
                tb2.CssClass = "Wdate";
                tb2.Attributes.Add("onclick", "WdatePicker()");
                tb2.Attributes.Add("onfocus", "WdatePicker({dateFmt:'HH:mm:ss'})");
                tb2.Width = 150;
                tb2.Columns = 10;
                tb2.Text = e;

                htc3.Controls.Add(lb2);
                htc3.Controls.Add(tb1);
                htc3.Controls.Add(lb3);
                htc3.Controls.Add(tb2);
                htr.Cells.Add(htc3);
                Table3.Controls.Add(htr);

                d.Add(tb1.ID + "|" + tb2.ID, tb1.Text + "|" + tb2.Text);
            }
            ViewState["DateAreas"] = d;
        }


        private void DataBindArea()
        {
            Dictionary<string, string> dictionary = ViewState["DateAreas"] as Dictionary<string, string>;
            if (dictionary != null)
            {
                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    string[] area = kvp.Key.Split('|');
                    string s = area[0];
                    string e = area[1];
                    string[] values = kvp.Value.Split('|');
                    HtmlTableRow htr = new HtmlTableRow();   //创建一行

                    //创建第三列
                    HtmlTableCell htc3 = new HtmlTableCell();
                    Label lb2 = new Label();
                    lb2.Text = "时间区间：";

                    TextBox tb1 = new TextBox();
                    tb1.ID = "S_Area_dtDate_Input" + s;
                    tb1.CssClass = "Wdate";
                    tb1.Attributes.Add("onclick", "WdatePicker()");
                    tb1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'HH:mm:ss'})");
                    tb1.Width = 150;
                    tb1.Columns = 10;
                    tb1.Text = values[0];

                    Label lb3 = new Label();
                    lb3.Text = "~";

                    TextBox tb2 = new TextBox();
                    tb2.ID = "E_Area_dtDate_Input" + e;
                    tb2.CssClass = "Wdate";
                    tb2.Attributes.Add("onclick", "WdatePicker()");
                    tb2.Attributes.Add("onfocus", "WdatePicker({dateFmt:'HH:mm:ss'})");
                    tb2.Width = 150;
                    tb2.Columns = 10;
                    tb2.Text = values[1];

                    htc3.Controls.Add(lb2);
                    htc3.Controls.Add(tb1);
                    htc3.Controls.Add(lb3);
                    htc3.Controls.Add(tb2);
                    htr.Cells.Add(htc3);
                    Table3.Controls.Add(htr);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> d = ViewState["DateAreas"] as Dictionary<string, string>;
            if (d != null)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> kvp in d)
                {
                    string[] area = kvp.Key.Split('|');
                    string sID = area[0];
                    string eID = area[1];

                    string sValue = "";
                    string eValue = "";
                    if (this.Request.Form["ctl00$PageBody$" + sID] == null)
                    {
                        sValue = this.Request.Form["ctl00$PageBody$S_Area_dtDate_Input" + sID].ToString();
                    }
                    else
                    {
                        sValue = this.Request.Form["ctl00$PageBody$" + sID].ToString();
                    }

                    if (this.Request.Form["ctl00$PageBody$" + eID] == null)
                    {
                        eValue = this.Request.Form["ctl00$PageBody$E_Area_dtDate_Input" + eID].ToString();
                    }
                    else
                    {
                        eValue = this.Request.Form["ctl00$PageBody$" + eID].ToString();
                    }
                    dictionary.Add(kvp.Key, sValue + "|" + eValue);
                }

                Random random = new Random();
                int num = random.Next(10000);
                string key = "S_Area_dtDate_Input" + num + "|" + "E_Area_dtDate_Input" + num;

                while (d.ContainsKey(key))
                {
                    num = random.Next(10000);
                    key = "S_Area_dtDate_Input" + num + "|" + "E_Area_dtDate_Input" + num;
                }

                dictionary.Add(key, "|");
                ViewState["DateAreas"] = dictionary;
            }
            DataBindArea();
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> d = ViewState["DateAreas"] as Dictionary<string, string>;
            if (d != null)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string value = "";
                foreach (KeyValuePair<string, string> kvp in d)
                {
                    string[] area = kvp.Key.Split('|');
                    string sID = area[0];
                    string eID = area[1];
                   
                    string sValue = "";
                    string eValue = "";
                    if (this.Request.Form["ctl00$PageBody$" + sID] == null)
                    {
                        sValue = this.Request.Form["ctl00$PageBody$S_Area_dtDate_Input" + sID].ToString();
                    }
                    else {
                        sValue = this.Request.Form["ctl00$PageBody$" + sID].ToString();
                    }

                    if (this.Request.Form["ctl00$PageBody$" + eID] == null)
                    {
                        eValue = this.Request.Form["ctl00$PageBody$E_Area_dtDate_Input" + eID].ToString();
                    }
                    else {
                        eValue = this.Request.Form["ctl00$PageBody$" + eID].ToString();
                    }
                    value = value + sValue + "|" + eValue + ",";
                    dictionary.Add(kvp.Key, sValue + "|" + eValue);
                }
                ViewState["DateAreas"] = dictionary;
                if (value != "") {
                    value = value.Substring(0, value.Length - 1);
                    tsSysParamEntity tsSysParam = new tsSysParamEntity();
                    tsSysParam.ID = 1000;
                    tsSysParam.Name = "";
                    tsSysParam.Value = value;
                    tsSysParam.Comment = "";
                    tsSysParam.DataTable_Action_ = DataTable_Action.Update;
                    int result=BusinessFacadeDLT.tsSysParamInsertUpdateDelete(tsSysParam);
                    if (result > 0)
                    {
                        Response.Write("<script language='javascript'>alert('保存成功！');</script>");
                        DataBindArea();
                    }
                    else {
                        Response.Write("<script language='javascript'>alert('保存失败！');</script>");
                    }
                }
            }
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> d = ViewState["DateAreas"] as Dictionary<string, string>;
            if (d != null) {
                string key = "";
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> kvp in d)
                {
                    string[] area = kvp.Key.Split('|');
                    string sID = area[0];
                    string eID = area[1];

                    string sValue = "";
                    string eValue = "";
                    if (this.Request.Form["ctl00$PageBody$" + sID] == null)
                    {
                        sValue = this.Request.Form["ctl00$PageBody$S_Area_dtDate_Input" + sID].ToString();
                    }
                    else
                    {
                        sValue = this.Request.Form["ctl00$PageBody$" + sID].ToString();
                    }

                    if (this.Request.Form["ctl00$PageBody$" + eID] == null)
                    {
                        eValue = this.Request.Form["ctl00$PageBody$E_Area_dtDate_Input" + eID].ToString();
                    }
                    else
                    {
                        eValue = this.Request.Form["ctl00$PageBody$" + eID].ToString();
                    }
                    key = kvp.Key;
                    dictionary.Add(kvp.Key, sValue + "|" + eValue);
                }
                if (key != "")
                {
                    dictionary.Remove(key);
                }
                ViewState["DateAreas"] = dictionary;
                DataBindArea();
            }
        }
      
        #endregion


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.TableName = "vw_RightLockAuto";
            //qp.Where = SearchTerms;
            qp.Where = "where CreateDate>='" + DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            qp.ReturnFields = "*";
            int RecordCount;
            List<tsRightLockAutoEntity> list = BusinessFacadeDLT.tsRightLockAutoList(qp, out RecordCount);
            GridView1.DataSource = list;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDataList();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchTerms
        {
            get
            {
                if (ViewState["SearchTerms"] == null)
                    ViewState["SearchTerms"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "ActivityID";

                return (string)ViewState["sortOrderfld"];
            }
            set
            {
                ViewState["sortOrderfld"] = value;
            }
        }

        /// <summary>
        /// 排序类型 1:降序 0:升序
        /// </summary>
        public int OrderType
        {

            get
            {

                if (ViewState["sortOrderType"] == null)
                    ViewState["sortOrderType"] = 1;

                return (int)ViewState["sortOrderType"];


            }

            set { ViewState["sortOrderType"] = value; }

        }

       
    }
}
