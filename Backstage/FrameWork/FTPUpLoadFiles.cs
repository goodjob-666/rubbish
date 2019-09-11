using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Configuration;

namespace FrameWork
{
    public class FTPUpLoadFiles
    {


        #region 本地文件上传到FTP服务器


        /// <summary>
        /// 上传文件到远程ftp
        /// </summary>
        /// <param name="ftpPath">ftp上的文件路径</param>
        /// <param name="path">本地的文件目录</param>
        /// <param name="id">文件名</param>
        /// <returns></returns>
        static bool UploadFile(string FTPCONSTR, string FTPUSERNAME, string FTPPASSWORD, string ftpPath, string path, string id, ref string message)
        {

            FileInfo f = new FileInfo(path);
            path = path.Replace("\\", "/");
            bool b = MakeDir(FTPCONSTR, FTPUSERNAME, FTPPASSWORD, ftpPath);
            if (b == false)
            {
                return false;
            }
            path = FTPCONSTR + ftpPath + id;
            FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FTPUSERNAME, FTPPASSWORD);
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.ContentLength = f.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = f.OpenRead();
            try
            {
                Stream strm = reqFtp.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                message = "完成";
                return true;
            }
            catch (Exception ex)
            {
                message = string.Format("因{0},无法完成上传", ex.Message);
                return false;
            }
        }

        public static bool UploadFile1(string fileName, ref string message)
        {
            //string strFtpAddress = ConfigurationManager.AppSettings["ftpIp"];//ftp地址
            //string strFtpUser = ConfigurationManager.AppSettings["ftpUserName"];//ftp用户
            //string strFtpPwd = ConfigurationManager.AppSettings["ftpPwd"];//ftp密码
            //string strFtpUploadAddress = "Upload1/";//ftp文件路径
            //string htmlnamepath = System.Web.HttpContext.Current.Server.MapPath("/Upload1/") + fileName;
            //bool bb = UploadFile(strFtpAddress, strFtpUser, strFtpPwd, strFtpUploadAddress, htmlnamepath, fileName, ref message);
            bool bb = true;
            return bb;
        }

        #endregion



        #region 在ftp服务器上创建文件目录

        /// <summary>
        ///在ftp服务器上创建文件目录
        /// </summary>
        /// <param name="dirName">文件目录</param>
        /// <returns></returns>
        public static bool MakeDir(string FTPCONSTR, string FTPUSERNAME, string FTPPASSWORD, string dirName)
        {
            try
            {
                bool b = RemoteFtpDirExists( FTPCONSTR,  FTPUSERNAME,  FTPPASSWORD,dirName);
                if (b)
                {
                    return true;
                }
                string url = FTPCONSTR + dirName;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.UseBinary = true;
                // reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFtp.Credentials = new NetworkCredential(FTPUSERNAME, FTPPASSWORD);
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                //errorinfo = string.Format("因{0},无法下载", ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 判断ftp上的文件目录是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool RemoteFtpDirExists(string FTPCONSTR, string FTPUSERNAME, string FTPPASSWORD, string path)
        {

            path = FTPCONSTR + path;
            FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FTPUSERNAME, FTPPASSWORD);
            reqFtp.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse resFtp = null;
            try
            {
                resFtp = (FtpWebResponse)reqFtp.GetResponse();
                FtpStatusCode code = resFtp.StatusCode;//OpeningData
                resFtp.Close();
                return true;
            }
            catch
            {
                if (resFtp != null)
                {
                    resFtp.Close();
                }
                return false;
            }
        }
        #endregion

        #region 从ftp服务器删除文件的功能
        /// <summary>
        /// 从ftp服务器删除文件的功能
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DeleteFile(string FTPCONSTR, string FTPUSERNAME, string FTPPASSWORD, string fileName)
        {
            try
            {
                string url = FTPCONSTR + fileName;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.UseBinary = true;
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFtp.Credentials = new NetworkCredential(FTPUSERNAME, FTPPASSWORD);
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                //errorinfo = string.Format("因{0},无法下载", ex.Message);
                return false;
            }
        }
        #endregion
    }
}
