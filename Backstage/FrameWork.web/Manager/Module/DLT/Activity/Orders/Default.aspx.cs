using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLT;
using DLT.Data;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;



namespace DLT.Web.Module.DLT.Activity.Orders
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                S_dtDate_Input.Text = (DateTime.Now.AddDays(-6)).Date.ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                BindDifficultyList();

                string UserID = Request.QueryString["UserID"];
                if (!string.IsNullOrEmpty(UserID)) {
                    ViewState["UserID"] = UserID;
                    Button1_Click(null, null);
                }
            }
        }

        private void BindDifficultyList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            qp.Where = " where 1=1 ";
            int RecordCount = 0;

            List<tbDifficultyEntity> lst = BusinessFacadeDLT.tbDifficultytList(qp, out RecordCount);
            foreach (tbDifficultyEntity var in lst)
            {
                dllDifficultyLevel.Items.Add(new ListItem(var.DifficultyName, var.ID.ToString()));
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindDataList();//绑定 
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindDataList();//绑定 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label label1 = GridView1.Rows[e.RowIndex].FindControl("lblSeriaNo") as Label;
            string SeriaNo = label1.Text;
            DropDownList ddlSubject = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSubject");

            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@SubjectType",ddlSubject.SelectedValue),
                    new SqlParameter("@SeriaNo",SeriaNo)
                };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MsSql"], CommandType.Text,
                    "update [dbo].[tbLevelOrder] set SubjectType =@SubjectType where SeriaNo = @SeriaNo", pms);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView1.EditIndex = -1;
            BindDataList();//绑定数据
        }

        private List<tbSubjectEntity> BindSubjectList()
        {
            List<tbSubjectEntity> lst;
            if (ViewState["SubjectList"] != null)
            {
                lst = ViewState["SubjectList"] as List<tbSubjectEntity>;
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
                ViewState["SubjectList"] = lst;
            }

            return lst;
        }

        public string HaveSubUser(string havesubuser)
        {
            if (havesubuser == "True")
            {
                return "启用";
            }
            else
            {
                return "禁用";
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
                    ViewState["SearchTerms"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms"];
            }
            set { ViewState["SearchTerms"] = value; }
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

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string S_Date = (string)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);   //开始时间
            string E_Date = (string)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);   //结束时间

            string SeriaNo_Value = (string)Common.sink(SeriaNo_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);    //订单编号
            string NickName_Value = (string)Common.sink(NickName_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string Difficulty_Value = (string)Common.sink(dllDifficultyLevel.UniqueID, MethodType.Post, 5, 0, DataType.Str);

            string ID_Value = (string)Common.sink(ID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            
            StringBuilder sb = new StringBuilder();

            sb.Append(" Where 1=1 ");

            string UserID = ViewState["UserID"] == null ? "" : ViewState["UserID"].ToString();
            if (UserID != "")
            {
                sb.AppendFormat(" AND UserID ={0} ", UserID);
            }

            if (ID_Value != string.Empty)
            {
                sb.AppendFormat(" AND ID = {0} ", ID_Value);
            }

            if (NickName_Value != string.Empty)
            {
                sb.AppendFormat(" AND Nickname = '{0}' ", Common.Base64Encode(Common.inSQL(NickName_Value.Trim().Replace("'", "''"))));
            }

            if (SeriaNo_Value != string.Empty)
            {
                sb.AppendFormat(" AND SeriaNo = '{0}' ", Common.inSQL(SeriaNo_Value));
            }

            if (Difficulty_Value != string.Empty)
            {
                sb.AppendFormat(" AND Level = {0} ", Convert.ToInt32(Difficulty_Value));
            }

            if (S_Date != string.Empty)
            {
                sb.AppendFormat(" AND CreateDate >= '{0}' ", S_Date + " 00:00:00");
            }

            if (E_Date != string.Empty)
            {
                sb.AppendFormat(" AND CreateDate <= '{0}' ", E_Date + " 23:59:59");
            }

            ViewState["SearchTerms"] = sb.ToString();
            BindDataList();
            TabOptionWebControls1.SelectIndex = 0;
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

            DataSet ds = BusinessFacadeDLT.OrderList(qp);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);

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

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                if (ViewState["sortOrderfld"] == null)

                    ViewState["sortOrderfld"] = "CreateDate";

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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == GridView1.EditIndex)
                {
                    DropDownList ddlSubject = (DropDownList)e.Row.FindControl("ddlSubject");
                    List<tbSubjectEntity> lst = BindSubjectList();
                    if (lst != null)
                    {
                        foreach (tbSubjectEntity var in lst)
                        {
                            ddlSubject.Items.Add(new ListItem(var.Name, var.ID.ToString()));
                        }
                    }
                }
            }
        }
    }
}