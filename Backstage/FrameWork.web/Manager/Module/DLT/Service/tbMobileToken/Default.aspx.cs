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
using System.Text;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.tbMobileToken
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.GetTokenMobile(qp.PageIndex, qp.PageSize,qp.Where);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public string IsVerify(string isverify)
        {
            if (isverify == "1")
            {
                return "已验证";
            }
            else
            {
                return "未验证";
            }
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
                    ViewState["SearchTerms"] = " ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 20, 0, DataType.Str);
            string SerialNo_Value = (string)Common.sink(SerialNo_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string Mobile_Value = (string)Common.sink(Mobile_Input.UniqueID, MethodType.Post, 50, 0, DataType.Str);
            string VerifyCode_Value = (string)Common.sink(VerifyCode_Input.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            string IsVerify_Value = (string)Common.sink(ddlIsVerify.UniqueID, MethodType.Post, 100, 0, DataType.Str);
            DateTime? S_dtDate_Input_Value = (DateTime?)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            DateTime? E_dtDate_Input_Value = (DateTime?)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 255, 0, DataType.Dat);
            StringBuilder sb = new StringBuilder();

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND B.UID = '{0}' ", Common.inSQL(UserID_Value));
            }

            if (SerialNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND SerialNo = '{0}' ", Common.inSQL(SerialNo_Value));
            }

            if (Mobile_Value != string.Empty)
            {
                sb.AppendFormat(" AND Mobile like '%{0}%' ", Common.inSQL(Mobile_Value));
            }

            if (VerifyCode_Value != string.Empty)
            {
                sb.AppendFormat(" AND VerifyCode like '%{0}%' ", Common.inSQL(VerifyCode_Value));
            }

            if (IsVerify_Value != string.Empty)
            {
                sb.AppendFormat(" AND IsVerify = {0} ", Common.inSQL(IsVerify_Value));
            }

            if (S_dtDate_Input_Value.HasValue && E_dtDate_Input_Value.HasValue)
            {
                if (Common.GetDBType == "Access")
                    sb.AppendFormat(string.Format(" and a.CreateDate between #{0} 00:00:00# and #{1} 23:59:59# ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else if (Common.GetDBType == "Oracle")
                    sb.AppendFormat(string.Format(" and a.CreateDate between to_date('{0} 00:00:00','yyyy-mm-dd HH24:MI:SS') and to_date('{1} 23:59:59','yyyy-mm-dd HH24:MI:SS') ", S_dtDate_Input_Value.Value.Date.ToShortDateString(), E_dtDate_Input_Value.Value.Date.ToShortDateString()));
                else
                    sb.AppendFormat(string.Format(" and a.CreateDate between '{0} 00:00:00' and '{1} 23:59:59' ", S_dtDate_Input_Value.Value.Date.ToString("yyyy-MM-dd"), E_dtDate_Input_Value.Value.Date.ToString("yyyy-MM-dd")));
            }
            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }
        
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            BindDataList();
        }
    }
}
