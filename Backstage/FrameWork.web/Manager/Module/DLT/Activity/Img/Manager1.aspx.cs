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
using System.IO;

namespace DLT.Web.Module.DLT.Activity.Img
{
    public partial class Manager1 : System.Web.UI.Page
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        Int32 ImgID = (Int32)Common.sink("ImgID", MethodType.Get, 10, 0, DataType.Int);
        string Type = (string)Common.sink("Type", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPagePermission(CMD);
            if (!Page.IsPostBack)
            {
                OnStart();
            }
        }

        //private void GetFontFamaly()
        //{
        //    Hashtable table = ReplaceFontStr();
        //    foreach (DictionaryEntry item in table)
        //    {
        //        ddlFontFamily.Items.Add(new ListItem(item.Value.ToString(), item.Key.ToString()));
        //    }

        //    //string path = @"C:\Windows\Fonts";
        //    //var files = Directory.GetFiles(path, "*.ttf");
        //    //foreach (var file in files)
        //    //{
        //    //    var file1 = file.Substring(file.LastIndexOf("\\") + 1);
        //    //    file1 = file1.Substring(0, file1.LastIndexOf("."));
        //    //    ddlFontFamily.Items.Add(new ListItem(file1, file));
        //    //}
        //    //table = null;
        //}

        #region 常用字体英文转中文
        private Hashtable ReplaceFontStr()
        {
            Hashtable table = new Hashtable();
            table.Add("SIMLI", "隶书");
            table.Add("微软雅黑", "微软雅黑");
            table.Add("simkai", "楷体");
            table.Add("simfang", "仿宋");
            table.Add("宋体", "宋体");
            table.Add("simhei", "黑体");
            table.Add("SIMYOU", "幼圆");
            table.Add("FZSTK", "方正舒体");
            table.Add("FZYTK", "方正姚体");
            table.Add("STXINWEI", "华文新魏");
            table.Add("STXINGKA", "华文行楷");
            table.Add("STLITI", "华文隶书");
            table.Add("STHUPO", "华文琥珀");
            table.Add("stcaiyun", "华文彩云");
            table.Add("STFANGSO", "华文仿宋");
            table.Add("STZHONGS", "华文中宋");
            table.Add("STSONG", "华文宋体");
            table.Add("STKAITI", "华文楷体");
            table.Add("STXIHEI", "华文细黑");

            //增加常用特殊字体
            table.Add("手写大象体", "手写大象体");
            table.Add("DFPShaoNvW5-GB", "少女字体");
            table.Add("熊猫中文", "熊猫中文");
            table.Add("华康雅宋体W9", "华康雅宋体W9");
            table.Add("yuhongliang", "于洪亮硬笔行楷手写字体");
            table.Add("何云手写体", "何云手写体");
            table.Add("陈晓江哈哈手写简体", "陈晓江哈哈手写简体");
            table.Add("阿美手写体", "阿美手写体");

            //增加艺术签名字体
            table.Add("刘德华字体叶根友仿版", "刘德华字体叶根友仿版");
            table.Add("叶根友奥运字体", "叶根友奥运字体");
            table.Add("叶根友蚕燕隶书", "叶根友蚕燕隶书");
            table.Add("叶根友蚕燕隶书_新春版", "叶根友蚕燕隶书_新春版");
            table.Add("叶根友刀锋黑草", "叶根友刀锋黑草");
            table.Add("叶根友非主流手写", "叶根友非主流手写");
            table.Add("叶根友风帆特色", "叶根友风帆特色");
            table.Add("叶根友钢笔行书", "叶根友钢笔行书");
            table.Add("叶根友钢笔行书简体", "叶根友钢笔行书简体");
            table.Add("叶根友行书繁", "叶根友行书繁");
            table.Add("叶根友疾风草书", "叶根友疾风草书");
            table.Add("叶根友空心简体", "叶根友空心简体");
            table.Add("叶根友毛笔行书", "叶根友毛笔行书");
            table.Add("叶根友签名体", "叶根友签名体");
            table.Add("叶根友神工体", "叶根友神工体");
            table.Add("叶根友特楷简体", "叶根友特楷简体");
            table.Add("叶根友特隶简体", "叶根友特隶简体");
            table.Add("叶根友特色简体", "叶根友特色简体");
            table.Add("叶根友特色空心简体终极版", "叶根友特色空心简体终极版");
            table.Add("叶根友圆趣卡通体", "叶根友圆趣卡通体");
            return table;
        }
        #endregion


        /// <summary>
        /// 开始操作
        /// </summary>
        private void OnStart()
        {
            tbFieldsEntity ut = null;
            if (CMD != "New")
            {
                ut = BusinessFacadeDLT.tbFieldsDisp(IDX);
                OnStartData(ut);
            }

            switch (CMD)
            {
                case "New":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "增加参数";
                    Hidden_Disp();
                    break;
                case "List":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "查看参数";
                    Hidden_Input();
                    ButtonOption.Visible = false;
                    AddEditButton();
                    break;
                case "Edit":
                    TabOptionItem1.Tab_Name = HeadMenuWebControls1.HeadOPTxt = "修改参数";
                    Hidden_Disp();
                    AddDeleteButton();
                    break;
                case "Delete":
                    ut.DataTable_Action_ = DataTable_Action.Delete;
                    if (BusinessFacadeDLT.tbFieldsInsertUpdateDelete(ut) > 0)
                    {
                        EventMessage.MessageBox(1, "删除成功", string.Format("删除ID:{0}成功!", IDX), Icon_Type.OK, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
                    }
                    else
                    {
                        EventMessage.MessageBox(1, "删除失败", string.Format("删除ID:{0}失败!", IDX), Icon_Type.Error, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
                    }
                    break;
                default:
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
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
            bi.ButtonName = "参数";
            bi.ButtonUrl = string.Format("?CMD=Edit&IDX={0}&ImgID={1}&Type={2}", IDX, ImgID, Type);
            HeadMenuWebControls1.ButtonList.Add(bi);
        }


        /// <summary>
        /// 增加删除按钮
        /// </summary>
        private void AddDeleteButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Delete;
            bi.ButtonName = "参数";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = string.Format("DelData('?CMD=Delete&IDX={0}&ImgID={1}&Type={2}')", IDX, ImgID, Type);
            HeadMenuWebControls1.ButtonList.Add(bi);

            HeadMenuButtonItem bi1 = new HeadMenuButtonItem();
            bi1.ButtonPopedom = PopedomType.List;
            bi1.ButtonIcon = "back.gif";
            bi1.ButtonName = "返回";
            bi1.ButtonUrl = string.Format("?CMD=List&IDX={0}&ImgID={1}&Type={2}", IDX, ImgID, Type);
            HeadMenuWebControls1.ButtonList.Add(bi1);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="ut"></param>
        private void OnStartData(tbFieldsEntity ut)
        {
            txtTitle.Text = lblTitle.Text = ut.Title;
            txtPreValue.Text = lblPreValue.Text = ut.PreValue;
            txtDefault.Text = lblDefault.Text = ut.Default;
            txtSuffixValue.Text = lblSuffixValue.Text = ut.SuffixValue;
            ddlType.SelectedValue = ut.Type;
            txtData.Text = lblData.Text = ut.Data;
            txtFontSize.Text = lblFontSize.Text = ut.FontSize.ToString();

            int index = ut.FontFamily.IndexOf(".ttf");
            if (index != -1)
            {
                ddlFontFamily.SelectedValue = ut.FontFamily.Substring(0, index);
            }
            else
            {
                ddlFontFamily.SelectedValue = ut.FontFamily;
            }
            lblFontFamily.Text = ut.FontFamily;

            if (ut.Type == "String")
            {
                lblType.Text = "字符";
            }
            else if (ut.Type == "Number")
            {
                lblType.Text = "整数";
            }
            else if (ut.Type == "Digit")
            {
                lblType.Text = "小数";
            }
            else if (ut.Type == "Date")
            {
                lblType.Text = "日期";
            }
            else if (ut.Type == "Time")
            {
                lblType.Text = "时间：时分";
            }
            else if (ut.Type == "Array")
            {
                lblType.Text = "数组";
            }
            else if (ut.Type == "Image")
            {
                lblType.Text = "图片";
            }

            txtFontColor.Text = lblFontColor.Text = ut.FontColor;
            ddlFontStyle.SelectedValue = ut.FontStyle;
            txtX.Text = lblX.Text = ut.X.ToString();
            txtY.Text = lblY.Text = ut.Y.ToString();
            ddlIsCircle.SelectedValue = ut.IsCircle.ToString();
            lblIsCircle.Text = ut.IsCircle.ToString();
            txtWidth.Text = lblWidth.Text = ut.Width.ToString();
            txtHeight.Text = lblHeight.Text = ut.Height.ToString();
            ddlIsRandom.SelectedValue = ut.IsRandom.ToString();

            if (ut.IsRandom == 0)
            {
                lblIsRandom.Text = "否";
            }
            else if (ut.IsRandom == 1)
            {
                lblIsRandom.Text = "是（无关联）";
            }
            else
            {
                lblIsRandom.Text = "是（有关联）";
            }

            if (ut.FontStyle == "Regular")
            {
                lblFontStyle.Text = "常规";
            }
            else
            {
                lblFontStyle.Text = "加粗";
            }

            txtOrderBy.Text = lblOrderBy.Text = ut.OrderBy.ToString();

            if (ut.Default != "" && ut.Type == "Image")
            {
                Image1.ImageUrl = "~/Upload1/" + ut.Default.Substring(ut.Default.LastIndexOf('/') + 1);
            }

            txtRotate.Text = lblRotate.Text = ut.Rotate.ToString();
            txtBorderColor.Text = lblBorderColor.Text = ut.BorderColor;
            txtBorderSize.Text = lblBorderSize.Text = ut.BorderSize.ToString();
        }

        /// <summary>
        /// 隐藏显示框
        /// </summary>
        private void Hidden_Disp()
        {
            lblTitle.Visible = false;
            lblPreValue.Visible = false;
            lblDefault.Visible = false;
            lblSuffixValue.Visible = false;
            lblType.Visible = false;
            lblData.Visible = false;
            lblFontSize.Visible = false;
            lblFontFamily.Visible = false;

            lblFontColor.Visible = false;
            lblFontStyle.Visible = false;
            lblX.Visible = false;
            lblY.Visible = false;
            lblIsCircle.Visible = false;
            lblWidth.Visible = false;
            lblHeight.Visible = false;
            lblIsRandom.Visible = false;
            lblOrderBy.Visible = false;

            lblBorderSize.Visible = false;
            lblBorderColor.Visible = false;
            lblRotate.Visible = false;
        }

        /// <summary>
        /// 隐藏输入框
        /// </summary>
        private void Hidden_Input()
        {
            txtTitle.Visible = false;
            txtPreValue.Visible = false;
            txtDefault.Visible = false;
            txtSuffixValue.Visible = false;
            ddlType.Visible = false;
            txtData.Visible = false;
            txtFontSize.Visible = false;
            ddlFontFamily.Visible = false;
            txtFontColor.Visible = false;
            ddlFontStyle.Visible = false;
            txtX.Visible = false;
            txtY.Visible = false;
            ddlIsCircle.Visible = false;
            txtWidth.Visible = false;
            txtHeight.Visible = false;
            ddlIsRandom.Visible = false;
            txtOrderBy.Visible = false;

            txtBorderSize.Visible = false;
            txtBorderColor.Visible = false;
            txtRotate.Visible = false;
        }

        /// <summary>
        /// 增加/修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            tbFieldsEntity ut = new tbFieldsEntity();
            //ID, ImgID, Title, PreValue, Placeholder, Default, SuffixValue, Type, Data, FontSize, FontFamily, FontColor, FontStyle, X, Y, IsCircle, Width, Height, Rotate, IsRandom, OrderBy
            ut.ID = IDX;
            ut.ImgID = ImgID;
            ut.Title = txtTitle.Text.Trim();
            ut.PreValue = txtPreValue.Text.Trim();
            ut.Placeholder = "请输入" + ut.Title;
            ut.Default = txtDefault.Text.Trim();
            ut.SuffixValue = txtSuffixValue.Text.Trim();
            ut.Type = ddlType.SelectedValue;
            ut.Data = txtData.Text.Trim();
            if (txtFontSize.Text.Trim() != "")
            {
                ut.FontSize = Convert.ToInt32(txtFontSize.Text.Trim());
            }
            ut.FontFamily = FontFamily(ddlFontFamily.Text.Trim());
            ut.FontColor = txtFontColor.Text.Trim();
            ut.FontStyle = ddlFontStyle.Text;
            ut.X = Convert.ToInt32(txtX.Text.Trim());
            ut.Y = Convert.ToInt32(txtY.Text.Trim());
            ut.IsCircle = Convert.ToInt32(ddlIsCircle.SelectedValue);
            if (txtWidth.Text.Trim() != "")
            {
                ut.Width = Convert.ToInt32(txtWidth.Text.Trim());
            }
            if (txtHeight.Text.Trim() != "")
            {
                ut.Height = Convert.ToInt32(txtHeight.Text.Trim());
            }
            ut.IsRandom = Convert.ToInt32(ddlIsRandom.SelectedValue);
            ut.OrderBy = Convert.ToInt32(txtOrderBy.Text);

            ut.BorderSize = Convert.ToDouble(txtBorderSize.Text);
            ut.BorderColor = txtBorderColor.Text;
            ut.Rotate = Convert.ToInt32(txtRotate.Text);

            if (ut.Type == "Image") {
                string filename = "";
                bool b = false;
                if (FileUpload1.PostedFile.FileName == "")   //没有重新上传参数
                {
                    if (Image1.ImageUrl != "")
                    {
                        ut.Default ="/Upload1/" + Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/') + 1);
                    }
                }
                else
                {
                    string[] type = new string[] { "gif", "jpeg", "png", "jpg" };
                    b = UpFileFun(FileUpload1, type, 300 * 1024, "Upload1", out filename);
                    if (b)
                    {
                        ut.Default ="/Upload1/" + filename;
                    }
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
                EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Parameter.aspx?ID=" + ImgID));
            }
            Int32 rInt = BusinessFacadeDLT.tbFieldsInsertUpdateDelete(ut);
            if (rInt > 0)
            {
                string OpTxt = string.Format("增加参数成功!(ID:{0})", rInt);
                if (ut.DataTable_Action_ == DataTable_Action.Update)
                    OpTxt = string.Format("修改参数成功!(ID:{0})", IDX);
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
                catch( Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "<script>alert('"+ex.Message+"');</script>");
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