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

namespace FrameWork.web
{
    public partial class WithDraw : System.Web.UI.Page
    {
        protected string BankAcc;
        protected string BankName;
        protected string RealBal;

        [PopedomTypeAttaible(PopedomType.A)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                OnStart();
                Button2.Attributes.Add("onclick", "return   confirm('您确定要撤销提现吗？')");
            }
        }

        public string BankType(string banktype)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1003 and Kind=" + banktype;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        private void OnStart()
        {
            DataSet ds = BusinessFacadeDLT.GetWithdrawDeposit(Request.QueryString["SerialNo"].ToString(), UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName);
            U_SerialNo_Txt.Text = Request.QueryString["SerialNo"].ToString();
            U_UID_Txt.Text = ds.Tables[0].Rows[0]["UID"].ToString();
            if (ds.Tables[0].Rows[0]["LoginID"].ToString() == "")
            {
                Button3.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
            }
            else
            {
                Button3.Visible = false;
                Button1.Visible = true;
                Button2.Visible = true;
            }
            U_LoginID_Txt.Text = ds.Tables[0].Rows[0]["LoginID"].ToString();
            if (ds.Tables[0].Rows[0]["BankID"].ToString() == "")
            {
                U_BankID_Txt.Text = "";
            }
            else
            {
                U_BankID_Txt.Text = BankType(ds.Tables[0].Rows[0]["BankID"].ToString());
            }
            U_BankAcc_Txt.Text = BankAcc = ds.Tables[0].Rows[0]["BankAcc"].ToString();
            U_BankUser_Txt.Text = BankName = ds.Tables[0].Rows[0]["BankUser"].ToString();
            U_Fee_Txt.Text = ds.Tables[0].Rows[0]["Fee"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["Fee"].ToString();
            U_Payout_Txt.Text = ds.Tables[0].Rows[0]["Bal"].ToString();
            tbRealPay.Text = RealBal = (float.Parse(U_Payout_Txt.Text) - float.Parse(U_Fee_Txt.Text)).ToString();
            U_BankSerialNo_Txt.Text = ds.Tables[0].Rows[0]["BankSerialNo"].ToString();
            U_Comment_Txt.Text = ds.Tables[0].Rows[0]["Comment"].ToString();
            if (ds.Tables[0].Rows[0]["Status"].ToString() != "10")
            {
                Button1.Visible = false;
                Button2.Visible = false;
            }
        }

        /// <summary>
        /// 确认提现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "确认提现")
            {
                string DispTxt = "";
                if (Common.Get_UserID != 0)
                {
                    if (U_BankSerialNo_Txt.Text != "")
                    {
                        string U_SerialNo_Txt_Value = U_SerialNo_Txt.Text;
                        string RealPay_Value = (string)Common.sink(tbRealPay.UniqueID, MethodType.Post, 20, 0, DataType.Str);
                        string U_Fee_Txt_Value = U_Fee_Txt.Text;
                        string U_BankSerialNo_Txt_Value = (string)Common.sink(U_BankSerialNo_Txt.UniqueID, MethodType.Post, 40, 0, DataType.Str);
                        string U_Comment_Txt_Value = (string)Common.sink(U_Comment_Txt.UniqueID, MethodType.Post, 50, 0, DataType.Str);
                        string RT = BusinessFacadeDLT.WithdrawSuccess(U_SerialNo_Txt_Value, U_BankSerialNo_Txt_Value, U_Comment_Txt_Value, Common.Get_UserID);
                        if (RT == "1")
                        {
                            string titleMessage = "确认提现操作-流水号：" + U_SerialNo_Txt_Value + "，实际金额：" + RealPay_Value.ToString();
                            EventMessage.EventWriteDB(1, titleMessage);
                            ClientScriptManager cs = Page.ClientScript;
                            cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='确认提现成功！';window.parent.hidePopWin(true);</script>");
                        }
                    }
                    else
                    {
                        DispTxt = "银行流水号不能为空！";
                        Common.MessBox(DispTxt);
                    }
                }
            }
            ClosePop();
        }

        /// <summary>
        /// 撤销提现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Common.Get_UserID != 0)
            {
                string U_WalletID_Txt_Value = U_SerialNo_Txt.Text;
                string U_Comment_Txt_Value = (string)Common.sink(U_Comment_Txt.UniqueID, MethodType.Post, 20, 0, DataType.Str);
                string RT = BusinessFacadeDLT.WithdrawCancel(U_SerialNo_Txt.Text, U_Comment_Txt_Value, Common.Get_UserID);
                if (RT == "1")
                {
                    string titleMessage = "撤销提现操作-流水号：" + U_WalletID_Txt_Value;
                    EventMessage.EventWriteDB(1, titleMessage);
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='撤销提现成功！';window.parent.hidePopWin(true);</script>");
                }
            }
            ClosePop();
        }

        private void ClosePop()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClosePop();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //解锁
            DataSet ds = BusinessFacadeDLT.LockWithDraw(Request.QueryString["SerialNo"].ToString(), 0,UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName);
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                string titleMessage = ds.Tables[0].Rows[0][1].ToString() + "：解锁人：" + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                EventMessage.EventWriteDB(1, titleMessage);
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='解锁成功！';window.parent.hidePopWin(true);</script>");
            }
            else
            {
                string titleMessage = ds.Tables[0].Rows[0][1].ToString() + "：解锁人：" + UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName;
                EventMessage.EventWriteDB(1, titleMessage);
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='解锁失败！';window.parent.hidePopWin(true);</script>");
            }
            ClosePop();
        }

    }
}
