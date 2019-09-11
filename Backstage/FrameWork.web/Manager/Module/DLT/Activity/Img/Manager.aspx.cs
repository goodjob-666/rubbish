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

namespace DLT.Web.Module.DLT.Activity.Img
{
    public partial class Manager : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
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
            AlbumList();
            tbImgEntity ut = null;
            if (CMD != "New")
            {
                ut = BusinessFacadeDLT.tbImgDisp(IDX);
                OnStartData(ut);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加图片";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看图片";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改图片";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbImgInsertUpdateDelete(ut) > 0)
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

        private void AlbumList()
        {
            List<tbAlbumEntity> lst;
            if (ViewState["AlbumList"] != null)
            {
                lst = ViewState["AlbumList"] as List<tbAlbumEntity>;
            }
            else
            {
                QueryParam qp = new QueryParam();
                qp.Where = " where 1=1";
                qp.PageIndex = 1;
                qp.PageSize = 1000;
                qp.Orderfld = "ID";
                qp.OrderType = 1;
                int RecordCount = 0;
                lst = BusinessFacadeDLT.tbAlbumList(qp, out RecordCount, null);
                ViewState["AlbumList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbAlbumEntity var in lst)
                {
                    ddlAlbum.Items.Add(new ListItem(var.AlbumName, var.ID.ToString()));
                }
            }
        }

        private string AlbumList(int id)
        {
            string str = "";
            List<tbAlbumEntity> lst;
            if (ViewState["AlbumList"] != null)
            {
                lst = ViewState["AlbumList"] as List<tbAlbumEntity>;
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
                lst = BusinessFacadeDLT.tbAlbumList(qp, out RecordCount, null);
                ViewState["AlbumTypeList"] = lst;
            }

            if (lst != null)
            {
                foreach (tbAlbumEntity item in lst)
                {
                    if (item.ID == id)
                    {
                        str = item.AlbumName;
                        break;
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 增加修改按钮
        /// </summary>
        private void AddEditButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "图片";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "图片";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}')", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}", IDX);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(tbImgEntity ut)
        {
            txtImageName.Text = lblImageName.Text = ut.ImageName;
            if (ut.ImageUrl != "")
            {
                Image1.ImageUrl = "~/Upload1/" + ut.ImageUrl.Substring(ut.ImageUrl.LastIndexOf('/') + 1);
            }
            if (ut.BgImageUrl != "")
            {
                Image2.ImageUrl = "~/Upload1/" + ut.BgImageUrl.Substring(ut.BgImageUrl.LastIndexOf('/') + 1);
            }

            ddlAlbum.SelectedValue = ut.AlbumID.ToString();
            lblAlbum.Text = AlbumList(ut.AlbumID);
            ddlEnable.SelectedValue = ut.Enable.ToString();
            lblEnable.Text = ut.Enable == 1 ? "是" : "否";
            
            ddlImageType.SelectedValue=ut.ImageType.ToString();
            if (ut.ImageType == 0) {
                lblImageType.Text = "普通图片";
            }
            else if (ut.ImageType == 1)
            {
                lblImageType.Text = "GIF图片";
            }
            else
            {
                lblImageType.Text = "字体";
            }

            ddlIsHot.SelectedValue = ut.IsHot.ToString();
            lblIsHot.Text = ut.IsHot == 1 ? "是" : "否";
            txtDelay.Text = lblDelay.Text = ut.Delay.ToString();
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            txtImageName.Visible = false;
            ddlAlbum.Visible = false;
          
            ddlEnable.Visible = false;
            ddlImageType.Visible = false;
            FileUpload1.Visible = false;
            FileUpload2.Visible = false;
            ddlIsHot.Visible = false;
            txtDelay.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            lblImageName.Visible = false;
            lblEnable.Visible = false;
            lblImageType.Visible = false;
            lblAlbum.Visible = false;
            lblIsHot.Visible = false;
            lblDelay.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            tbImgEntity ut = new tbImgEntity();
            ut.AlbumID = Convert.ToInt32(ddlAlbum.SelectedValue);
            ut.ImageName = txtImageName.Text;
            ut.ID = IDX;
            ut.ImageType = Convert.ToInt32(ddlImageType.SelectedValue);
            ut.Enable = Convert.ToInt32(ddlEnable.SelectedValue);
            ut.IsHot = Convert.ToInt32(ddlIsHot.SelectedValue);
            ut.Delay = Convert.ToInt32(txtDelay.Text);
          
            string domain = ConfigurationManager.AppSettings["domain"];
            int Result = 0;
            int Result1 = 0;
            if (FileUpload1.PostedFile.FileName == "")   //没有重新上传图片
            {
                if (Image1.ImageUrl != "")
                {
                    ut.ImageUrl =domain+ "/Upload1/" + Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1);
                }
            }
            else
            {
                string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                Random Random = new Random();
                Result = Random.Next(1000, 9999);
                string filename = UpFileFun(FileUpload1, type, 1000 * 1024, "Upload1",Result.ToString());
               
                if (filename != "")
                {
                    ut.ImageUrl =domain+ "/Upload1/" + filename;

                    string message = string.Empty;
                    bool bb = FTPUpLoadFiles.UploadFile1(filename, ref message);
                }
            }

            if (FileUpload2.PostedFile.FileName == "")   //没有重新上传图片
            {
                if (Image2.ImageUrl != "")
                {
                    ut.BgImageUrl = "/Upload1/" + Image2.ImageUrl.Substring(Image2.ImageUrl.LastIndexOf('/') + 1);
                }
            }
            else
            {
                string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                Result1 = Result + 1;
                string filename1 = UpFileFun(FileUpload2, type, 1000 * 1024, "Upload1", Result1.ToString());

                if (filename1 != "")
                {
                    ut.BgImageUrl = "/Upload1/" + filename1;

                    string message = string.Empty;
                    bool bb = FTPUpLoadFiles.UploadFile1(filename1, ref message);
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
            Int32 rInt = BusinessFacadeDLT.tbImgInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加图片成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改图片成功!(ID:{0})", IDX);
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
        private string UpFileFun(FileUpload Controlfile, string[] FileType, int FileSize, string SaveFileName,string Result)
        {
            string FileDir = Controlfile.PostedFile.FileName;
            if (FileDir != "")
            {
                string FileName = FileDir.Substring(FileDir.LastIndexOf("\\") + 1);                  //获取上传文件名称
                string FileNameType = FileDir.Substring(FileDir.LastIndexOf(".") + 1).ToString().ToLower();    //获取上传文件类型

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
                            string EditFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Result + "." + FileNameType;
                            Controlfile.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("\\") + SaveFileName + "\\" + EditFileName);
                            return EditFileName;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "<script>alert('上传图片失败！上传图片类型不符合！');</script>");
                            return "";
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('上传图片失败！上传图片尺寸超出限制！');</script>");
                        return "";
                    }
                }
                catch( Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('"+ex.Message+"');</script>");
                    return "";
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('请点击浏览选择图片文件！')</script>");
                return "";
            }
        }
    }
}