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
using System.Drawing;
using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.DLT.Service.tbLevelOrder
{
    public partial class OrderMessage : System.Web.UI.Page
    {
        public string SerialNo = "";
        public string PostID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["SerialNo"] != null&&Request.QueryString["PostID"]!=null)
                {
                    SerialNo = Request.QueryString["SerialNo"].ToString();
                    PostID = Request.QueryString["PostID"].ToString();
                    BindDataList2();
                }
            }
        }

        public string UIDPost(string UID)
        {
            if (UID == Request.QueryString["PostID"].ToString())
            {
                return UID + "[发单者]";
            }
            else if (UID == "USR201305030006")
            {
                return UID + "[系统]";
            }
            else
            {
                return UID;
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDataList2();
        }


        public string Unicode2Chinese(string strUnicode)
        {
            strUnicode = strUnicode.Replace(@"\", "%");
            return Microsoft.JScript.GlobalObject.unescape(strUnicode);
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView3.Columns[0].ItemStyle.Width = 40;
                GridView3.Columns[1].ItemStyle.Width = 170;
                GridView3.Columns[2].ItemStyle.Width = 170;

                string tmpstr = DataBinder.Eval(e.Row.DataItem, "UID").ToString();
                HiddenField hdMsgType = e.Row.FindControl("hdMsgType") as HiddenField;
                Label lblMsg = e.Row.FindControl("lblMsg") as Label;

                //处理韩文乱码
                lblMsg.Text = Unicode2Chinese(lblMsg.Text);


                if (tmpstr == "USR201305030006")
                {
                    e.Row.Cells[3].ForeColor = Color.MediumVioletRed;
                }


                if (lblMsg.Text.Contains("沟通协商解决，若无法协商达成一致。"))
                {
                    lblMsg.Text = lblMsg.Text.Replace("，若无法协商达成一致。您可以在订单进入“撤销中”状态的5小时后申请客服介入（怎么申请客服介入,请在此了解：http://help.dailiantong.com/contents/22/68.html）", "");
                }


                if (hdMsgType.Value == "10")
                {
                    lblMsg.Text = "<font style=\"color:#760000\">【系统】：</font>" + lblMsg.Text;
                }

                //string tmpType = DataBinder.Eval(e.Row.DataItem, "MsgType").ToString();

                string tmpMsg=DataBinder.Eval(e.Row.DataItem, "Msg").ToString();

                if (lblMsg.Text.IndexOf("温馨提示：") > 0 && lblMsg.Text.IndexOf("撤销原因：") > 0)
                {
                    lblMsg.Text = lblMsg.Text.Insert(lblMsg.Text.IndexOf("撤销原因："), "<br />");
                }

                //if (tmpType == "10")
                //{
                //    if (tmpMsg != "执行启动游戏" || tmpMsg.IndexOf("请接手者1个小时内上传原始截图") == -1)
                //    {
                //        e.Row.Cells[3].Font.Bold = true;
                //    }
                //}
            }


        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            QueryParam qp = new QueryParam();
            qp.Where = " and a.ODSerialNo = '" + Request.QueryString["SerialNo"].ToString() + "'";
            qp.PageIndex = 1;
            qp.PageSize = 10;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.LevelOrderMessage(qp.PageIndex, qp.PageSize, qp.Where);
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;
        }

        /// <summary>
        /// 交互留言
        /// </summary>
        private void BindDataList2()
        {
            QueryParam qp = new QueryParam();
            qp.Where = " and a.ODSerialNo = '" + Request.QueryString["SerialNo"].ToString() + "'";
            qp.PageIndex = AspNetPager2.CurrentPageIndex;
            qp.PageSize = 10;
            int RecordCount = 0;
            DataSet ds = BusinessFacadeDLT.LevelOrderMessage(qp.PageIndex, qp.PageSize, qp.Where);
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
            RecordCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager2.RecordCount = RecordCount;

        }
    }
}
