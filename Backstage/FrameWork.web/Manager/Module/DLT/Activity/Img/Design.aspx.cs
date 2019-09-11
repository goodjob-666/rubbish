using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Collections;
using DLT;
using FrameWork.Components;
using DLT.Components;
using System.Configuration;

namespace FrameWork.web.Manager.Module.DLT.Activity.Img
{
    public partial class Design : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tbFieldsEntity ut = new tbFieldsEntity();
            int ImgID = Convert.ToInt32(Request.QueryString["ID"]);
            ut.ID = 1;
            ut.ImgID = ImgID;
            ut.Title = txtTitle.Value.Trim();
            ut.PreValue = txtPreValue.Value.Trim();
            ut.Placeholder = "请输入" + ut.Title;
            ut.Default = txtDefault.Value.Trim();
            ut.SuffixValue = txtSuffixValue.Value.Trim();

            int num;
            if (int.TryParse(ut.Default, out num))
            {
                ut.Type = "Number";
            }
            else {
                ut.Type = "String";
            }
            if (ut.Title == "日期") {
                ut.Type = "Date";
            }
            else if (ut.Title == "时间") {
                ut.Type = "Time";
            }
            else if (ut.Title == "小数")
            {
                ut.Type = "Digit";
            }
            
            ut.Data = "";
            if (txtFontSize.Value.Trim() != "")
            {
                ut.FontSize = Convert.ToInt32(txtFontSize.Value.Trim());
            }
            ut.FontFamily = FontFamily(ddlFontFamily.Text.Trim());
            ut.FontColor = txtColor.Value.Trim();
            ut.FontStyle = ddlFontStyle.Value;
            int i1 = hidX.Value.IndexOf('.');
            if (i1 != -1)
            {
                ut.X = Convert.ToInt32(hidX.Value.Trim().Substring(0, i1));
            }
            else {
                ut.X = Convert.ToInt32(hidX.Value.Trim());
            }

            int i2 = hidY.Value.IndexOf('.');
            if (i2 != -1)
            {
                ut.Y = Convert.ToInt32(hidY.Value.Trim().Substring(0, i2));
            }
            else
            {
                ut.Y = Convert.ToInt32(hidY.Value.Trim());
            }
           
            ut.IsCircle = 0;
            ut.BorderSize = Convert.ToDouble(txtBorderSize.Value.Trim());
            ut.BorderColor = txtBorderColor.Value.Trim();
            ut.Rotate = Convert.ToInt32(txtRotate.Value.Trim());
            if (txtWidth.Value.Trim() != "")
            {
                ut.Width = Convert.ToInt32(txtWidth.Value.Trim());
            }
            if (txtHeight.Value.Trim() != "")
            {
                ut.Height = Convert.ToInt32(txtHeight.Value.Trim());
            }

            string shuiyin = ddlShuiYin1.Items[ddlShuiYin1.SelectedIndex].Value;
            if (shuiyin == "1")
            {
                ut.IsRandom = 2;
            }
            else {
                ut.IsRandom = 0;
            }
            
            ut.OrderBy = Convert.ToInt32(txtOrderBy.Value);

            ut.DataTable_Action_ = DataTable_Action.Insert;
            Int32 rInt = BusinessFacadeDLT.tbFieldsInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加参数成功!(ID:{0})", rInt);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Parameter.aspx?id=" + ImgID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
            }
        }


        private string FontFamily(string font)
        {
            string str;
            if (font == "宋体" || font == "微软雅黑")
            {
                str = font;
            }
            else
            {
                str = font + ".ttf";
            }
            return str;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tbFieldsEntity ut = new tbFieldsEntity();
            int ImgID = Convert.ToInt32(Request.QueryString["ID"]);
            ut.ID = 1;
            ut.ImgID = ImgID;
            ut.Title = txtTitle1.Value.Trim();
            ut.Placeholder = "请输入" + ut.Title;
            ut.Type = "Image";
            ut.X = Convert.ToInt32(hidX1.Value.Trim());
            ut.Y = Convert.ToInt32(hidY1.Value.Trim());
            ut.IsCircle = Convert.ToInt32(ddlCircle.Items[ddlCircle.SelectedIndex].Value);
            ut.Width = Convert.ToInt32(txtWidth1.Value.Trim());
            ut.Height = Convert.ToInt32(txtHeight1.Value.Trim());
            ut.Rotate = Convert.ToInt32(txtRotate1.Value.Trim());
            ut.IsRandom = 0;
            ut.OrderBy = Convert.ToInt32(txtOrderBy1.Value);

            string filename = "";
            bool b = false;

            string shuiyin = ddlShuiYin.Items[ddlShuiYin.SelectedIndex].Value;
            if (shuiyin == "")
            {
                if (FileUpload1.PostedFile.FileName == "")   //没有重新上传参数
                {
                    ut.Default = "";
                }
                else
                {
                    string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                    b = UpFileFun(FileUpload1, type, 300 * 1024, "Upload1", out filename);
                    if (b)
                    {
                        ut.Default = "/Upload1/" + filename;

                        string message = string.Empty;
                        bool bb = FTPUpLoadFiles.UploadFile1(filename, ref message);
                    }
                }
            }
            else
            {
                ut.Default = shuiyin;
                ut.IsRandom = 2;
                ut.FontFamily = "";
            }
            ut.DataTable_Action_ = DataTable_Action.Insert;
            Int32 rInt = BusinessFacadeDLT.tbFieldsInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加参数成功!(ID:{0})", rInt);
                EventMessage.MessageBox(1, "操作成功", OpTxt, Icon_Type.OK, Common.GetHomeBaseUrl("Parameter.aspx?id=" + ImgID));
            }
            else if (rInt == -2)
            {
                EventMessage.MessageBox(1, "操作失败", "操作失败,存在相同的键值(用户名/数据)!", Icon_Type.Alert, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
            }
            else
            {
                EventMessage.MessageBox(1, "操作失败", string.Format("操作失败,返回值:{0}!", rInt), Icon_Type.Error, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
            }
        }

        /// <summary>
        /// 上传参数
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
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "<script>alert('上传参数失败！上传参数类型不符合！');</script>");
                            return false;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('上传参数失败！上传参数尺寸超出限制！');</script>");
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>alert('请点击浏览选择参数文件！')</script>");
                return false;
            }
        }
    }
}