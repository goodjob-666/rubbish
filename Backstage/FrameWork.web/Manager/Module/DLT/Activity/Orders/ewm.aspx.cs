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
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DLT.Web.Module.DLT.Activity.Orders
{
    public partial class ewm : System.Web.UI.Page
    {
        string SeriaNo = (string)Common.sink("SeriaNo", MethodType.Get, 20, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SeriaNo == "")
                {
                    Response.Write("<script language='javascript'>alert('订单号不能为空！');</script>");
                    return;
                }
                else
                {
                    string path = PostMoths(SeriaNo);
                    Image1.ImageUrl = path;
                    Label1.Text = "pages/index/record_detail/record_detail?SeriaNo=" + SeriaNo;
                }
            }
        }

        public string PostMoths(string seriaNo)
        {
            string appId = "wx5e9e01270444b4c9";
            string appSecret = "52deaa5c1c101b3a90197916e8dd2d82";
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
            string error = "";
            System.Net.CookieContainer cookie = null;
            string accessTokenJson = HttpRun("GET", "utf-8", url, "", ref cookie, 5000, "", "", "", ref error);
            if (accessTokenJson.ToLower().IndexOf("errcode") != -1)
            {
                return "";
            }
            else
            {
                AccessTokenEntity obj = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessTokenEntity>(accessTokenJson);  //获取 access_token
                string _url = string.Format("https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={0}", obj.access_token);

                string strURL = _url;
                System.Net.HttpWebRequest request;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";

                string json = "{\"scene\":\"" + seriaNo + "\",\"page\":\"pages/index/record_detail/record_detail\",\"width\":280,\"auto_color\":false,\"line_color\":{\"r\":\"26\",\"g\":\"173\",\"b\":\"25\"}}";
                byte[] payload = System.Text.Encoding.UTF8.GetBytes(json);
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.Stream s;
                s = response.GetResponseStream();
                List<byte> bytes = new List<byte>();
                int temp = s.ReadByte();
                while (temp != -1)
                {
                    bytes.Add((byte)temp);
                    temp = s.ReadByte();
                }
                byte[] tt = bytes.ToArray();

                string path = HttpContext.Current.Server.MapPath("\\Upload\\");
                string curPath = DateTime.Now.ToString("yyyyMMdd") + "\\";
                
                if (Directory.Exists(path + curPath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(path + curPath);
                }

                Random Random = new Random();
                int Result = Random.Next(1000, 9999);
                string EditFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Result + ".jpg";
                string fileName = path + curPath + EditFileName;
                System.IO.File.WriteAllBytes(fileName, tt);
                return "\\Upload\\" + curPath + EditFileName;
            }
        }

        #region 模拟向网站提交(返回字符串)
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开       
            return true;
        }



        /// <summary>
        /// 模拟向网站提交(返回字符串)
        /// </summary>
        /// <param name="AMothod">是GET还是POST</param>
        /// <param name="AUrl">提交地址</param>
        /// <param name="AReferer">引用页</param>
        /// <param name="ACookie">Cookie</param>
        /// <param name="Timeout">超时设置,毫秒</param>
        /// <param name="InData">POST时提交的数据</param>
        /// <param name="AContentType">标头信息的文件格式,为空则用缺省值</param>
        /// <param name="AAccept">标头定义客户机可以处理的文件类型,为空则用缺省值</param>
        /// <param name="AErrStr">错误的信息返回</param>
        /// <returns></returns>
        public static string HttpRun(string AMothod, string Charset, string AUrl, string AReferer, ref CookieContainer ACookie, int Timeout, string InData, string AContentType, string AAccept, ref string AErrStr)
        {
            ServicePointManager.Expect100Continue = false; //解决417错误

            AErrStr = "";
            string m_rt = string.Empty;
            string m_UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            Encoding m_encode = null;
            if (Charset == "") m_encode = System.Text.Encoding.GetEncoding("GB2312"); else m_encode = System.Text.Encoding.GetEncoding(Charset);
            string m_ContentType;
            string m_Mothod;
            string m_Accept;
            HttpWebResponse m_resp = null;

            if (AMothod == "") m_Mothod = "GET"; else m_Mothod = AMothod;

            if (AContentType != "") m_ContentType = AContentType;
            else if (m_Mothod.ToUpper() == "POST") m_ContentType = "application/x-www-form-urlencoded";
            else m_ContentType = "text/plain; charset=utf-8";

            if (AAccept == "") m_Accept = "*/*"; else m_Accept = AAccept;

            ServicePointManager.ServerCertificateValidationCallback += CheckValidationResult;//解决https问题
            HttpWebRequest m_req = (HttpWebRequest)WebRequest.Create(AUrl);
            m_req.Method = m_Mothod;
            m_req.UserAgent = m_UserAgent;
            m_req.Accept = m_Accept;
            m_req.ContentType = m_ContentType;
            m_req.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");
            m_req.Headers.Add("Accept-Encoding", "gzip,deflate");
            m_req.Headers.Add("Accept-Charset", "gb2312,utf-8;q=0.7,*;q=0.7");
            m_req.CookieContainer = ACookie;
            if (m_Mothod.ToUpper() == "POST")
            {
                m_req.ContentLength = InData.Length;
                //StreamWriter reqStream = new StreamWriter(m_req.GetRequestStream());
                //reqStream.Write(InData, 0, InData.Length);
                //try
                //{
                //    //reqStream.Flush();
                //    reqStream.Close();
                //}
                //catch
                //{ }
                using (Stream s = m_req.GetRequestStream())
                {
                    s.Write(Encoding.ASCII.GetBytes(InData), 0, InData.Length);
                    s.Close();
                }
            }
            m_req.Timeout = Timeout;
            try
            {
                m_resp = (HttpWebResponse)m_req.GetResponse();
                if (m_resp.StatusCode == HttpStatusCode.OK) //返回成功
                {
                    Stream m_respStream = null;
                    if (m_resp.ContentEncoding == "gzip")
                    {
                        System.IO.Compression.GZipStream zipStream = new GZipStream(m_resp.GetResponseStream(), CompressionMode.Decompress);
                        m_respStream = zipStream;
                    }
                    else
                    {
                        m_respStream = m_resp.GetResponseStream();
                    }
                    StreamReader responeReader = new StreamReader(m_respStream, m_encode);
                    m_rt = responeReader.ReadToEnd();
                    responeReader.Close();
                    m_resp.Close();
                }
                else
                {
                    AErrStr = "Error: " + m_resp.StatusCode.ToString();
                }
            }
            catch (Exception ee)
            {
                AErrStr = "Error: " + ee.Message;
            }
            return m_rt;
        }
        #endregion
    }
}