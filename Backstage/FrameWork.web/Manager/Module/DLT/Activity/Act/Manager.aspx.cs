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

using DLT;
using DLT.Components;
using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;

namespace DLT.Web.Module.DLT.Activity.Act
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        Int32 ModuleID = (Int32)Common.sink("ModuleID", MethodType.Get, 10, 0, DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                OnStart();
               
            }
        }


        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            BindGameList();
            BindModuleList();
            tsActivityEntity ut = null;
            if (CMD != "New")
            {
                ut = BusinessFacadeDLT.tsActivityDisp(IDX, ModuleID);
                OnStartData(ut);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加游戏";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看游戏";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改游戏";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tsActivityInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    else
                    {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    }
                    break;
                default:
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    break;
            }
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "活动";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}&ModuleID={1}", IDX, ModuleID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "活动";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}&ModuleID={1}')", IDX, ModuleID);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}&ModuleID={1}", IDX, ModuleID);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(tsActivityEntity ut)
        {
            ddlGame.SelectedValue = ut.GameID.ToString();
            tsGame_Game_Disp.Text = ut.Game;
            tsGame_IsOnline_Disp.Text = ut.Enable == true ? "可用" : "禁用";
            tsGame_IsOnline_Input.SelectedValue = ut.Enable == true ? "1" : "0";
            ddlSort.SelectedValue = lblSort.Text = ut.Sort.ToString();
            txtTimeLimit.Text = lblTimeLimit.Text = ut.TimeLimit.ToString();
            txtTitle.Text = lblTitle.Text = ut.Name;
            txtReward.Text = lblReward.Text = ut.Reward.ToString();
            tsGame_Comment_Input.Text = tsGame_Comment_Disp.Text = ut.Content;
            Image1.ImageUrl = "~/Upload/" + ut.ImageUrl;
            CKEditor1.Text = lblRule.Text = ut.Rule;
            CKEditor2.Text = lblQuestion.Text = ut.Question;

            txtS.Text = ut.StartPosition.ToString();
            txtE.Text = ut.EndPosition.ToString();
            lblSE.Text = txtS.Text + "~" + txtE.Text;

            txtNum.Text =lblNum.Text= ut.num.ToString();
            txtS_dtDate_Input.Text = lblS_dtDate_Input.Text = ut.StartD.ToString();
            txtE_dtDate_Input.Text = lblE_dtDate_Input.Text = ut.EndD.ToString();

            for (int i = 0; i < ddlModule.Items.Count; i++)
            {
                if (ddlModule.Items[i].Value == ut.ModuleID.ToString()) {
                    tsModule_Module_Disp.Text = ddlModule.Items[i].Text;
                    break;
                }
            }
            ddlModule.SelectedValue = ut.ModuleID.ToString();
        }

        /// <summary>
        /// 绑定游戏列表
        /// </summary>
        private void BindGameList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;

            List<tsGameEntity> lst = BusinessFacadeDLT.tsGameList(qp, out RecordCount);
            foreach (tsGameEntity var in lst)
            {

                ddlGame.Items.Add(new ListItem(var.Game, var.ID.ToString()));
            }
        }

        private void BindModuleList()
        {
            QueryParam qp = new QueryParam();
            qp.OrderType = 0;
            int RecordCount = 0;

            List<tsModuleEntity> lst = BusinessFacadeDLT.tsModuleList(qp, out RecordCount);
            foreach (tsModuleEntity var in lst)
            {
                ddlModule.Items.Add(new ListItem(var.Title, var.ID.ToString()));
            }
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            ddlGame.Visible = false;
            ddlModule.Visible = false;
            tsGame_Comment_Input.Visible = false;
            tsGame_IsOnline_Input.Visible = false;
            //ddlCompany.Visible = false;
            ddlSort.Visible = false;
            txtReward.Visible = false;
            txtTitle.Visible = false;
            txtTimeLimit.Visible = false;
            FileUpload1.Visible = false;
            CKEditor1.Visible = false;
            CKEditor2.Visible = false;

            txtS.Visible = false;
            txtE.Visible = false;
            lblsep.Visible = false;

            txtNum.Visible = false;
            txtS_dtDate_Input.Visible = false;
            txtE_dtDate_Input.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            //tsGame_CompID_Disp.Visible = false;
            tsGame_Game_Disp.Visible = false;
            tsGame_Comment_Disp.Visible = false;
            tsGame_IsOnline_Disp.Visible = false;
            lblSort.Visible = false;
            lblReward.Visible = false;
            lblTimeLimit.Visible = false;
            lblTitle.Visible = false;
            lblRule.Visible = false;
            lblQuestion.Visible = false;

            lblSE.Visible = false;

            lblNum.Visible = false;
            lblS_dtDate_Input.Visible = false;
            lblE_dtDate_Input.Visible = false;

            tsModule_Module_Disp.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string tsGame_Game_Value = (string)Common.sink(ddlGame.UniqueID, MethodType.Post, 50, 1, DataType.Str);
            string tsGame_Comment_Value = (string)Common.sink(tsGame_Comment_Input.UniqueID, MethodType.Post, 512, 0, DataType.Str);

            bool tsGame_IsOnline_Value = Convert.ToBoolean(Common.sink(tsGame_IsOnline_Input.UniqueID, MethodType.Post, 1, 0, DataType.Int));

            tsActivityEntity ut = BusinessFacadeDLT.tsActivityDisp(IDX, ModuleID);
            ut.ID = IDX;
            ut.ModuleID = Convert.ToInt32(ddlModule.SelectedValue);
            ut.GameID = Convert.ToInt32(ddlGame.SelectedValue);
            //ut.ImageUrl = Image1.ImageUrl;
            ut.Name = txtTitle.Text.Trim();
            ut.Reward = Convert.ToDouble(txtReward.Text.Trim());
            ut.TimeLimit = Convert.ToInt32(txtTimeLimit.Text.Trim());
            ut.Content = tsGame_Comment_Value;
            ut.Sort = Convert.ToInt32(ddlSort.SelectedValue);
            ut.Enable = tsGame_IsOnline_Value;
            ut.Game = tsGame_Game_Value;
            ut.Rule = CKEditor1.Text;
            ut.Question = CKEditor2.Text;
            ut.StartPosition = Convert.ToInt32(txtS.Text.Trim());
            ut.EndPosition = Convert.ToInt32(txtE.Text.Trim());
            int num;
            if (int.TryParse(txtNum.Text.Trim(), out num))
            {
                ut.num = num;
            }
            else {
                ut.num = 0;
            }
           
            DateTime startD;
            if (DateTime.TryParse(txtS_dtDate_Input.Text.Trim(), out startD))
            {
                ut.StartD = startD;
            }
            else {
                ut.StartD = null;
            }
            DateTime endD;
            if (DateTime.TryParse(txtE_dtDate_Input.Text.Trim(), out endD))
            {
                ut.EndD = endD;
            }
            else {
                ut.EndD = null;
            }
          
            string filename = "";
            bool b = false;
            if (FileUpload1.PostedFile.FileName == "")   //没有重新上传图片
            {
                ut.ImageUrl = Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1);
            }
            else
            {
                string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                b = UpFileFun(FileUpload1, type, 2 * 1024 * 1024, "Upload", out filename);
                if (b)
                {
                    ut.ImageUrl = filename;
                }
            }
           
            if (CMD == "New")
            {
                ut.DataTable_Action_ = DataTable_Action.Insert;
            }
            else if (CMD == "Edit")
            {
                ut.DataTable_Action_ = DataTable_Action.Update;
            }
            else
            {
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
            Int32 rInt = BusinessFacadeDLT.tsActivityInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加游戏成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改游戏成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("Default.aspx"));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
            }
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
                catch( Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('"+ex.Message+"');</script>");
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