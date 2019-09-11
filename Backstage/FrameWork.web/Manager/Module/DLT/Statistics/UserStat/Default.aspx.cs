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
using System.Data.SqlClient;
using System.Drawing;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using dotnetCHARTING;

namespace DLT.Web.Module.DLT.UserStat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-3)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //BindDataList();
                UserOnline();
                DivTotalDisplay();
            }
        }

        private void DivTotalDisplay()
        {
            if (FrameWorkPermission.CheckButtonPermission(PopedomType.Orderby))
            {
                divTotal.Visible = true;
            }
            else
            {
                divTotal.Visible = false;
            }
        }

        private void UserOnline()
        {
            DataTable dt = BusinessFacadeDLT.UserOnline().Tables[0];

            lblOnline.Text = dt.Rows[0][0].ToString();
            lblCZCount.Text = dt.Rows[1][0].ToString();
            lblAll.Text = dt.Rows[2][0].ToString();
            Label1.Text = dt.Rows[3][0].ToString();
            Label2.Text = dt.Rows[4][0].ToString();
            Label3.Text = dt.Rows[7][0].ToString();
            Label4.Text = dt.Rows[6][0].ToString();
            Label5.Text = dt.Rows[5][0].ToString();
        }

        private void BindDataList()
        {
            DataSet ds = BusinessFacadeDLT.UserStat(DateTime.Parse(S_dtDate_Input.Text + " 00:00:00"), DateTime.Parse(E_dtDate_Input.Text + " 23:59:59"));
            GridView2.DataSource = ds;
            GridView2.DataBind();

            /*
            Charting c = new Charting();

            c.Title = "用户情况统计";
            c.XTitle = "日期";
            c.YTitle = "人数";
            c.PicHight = 400;
            c.PicWidth = 1024;
            c.SeriesName = "合计";//仅对于DataTable类型做数据源时，此属性有效
            c.PhaysicalImagePath = "/ChartImages";//统计图片存放的文件夹名称，缺少对应的文件夹生成不了统计图片
            c.FileName = "UserStat";
            c.Type = SeriesType.Spline;
            c.Use3D = false;

            SeriesCollection SC = new SeriesCollection();
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;
            dv.Sort = "StatDate ASC";
            dt = dv.ToTable();


            // 生成对比图
            for (int i = 0; i < dt.Columns.Count; i++) //对比的项数，如2008年各月的公交和地铁载客量数据对比就相当于有两个数据项
            {
                Series s = new Series();
                switch (dt.Columns[i].ToString())
                {
                    case "RegCount":
                        s.Name = "注册用户数量";
                        for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
                        {
                            Element e = new Element();
                            e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
                            if (dt.Rows[j]["RegCount"].ToString() == "")
                            {
                                e.YValue = 0;
                            }
                            else
                            {
                                e.YValue = double.Parse(dt.Rows[j]["RegCount"].ToString());//与X轴对应的Y轴的数值
                            }
                            s.Elements.Add(e);
                        }
                        SC.Add(s);
                        break;
                    case "RegReCount":
                        s.Name = "注册用户充值数量";
                        for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
                        {
                            Element e = new Element();
                            e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
                            if (dt.Rows[j]["RegReCount"].ToString() == "")
                            {
                                e.YValue = 0;
                            }
                            else
                            {
                                e.YValue = double.Parse(dt.Rows[j]["RegReCount"].ToString());//与X轴对应的Y轴的数值
                            }
                            s.Elements.Add(e);
                        }
                        SC.Add(s);
                        break;
                    case "LoginCount":
                        s.Name = "登录用户数量";
                        for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
                        {
                            Element e = new Element();
                            e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
                            if (dt.Rows[j]["LoginCount"].ToString() == "")
                            {
                                e.YValue = 0;
                            }
                            else
                            {
                                e.YValue = double.Parse(dt.Rows[j]["LoginCount"].ToString());//与X轴对应的Y轴的数值
                            }
                            s.Elements.Add(e);
                        }
                        SC.Add(s);
                        break;
                    case "PubCount":
                        s.Name = "发单用户数量";
                        for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
                        {
                            Element e = new Element();
                            e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
                            if (dt.Rows[j]["PubCount"].ToString() == "")
                            {
                                e.YValue = 0;
                            }
                            else
                            {
                                e.YValue = double.Parse(dt.Rows[j]["PubCount"].ToString());//与X轴对应的Y轴的数值
                            }
                            s.Elements.Add(e);
                        }
                        SC.Add(s);
                        break;
                    case "Acccount":
                        s.Name = "接单用户数量";
                        for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
                        {
                            Element e = new Element();
                            e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
                            if (dt.Rows[j]["AccCount"].ToString() == "")
                            {
                                e.YValue = 0;
                            }
                            else
                            {
                                e.YValue = double.Parse(dt.Rows[j]["AccCount"].ToString());//与X轴对应的Y轴的数值
                            }
                            s.Elements.Add(e);
                        }
                        SC.Add(s);
                        break;

                    default:
                        break;
                }
                
            }
                
            //}

            //可自定义填充图的填充色，系统采取默认分配各数据项的填充色
            SC[0].DefaultElement.Color = Color.Blue;
            SC[1].DefaultElement.Color = Color.Red;
            SC[2].DefaultElement.Color = Color.Black;
            SC[3].DefaultElement.Color = Color.Purple;
            SC[4].DefaultElement.Color = Color.YellowGreen;

            c.DataSource = SC;
            c.CreateStatisticPic(this.Chart1);
            */

        }

        public string StatDate(string statdate)
        {
            if (statdate == "1900-00-00")
            {
                return "合计";
            }
            else
            {
                return statdate;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }
    }
}
