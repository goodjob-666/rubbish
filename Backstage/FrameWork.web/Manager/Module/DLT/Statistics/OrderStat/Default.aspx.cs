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

using dotnetCHARTING;
using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.FinanceAccount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGameList();
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-7)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //BindDataList();
            }
        }

        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            //qp.Where = " Where [Key]=1013";
            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {
                ddlGame.Items.Add(new ListItem(var.Game.ToString(), var.ID.ToString()));
            }
        }
        
        private void BindDataList()
        {
            int IsGood = cbGood.Checked ? 1 : -1;
            //DataSet ds = BusinessFacadeDLT.AllstatisticsMore(ddlGame.SelectedValue, DateTime.Parse(S_dtDate_Input.Text + " 00:00:00"), DateTime.Parse(E_dtDate_Input.Text + " 23:59:59"), IsGood);
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.AppSettings["MSSql"], "BM_AllstatisticsMore", ddlGame.SelectedValue, IsGood, DateTime.Parse(S_dtDate_Input.Text + " 00:00:00"), DateTime.Parse(E_dtDate_Input.Text + " 23:59:59"));
            GridView2.DataSource = ds;
            GridView2.DataBind();

            //Charting c = new Charting();
            //Charting c1 = new Charting();

            //c.Title = "订单数量统计";
            //c.XTitle = "日期";
            //c.YTitle = "订单数";
            //c.PicHight = 400;
            //c.PicWidth = 1024;
            //c.SeriesName = "合计";//仅对于DataTable类型做数据源时，此属性有效
            //c.PhaysicalImagePath = "/ChartImages";//统计图片存放的文件夹名称，缺少对应的文件夹生成不了统计图片
            //c.FileName = "OrderStat_Order";
            //c.Type = SeriesType.Spline;
            //c.Use3D = false;

            //c1.Title = "订单金额统计";
            //c1.XTitle = "日期";
            //c1.YTitle = "金额";
            //c1.PicHight = 400;
            //c1.PicWidth = 1024;
            //c1.SeriesName = "合计";//仅对于DataTable类型做数据源时，此属性有效
            //c1.PhaysicalImagePath = "/ChartImages";//统计图片存放的文件夹名称，缺少对应的文件夹生成不了统计图片
            //c1.FileName = "OrderStat_Money";
            //c1.Type = SeriesType.Spline;
            //c1.Use3D = false;

            //SeriesCollection SC = new SeriesCollection();
            //SeriesCollection SC1 = new SeriesCollection();
            //DataTable dt = ds.Tables[0];
            //DataView dv = dt.DefaultView;
            //dv.Sort = "StatDate ASC";
            //dt = dv.ToTable();


            //// 生成对比图
            //for (int i = 0; i < dt.Columns.Count; i++) //对比的项数，如2008年各月的公交和地铁载客量数据对比就相当于有两个数据项
            //{
            //    Series s = new Series();
            //    switch (dt.Columns[i].ToString())
            //    {
            //        case "PubStatCount":
            //            s.Name = "发布笔数";
            //            for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
            //            {
            //                Element e = new Element();
            //                e.SecondaryColor = Color.White;
            //                e.HatchColor = Color.White;
            //                e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
            //                if (dt.Rows[j]["PubStatCount"].ToString() == "")
            //                {
            //                    e.YValue = 0;
            //                }
            //                else
            //                {
            //                    e.YValue = double.Parse(dt.Rows[j]["PubStatCount"].ToString());//与X轴对应的Y轴的数值
            //                }
            //                s.Elements.Add(e);
            //            }
            //            SC.Add(s);
            //            break;
            //        case "PubStatBal":
            //            s.Name = "发布金额";
            //            for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
            //            {
            //                Element e = new Element();
            //                e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
            //                if (dt.Rows[j]["PubStatBal"].ToString() == "")
            //                {
            //                    e.YValue = 0;
            //                }
            //                else
            //                {
            //                    e.YValue = double.Parse(dt.Rows[j]["PubStatBal"].ToString());//与X轴对应的Y轴的数值
            //                }
            //                s.Elements.Add(e);
            //            }
            //            SC1.Add(s);
            //            break;
            //        case "AccStatCount":
            //            s.Name = "接手笔数";
            //            for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
            //            {
            //                Element e = new Element();
            //                e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
            //                if (dt.Rows[j]["AccStatCount"].ToString() == "")
            //                {
            //                    e.YValue = 0;
            //                }
            //                else
            //                {
            //                    e.YValue = double.Parse(dt.Rows[j]["AccStatCount"].ToString());//与X轴对应的Y轴的数值
            //                }
            //                s.Elements.Add(e);
            //            }
            //            SC.Add(s);
            //            break;
            //        case "AccStatBal":
            //            s.Name = "接手金额";
            //            for (int j = 1; j < dt.Rows.Count; j++) //X轴尺度个数，如12个月表示有12个尺度数
            //            {
            //                Element e = new Element();
            //                e.Name = dt.Rows[j]["StatDate"].ToString();//对应于X轴个尺度的名称
            //                if (dt.Rows[j]["AccStatBal"].ToString() == "")
            //                {
            //                    e.YValue = 0;
            //                }
            //                else
            //                {
            //                    e.YValue = double.Parse(dt.Rows[j]["AccStatBal"].ToString());//与X轴对应的Y轴的数值
            //                }
            //                s.Elements.Add(e);
            //            }
            //            SC1.Add(s);
            //            break;

            //        default:
            //            break;
            //    }

            //}

            ////}


            ////可自定义填充图的填充色，系统采取默认分配各数据项的填充色
            //SC[0].DefaultElement.Color = Color.White;
            //SC[1].DefaultElement.Color = Color.Red;
            //SC1[0].DefaultElement.Color = Color.Black;
            //SC1[1].DefaultElement.Color = Color.Purple;

            //c.DataSource = SC;
            //c.CreateStatisticPic(this.Chart1);

            //c1.DataSource = SC1;
            //c1.CreateStatisticPic(this.Chart2);
        }

        public string StatDate(string statdate)
        {
            if (statdate == "1900-01-01")
            {
                return "合计";
            }
            else
            {
                return statdate;
            }
        }

        public string SaveTwoDec(string money)
        {
            if (money != "")
            {
                return Convert.ToDouble(money).ToString("0.00");
            }
            else
            {
                return "";
            }
        }

        public string ShowFee(string money)
        {
            if ((ddlGame.SelectedValue == "107") && (money != ""))
            {
                return "(手续费:" + Convert.ToDouble(money).ToString("0.00") + ")";
            }
            else 
            {
                return "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDataList();
        }
    }
}
