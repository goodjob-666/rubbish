using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DLT.Data;

namespace FrameWork.web.Manager.Module.DLT.Activity.Img
{
    public partial class Preview : System.Web.UI.Page
    {
        string ConnString = System.Configuration.ConfigurationManager.AppSettings["MSSql"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preview();
            }
        }

        private void preview()
        {
            int imgId = Convert.ToInt32(Request.QueryString["ID"]);
            ImageHelper im = new ImageHelper();
            DataTable dtValues = null;

            //根据图片ID得到图片信息
            DataTable dtImg = GetImg(imgId);
            if (dtImg != null && dtImg.Rows.Count > 0)
            {
                //1 根据图片ID得到所有参数 [{"ID":"1","ImgID":null,"Title":null,"PreValue":null,"Placeholder":null,"Default":"中国联通","SuffixValue":null,"Type":null,"Data":null,"FontSize":null,"FontFamily":null,"FontColor":null,"FontStyle":null,"X":null,"Y":null,"IsCircle":null,"Width":null,"Height":null,"IsRandom":null,"OrderBy":null},{"ID":"2","ImgID":null,"Title":null,"PreValue":null,"Placeholder":null,"Default":"12:00","SuffixValue":null,"Type":null,"Data":null,"FontSize":null,"FontFamily":null,"FontColor":null,"FontStyle":null,"X":null,"Y":null,"IsCircle":null,"Width":null,"Height":null,"IsRandom":null,"OrderBy":null},{"ID":"3","ImgID":null,"Title":null,"PreValue":null,"Placeholder":null,"Default":"99999.99","SuffixValue":null,"Type":null,"Data":null,"FontSize":null,"FontFamily":null,"FontColor":null,"FontStyle":null,"X":null,"Y":null,"IsCircle":null,"Width":null,"Height":null,"IsRandom":null,"OrderBy":null}]
                DataTable dtFields = GetFieldsByImageId1(imgId);

                string filePath = HttpContext.Current.Server.MapPath("/");
                string bgImageUrl = dtImg.Rows[0]["BgImageUrl"].ToString();
                int index = bgImageUrl.IndexOf("Upload");
                bgImageUrl = bgImageUrl.Substring(index).Replace('/', '\\');
                string oldPath = filePath + bgImageUrl;
                Bitmap bitmap = new Bitmap(oldPath);

                string SuffixName = bgImageUrl.Substring(bgImageUrl.IndexOf('.')).ToLower();
                Random Random = new Random();
                int Result = Random.Next(1000, 9999);
                string catalog = DateTime.Now.ToString("yyyyMMdd");
                string catalog1 = DateTime.Now.ToString("yyyyMMddHHmmss");
                int RelaID = 0;
                //保存文件路径
                string filePathName = filePath + "Upload2\\" + catalog + "\\";
                if (!System.IO.Directory.Exists(filePathName))
                {
                    System.IO.Directory.CreateDirectory(filePathName);
                }
                foreach (DataRow row in dtFields.Rows)
                {
                    //2 循环所有的参数并进行整合，如果遇到字段IsRandom=1，则说明需要查询[dbo].[tbValues]表，随机取出文字或图片，还有X,Y坐标
                    int id = Convert.ToInt32(row["ID"]);
                    int IsRandom = Convert.ToInt32(row["IsRandom"]);

                    //如果IsRandom=1，则需要随机取出文字或图片
                    if (IsRandom == 1)
                    {
                        dtValues = GetValues(id);
                        if (dtValues != null && dtValues.Rows.Count > 0)
                        {
                            row["Default"] = dtValues.Rows[0]["Value"];
                            row["X"] = dtValues.Rows[0]["X"];
                            row["Y"] = dtValues.Rows[0]["Y"];
                            RelaID = dtValues.Rows[0]["RelaID"] == DBNull.Value ? 0 : Convert.ToInt32(dtValues.Rows[0]["RelaID"]);
                        }
                    }
                    else if (IsRandom == 2)
                    {
                        if (RelaID > 0)
                        {
                            dtValues = GetValuesByID(RelaID);
                            if (dtValues != null && dtValues.Rows.Count > 0)
                            {
                                row["Default"] = dtValues.Rows[0]["Value"];
                                row["X"] = dtValues.Rows[0]["X"];
                                row["Y"] = dtValues.Rows[0]["Y"];
                            }
                        }
                    }

                    //3 循环所有参数 判断如果不是图片，则合成所有文字
                    string type = row["Type"].ToString();
                    if (type != "Image")
                    {
                        int width = 0;
                        int height = 0;
                        if (row["Width"] != null && row["Width"].ToString() != "")
                        {
                            width = Convert.ToInt32(row["Width"]);
                        }
                        if (row["Height"] != null && row["Height"].ToString() != "")
                        {
                            height = Convert.ToInt32(row["Height"]);
                        }

                        row["Default"] = row["PreValue"].ToString() + row["Default"].ToString() + row["SuffixValue"].ToString();
                        int rotate = row["Rotate"] != DBNull.Value ? Convert.ToInt32(row["Rotate"]) : 0;
                        im.WriteString(bitmap, row["Default"].ToString(), row["FontFamily"].ToString(), Convert.ToInt32(row["FontSize"]), row["FontColor"].ToString(), row["FontStyle"].ToString(), Convert.ToInt32(row["X"]), Convert.ToInt32(row["Y"]), width, height, rotate);
                    }
                    else if (type == "Image")
                    {
                        int width = Convert.ToInt32(row["Width"]);
                        int height = Convert.ToInt32(row["Height"]);
                        int x = Convert.ToInt32(row["X"]);
                        int y = Convert.ToInt32(row["Y"]);
                        bool isCircle = Convert.ToBoolean(row["IsCircle"]);

                        string url = row["Default"].ToString();
                        index = url.IndexOf("Upload");
                        if (index > 0)
                        {
                            url = url.Substring(index).Replace('/', '\\');
                            im.CreateWatermark(bitmap, filePath + url, width, height, x, y, isCircle);
                        }
                        else
                        {
                            //将网络头像下载到本地
                            string AvatarUrl1 = url;
                            if (url != "")
                            {
                                AvatarUrl1 = url.Substring(0, url.LastIndexOf('/'));
                                AvatarUrl1 = AvatarUrl1.Substring(AvatarUrl1.LastIndexOf('/') + 1) + ".jpg";
                            }

                            if (!File.Exists(filePathName + AvatarUrl1))
                            {
                                im.DownloadImage(url, filePathName + AvatarUrl1);
                            }
                            im.CreateWatermark(bitmap, filePathName + AvatarUrl1, width, height, x, y, isCircle);
                        }
                    }
                }

                string EditFileName = filePathName + catalog1 + Result + SuffixName;
                switch (SuffixName)
                {
                    case ".jpg":
                        bitmap.Save(EditFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        bitmap.Save(EditFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        bitmap.Save(EditFileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case ".png":
                        bitmap.Save(EditFileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        throw new Exception("不允许的后缀:" + EditFileName);
                }
                bitmap.Dispose();
                im = null;
                string imagePath = "/Upload2/" + catalog + "/" + catalog1 + Result + SuffixName;
                Image1.ImageUrl = imagePath;
            }
        }

        #region ado
        /// <summary>
        /// 根据图片ID得到图片
        /// </summary>
        /// <param name="imgId">图片ID</param>
        /// <returns></returns>
        public DataTable GetImg(int imgId)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ImgID",imgId)
                };
            string sql = "select ID, ImageName, BgImageUrl, ImageUrl from [dbo].[tbImg] where [ID]=@ImgID";
            return SqlHelp.ExecuteDataTable(ConnString, CommandType.Text, sql, pms);
        }

        /// <summary>
        /// 根据参数ID得到随机数
        /// </summary>
        /// <param name="FieldsId"></param>
        /// <returns></returns>
        public DataTable GetValues(int FieldsId)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@FieldsId",FieldsId)
                };
            string sql = "select top 1 * from [dbo].[tbValues] where [FieldsID]=@FieldsId order by newid()";
            return SqlHelp.ExecuteDataTable(ConnString, CommandType.Text, sql, pms);
        }

        /// <summary>
        /// 根据ID得到固定值
        /// </summary>
        /// <param name="FieldsId"></param>
        /// <returns></returns>
        public DataTable GetValuesByID(int ID)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ID",ID)
                };
            string sql = "select * from [dbo].[tbValues] where ID=@ID";
            return SqlHelp.ExecuteDataTable(ConnString, CommandType.Text, sql, pms);
        }

        /// <summary>
        /// 根据图片ID得到所有参数
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public DataTable GetFieldsByImageId1(int ImageID)
        {
            SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@ImageID",ImageID)
                };
            string sql = "select * from [dbo].[tbFields] where [ImgID]=@ImageID";
            return SqlHelp.ExecuteDataTable(ConnString, CommandType.Text, sql, pms);
        } 
        #endregion
    }
}