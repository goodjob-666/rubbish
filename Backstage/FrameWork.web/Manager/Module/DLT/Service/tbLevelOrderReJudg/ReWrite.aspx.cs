using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.DLT.Service.tbLevelOrderReJudg
{
    public partial class ReWrite : System.Web.UI.Page
    {
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            //DataSet ds = BusinessFacadeDLT.GetWithdrawDeposit(Request.QueryString["ID"].ToString(), UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName);

                QueryParam qp = new QueryParam();
                qp.OrderType = 0;
                int RecordCount = 0;
                qp.Where = " Where [ID]=" + Request.QueryString["ID"].ToString();
                List <tbLevelOrderReJudgEntity> lst = BusinessFacadeDLT.tbLevelOrderReJudgList(qp, out RecordCount);
                lblCustomerID.Text = UserData.Get_sys_UserTable(lst[0].CustomerID).U_LoginName;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (txtJudgReason.Text == "")
            //{
            //    Response.Write("<script language='javascript'>alert('判决理由不能为空！');</script>");
            //    return;
            //}
            string id = Request.QueryString["ID"].ToString();

            tbLevelOrderReJudgEntity ut = BusinessFacadeDLT.tbLevelOrderReJudgDisp(int.Parse(id));

            string reason = "后台仲裁处理,发单者支付代练费：" + float.Parse(tbInCome.Text.Trim()).ToString() + "元，接单者赔偿保证金：" + float.Parse(tbPayout.Text.Trim()).ToString() + "元。<br />";
            reason += "[后台客服] " + txtJudgReason.Text;

            ut.Reason = reason;

            ut.DataTable_Action_ = DataTable_Action.Update;

            Int32 rInt = BusinessFacadeDLT.tbLevelOrderReJudgInsertUpdateDelete(ut);

            if (rInt > 0)
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='修改订单重判分析数据成功！';window.parent.hidePopWin(true);</script>");
            }
        }

        private void ClosePop()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.parent.hidePopWin(false);</script>");
        }

        protected void BtClose_Click(object sender, EventArgs e)
        {
            ClosePop();
        }
    }
}
