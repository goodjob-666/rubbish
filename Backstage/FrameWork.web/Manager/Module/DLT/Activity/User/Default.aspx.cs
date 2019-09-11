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

namespace DLT.Web.Module.DLT.Activity.User
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TabOptionWebControls1.SelectIndex = 1;
                BindUserStatus();
                DateTime curTime = DateTime.Now;
                S_dtDate_Input.Text = curTime.Date.AddMonths(-3).ToString("yyyy-MM-dd");
                E_dtDate_Input.Text = curTime.Date.ToString("yyyy-MM-dd");
            }
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

        public string Status(string status)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1002 and Kind=" + status;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;
        }

        public string XQStatus(string id)
        {
            for (int i = 0; i < dllUserStatus.Items.Count; i++)
            {
                if (dllUserStatus.Items[i].Value == id) {
                    return dllUserStatus.Items[i].Text;
                }
            }
            return "";
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
           
            List<tsUser1Entity> lst = BusinessFacadeDLT.UserList(qp, out RecordCount);
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
        /// 绑定用户状态
        /// </summary>
        private void BindUserStatus()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1002";
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {
                dllUserStatus.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
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

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UID_Value = (string)Common.sink(UID_Input.UniqueID, MethodType.Post, 24, 0, DataType.Str);
            string Nickname_Value = (string)Common.sink(Nickname_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Province_Value = (string)Common.sink(Province_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string City_Value = (string)Common.sink(City_Input.UniqueID, MethodType.Post, 256, 0, DataType.Str);
            string Status_Value = (string)Common.sink(dllUserStatus.UniqueID, MethodType.Post, 5, 0, DataType.Str);

            StringBuilder sb = new StringBuilder();

            sb.Append(" Where 1=1 ");

           
            string S_Date = (string)Common.sink(S_dtDate_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);   //开始时间
            string E_Date = (string)Common.sink(E_dtDate_Input.UniqueID, MethodType.Post, 10, 0, DataType.Str);   //结束时间

            if (CheckBox1.Checked)
            {
                sb.AppendFormat(" AND MemberID >0 ");
            }

            if (UID_Value != string.Empty)
            {
                sb.AppendFormat(" AND ID = '{0}' ", Common.inSQL(UID_Value));
            }

            if (Nickname_Value != string.Empty)
            {
                sb.AppendFormat(" AND Nickname = '{0}' ", Common.inSQL(Nickname_Value.Trim().Replace("'", "''")));
            }

            if (Province_Value != string.Empty)
            {
                sb.AppendFormat(" AND Province = '{0}' ", Common.inSQL(Province_Value));
            }

            if (City_Value != string.Empty)
            {
                sb.AppendFormat(" AND City = '{0}' ", Common.inSQL(City_Value));
            }

            if (Status_Value != string.Empty)
            {
                sb.AppendFormat(" AND Status = {0} ", Convert.ToInt32(Status_Value));
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


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == GridView1.EditIndex)
                {
                    DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    ddlStatus.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                    TextBox textBox1 = (TextBox)e.Row.FindControl("txtEditNickName");
                    textBox1.Text = DataBinder.Eval(e.Row.DataItem, "NickName").ToString();

                    HiddenField hiddenField1 = (HiddenField)e.Row.FindControl("HiddenField1");
                    hiddenField1.Value = DataBinder.Eval(e.Row.DataItem, "AvatarUrl").ToString();

                    DropDownList ddlMember = (DropDownList)e.Row.FindControl("ddlMember");
                    int memberId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MemberID"));
                    ddlMember.SelectedValue = memberId.ToString();

                    TextBox textBox2 = (TextBox)e.Row.FindControl("txtEndDate");
                    textBox2.Text = DataBinder.Eval(e.Row.DataItem, "EndDate").ToString();
                    switch (memberId)
                    {
                        case 1:
                            textBox2.Text = "";
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            textBox2.Text = "";
                            break;
                    }
                }
                else {
                    Label label1 = (Label)e.Row.FindControl("lblMember");
                    Label label2 = (Label)e.Row.FindControl("lblEndDate");

                    //0：不是会员； 1：终身永久VIP；2：包年VIP；3：包月VIP
                    int memberId = Convert.ToInt32(label1.Text);
                    switch (memberId)
                    {
                        case 1:
                            label1.Text = "终身永久VIP";
                            label2.Text = "";
                            break;
                        case 2:
                            label1.Text = "包年VIP";
                            break;
                        case 3:
                            label1.Text = "包月VIP";
                            break;
                        default:
                            label1.Text = "";
                            label2.Text = "";
                            break;
                    }
                }
            }
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
        #endregion


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
            string ID = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();
            string Comment = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtComment")).Text;
            DropDownList ddlStatus = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlStatus");

            string nickName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditNickName")).Text;

            FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
            HiddenField hiddenField1 = (HiddenField)GridView1.Rows[e.RowIndex].FindControl("HiddenField1");

            string avatarUrl = hiddenField1.Value;
            string filename = "";
            bool b = false;
            if (FileUpload1.PostedFile.FileName != "")   //没有重新上传图片
            {
                string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                b = UpFileFun(FileUpload1, type, 2 * 1024 * 1024, "Upload", out filename);
                if (b)
                {
                    avatarUrl = "http://wxht.dailiantong.com:998/Upload/" + filename;
                }
            }

            string EndDate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEndDate")).Text;  //结束日期
            DropDownList ddlMember = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlMember");

            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@Comment",Comment),
                    new SqlParameter("@Status",ddlStatus.SelectedValue),
                    new SqlParameter("@NickName",nickName),
                    new SqlParameter("@AvatarUrl",avatarUrl),
                    new SqlParameter("@UserID",ID),
                    new SqlParameter("@MemberID",ddlMember.SelectedValue),
                    new SqlParameter("@EndDate",EndDate)
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["MsSql"], CommandType.Text,
                    "update dbo.tbUser set Comment =@Comment,Status=@Status,NickName=@NickName,AvatarUrl=@AvatarUrl,MemberID=@MemberID,EndDate=@EndDate where ID = @UserID", pms);

            Response.Write("<script language:javascript>javascript:window:alert('修改成功');</script>");
            GridView1.EditIndex = -1;
            BindDataList();//绑定数据
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="Controlfile">上传控件</param>
        /// <param name="FileType">文件类型</param>
        /// <param name="FileSize">文件大小</param>
        /// <param name="SaveFileName">保存路径</param>
        /// <returns></returns>
        private bool UpFileFun(FileUpload Controlfile, string[] FileType, int FileSize, string SaveFileName, out string fileName)
        {
            string FileDir = Controlfile.PostedFile.FileName;
            fileName = "";
            if (FileDir != "")
            {
                string FileName = FileDir.Substring(FileDir.LastIndexOf("\\") + 1);                  //获取上传文件名称
                string FileNameType = FileDir.Substring(FileDir.LastIndexOf(".") + 1).ToString();    //获取上传文件类型
                int FileNameSize = Controlfile.PostedFile.ContentLength;                             //获取上传文件大小
                //  定义上传文件类型，并初始化
                string Types = "";

                try
                {
                    if (FileNameSize < FileSize)
                    {
                        for (int i = 0; i < FileType.Length; i++)
                        {
                            if (FileNameType == FileType[i])
                            {
                                Types = FileNameType;
                            }
                        }
                        if (FileNameType == Types)
                        {
                            Random Random = new Random();
                            int Result = Random.Next(1000, 9999);
                            string EditFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Result + "." + FileNameType;
                            fileName = EditFileName;
                            Controlfile.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("\\") + SaveFileName + "\\" + EditFileName);
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('上传成功！');</script>");
                            return true;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "<script>alert('上传图片失败！上传图片类型不符合！');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('上传图片失败！上传图片尺寸超出限制！');</script>");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('" + ex.Message + "');</script>");
                    return false;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('请点击浏览选择图片文件！')</script>");
                return false;
            }
        }
    }
}