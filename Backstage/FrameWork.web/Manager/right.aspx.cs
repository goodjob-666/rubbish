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
using FrameWork.Components;
using DLT;
using System.Text.RegularExpressions;
using DLT.Components;
using FrameWork;
namespace FrameWork.web
{
    public partial class right : System.Web.UI.Page
    {
        public string NewsID = "";
        public string TabID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //TabID = Request["tab"].ToString();
                //if (TabID == "1")
                //{
                //    TabOptionWebControls1.SelectIndex = 0;
                //}
                //else if (TabID == "3")
                //{
                //    TabOptionWebControls1.SelectIndex = 2;
                //}
                //FrameWorkVer.Text = FrameSystemInfo.FrameWorkVerName + CheckUpdate.GetNewVerInfo;
                //sys_FrameWorkInfoTable si = FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo;
                //SystemName.Text = string.Format("{0} {1}", FrameSystemInfo.GetSystemInfoTable.S_Name, FrameSystemInfo.GetSystemInfoTable.S_Version);
                //FrameWorkWeb.NavigateUrl = si.S_RegsionUrl;
                //FrameWorkWeb.Text = si.S_RegsionUrl;
                //BindNewsType();
                

            }

        }

        public void BindNewsType()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1021";

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            foreach (tsDictEntity var in lst)
            {

                ddlNewsType.Items.Add(new ListItem(var.Value, var.Kind.ToString()));
            }
        }

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

        public void Start()
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = AspNetPager1.PageSize;
            int RecordCount = 0;
            List<sys_NewsEntity> lst = BusinessFacadeDLT.sys_NewsList(qp, out RecordCount);
            Repeater1.DataSource = lst;
            Repeater1.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }
        public void Start1()
        {
            QueryParam qp1 = new QueryParam();
            qp1.Where = SearchTerms8;
            qp1.PageIndex = AspNetPager3.CurrentPageIndex;
            qp1.PageSize = AspNetPager3.PageSize;
            int RecordCount1 = 0;
            DataSet ds = BusinessFacadeDLT.PendingMattersList(qp1.PageIndex, qp1.PageSize, qp1.Where);
            Repeater3.DataSource = ds.Tables[0];
            Repeater3.DataBind();
            RecordCount1 = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            this.AspNetPager3.RecordCount = RecordCount1;

        }

        public string NewsType(string newstype)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1021 and Kind=" + newstype;
            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        public string PendingType(string pendingtype)
        {
            string typeName = "";
            switch (pendingtype)
            {
                case "1":
                    typeName = "客服部";
                    break;
                case "2":
                    typeName = "介入部";
                    break;
                case "3":
                    typeName = "投诉";
                    break;
                case "4":
                    typeName = "其它";
                    break;
                case "5":
                    typeName = "盗号纠纷单";
                    break;
            }
            return typeName;

        }

        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }


        public string FormatContent(string content)
        {
            string str = "";
            str = RemoveHTML(content);
            if (str.Length > 35)
            {
                str = str.Substring(0, 35) + "...";
            }
            return str;
        }

        public string DealType(string dealtype)
        {
            string typeName = "";
            switch (dealtype)
            {
                case "0":
                    typeName = "<font style=\"color:red;\">未处理</font>";
                    break;
                case "1":
                    typeName = "<font style=\"color:blue;\">处理中</font>";
                    break;
                case "2":
                    typeName = "<font style=\"color:green;\">待确定</font>";
                    break;
                case "3":
                    typeName = "已处理";
                    break;
            }
            return typeName;

        }

        protected void Repeater1_RowCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                string newsID = e.CommandArgument.ToString();
                /*更新首查*/
                TabOptionWebControls1.SelectIndex = 1;
                View_NewsInfo(newsID);

            }
        }

        public string GetNewsType(string type)
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;
            qp.Where = " Where [Key]=1021 and Kind=" + type;

            List<tsDictEntity> lst = BusinessFacadeDLT.tsDictList(qp, out RecordCount);
            return lst[0].Value;

        }

        private void View_NewsInfo(string newsID)
        {
            sys_NewsEntity ut = BusinessFacadeDLT.sys_NewsDisp(int.Parse(newsID));
            hfID.Value = ut.N_ID.ToString();
            if (ut.N_TypeID.ToString() != "0")
            {
                sys_News_N_TypeID_Disp.Text = GetNewsType(ut.N_TypeID.ToString());
            }
            else
            {
                sys_News_N_TypeID_Disp.Text = "";
            }
            sys_News_N_Title_Disp.Text = ut.N_Title.ToString();
            sys_News_N_Author_Disp.Text = ut.N_Author.ToString();
            sys_News_N_CreateDate_Disp.Text = ut.N_CreateDate.ToString();
            sys_News_N_Click_Disp.Text = ut.N_Click.ToString();
            sys_News_N_Content_Disp.Text = ut.N_Content.ToString();

            //加载评论
            StartNewsID(newsID);
        }

        private void View_PendingInfo(string pendingID)
        {
            sys_PendingMattersEntity ut = BusinessFacadeDLT.sys_PendingMattersDisp(int.Parse(pendingID));
            hdPendingID.Value = ut.P_ID.ToString();
            switch (ut.P_Type.ToString())
            {
                case "1":
                    sys_PendingMatters_P_Type_Disp.Text = "客服部";
                    break;
                case "2":
                    sys_PendingMatters_P_Type_Disp.Text = "介入部";
                    break;
                case "3":
                    sys_PendingMatters_P_Type_Disp.Text = "投诉";
                    break;
                case "4":
                    sys_PendingMatters_P_Type_Disp.Text = "其它";
                    break;
                case "5":
                    sys_PendingMatters_P_Type_Disp.Text = "盗号纠纷单";
                    break;
            }
            sys_PendingMatters_P_UserID_Disp.Text = ut.P_UserID.ToString();
            sys_PendingMatters_P_Contact_Disp.Text = ut.P_Contact.ToString();
            sys_PendingMatters_P_OrderNum_Disp.Text = ut.P_OrderNum.ToString();
            sys_PendingMatters_P_CreateDate_Disp.Text = ut.P_CreateDate.ToString();
            sys_PendingMatters_P_ReplyDate_Disp.Text = ut.P_ReplyDate.ToString();
            sys_PendingMatters_P_Content_Disp.Text = ut.P_Content.ToString();
            sys_PendingMatters_P_ReContent_Input.Text = ut.P_ReContent.ToString();
            sys_PendingMatters_P_PostID_Disp.Text = GetOpLoginName(ut.P_PostID.ToString());
            if (ut.P_ReplyID.ToString() != "0")
            {
                sys_PendingMatters_P_ReplyID_Disp.Text = GetOpLoginName(ut.P_ReplyID.ToString());
            }
            else
            {
                sys_PendingMatters_P_ReplyID_Disp.Text = "";
            }

            sys_PendingMatters_P_IsDeal_Disp.Text = DealType(ut.P_IsDeal.ToString());

            if (ut.P_IsDeal.ToString() == "3")
            {
                Button2.Visible = false;
                sys_PendingMatters_P_ReContent_Input.Enabled = false;
                divInput.Visible = false;
            }

            //加载留言
            StartPendingID(pendingID);
        }

        private string SearchTerms1
        {
            get
            {
                if (ViewState["SearchTerms1"] == null)
                    ViewState["SearchTerms1"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms1"];
            }
            set { ViewState["SearchTerms1"] = value; }
        }

        private string SearchTerms4
        {
            get
            {
                if (ViewState["SearchTerms4"] == null)
                    ViewState["SearchTerms4"] = " Where 1=1 ";
                return (string)ViewState["SearchTerms4"];
            }
            set { ViewState["SearchTerms4"] = value; }
        }

        private string SearchTerms8
        {
            get
            {
                if (ViewState["SearchTerms8"] == null)
                    ViewState["SearchTerms8"] = " 1=1 ";
                return (string)ViewState["SearchTerms8"];
            }
            set { ViewState["SearchTerms8"] = value; }
        }

        public void StartNewsID(string newsID)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms1 + " and C_NewsID=" + newsID;
            qp.PageIndex = AspNetPager1.CurrentPageIndex;
            qp.PageSize = 30;
            int RecordCount = 0;
            List<sys_CommentEntity> lst = BusinessFacadeDLT.sys_CommentList(qp, out RecordCount);
            Repeater2.DataSource = lst;
            Repeater2.DataBind();
            this.AspNetPager1.RecordCount = RecordCount;
        }

        public void StartPendingID(string pendingID)
        {
            QueryParam qp = new QueryParam();
            qp.Where = SearchTerms4 + " and P_PendingID=" + pendingID;
            qp.PageIndex = AspNetPager4.CurrentPageIndex;
            qp.PageSize = 30;
            qp.OrderType = 0;
            int RecordCount = 0;
            List<sys_PendingCommentEntity> lst = BusinessFacadeDLT.sys_PendingCommentList(qp, out RecordCount);
            Repeater4.DataSource = lst;
            Repeater4.DataBind();
            this.AspNetPager4.RecordCount = RecordCount;
        }

        public string GetOpLoginName(string OPID)
        {
            return UserData.Get_sys_UserTable(int.Parse(OPID)).U_LoginName;
        }

        /// <summary>
        /// 点击分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Start();
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            Start1();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (hdPendingID.Value != "")
            {
                int sys_PendingComment_P_PendingID_Value = int.Parse(hdPendingID.Value);
                int sys_PendingComment_P_CommentPostID_Value = Common.Get_UserID;
                string sys_PendingComment_P_CommentContent_Value = (string)Common.sink(sys_PendingComment_P_CommentContent_Input.UniqueID, MethodType.Post, 2147483647, 1, DataType.Str);
                string sys_PendingComment_P_CommentRemarks_Value = "";
                string sys_PendingComment_P_Pre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sys_PendingComment_P_CommentStauts_Value = DropDownList1.SelectedValue;
                sys_PendingCommentEntity ut = BusinessFacadeDLT.sys_PendingCommentDisp(int.Parse(hdPendingID.Value));

                ut.P_PendingID = sys_PendingComment_P_PendingID_Value;
                ut.P_CommentPostID = sys_PendingComment_P_CommentPostID_Value;
                ut.P_CommentContent = sys_PendingComment_P_CommentContent_Value;
                ut.P_CommentRemarks = sys_PendingComment_P_CommentRemarks_Value;
                ut.P_Pre = sys_PendingComment_P_Pre;
                ut.P_CommentStauts = int.Parse(sys_PendingComment_P_CommentStauts_Value);

                if (sys_PendingComment_P_CommentContent_Value == "")
                {
                    Response.Write("<script language='javascript'>alert('评论内容不能为空！');</script>");
                    return;
                }

                ut.DataTable_Action_ = DataTable_Action.Insert;


                Int32 rInt = BusinessFacadeDLT.sys_PendingCommentInsertUpdateDelete(ut);
                if (rInt > 0)
                {
                    //同时更新待办事项状态
                    sys_PendingMattersEntity ut1 = BusinessFacadeDLT.sys_PendingMattersDisp(int.Parse(hdPendingID.Value));
                    ut1.P_IsDeal = int.Parse(sys_PendingComment_P_CommentStauts_Value);
                    ut1.DataTable_Action_ = DataTable_Action.Update;
                    Int32 rInt1 = BusinessFacadeDLT.sys_PendingMattersInsertUpdateDelete(ut1);
                    if (rInt1 > 0)
                    {
                        Response.Write("<script language='javascript'>alert('回复成功！');</script>");
                        Start1();
                        TabOptionWebControls1.SelectIndex = 3;
                        View_PendingInfo(hdPendingID.Value);
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一个待处理事项！');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (hfID.Value != "")
            {
                int sys_Comment_C_NewsID_Value = int.Parse(hfID.Value);
                int sys_Comment_C_PostID_Value = Common.Get_UserID;
                string sys_Comment_C_Content_Value = (string)Common.sink(sys_Comment_C_Content_Input.UniqueID, MethodType.Post, 2147483647, 1, DataType.Str);
                string sys_Comment_C_Remarks_Value = "";
                DateTime sys_Comment_C_CreateDate_Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                sys_CommentEntity ut = BusinessFacadeDLT.sys_CommentDisp(int.Parse(hfID.Value));

                ut.C_NewsID = sys_Comment_C_NewsID_Value;
                ut.C_PostID = sys_Comment_C_PostID_Value;
                ut.C_Content = sys_Comment_C_Content_Value;
                ut.C_Remarks = sys_Comment_C_Remarks_Value;
                ut.C_CreateDate = sys_Comment_C_CreateDate_Value;

                if (sys_Comment_C_Content_Value == "")
                {
                    Response.Write("<script language='javascript'>alert('评论内容不能为空！');</script>");
                    return;
                }

                ut.DataTable_Action_ = DataTable_Action.Insert;


                Int32 rInt = BusinessFacadeDLT.sys_CommentInsertUpdateDelete(ut);
                if (rInt > 0)
                {
                    Response.Write("<script language='javascript'>alert('评论成功！');</script>");
                    TabOptionWebControls1.SelectIndex = 1;
                    View_NewsInfo(hfID.Value);
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一篇新闻！');</script>");
            }
        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //读取最后留言客服ID
            HiddenField hd = e.Item.FindControl("hdPendingID") as HiddenField;
            Label lblLastOPID = e.Item.FindControl("lblLastOPID") as Label;
            QueryParam qp = new QueryParam();
            qp.Where = " Where P_PendingID="+hd.Value;
            qp.PageIndex = 1;
            qp.Orderfld="P_Pre";
            qp.OrderType=1;
            qp.PageSize = 1000;
            int RecordCount = 0;
            List<sys_PendingCommentEntity> lst = BusinessFacadeDLT.sys_PendingCommentList(qp, out RecordCount);
            if(lst.Count>0)
            {
                lblLastOPID.Text = "客服:" + GetOpLoginName(lst[0].P_CommentPostID.ToString());
            }
            else
            {
                lblLastOPID.Text = "";
            }
        }

        protected void Repeater3_RowCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                string pendingID = e.CommandArgument.ToString();
                /*更新首查*/
                View_PendingInfo(pendingID);
                TabOptionWebControls1.SelectIndex = 3;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (hdPendingID.Value != "")
            {
                sys_PendingMattersEntity ut = BusinessFacadeDLT.sys_PendingMattersDisp(int.Parse(hdPendingID.Value));
                ut.P_ReplyDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ut.P_ReplyID = Common.Get_UserID;
                ut.P_ReContent = sys_PendingMatters_P_ReContent_Input.Text;
                ut.DataTable_Action_ = DataTable_Action.Update;
                Int32 rInt = BusinessFacadeDLT.sys_PendingMattersInsertUpdateDelete(ut);
                if (rInt > 0)
                {
                    Response.Write("<script language='javascript'>alert('客服待办事项更新成功！');window.parent.mainFrame.location.href='right.aspx?tab=3'</script>");
                    TabOptionWebControls1.SelectIndex = 2;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请先选择一个待处理事项！');</script>");
            }
        }

        protected void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNewsType.SelectedValue != "")
            {
                ViewState["SearchTerms"] = " where 1=1 and N_TypeID=" + ddlNewsType.SelectedValue;
            }
            else
            {
                ViewState["SearchTerms"] = " where 1=1 ";
            }
            Start();
            TabOptionWebControls1.SelectIndex = 0;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "")
            {
                ViewState["SearchTerms8"] = " 1=1 and P_Type=" + DropDownList2.SelectedValue;
            }
            else
            {
                ViewState["SearchTerms8"] = " 1=1 ";
            }
            Start1();
            TabOptionWebControls1.SelectIndex = 2;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string tmp = "";
            string tmp1 = "";
            string tmp2 = "";
            string keyWords = txtKeyWords.Text;
            if (DropDownList2.SelectedValue != "")
            {
                tmp=" and P_Type=" + DropDownList2.SelectedValue;
            }
            if (DropDownList3.SelectedValue != "")
            {
                tmp1=" and P_IsDeal=" + DropDownList3.SelectedValue;
            }
            if (tmp == "" && tmp1 == "")
            {
                ViewState["SearchTerms8"] = " 1=1 ";
            }
            if (tmp == "" && tmp1 != "")
            {
                ViewState["SearchTerms8"] = " 1=1 " + tmp1;
            }
            if (tmp != "" && tmp1 == "")
            {
                ViewState["SearchTerms8"] = " 1=1 " + tmp;
            }
            if (tmp != "" && tmp1 != "")
            {
                ViewState["SearchTerms8"] = " 1=1 " + tmp + tmp1;
            }

            if (ddlSKeyType.SelectedValue != "")
            {

                if (keyWords != "")
                {

                    switch (ddlSKeyType.SelectedValue)
                    {

                        case "用户ID":
                            tmp2 = " and P_UserID like '%" + keyWords + "%'";
                            break;
                        case "用户联系方式":
                            tmp2 = " and P_Contact like '%" + keyWords + "%'";
                            break;
                        case "订单编号":
                            tmp2 = " and P_OrderNum like '%" + keyWords + "%'";
                            break;
                        case "提交客服ID":
                            //判断客服ID是否存在
                            if (UserData.Get_sys_UserTable1(keyWords) != null)
                            {
                                int id = UserData.Get_sys_UserTable1(keyWords).UserID;
                                if (id != 0)
                                {
                                    tmp2 = " and P_PostID = " + id;
                                }
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('客服ID输入错误！');</script>");
                                return;
                            }
                            break;
                        //case "最后回复客服ID":
                        //    //判断客服ID是否存在
                        //    if (UserData.Get_sys_UserTable1(keyWords) != null)
                        //    {
                        //        int id = UserData.Get_sys_UserTable1(keyWords).UserID;
                        //        if (id != 0)
                        //        {
                        //            tmp2 = " and P_ReplyID = " + id;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Response.Write("<script language='javascript'>alert('客服ID输入错误！');</script>");
                        //        return;
                        //    }
                        //    break;

                    }
                    ViewState["SearchTerms8"] = ViewState["SearchTerms8"].ToString() + tmp2;
                }
            }
            Start1();
            TabOptionWebControls1.SelectIndex = 2;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (ddlNewsType.SelectedValue != "")
            {
                ViewState["SearchTerms"] = " where 1=1 and N_TypeID=" + ddlNewsType.SelectedValue;
            }
            else
            {
                ViewState["SearchTerms"] = " where 1=1 ";
            }
            Start();
            TabOptionWebControls1.SelectIndex = 0;
        }

    }
}
