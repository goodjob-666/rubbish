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

namespace FrameWork.web.Manager.Module.DaiLianTong.BizManager.Order
{
    public partial class OrderProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        public string Source(string Source)
        {
            if (Source == "11")
            {
                return "<div style=\"text-align:center;color:Red;\"><span>";
            }
            else if (Source == "10")
            {
                return "<div style=\"text-align:center;color:Blue;\"><span>";
            }
            else
            {
                return "<div style=\"text-align:center;color:#607b00; font-weight:bold;\"><span>";
            }
        }

        private void OnStart()
        {
            string SerialNo = Request.QueryString["SerialNo"].ToString();
            Repeater1.DataSource = BusinessFacadeDLT.GetOrderProgress(SerialNo);
            Repeater1.DataBind();
            //string tmpstr = "";
            //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["Source"].ToString() == "11")
            //    {
            //        tmpstr += "<div style=\"text-align:center;color:Red;\"><span>";
            //    }
            //    else if (ds.Tables[0].Rows[i]["Source"].ToString() == "10")
            //    {
            //        tmpstr += "<div style=\"text-align:center;color:Blue;\"><span>";
            //    }
            //    else
            //    {
            //        tmpstr += "<div style=\"text-align:center;color:#607b00; font-weight:bold;\"><span>";
            //    }
            //    tmpstr += "第 " + (i + 1).ToString() + " 张： " + ds.Tables[0].Rows[i]["Comment"].ToString() + "     " + ds.Tables[0].Rows[i]["CreateDate"].ToString() + "      [" + ds.Tables[0].Rows[i]["Fromer"].ToString() + "]</span>" +"      "+"</div>";
            //    tmpstr += "<br />";
            //    tmpstr += "<div style=\"text-align:center\"><a href='" + ds.Tables[0].Rows[i]["Img"].ToString() + "'><img src='" + ds.Tables[0].Rows[i]["Img"].ToString() + "' width=\"800px\" height=\"600px\"/></a></div>";
            //    tmpstr += "<br />\n<hr />";

            //}
            //divpic.InnerHtml = tmpstr;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                BusinessFacadeDLT.DeleteLevelOrderProgress(int.Parse(e.CommandArgument.ToString()));
                Response.Write("<script language='javascript'>alert('客服图片删除成功!');</script>");
                OnStart();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hf = e.Item.FindControl("hf") as HiddenField;
                Button btn = e.Item.FindControl("btnDelete") as Button;

                if (hf.Value == "12")
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
        }

    }
}
