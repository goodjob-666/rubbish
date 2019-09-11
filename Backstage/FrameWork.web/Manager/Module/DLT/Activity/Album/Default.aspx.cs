/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            用户成员列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
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
using System.Text;

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;

namespace DLT.Web.Module.DLT.Activity.Album
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
                AlbumTypeList();
            }
        }

        private void AlbumTypeList()
        {
            List<tbSubjectEntity> lst;
            if (ViewState["AlbumTypeList"] != null)
            {
                lst = ViewState["AlbumTypeList"] as List<tbSubjectEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbSubjectList(qp, out RecordCount, null);
                ViewState["AlbumTypeList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbSubjectEntity var in lst)
                {
                    ddlAlbumType.Items.Add(new ListItem(var.Name, var.ID.ToString()));
                }
            }
        }

        private string AlbumTypeList(int id)
        {
            string str = "";
            List<tbSubjectEntity> lst;
            if (ViewState["AlbumTypeList"] != null)
            {
                lst = ViewState["AlbumTypeList"] as List<tbSubjectEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                qp.Orderfld = "ID";
                qp.OrderType = 0;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbSubjectList(qp, out RecordCount, null);
                ViewState["AlbumTypeList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbSubjectEntity item in lst)
                {
                    if (item.ID == id)
                    {
                        str = item.Name;
                        break;
                    }
                }
            }
            return str;
        }

        public string Substr(string url)
        {
            int index=url.IndexOf("/Upload1");
            string str = url;
            if (index != -1) {
               str= str.Substring(index);
            }
            return str;
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
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<tbAlbumEntity> lst = BusinessFacadeDLT.tbAlbumList(qp, out RecordCount, null);
            GridView1.DataSource = lst;
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
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Kind_Value = (string)Common.sink(txtKind.UniqueID, MethodType.Post, 100, 0, DataType.Str);

            string AlbumType_Value = (string)Common.sink(ddlAlbumType.UniqueID, MethodType.Post, 4, 0, DataType.Str);
           
            
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (Kind_Value != string.Empty)
            {
                sb.AppendFormat(" AND AlbumName like '%{0}%' ", Common.inSQL(Kind_Value));
            }

            if (AlbumType_Value != string.Empty) {
                sb.AppendFormat(" AND AlbumType = '{0}' ", AlbumType_Value);
            }

            if (chkIsHot.Checked) {
                sb.AppendFormat(" AND IsHot = 1 ");
            }

            if (chkIsNew.Checked)
            {
                sb.AppendFormat(" AND IsNew = 1 ");
            }

            if (chkIsEnable.Checked)
            {
                sb.AppendFormat(" AND [Enable] = 1 ");
            }

           
            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
        }


       

        #region "排序"
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Orderfld == e.SortExpression)
            {
                if (OrderType == 0)
                {
                    OrderType = 1;
                }
                else
                {
                    OrderType = 0;
                }
            }
            Orderfld = e.SortExpression;
            BindDataList();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label1 = e.Row.FindControl("lblAlbumType") as Label;
                int id = Convert.ToInt32(label1.Text);
                label1.Text = AlbumTypeList(id);
            }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "ID";

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
        
        #endregion

    }
}
