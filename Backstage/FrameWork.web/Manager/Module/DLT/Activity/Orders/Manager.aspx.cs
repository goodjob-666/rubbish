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

namespace DLT.Web.Module.DLT.Activity.Orders
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
            if (CMD != "New")
            {
                QueryParam qp = new QueryParam();
                qp.Where = " Where ID=" + IDX;
                qp.PageIndex = 1;
                qp.PageSize = 1;
                qp.Orderfld = "ID";
                qp.OrderType = 1;

                DataSet ds = BusinessFacadeDLT.OrderList(qp);
                OnStartData(ds.Tables[0]);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加订单";
                    
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看订单";
                    
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "判决订单";
                    break;

                case "Delete":
                    //ut.DataTable_Action_ = DataTable_Action.Delete;
                    //if (BusinessFacadeDLT.tsActivityInsertUpdateDelete(ut) > 0)
                    //{
                    //    EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    //}
                    //else
                    //{
                    //    EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    //}
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
            bi.ButtonName = "订单";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(DataTable dt)
        {
            lblEndDate.Text = dt.Rows[0]["EndDate"].ToString();
            //lblGame.Text = dt.Rows[0]["Game"].ToString();
            lblSeriaNo.Text = dt.Rows[0]["SeriaNo"].ToString();
            lblStartDate.Text = dt.Rows[0]["StartDate"].ToString();
            lblTitle.Text = dt.Rows[0]["Title"].ToString();
            lblUserID.Text = dt.Rows[0]["UID"].ToString();
            HiddenField1.Value = dt.Rows[0]["UserID"].ToString();
            lblZoneServer.Text = dt.Rows[0]["ZoneServer"].ToString();
            lblRoleName.Text = dt.Rows[0]["RoleName"].ToString();
            lblRegAmount.Text = dt.Rows[0]["RegAmount"].ToString();
            txtResAmount.Text = dt.Rows[0]["ResAmount"].ToString();
            lblResult.Text = txtResAmount.Text == "0.00" ? "输" : "赢";
            lblComment.Text = dt.Rows[0]["Comment"].ToString();
            lblReward.Text = dt.Rows[0]["Reward"].ToString();

            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1013";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                if (var.Kind.ToString() == dt.Rows[0]["Status"].ToString())
                {
                    lblStatus.Text = var.Value;
                    break;
                }
            }

            int moduleId = Convert.ToInt32(dt.Rows[0]["ModuleID"]);
            int activityId = Convert.ToInt32(dt.Rows[0]["ActivityID"]);
            bool b = Convert.ToBoolean(dt.Rows[0]["OddEven"]);
            if (moduleId == 3 && activityId != 10)
            {
                if (b)
                {
                    lblEvenOdd.Text = "奇数";
                }
                else
                {
                    lblEvenOdd.Text = "偶数";
                }
                Panel1.Visible = true;
            }
            else {
                Panel1.Visible = false;
            }

            if (moduleId == 1)
            {
                LinkButton1.Visible = true;
                LinkButton1.PostBackUrl = string.Format("ZhanKengList.aspx?SeriaNo={0}&IDX={1}", lblSeriaNo.Text, IDX);
            }
            else {
                LinkButton1.Visible = false;
            }
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(ddlResult.SelectedValue);
            if (status == -1)
            {
                Response.Write("<script language='javascript'>alert('请在二次判决结果中选择判定该订单输赢！');</script>");
                return;
            }
            if (txtFeedBack.Text == "") {
                Response.Write("<script language='javascript'>alert('请输入反馈备注！');</script>");
                return;
            }

            DateTime curTime = DateTime.Now;
            int userId = Convert.ToInt32(HiddenField1.Value);
            double resAmount = Convert.ToDouble(txtResAmount.Text);
            double sumBal = BusinessFacadeDLT.GetUserSumBal(userId);
            //资金流水表
            tbMoneyChangeEntity tbMoneyChange = new tbMoneyChangeEntity();
            tbMoneyChange.SerialNo = "";
            tbMoneyChange.UserID = userId;
            tbMoneyChange.ChangeType = 16;
            tbMoneyChange.PreBal = sumBal;
            tbMoneyChange.ChangeBal = resAmount;
            tbMoneyChange.CurBal = sumBal + resAmount;
            tbMoneyChange.ChangeDate = curTime;
            tbMoneyChange.RelaSerialNo = lblSeriaNo.Text;
            tbMoneyChange.Comment = "二次判决结算费用";

            //操作日志
            tlOperateEntity fam = new tlOperateEntity();
            fam.ID = 0;
            fam.UserID = userId;
            fam.OPType = 22;
            fam.OPLog = "系统二次判决";
            fam.CreateDate = curTime;
            fam.IP = Common.GetIPAddress();
            fam.DataTable_Action_ = DataTable_Action.Insert;

            BusinessFacadeDLT.MacthResult(lblSeriaNo.Text, userId, Convert.ToDouble(lblRegAmount.Text), resAmount, status, curTime,txtFeedBack.Text, tbMoneyChange, fam);
            Response.Write("<script language='javascript'>alert('二次判决成功'); window.location='Default.aspx';</script>");

        }

        protected void DropDownList_ddlResult(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(ddlResult.SelectedValue);
            if (status == -1)
            {
            }
            else if(status==0){
                txtResAmount.Text = "0.00";
            }
            else if (status == 1)
            {
                double money = Convert.ToDouble(lblRegAmount.Text) * Convert.ToDouble(lblReward.Text);
                txtResAmount.Text = money.ToString("F2");
            }
        }

        //public string AcceptUserID(string userId)
        //{
        //    if (userId != "0")
        //    {
        //        QueryParam qp = new QueryParam();
        //        qp.OrderType = 0;
        //        int RecordCount = 0;
        //        qp.Where = " Where [ID]=" + userId;
        //        List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
        //        return lst[0].UID;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
    }
}