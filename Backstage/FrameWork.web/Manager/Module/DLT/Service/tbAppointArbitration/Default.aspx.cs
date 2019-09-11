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

namespace DLT.Web.Module.DLT.tbAppointArbitration
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataList();
                BindRuleOut();
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
            qp.Orderfld = Orderfld;
            qp.OrderType = OrderType;
            int RecordCount = 0;
            List<tbAppointArbitrationEntity> lst = BusinessFacadeDLT.tbAppointArbitrationList(qp, out RecordCount);
            GridView1.DataSource = lst;
            GridView1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        private void BindRuleOut()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where ID = 1030";

            List<tsSysParamEntity> lst = BusinessFacadeDLT.tsSysParamList(qp, out RecordCount);
            TextBox3.Text = lst[0].Value;
        }

        public string DealCustomerID(string OPID)
        {
            if (OPID != "0")
            {
                return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
            }
            else
            {
                return "";
            }
        }

        public string GetUIDByID(string ID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [ID]='" + ID + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                return lst[0].UID.ToString();
            }
            else
            {
                return "-1";
            }
        }

        public string UserIDList(string userList)
        {
            if (userList.IndexOf(',') > 0)
            {
                string s = "";
                string[] arr = userList.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    s += GetUIDByID(arr[i].ToString()) + ",";
                }
                return s.Substring(0, s.Length - 1);
            }
            else
            {
                return GetUIDByID(userList);
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

        public string GetOpLoginID(string customerid)
        {
            if (customerid != "0")
            {
                return UserData.Get_sys_UserTable(int.Parse(customerid)).U_LoginName;
            }
            else
            {
                return "";
            }
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
            string CustomerID_Value = (string)Common.sink(CustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            string UserID_Value = (string)Common.sink(UserID_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);

            string Comment_Value = (string)Common.sink(Comment_Input.UniqueID, MethodType.Post, 1024, 0, DataType.Str);
            string OpCustomerID_Value = (string)Common.sink(OpCustomerID_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);
            StringBuilder sb = new StringBuilder();
            sb.Append(" Where 1=1 ");

            if (CustomerID_Value != string.Empty)
            {
                sb.AppendFormat(" AND CustomerID = {0} ", Convert.ToInt32(CustomerID_Value));
            }

            if (UserID_Value != string.Empty)
            {
                sb.AppendFormat(" AND UserID like '%{0}%' ", Common.inSQL(UserID_Value));
            }


            if (Comment_Value != string.Empty)
            {
                sb.AppendFormat(" AND Comment like '%{0}%' ", Common.inSQL(Comment_Value));
            }

            if (OpCustomerID_Value != string.Empty)
            {
                sb.AppendFormat(" AND OpCustomerID = {0} ", Convert.ToInt32(OpCustomerID_Value));
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
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            Int32 DataIDX = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    Button2.Visible = true;
                    //增加check列头全选
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = " <input id='CheckboxAll' value='0' type='checkbox' onclick='SelectAll()'/>";
                    e.Row.Cells.AddAt(0, cell);
                }

                foreach (TableCell var in e.Row.Cells)
                {
                    if (var.Controls.Count > 0 && var.Controls[0] is LinkButton)
                    {
                        string Colume = ((LinkButton)var.Controls[0]).CommandArgument;
                        if (Colume == Orderfld)
                        {

                            LinkButton l = (LinkButton)var.Controls[0];
                            l.Text += string.Format("<img src='{0}' border='0'>", (OrderType == 0) ? Page.ResolveUrl("~/Manager/images/sort_asc.gif") : Page.ResolveUrl("~/Manager/images/sort_desc.gif"));
                            //Image Img = new Image();
                            //SortDirection a = GridView1.SortDirection;
                            //Img.ImageUrl = (a == SortDirection.Ascending) ? "i_p_sort_asc.gif" : "i_p_sort_desc.gif";
                            //var.Controls.Add(Img);
                        }
                    }
                }
            }
            else
            {
                if (FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                {
                    //增加行选项
                    DataIDX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ID"));
                    TableCell cell = new TableCell();
                    cell.Width = Unit.Pixel(5);
                    cell.Text = string.Format(" <input name='Checkbox' id='Checkbox' value='{0}' type='checkbox' />", DataIDX);
                    e.Row.Cells.AddAt(0, cell);
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PopedomTypeAttaible(PopedomType.Delete)]
        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "OR")]
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Checkbox_Value = (string)Common.sink("Checkbox", MethodType.Post, 2000, 1, DataType.Str);
            string[] Checkbox_Value_Array = Checkbox_Value.Split(',');
            Int32 IDX = 0;
            for (int i = 0; i < Checkbox_Value_Array.Length; i++)
            {
                if (Int32.TryParse(Checkbox_Value_Array[i], out IDX))
                {
                    tbAppointArbitrationEntity et = new tbAppointArbitrationEntity();


                    tbAppointArbitrationEntity ut = BusinessFacadeDLT.tbAppointArbitrationDisp(IDX);

                    //删除sysparam
                    QueryParam qp = new QueryParam();
                    qp.OrderType = 0;
                    int RecordCount = 0;
                    qp.Where = " Where [ID]<>" + IDX.ToString() + "";

                    List<tbAppointArbitrationEntity> lst = BusinessFacadeDLT.tbAppointArbitrationList(qp, out RecordCount);

                    string[] arr = null;
                    string[] arrUserID = null;

                    ArrayList delList = new ArrayList();


                    if (ut.UserID.IndexOf(',') > 0)
                    {
                        arrUserID = ut.UserID.Split(',');
                    }
                    else
                    {
                        arrUserID = new string[] { ut.UserID.ToString() };
                    }

                    for (int x = 0; x < arrUserID.Length; x++)
                    {
                        delList.Add(arrUserID[x].ToString());
                    }

                    for (int j = 0; j < lst.Count; j++)
                    {
                        if (lst[j].UserID.IndexOf(',') > 0)
                        {
                            arr = lst[j].UserID.Split(',');
                        }
                        else
                        {
                            arr = new string[] { lst[j].UserID.ToString() };
                        }

                        for (int k = 0; k < arr.Length; k++)
                        {
                            if (delList.Contains(arr[k]))
                            {
                                delList.Remove(arr[k]);
                            }
                        }
                    }

                    if (delList.Count > 0)
                    {
                        //有需要删除sysparam，需要获取
                        string s = "";
                        string[] sysParam = null;
                        tsSysParamEntity ut1 = BusinessFacadeDLT.tsSysParamDisp(1027);
                        if (ut1.Value.IndexOf(',') > 0)
                        {
                            sysParam = ut1.Value.Split(',');

                            ArrayList arrSysParam = new ArrayList();

                            for (int z = 0; z < sysParam.Length; z++)
                            {
                                arrSysParam.Add(sysParam[z]);
                            }

                            for (int m = 0; m < delList.Count; m++)
                            {
                                if (arrSysParam.Contains(delList[m]))
                                {
                                    arrSysParam.Remove(delList[m]);
                                }
                            }

                            for (int n = 0; n < arrSysParam.Count; n++)
                            {
                                s += arrSysParam[n].ToString() + ",";
                            }

                            if (s != "")
                            {
                                s = s.Substring(0, s.Length - 1);
                            }

                            tsSysParamEntity ut3 = BusinessFacadeDLT.tsSysParamDisp(1027);
                            ut3.Value = s;
                            ut3.DataTable_Action_ = DataTable_Action.Update;
                            BusinessFacadeDLT.tsSysParamInsertUpdateDelete(ut3);

                        }

                    }

                    et.DataTable_Action_ = DataTable_Action.Delete;
                    et.ID = IDX;
                    BusinessFacadeDLT.tbAppointArbitrationInsertUpdateDelete(et);



                }
            }

            EventMessage.MessageBox(1, "批量删除成功", string.Format("批量删除({0})成功!", Checkbox_Value), Icon_Type.OK, Common.GetHomeBaseUrl("default.aspx"));
        }



        public string IsUIDTrue(string UID)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [UID]='" + UID + "'";

            List<tsUserEntity> lst = BusinessFacadeDLT.tsUserList(qp, out RecordCount);
            if (lst.Count > 0)
            {
                return lst[0].ID.ToString();
            }
            else
            {
                return "-1";
            }
        }

        public string AllAppointArbitration()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where ID = 1027";

            List<tsSysParamEntity> lst = BusinessFacadeDLT.tsSysParamList(qp, out RecordCount);
            return lst[0].Value;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int CustomerID = 0;
            string UserID = "";

            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入客服ID');</script>");
                return;
            }
            else
            {
                if (UserData.Get_sys_UserTable1(TextBox1.Text) != null)
                {
                    CustomerID = UserData.Get_sys_UserTable1(TextBox1.Text).UserID;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('客服ID输入错误！');</script>");
                    return;
                }

            }

            if (TextBox2.Text == "")
            {
                Response.Write("<script language='javascript'>alert('请输入上家ID');</script>");
                return;
            }
            else
            {
                string[] postIDList = TextBox2.Text.Split(',');

                ArrayList arr = new ArrayList();

                for (int i = 0; i < postIDList.Length; i++)
                {
                    if (IsUIDTrue(postIDList[i].ToString()) != "-1")
                    {
                        arr.Add(postIDList[i].ToString());
                        UserID += IsUIDTrue(postIDList[i].ToString()) + ",";
                    }
                }

                //UserID去除最后一个逗号
                UserID = UserID.Substring(0, UserID.Length - 1);
            }

            if (AllAppointArbitration() != "")
            {
                ArrayList arrAll = new ArrayList();
                string[] allUserIDList = AllAppointArbitration().Split(',');
                for (int j = 0; j < allUserIDList.Length; j++)
                {
                    arrAll.Add(allUserIDList[j].ToString());
                }

                string[] idList = UserID.Split(',');

                string tmpStr = "";

                for (int k = 0; k < idList.Length; k++)
                {
                    if (arrAll.Contains(idList[k]))
                    {
                        continue;
                    }
                    else
                    {
                        tmpStr += idList[k].ToString() + ",";
                    }
                }


                if (tmpStr != "")
                {
                    tmpStr = tmpStr.Substring(0, tmpStr.Length - 1);
                    string result = AllAppointArbitration() + "," + tmpStr;

                    //更新result到sysparam
                    tsSysParamEntity ut = BusinessFacadeDLT.tsSysParamDisp(1027);

                    ut.Value = result;
                    ut.DataTable_Action_ = DataTable_Action.Update;
                    BusinessFacadeDLT.tsSysParamInsertUpdateDelete(ut);
                }

            }
            else
            {
                //更新result到sysparam
                tsSysParamEntity ut = BusinessFacadeDLT.tsSysParamDisp(1027);
                ut.Value = UserID;
                ut.DataTable_Action_ = DataTable_Action.Update;
                BusinessFacadeDLT.tsSysParamInsertUpdateDelete(ut);
            }



            if (UserID == "")
            {
                Response.Write("<script language='javascript'>alert('输入的上家ID有误，请重新输入上家ID');</script>");
                return;
            }

            DataSet ds = BusinessFacadeDLT.AddAppointArbitration(CustomerID.ToString(), UserID, Common.Get_UserID);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "-1")
                {
                    Response.Write("<script language='javascript'>alert('此客服已存在于列表，请直接更新!');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('添加成功!');</script>");
                    BindDataList();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MSSql"], CommandType.Text,
                    "update dbo.tsSysParam set Value = '" + TextBox3.Text + "' where ID = 1030");

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
        }
    }
}
