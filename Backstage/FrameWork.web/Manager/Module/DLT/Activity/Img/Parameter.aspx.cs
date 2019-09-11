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
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.Activity.Img
{
    public partial class Parameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int imgId = int.Parse(Request.QueryString["ID"]);
                BindDataList();

                LinkButton1.PostBackUrl = "Manager1.aspx?CMD=New&Type=String&ImgID=" + imgId;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataList()
        {
            int imgId = int.Parse(Request.QueryString["ID"]);
            string where = "where ImgID=" + imgId;
            DataTable dt = BusinessFacadeDLT.tbFieldsList(where);
            if (dt != null && dt.Rows.Count > 0) {
                Label1.Text = "图片名称：" + dt.Rows[0]["ImageName"].ToString();
            }
            
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string type = DataBinder.Eval(e.Row.DataItem, "Type").ToString();
                string d = DataBinder.Eval(e.Row.DataItem, "Default").ToString();
                int random = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsRandom"));

                Label label4 = e.Row.FindControl("Label4") as Label;
                Label label2 = e.Row.FindControl("Label2") as Label;
                Image image1 = e.Row.FindControl("Image1") as Image;
                if (type == "Image") {
                   
                    image1.ImageUrl = d;
                    label4.Visible = false;
                }
                else
                {
                    label4.Text = d;
                    image1.Visible = false;
                }

                if (random == 0)
                {
                    label2.Text = "否";
                }
                else
                {
                    label2.Text = "是";
                }
            }
        }
    }
}
