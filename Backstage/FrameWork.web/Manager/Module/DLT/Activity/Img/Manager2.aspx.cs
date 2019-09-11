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
    public partial class Manager2 : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        Int32 FieldsID = (Int32)Common.sink("FieldsID", MethodType.Get, 10, 0, DataType.Int);
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
            tbValuesEntity ut = null;
            if (CMD != "New")
            {
                ut = BusinessFacadeDLT.tbValuesDisp(IDX);
                OnStartData(ut);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加随机数";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看随机数";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改随机数";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbValuesInsertUpdateDelete(ut) > 0)
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
            bi.ButtonName = "随机数";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}&FieldsID={1}", IDX, FieldsID);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "随机数";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}&FieldsID={1}')", IDX, FieldsID);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}&FieldsID={1}", IDX, FieldsID);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(tbValuesEntity ut)
        {
            if (ut.Value != "" && ut.Value.IndexOf("wxtpht") != -1)
            {
                Image1.ImageUrl = "~/Upload1/" + ut.Value.Substring(ut.Value.LastIndexOf('/') + 1);
            }
            else {
                txtValue.Text = lblValue.Text = ut.Value;
            }
            txtX.Text = lblX.Text = ut.X.ToString();
            txtY.Text = lblY.Text = ut.Y.ToString();
            txtRelaID.Text = lblRelaID.Text = ut.RelaID.ToString();


        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            txtValue.Visible = false;
            txtX.Visible = false;
            txtY.Visible = false;
            txtRelaID.Visible = false;
            FileUpload1.Visible = false;
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            lblValue.Visible = false;
            lblX.Visible = false;
            lblY.Visible = false;
            lblRelaID.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            tbValuesEntity ut = new tbValuesEntity();

            string filename = "";
            bool b = false;
            string domain = ConfigurationManager.AppSettings["domain"];


            if (txtValue.Text == "")
            {
                if (FileUpload1.PostedFile.FileName == "")   //没有重新上传随机数
                {
                    if (Image1.ImageUrl != "")
                    {
                        ut.Value = domain + "/Upload1/" + Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1);
                    }
                }
                else
                {
                    string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                    b = UpFileFun(FileUpload1, type, 300 * 1024, "Upload1", out filename);
                    if (b)
                    {
                        ut.Value = domain + "/Upload1/" + filename;
                    }
                }
            }
            else {
                ut.Value = txtValue.Text.Trim();
            }

            ut.X = Convert.ToInt32(txtX.Text.Trim());
            ut.Y = Convert.ToInt32(txtY.Text.Trim());
            ut.RelaID = Convert.ToInt32(txtRelaID.Text.Trim());
            ut.FieldsID = FieldsID;
            ut.ID = IDX;
           
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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("RandomSet.aspx?ID="+FieldsID));
            }
            Int32 rInt = BusinessFacadeDLT.tbValuesInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加随机数成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改随机数成功!(ID:{0})", IDX);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("RandomSet.aspx?ID=" + FieldsID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("RandomSet.aspx?ID=" + FieldsID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("RandomSet.aspx?ID=" + FieldsID));
            }
        }

        /// <summary>
        /// 上传随机数
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
                            Random Random = new Random();
                            int Result = Random.Next(1000, 9999);
                            string EditFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Result + "." + FileNameType;
                            fileName = EditFileName;
                            Controlfile.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("\\") + SaveFileName + "\\" + EditFileName);
                            return true;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "<script>alert('上传随机数失败！上传随机数类型不符合！');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('上传随机数失败！上传随机数尺寸超出限制！');</script>");
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('请点击浏览选择随机数文件！')</script>");
                return false;
            }
        }
    }
}