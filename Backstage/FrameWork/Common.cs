/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved					
 *      File:																
 *				Common.cs	                                            	
 *      Description:															
 *				 通用类        												
 *      Author:																
 *				Lzppcc														
 *				Lzppcc@hotmail.com											
 *				http://www.supesoft.com										
 *      Finish DateTime:														
 *				2007年8月6日													
 *      History:																
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Globalization;
using System.Web.SessionState;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Microsoft.Win32;
using FrameWork.Components;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO.Compression;
using DLT.Components;

namespace FrameWork
{
    /// <summary>
    /// 通用类
    /// </summary>
    public class Common
    {
        #region "返回字符串在字符串中出现的次数"
        /// <summary>
        /// 返回字符串在字符串中出现的次数
        /// </summary>
        /// <param name="Char">要检测出现的字符</param>
        /// <param name="String">要检测的字符串</param>
        /// <returns>出现次数</returns>
        public static int GetCharInStringCount(string Char, string String)
        {
            string str = String.Replace(Char, "");
            return (String.Length - str.Length) / Char.Length;

        }
        #endregion

        #region "获得物理路径"
        /// <summary>
        /// 获得物理路径
        /// </summary>
        /// <param name="a">路径</param>
        /// <returns>物理路径</returns>
        public static string GetFullPath(string a)
        {
            string AppDir = System.AppDomain.CurrentDomain.BaseDirectory;
            if (a.IndexOf(":") < 0)
            {
                string str = a.Replace("..\\", "");
                if (str != a)
                {
                    int Num = (a.Length - str.Length) / ("..\\").Length + 1;
                    for (int i = 0; i < Num; i++)
                    {
                        AppDir = AppDir.Substring(0, AppDir.LastIndexOf("\\"));
                    }
                    str = "\\" + str;

                }
                a = AppDir + str;
            }
            return a;
        }
        #endregion

        #region "获得日志文件存放目录"
        /// <summary>
        /// 获得日志文件存放目录
        /// </summary>
        public static string LogDir
        {
            get
            {
                string LogFilePath = GetFullPath(ConfigurationManager.AppSettings["LogDir"]);
                if (!Directory.Exists(LogFilePath))
                    Directory.CreateDirectory(LogFilePath);
                return LogFilePath;
            }
        }
        #endregion

        #region "获取用户Form提交字段值"
        /// <summary>
        /// 获取post和get提交值
        /// </summary>
        /// <param name="InputName">字段名</param>
        /// <param name="Method">post和get</param>
        /// <param name="MaxLen">最大允许字符长度 0为不限制</param>
        /// <param name="MinLen">最小字符长度 0为不限制</param>
        /// <param name="DataType">字段数值类型 int 和str和dat不限为为空</param>
        /// <returns></returns>
        public static object sink(string InputName, MethodType Method, int MaxLen, int MinLen, DataType DataType)
        {
            HttpContext rq = HttpContext.Current;
            string TempValue = "";

            #region "获取提交字段数据TempValue"
            if (Method == MethodType.Post)
            {
                if (rq.Request.Form[InputName] != null)
                {
                    TempValue = rq.Request.Form[InputName].ToString();
                }

            }
            else if (Method == MethodType.Get)
            {
                if (rq.Request.QueryString[InputName] != null)
                {
                    TempValue = rq.Request.QueryString[InputName].ToString();
                }
            }
            else
            {
                MessBox("提交数据方式不是post和get!", "?", rq);
                EventMessage.MessageBox(2, "获取数据失败", string.Format("{0}字段提交数据方式不是post和get!", InputName), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            }
            #endregion

            #region "检测最大允许长度"
            if (MaxLen != 0)
            {
                if (TempValue.Length > MaxLen)
                {
                    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}超过系统允许长度{2}!", InputName, TempValue, MaxLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                }
            }
            #endregion

            #region "检测最小允许长度"
            if (MinLen != 0)
            {
                if (TempValue.Length < MinLen)
                {
                    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}低于系统允许长度{2}!", InputName, TempValue, MinLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                }
            }
            #endregion

            #region "检测数据类型"
            if (TempValue != "")
            {

                switch (DataType)
                {
                    case DataType.Int:
                        int IntTempValue = 0;
                        if (!int.TryParse(TempValue, out IntTempValue))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Int型!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return IntTempValue;
                    case DataType.Dat:
                        DateTime DateTempValue = DateTime.MinValue;
                        if (!DateTime.TryParse(TempValue, out DateTempValue))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为日期型!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DateTempValue;
                    case DataType.Long:
                        long LongTempValue = long.MinValue;
                        if (!long.TryParse(TempValue, out LongTempValue))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Log型!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return LongTempValue;
                    case DataType.Double:
                        double DoubleTempValue = double.MinValue;
                        if (!double.TryParse(TempValue, out DoubleTempValue))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Double型!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DoubleTempValue;
                    case DataType.CharAndNum:
                        if (!CheckRegEx(TempValue, "^[A-Za-z0-9]+$"))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为英文或数字!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return TempValue;
                    case DataType.CharAndNumAndChinese:
                        if (!CheckRegEx(TempValue, "^[A-Za-z0-9\u00A1-\u2999\u3001-\uFFFD]+$"))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为英文或数字或中文!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return TempValue;
                    case DataType.Email:
                        if (!CheckRegEx(TempValue, "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
                            EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为邮件地址!", InputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return TempValue;
                    default:
                        return TempValue;
                }

            }
            else
            {
                switch (DataType)
                {
                    case DataType.Int:
                        return 0;
                    case DataType.Dat:
                        return null;
                    case DataType.Long:
                        return long.MinValue;
                    case DataType.Double:
                        return 0.0f;
                    default:
                        return TempValue;
                }
            }

            #endregion
        }

        #endregion

        #region "js信息提示框"
        /// <summary>
        /// js信息提示框
        /// </summary>
        /// <param name="Message">提示信息文字</param>
        /// <param name="ReturnUrl">返回地址</param>
        /// <param name="rq"></param>
        public static void MessBox(string Message, string ReturnUrl, HttpContext rq)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("parent.location.href='" + ReturnUrl + "';\n");
            msgScript.Append("</script>\n");
            rq.Response.Write(msgScript.ToString());
            rq.Response.End();
        }

        /// <summary>
        /// 弹出Alert信息窗
        /// </summary>
        /// <param name="Message">信息内容</param>
        public static void MessBox(string Message)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("</script>\n");
            HttpContext.Current.Response.Write(msgScript.ToString());
        }

        #endregion

        #region 格式化字符串,符合SQL语句
        /// <summary>
        /// 格式化字符串,符合SQL语句
        /// </summary>
        /// <param name="formatStr">需要格式化的字符串</param>
        /// <returns>字符串</returns>
        public static string inSQL(string formatStr)
        {
            string rStr = formatStr;
            if (formatStr != null && formatStr != string.Empty)
            {
                rStr = rStr.Replace("'", "''");
                //rStr = rStr.Replace("\"", "\"\"");
            }
            return rStr;
        }
        /// <summary>
        /// 格式化字符串,是inSQL的反向
        /// </summary>
        /// <param name="formatStr"></param>
        /// <returns></returns>
        public static string outSQL(string formatStr)
        {
            string rStr = formatStr;
            if (rStr != null)
            {
                rStr = rStr.Replace("''", "'");
                rStr = rStr.Replace("\"\"", "\"");
            }
            return rStr;
        }

        /// <summary>
        /// 查询SQL语句,删除一些SQL注入问题
        /// </summary>
        /// <param name="formatStr">需要格式化的字符串</param>
        /// <returns></returns>
        public static string querySQL(string formatStr)
        {
            string rStr = formatStr;
            if (rStr != null && rStr != "")
            {
                rStr = rStr.Replace("'", "");
            }
            return rStr;
        }
        #endregion

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str_value"></param>
        /// <param name="str_len"></param>
        /// <returns></returns>
        public static string leftx(string str_value, int str_len)
        {
            int p_num = 0;
            int i;
            string New_Str_value = "";

            if (str_value == "")
            {
                New_Str_value = "";
            }
            else
            {
                int Len_Num = str_value.Length;
                for (i = 0; i <= Len_Num - 1; i++)
                {
                    if (i > Len_Num) break;
                    char c = Convert.ToChar(str_value.Substring(i, 1));
                    if (((int)c > 255) || ((int)c < 0))
                        p_num = p_num + 2;
                    else
                        p_num = p_num + 1;



                    if (p_num >= str_len)
                    {

                        New_Str_value = str_value.Substring(0, i + 1);
                        break;
                    }
                    else
                    {
                        New_Str_value = str_value;
                    }

                }

            }
            return New_Str_value;
        }
        #endregion

        #region 检测用户提交页面
        /// <summary>
        /// 检测用户提交页面
        /// </summary>
        /// <param name="rq"></param>
        public static void Check_Post_Url(HttpContext rq)
        {
            string WebHost = "";
            if (rq.Request.ServerVariables["SERVER_NAME"] != null)
            {
                WebHost = rq.Request.ServerVariables["SERVER_NAME"].ToString();
            }

            string From_Url = "";
            if (rq.Request.UrlReferrer != null)
            {
                From_Url = rq.Request.UrlReferrer.ToString();
            }

            if (From_Url == "" || WebHost == "")
            {
                rq.Response.Write("禁止外部提交数据!");
                rq.Response.End();
            }
            else
            {
                WebHost = "HTTP://" + WebHost.ToUpper();
                From_Url = From_Url.ToUpper();
                int a = From_Url.IndexOf(WebHost);
                if (From_Url.IndexOf(WebHost) < 0)
                {
                    rq.Response.Write("禁止外部提交数据!");
                    rq.Response.End();
                }
            }

        }
        #endregion

        #region 日期处理
        /// <summary>
        /// 格式化日期为2006-12-22
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public static string formatDate(DateTime dTime)
        {
            string rStr;
            rStr = dTime.Year + "-" + dTime.Month + "-" + dTime.Day;
            return rStr;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static string getWeek(DateTime sDate)
        {
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;


            string rStr = "";
            switch (myCal.GetDayOfWeek(sDate).ToString())
            {
                case "Sunday":
                    rStr = "星期日";
                    break;
                case "Monday":
                    rStr = "星期一";
                    break;
                case "Tuesday":
                    rStr = "星期二";
                    break;
                case "Wednesday":
                    rStr = "星期三";
                    break;
                case "Thursday":
                    rStr = "星期四";
                    break;
                case "Friday":
                    rStr = "星期五";
                    break;
                case "Saturday":
                    rStr = "星期六";
                    break;
            }
            return rStr;
        }
        #endregion

        #region 随机颜色数据

        /// <summary>
        /// 随机颜色数据
        /// </summary>
        /// <returns></returns>
        public static string getStrColor()
        {
            int length = 6;
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "隐藏IP地址最后一位用*号代替"
        /// <summary>
        /// 隐藏IP地址最后一位用*号代替
        /// </summary>
        /// <param name="Ipaddress">IP地址:192.168.34.23</param>
        /// <returns></returns>
        public static string HidenLastIp(string Ipaddress)
        {
            return Ipaddress.Substring(0, Ipaddress.LastIndexOf(".")) + ".*";
        }
        #endregion

        #region "防刷新检测"
        /// <summary>
        /// 防刷新检测
        /// </summary>
        /// <param name="Second">访问间隔秒</param>
        /// <param name="UserSession"></param>
        public static bool CheckRefurbish(int Second, HttpSessionState UserSession)
        {

            bool i = true;
            if (UserSession["RefTime"] != null)
            {
                DateTime d1 = Convert.ToDateTime(UserSession["RefTime"]);
                DateTime d2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                TimeSpan d3 = d2.Subtract(d1);
                if (d3.Seconds < Second)
                {
                    i = false;
                }
                else
                {
                    UserSession["RefTime"] = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                }
            }
            else
            {
                UserSession["RefTime"] = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }

            return i;
        }
        #endregion

        #region "判断是否是Decimal类型"
        /// <summary>
        /// 判断是否是Decimal类型
        /// </summary>
        /// <param name="TBstr0">判断数据字符</param>
        /// <returns>true是false否</returns>
        public static bool IsDecimal(string TBstr0)
        {
            bool IsBool = false;
            string Intstr0 = "1234567890";
            string IntSign0, StrInt, StrDecimal;
            int IntIndex0, IntSubstr, IndexInt;
            int decimalbool = 0;
            int db = 0;
            bool Bf, Bl;
            if (TBstr0.Length > 2)
            {
                IntIndex0 = TBstr0.IndexOf(".");
                if (IntIndex0 != -1)
                {
                    string StrArr = ".";
                    char[] CharArr = StrArr.ToCharArray();
                    string[] NumArr = TBstr0.Split(CharArr);
                    IndexInt = NumArr.GetUpperBound(0);
                    if (IndexInt > 1)
                    {
                        decimalbool = 1;
                    }
                    else
                    {
                        StrInt = NumArr[0].ToString();
                        StrDecimal = NumArr[1].ToString();
                        //--- 整数部分－－－－－
                        if (StrInt.Length > 0)
                        {
                            if (StrInt.Length == 1)
                            {
                                IntSubstr = Intstr0.IndexOf(StrInt);
                                if (IntSubstr != -1)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                            else
                            {
                                for (int i = 0; i <= StrInt.Length - 1; i++)
                                {
                                    IntSign0 = StrInt.Substring(i, 1).ToString();
                                    IntSubstr = Intstr0.IndexOf(IntSign0);
                                    if (IntSubstr != -1)
                                    {
                                        db = db + 0;
                                    }
                                    else
                                    {
                                        db = i + 1;
                                        break;
                                    }
                                }

                                if (db == 0)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                        }
                        else
                        {
                            Bf = true;
                        }
                        //----小数部分－－－－
                        if (StrDecimal.Length > 0)
                        {
                            for (int j = 0; j <= StrDecimal.Length - 1; j++)
                            {
                                IntSign0 = StrDecimal.Substring(j, 1).ToString();
                                IntSubstr = Intstr0.IndexOf(IntSign0);
                                if (IntSubstr != -1)
                                {
                                    db = db + 0;
                                }
                                else
                                {
                                    db = j + 1;
                                    break;
                                }
                            }
                            if (db == 0)
                            {
                                Bl = true;
                            }
                            else
                            {
                                Bl = false;
                            }
                        }
                        else
                        {
                            Bl = false;
                        }
                        if ((Bf && Bl) == true)
                        {
                            decimalbool = 0;
                        }
                        else
                        {
                            decimalbool = 1;
                        }

                    }

                }
                else
                {
                    decimalbool = 1;
                }

            }
            else
            {
                decimalbool = 1;
            }

            if (decimalbool == 0)
            {
                IsBool = true;
            }
            else
            {
                IsBool = false;
            }

            return IsBool;
        }
        #endregion

        #region "获取随机数"
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GetRandomPassword(int length)
        {
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "获取用户IP地址"
        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {

            string user_IP = string.Empty;
            //if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            //{
            //    if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            //    {
            //        user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            //    }
            //    else
            //    {
            //        user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            //    }
            //}
            //else
            //{
            //    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            //}
            user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            return user_IP;
        }
        #endregion

        #region 字符串截取补字符函数
        /// <summary>
        /// 字符串截取补字符函数
        /// </summary>
        /// <param name="s">要处理的字符串</param>
        /// <param name="len">长度</param>
        /// <param name="b">补充的字符</param>
        /// <returns>处理后字符</returns>
        public static string splitStringLen(string s, int len, char b)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            if (s.Length >= len)
                return s.Substring(0, len);
            return s.PadRight(len, b);
        }
        #endregion

        #region "3des加密字符串"
        /// <summary>
        /// 3des加密函数(ECB加密模式,PaddingMode.PKCS7,无IV)
        /// </summary>
        /// <param name="encryptValue">加密字符</param>
        /// <param name="key">加密key(24字符)</param>
        /// <returns>加密后Base64字符</returns>
        public static string EncryptString(string encryptValue, string key)
        {
            string enstring = "加密出错!";
            ICryptoTransform ct; //需要此接口才能在任何服务提供程序上调用 CreateEncryptor 方法，服务提供程序将返回定义该接口的实际 encryptor 对象。
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            SymmetricAlgorithm des3 = SymmetricAlgorithm.Create("TripleDES");
            des3.Mode = CipherMode.ECB;
            des3.Key = Encoding.UTF8.GetBytes(splitStringLen(key,24,'0'));
            //des3.KeySize = 192;
            des3.Padding = PaddingMode.PKCS7;

            ct = des3.CreateEncryptor();

            byt = Encoding.UTF8.GetBytes(encryptValue);//将原始字符串转换成字节数组。大多数 .NET 加密算法处理的是字节数组而不是字符串。

            //创建 CryptoStream 对象 cs 后，现在使用 CryptoStream 对象的 Write 方法将数据写入到内存数据流。这就是进行实际加密的方法，加密每个数据块时，数据将被写入 MemoryStream 对象。

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            try
            {
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                enstring = Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                enstring = ex.ToString();
            }
            finally
            {
                cs.Close();
                cs.Dispose();
                ms.Close();
                ms.Dispose();
                des3.Clear();
                ct.Dispose();
            }
            enstring = Convert.ToBase64String(ms.ToArray());
            return enstring;
        }
        #endregion

        #region "3des解密字符串"
        /// <summary>
        /// 3des解密函数(ECB加密模式,PaddingMode.PKCS7,无IV)
        /// </summary>
        /// <param name="decryptString">解密字符</param>
        /// <param name="key">解密key(24字符)</param>
        /// <returns>解密后字符</returns>
        public static string DecryptString(string decryptString,string key)
        {
            string destring="解密字符失败!";
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            SymmetricAlgorithm des3 = SymmetricAlgorithm.Create("TripleDES");
            des3.Mode = CipherMode.ECB;
            des3.Key = Encoding.UTF8.GetBytes(splitStringLen(key,24,'0'));
            //des3.KeySize = 192;
            des3.Padding = PaddingMode.PKCS7;

            ct = des3.CreateDecryptor();

            byt = Convert.FromBase64String(decryptString);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            try
            {
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                destring = Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                destring = ex.ToString();
            }
            finally{
                ms.Close();
                cs.Close();
                ms.Dispose();
                cs.Dispose();
                ct.Dispose();
                des3.Clear();
            }
            return destring;
        }
        #endregion

        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }
        #endregion

        #region 脚本提示信息,并且跳转到最上层框架
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg">信息内容,可以为空,为空表示不出现提示窗口</param>
        /// <param name="Url">跳转地址</param>
        public static string Hint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='javascript'>");
            if (Msg != "")
                rStr.Append("	alert('" + Msg + "');");

            if (Url != "")
                rStr.Append("	window.top.location.href = '" + Url + "';");

            rStr.Append("</script>");

            return rStr.ToString();
        }
        #endregion

        #region 脚本提示信息,并且跳转到当前框架内
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg">信息内容,可以为空,为空表示不出现提示窗口</param>
        /// <param name="Url">跳转地址,自已可以写入脚本</param>
        /// <returns></returns>
        public static string LocalHintJs(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.Append(Url + "\n");
            rStr.Append("</script>");

            return rStr.ToString();
        }

        #endregion

        #region 脚本提示信息,并且跳转到当前框架内,地址为空时,返回上页
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string LocalHint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.AppendFormat("	window.location.href = '" + Url + "';\n");
            else
                rStr.AppendFormat(" window.history.back();");

            rStr.Append("</script>\n");

            return rStr.ToString();
        }
        #endregion

        #region "按当前日期和时间生成随机数"
        /// <summary>
        /// 按当前日期和时间生成随机数
        /// </summary>
        /// <param name="Num">附加随机数长度</param>
        /// <returns></returns>
        public static string sRndNum(int Num)
        {
            string sTmp_Str = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00") + System.DateTime.Today.Day.ToString("00") + System.DateTime.Now.Hour.ToString("00") + System.DateTime.Now.Minute.ToString("00") + System.DateTime.Now.Second.ToString("00");
            return sTmp_Str + RndNum(Num);
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="VcodeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int VcodeNum)
        {
            StringBuilder sb = new StringBuilder(VcodeNum);
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="VcodeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum1(int VcodeNum)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            while (sb.Length < VcodeNum)
            {
                int t = rand.Next(9);
                if (sb.Length == 0 && t == 0)
                {
                    continue;
                }
                else
                {
                    sb.AppendFormat("{0}", t);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "通过RNGCryptoServiceProvider 生成随机数 0-9"
        /// <summary>
        /// 通过RNGCryptoServiceProvider 生成随机数 0-9 
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string RndNumRNG(int length)
        {
            byte[] bytes = new byte[16];
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                r.GetBytes(bytes);
                sb.AppendFormat("{0}", (int)((decimal)bytes[0] / 256 * 10));
            }
            return sb.ToString();

        }
        #endregion

        #region "在当前路径上创建日期格式目录(20060205)"
        /// <summary>
        /// 在当前路径上创建日期格式目录(20060205)
        /// </summary>
        /// <param name="sPath">返回目录名</param>
        /// <returns></returns>
        public static string CreateDir(string sPath)
        {
            string sTemp = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00") + System.DateTime.Today.Day.ToString("00");
            sPath += sTemp;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@sPath); //构造函数创建目录
            if (di.Exists == false)
            {
                di.Create();
            }

            return sTemp;
        }
        #endregion

        #region "检测是否为有效邮件地址格式"
        /// <summary>
        /// 检测是否为有效邮件地址格式
        /// </summary>
        /// <param name="strIn">输入邮件地址</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region "邮件发送"
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strto">接收邮件地址</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">内容</param>
        public static void SendSMTPEMail(string strto, string strSubject, string strBody)
        {
            string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"];
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
            string SMTPUser = ConfigurationManager.AppSettings["SMTPUser"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            string MailFrom = ConfigurationManager.AppSettings["MailFrom"];
            string MailSubject = ConfigurationManager.AppSettings["MailSubject"];

            SmtpClient client = new SmtpClient(SMTPHost);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(SMTPUser, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
            message.IsBodyHtml = true;

            client.Send(message);
        }
        #endregion

        #region "转换编码"
        /// <summary>
        /// 转换编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {

                return System.Web.HttpUtility.UrlEncode(Encoding.GetEncoding(54936).GetBytes(str));
            }
        }
        #endregion

        #region "当前显示应用模组"
        /// <summary>
        /// 显示应用模组
        /// </summary>
        public static int ApplicationID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationID"]);
                }
                catch
                {
                    return 0;
                }
            }
        }
        #endregion

        #region "获取登陆用户UserID"
        /// <summary>
        /// 获取登陆用户UserID,如果未登陆为0
        /// </summary>
        public static int Get_UserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? Convert.ToInt32(HttpContext.Current.User.Identity.Name) : 0;
            }

        }
        #endregion

        #region "获取当前Cookies名称"
        /// <summary>
        /// "获取当前Cookies名称
        /// </summary>
        public static string Get_CookiesName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "获取WEBCache名称前辍"
        /// <summary>
        /// 获取WEBCache名称前辍
        /// </summary>
        public static string Get_WebCacheName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "设置页面不被缓存"
        /// <summary>
        /// 设置页面不被缓存
        /// </summary>
        public static void SetPageNoCache()
        {

            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Pragma", "No-Cache");
        }
        #endregion

        #region "获取页面url"
        /// <summary>
        /// 获取当前访问页面地址
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }

        /// <summary>
        /// 检测当前url是否包含指定的字符
        /// </summary>
        /// <param name="sChar">要检测的字符</param>
        /// <returns></returns>
        public static bool CheckScriptNameChar(string sChar)
        {
            bool rBool = false;
            if (GetScriptName.ToLower().LastIndexOf(sChar) >= 0)
                rBool = true;
            return rBool;
        }

        /// <summary>
        /// 获取当前页面的扩展名
        /// </summary>
        public static string GetScriptNameExt
        {
            get
            {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }

        /// <summary>
        /// 获取当前访问页面地址参数
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }

        /// <summary>
        /// 获得页面文件名和参数名
        /// </summary>
        public static string GetScriptNameUrl
        {
            get {
                string Script_Name = Common.GetScriptName;
                Script_Name = Script_Name.Substring(Script_Name.LastIndexOf("/") + 1);
                Script_Name += "?"+GetScriptNameQueryString;
                return Script_Name;
            }
        }

        /// <summary>
        /// 获得当前页面的文件名
        /// </summary>
        public static string GetScriptFileName
        {
            get {
                string Script_Name = Common.GetScriptName;
                Script_Name = Script_Name.Substring(Script_Name.LastIndexOf("/") + 1);
                return Script_Name;
            }
        }

        /// <summary>
        /// 获取当前访问页面Url
        /// </summary>
        public static string GetScriptUrl
        {
            get
            {
                return Common.GetScriptNameQueryString == "" ? Common.GetScriptName : string.Format("{0}?{1}", Common.GetScriptName, Common.GetScriptNameQueryString);
            }
        }

        /// <summary>
        /// 返回当前页面目录的url
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public static string GetHomeBaseUrl(string FileName)
        {
            string Script_Name = Common.GetScriptName;
            return string.Format("{0}/{1}", Script_Name.Remove(Script_Name.LastIndexOf("/")), FileName);
        }

        /// <summary>
        /// 返回当前网站网址
        /// </summary>
        /// <returns></returns>
        public static string GetHomeUrl()
        {
            return HttpContext.Current.Request.Url.Authority;
        }

        /// <summary>
        /// 获取当前访问文件物理目录
        /// </summary>
        /// <returns>路径</returns>
        public static string GetScriptPath
        {
            get
            {
                string Paths = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"].ToString();
                return Paths.Remove(Paths.LastIndexOf("\\"));
            }
        }
        #endregion

        #region "按字符串位数补0"
        /// <summary>
        /// 按字符串位数补0
        /// </summary>
        /// <param name="CharTxt">字符串</param>
        /// <param name="CharLen">字符长度</param>
        /// <returns></returns>
        public static string FillZero(string CharTxt, int CharLen)
        {
            if (CharTxt.Length < CharLen)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < CharLen - CharTxt.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(CharTxt);
                return sb.ToString();
            }
            else
            {
                return CharTxt;
            }
        }

        #endregion

        #region "替换JS中特殊字符"
        /// <summary>
        /// 将JS中的特殊字符替换
        /// </summary>
        /// <param name="str">要替换字符</param>
        /// <returns></returns>
        public static string ReplaceJs(string str)
        {

            if (str != null)
            {
                str = str.Replace("\"", "&quot;");
                str = str.Replace("(", "&#40;");
                str = str.Replace(")", "&#41;");
                str = str.Replace("%", "&#37;");
            }

            return str;

        }
        #endregion

        #region "正式表达式验证"
        /// <summary>
        /// 正式表达式验证
        /// </summary>
        /// <param name="C_Value">验证字符</param>
        /// <param name="C_Str">正式表达式</param>
        /// <returns>符合true不符合false</returns>
        public static bool CheckRegEx(string C_Value, string C_Str)
        {
            Regex objAlphaPatt;
            objAlphaPatt = new Regex(C_Str, RegexOptions.Compiled);


            return objAlphaPatt.Match(C_Value).Success;
        }
        #endregion

        #region "检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)"
        /// <summary>
        /// 检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)
        /// </summary>
        /// <param name="TempChar">需检测字符</param>
        /// <param name="TempStr">待检测字符串</param>
        /// <returns>存在true,不存在false</returns>
        public static bool Check_Char_Is(string TempChar, string TempStr)
        {
            bool rBool = false;
            if (TempChar != null && TempStr != null)
            {
                string[] TempStrArray = TempStr.Split(',');
                for (int i = 0; i < TempStrArray.Length; i++)
                {
                    if (TempChar == TempStrArray[i].Trim())
                    {
                        rBool = true;
                        break;
                    }
                }
            }
            return rBool;
        }
        #endregion

        #region "上传文件配置"
        /// <summary>
        /// 上传目录设置
        /// </summary>
        public static string UpLoadDir
        {
            get
            {
                return FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_UploadPath;
            }
        }

        /// <summary>
        /// 图片缩图高度
        /// </summary>
        public static int UpImgHeight
        {
            get
            {
                //return Convert.ToInt32(ConfigurationManager.AppSettings["UpImgHeight"]);
                return FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_UpImgHeight;
            }
        }
        /// <summary>
        /// 图片缩图宽度
        /// </summary>
        public static int UpImgWidth
        {
            get
            {
                //return Convert.ToInt32(ConfigurationManager.AppSettings["UpImgWidth"]);
                return FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_UpImgWidth;
            }
        }
        #endregion

        #region "前台设置"

        /// <summary>
        /// 菜单风格 0:经典 1:流行 2:朴素
        /// </summary>
        public static int MenuStyle
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["MenuStyle"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["MenuStyle"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["MenuStyle"].Value = value.ToString();
            }
        }

        /// <summary>
        /// 分页每页记录数(默认10)
        /// </summary>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["PageSize"] == null)
                {
                    return 10;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["PageSize"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["PageSize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// 表格样式(默认default)
        /// </summary>
        public static string TableSink
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["TableSink"] == null)
                {
                    return "default";
                }
                else
                {
                    return HttpContext.Current.Request.Cookies["TableSink"].Value.ToString();
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["TableSink"].Value = value;
            }
        }

        /// <summary>
        /// 用户在线过期时间 (分)默认30分 如果用户在当前设定的时间内没有任何操作,将会被系统自动退出
        /// </summary>
        public static int OnlineMinute
        {
            get
            {
                try
                {
                    int _onlineminute = Convert.ToInt32(ConfigurationManager.AppSettings["OnlineMinute"]);
                    if (_onlineminute == 0)
                        return 10000;
                    else
                        return _onlineminute;
                }
                catch
                {
                    return 30;
                }
            }
        }

        /// <summary>
        /// 是否允许清空操作日志
        /// </summary>
        public static bool AllowClearData
        {
            get {
                try
                {
                    bool _allowcleardata = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowClearData"]);
                    return _allowcleardata;
                }
                catch
                {
                    return false;
                } 
            }
        }

        #endregion

        #region "数据库设置"

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static string GetDBType
        {
            get
            {
                return ConfigurationManager.AppSettings["DBType"];
            }
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string GetConnString
        {
            get
            {
                return ConfigurationManager.AppSettings[GetDBType];
            }
        }
        #endregion

        #region "产生GUID"
        /// <summary>
        /// 获取一个GUID字符串
        /// </summary>
        public static string GetGUID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        #endregion

        #region "生成刷新部门列表js"
        /// <summary>
        /// 生成刷新部门列表js
        /// </summary>
        public static string BuildJs
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language=javascript>");
                sb.Append("window.parent.leftbody.location.reload();");
                sb.Append("</script>");

                return sb.ToString();
            }
        }
        #endregion

        #region "获取服务器IP"
        /// <summary>
        /// 获取服务器IP
        /// </summary>
        public static string GetServerIp
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"].ToString();
            }
        }
        #endregion

        #region "获取服务器操作系统"
        /// <summary>
        /// 获取服务器操作系统
        /// </summary>
        public static string GetServerOS
        {
            get
            {
                return Environment.OSVersion.VersionString;
            }
        }
        #endregion

        #region "获取服务器域名"
        /// <summary>
        /// 获取服务器域名
        /// </summary>
        public static string GetServerHost
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            }
        }
        #endregion

        #region "显示出错详细信息在用户页面(用户开发调试,在生产环境请设置为false)"
        /// <summary>
        /// 显示出错详细信息在用户页面(用户开发调试,在生产环境请设置为false)
        /// </summary>
        public static bool DispError
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["DispError"]);
            }
        }
        #endregion

        #region "根据IP获取IP查询Url地址"
        /// <summary>
        /// 根据IP获取IP查询Url地址
        /// </summary>
        /// <param name="IP">IP地址</param>
        /// <returns>查询url</returns>
        public static string GetIPLookUrl(string IP)
        {
            return string.Format("<a href='" + FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_IPLookUrl + "' target='_blank'>{0}</a>", IP);
        }
        #endregion

        #region "根据文件扩展名获取当前目录下的文件列表"
        /// <summary>
        /// 根据文件扩展名获取当前目录下的文件列表
        /// </summary>
        /// <param name="FileExt">文件扩展名</param>
        /// <returns>返回文件列表</returns>
        public static List<string> GetDirFileList(string FileExt)
        {
            List<string> FilesList = new List<string>();
            string[] Files = Directory.GetFiles(GetScriptPath, string.Format("*.{0}", FileExt));
            foreach (string var in Files)
            {
                FilesList.Add(System.IO.Path.GetFileName(var).ToLower());
            }
            return FilesList;
        }
        #endregion

        #region "根据文件相对路径生成下载Url地址"
        /// <summary>
        /// 根据文件相对路径生成下载Url地址
        /// </summary>
        /// <param name="FilePath">文件相对路径</param>
        /// <returns>加密后Url地址</returns>
        public static string BuildDownFileUrl(string FilePath)
        {
            string MKey = EncryptString(FilePath, FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo.S_RegsionGUID);
            MKey = HttpContext.Current.Server.UrlEncode(MKey);
            return string.Format("{0}?FileName={1}", new System.Web.UI.Control().ResolveUrl("~/Manager/DownLoadfile.aspx"), MKey);
        }
        #endregion

        #region "根据文件扩展名获得文件的content-type"
        /// <summary>
        /// 根据文件扩展名获得文件的content-type
        /// </summary>
        /// <param name="fileextension">文件扩展名如.gif</param>
        /// <returns>文件对应的content-type 如:application/gif</returns>
        public static string GetFileMIME(string fileextension)
        {
            //set the default content-type
            const string DEFAULT_CONTENT_TYPE = "application/unknown";

            RegistryKey regkey, fileextkey;
            string filecontenttype;

            //the file extension to lookup


            try
            {
                //look in HKCR
                regkey = Registry.ClassesRoot;

                //look for extension
                fileextkey = regkey.OpenSubKey(fileextension);

                //retrieve Content Type value
                filecontenttype = fileextkey.GetValue("Content Type", DEFAULT_CONTENT_TYPE).ToString();

                //cleanup
                fileextkey = null;
                regkey = null;
            }
            catch
            {
                filecontenttype = DEFAULT_CONTENT_TYPE;
            }

            return filecontenttype;
        }
        #endregion

        #region "返回状态字符"
        /// <summary>
        /// 根据状态值返回状态字符
        /// </summary>
        /// <param name="i">状态值</param>
        /// <returns>返回字符</returns>
        public static string ReturnStatusInt(int i)
        {
            string rString = "未知";
            switch (i)
            {
                case 0:
                    rString = "正常";
                    break;
                case 1:
                    rString = "禁用";
                    break;
            }
            return rString;
        }
        #endregion

        #region "删除文件"
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="FilePath">删除的文件路径</param>
        /// <param name="PathType">删除文件路径类型</param>
        /// <returns>成功/失败</returns>
        public static bool DeleteFile(string FilePath, DeleteFilePathType PathType)
        {
            bool rBool = false;
            switch (PathType)
            {
                case DeleteFilePathType.DummyPath:
                    FilePath = HttpContext.Current.Server.MapPath(FilePath);
                    break;
                case DeleteFilePathType.NowDirectoryPath:
                    FilePath = HttpContext.Current.Server.MapPath(FilePath);
                    break;
                case DeleteFilePathType.PhysicsPath:
                    break;
            }
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                rBool = true;
            }
            return rBool;
        }
        #endregion

        #region "获得操作系统"
        /// <summary>
        /// 获得操作系统
        /// </summary>
        /// <returns>操作系统名称</returns>
        public static string GetSystem
        {
            get
            {
                string s = HttpContext.Current.Request.UserAgent.Trim().Replace("(", "").Replace(")", "");
                string[] sArray = s.Split(';');
                switch (sArray[2].Trim())
                {
                    case "Windows 4.10":
                        s = "Windows 98";
                        break;
                    case "Windows 4.9":
                        s = "Windows Me";
                        break;
                    case "Windows NT 5.0":
                        s = "Windows 2000";
                        break;
                    case "Windows NT 5.1":
                        s = "Windows XP";
                        break;
                    case "Windows NT 5.2":
                        s = "Windows 2003";
                        break;
                    case "Windows NT 6.0":
                        s = "Windows Vista";
                        break;
                    default:
                        s = "Other";
                        break;
                }
                return s;
            }
        }


        #endregion

        #region "获得状态文字"
        /// <summary>
        /// 获得状态文字
        /// </summary>
        /// <param name="Status">状态类型</param>
        /// <param name="AddWord">附加文字</param>
        /// <returns></returns>
        public static string GetStatTxt(int Status, string AddWord)
        {
            if (Status == 0)
                return "未" + AddWord;
            else
                return "己" + AddWord;
        }
        #endregion

        #region "获得在线统计数据保存环境"
        /// <summary>
        /// 获得在线统计数据保存环境
        /// </summary>
        public static OnlineCountType GetOnlineCountType
        {
            get
            {
                if (GetConfigOnlineCountType == 1)
                    return OnlineCountType.DataBase;
                else
                    return OnlineCountType.Cache;
            }
        }

        /// <summary>
        /// 获得配置在线统计类型
        /// </summary>
        private static int GetConfigOnlineCountType
        {
            get
            {
                int rInt = 0;
                try
                {
                    rInt = Convert.ToInt32(ConfigurationManager.AppSettings["OnlineCountType"]);
                }
                catch (Exception ex)
                {
                    FileTxtLogs.WriteLog(ex.ToString());
                }
                return rInt;
            }
        }
        #endregion

        #region "获得sessionid"
        /// <summary>
        /// 获得sessionid
        /// </summary>
        public static string GetSessionID
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }
        #endregion


        #region "进行base64编码"
        /// <summary>
        /// 进行base64编码
        /// </summary>
        /// <param name="s">字符</param>
        /// <returns></returns>
        public static string EnBase64(string s)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s));
        }
        #endregion

        #region "进行Base64解码"
        /// <summary>
        /// 进行Base64解码
        /// </summary>
        /// <param name="s">字符</param>
        /// <returns></returns>
        public static string DeBase64(string s)
        {
            return System.Text.Encoding.Default.GetString(Convert.FromBase64String(s));
        }
        #endregion 

        #region "获得缓存类配置(命名空间)"
        /// <summary>
        /// 获得缓存类配置(命名空间)
        /// </summary>
        public static string GetCachenamespace
        {
            get
            {
                return ConfigurationManager.AppSettings["Cachenamespace"];
            }
        }
        #endregion

        #region "获得缓存类配置(类名)"
        /// <summary>
        /// 获得缓存类配置(类名)
        /// </summary>
        public static string GetCacheclassName
        {
            get
            {
                return ConfigurationManager.AppSettings["CacheclassName"];
            }
        }
        #endregion 

        #region "将日期类型转换成字符"
        /// <summary>
        /// 将日期类型转换成字符
        /// </summary>
        /// <param name="s">日期</param>
        /// <returns>字符</returns>
        public static string ConvertDate(DateTime? s)
        {
            if (s.HasValue)
                return s.Value.ToString("yyyy/MM/dd");
            else
                return "";
        }
        #endregion 

        #region "格式化TextArea输入内容为html显示"
        /// <summary>
        /// 格式化TextArea输入内容为html显示
        /// </summary>
        /// <param name="s">要格式化内容</param>
        /// <returns>完成内容</returns>
        public static string FormatTextArea(string s)
        {
            s = s.Replace("\n", "<br>");
            s = s.Replace("\x20", "&nbsp;");
            return s;
        }
        #endregion 

        #region "检测Ip地址是否正确"
        /// <summary>
        /// 检测Ip地址是否正确
        /// </summary>
        /// <param name="ip">ip字符串</param>
        /// <returns>正确/不正确</returns>
        public static bool CheckIp(string ip)
        {
            System.Net.IPAddress ipa;
            if (System.Net.IPAddress.TryParse(ip, out ipa))
            {
                ipa = null;
                return true;
            }
            else
            {
                ipa = null;
                return false;
            }
        }
        #endregion

        #region "格式化日期24小时制为字符串如:2008/12/12 21:22:33"
        /// <summary>
        /// 格式化日期24小时制为字符串如:2008-12-12 21:22:33
        /// </summary>
        /// <param name="d">日期</param>
        /// <returns>字符</returns>
        public static string FormatDateToString(DateTime d)
        {
            return d.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region "格式化日期显示为字符"
        /// <summary>
        /// 格式化日期24小时制为字符串如:2008/12/12 21:22:33
        /// </summary>
        /// <param name="d">日期</param>
        /// <returns></returns>
        public static string FormatDateToDispString(DateTime d)
        {
            return d.ToString("yyyy/MM/dd HH:mm:ss");    
        }
        #endregion

        #region "格式化为UTC时间"
        /// <summary>
        /// 格式化为UTC时间
        /// </summary>
        /// <param name="d">时间</param>
        /// <returns>格式化日期</returns>
        public static DateTime FormatDateToUTC(DateTime d)
        {
            return d.ToUniversalTime();
        }

        /// <summary>
        /// 格式化为UTC时间
        /// </summary>
        /// <param name="d">时间字符</param>
        /// <returns>时间</returns>
        public static DateTime FormatDateToUTC(string d)
        {
            return Convert.ToDateTime(d).ToUniversalTime();
        }
        #endregion

        #region  MD5加密 32, 不足的位以0填充
        /// <summary>
        /// MD5加密 32, 不足的位以0填充
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5Encrypt32(string str)
        {
            string code = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像 

            // 加密后是一个字节类型的数组，这里要注意编码的选择　
            byte[] s = md5.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(str));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                // 数组中每一元素值转换成2个字符，不足的位补0
                code = code + s[i].ToString("x").PadLeft(2, '0');
            }

            return code;

        } 
        #endregion

        #region 添加缓存

        /// <summary>
        /// 添加对象至Cache
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="dependencies">缓存依赖项，若无依赖项则传递null</param>
        /// <param name="absoultExpiration">绝对过期时间，如果无绝对过期时间，则传递 null</param>
        /// <param name="slidingExpiration">平滑过期时间，如无平滑过期时间，则传递 null</param>
        public static void AddCache(string key, object val, System.Web.Caching.CacheDependency dependencies, DateTime absoultExpiration, TimeSpan slidingExpiration)
        {
            if (HttpContext.Current.Cache[key] != null)
                HttpContext.Current.Cache.Remove(key);

            HttpContext.Current.Cache.Insert(key, val, dependencies, absoultExpiration, slidingExpiration);
        }

        /// <summary>
        /// 添加缓存，默认为绝对过期（20分钟）
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        public static void AddCache(string key, object val)
        {
            AddCache(key, val, null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 添加缓存，绝对时间后过期
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="expiration">绝对过期时间</param>
        public static void AddCache(string key, object val, DateTime expiration)
        {
            AddCache(key, val, null, expiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 添加缓存，平滑时间过期
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="slidingExpiration">平滑过期时间</param>
        public static void AddCache(string key, object val, TimeSpan slidingExpiration)
        {
            AddCache(key, val, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveCache(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        public static void SetCache(string key, object val)
        {
            HttpContext.Current.Cache[key] = val;
        }


        public static void SetSession(string key,object val)
        {
            //保存sesstion
            HttpContext.Current.Session[key] = val;
        }

        public static object GetSession(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static void SetSession(object val, int timeOut)
        {
            //保存sesstion
            string key = Get_WEBSessionName;
            HttpContext.Current.Session[key] = val;
            HttpContext.Current.Session.Timeout = timeOut;

            //保存cookie
            tsUserEntity tsUser = val as tsUserEntity;
            string val1 = tsUser.ID + "," + tsUser.Nickname.Replace(",","") + "," + tsUser.UID;
            val1= EnBase64(val1);
            SetCookie(val1, timeOut);
        }
      
        public static object GetSession()
        {
            string key = Get_WEBSessionName;

            string val = GetCookie();
            if (val != string.Empty)
            {
                val = DeBase64(val);
                tsUserEntity tsUser = new tsUserEntity();
                string[] arr = val.Split(',');
                if (arr != null && arr.Length >= 3)
                {
                    tsUser.ID = Convert.ToInt32(arr[0]);
                    tsUser.Nickname = arr[1];
                    tsUser.UID = arr[2];
                    return tsUser;
                }
                else
                {
                    return null;
                }
            }
            else {
                return HttpContext.Current.Session[key];
            }
        }

        public static void ClearSession(string key)
        {
            HttpContext.Current.Session[key] = null;
            HttpContext.Current.Session.Abandon();
            ClearClientPageCache();
        }

        public static void ClearSession()
        {
            string key = Get_WEBSessionName;
            HttpContext.Current.Session[key] = null;
            HttpContext.Current.Session.Abandon();
            ClearCookie();
            ClearClientPageCache();
        }

        public static void ReplaceSession()
        {
            string key = Get_WEBSessionName;
            HttpContext.Current.Session[key] = null;
            ClearClientPageCache();
        }


        public static void ClearClientPageCache()
        {
            //清除浏览器缓存
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Cache.SetNoStore();

        }

        public static string GetCookie()
        {
            string name = Get_WEBSessionName;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            return ((cookie != null) ? cookie.Value : string.Empty);
        }

        public static string GetCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            return ((cookie != null) ? cookie.Value : string.Empty);
        }

        public static void SetCookie(string value, int timeOut)
        {
            string name = Get_WEBSessionName;
            HttpCookie cookie1 = new HttpCookie(name);
            cookie1.Value = value;
            cookie1.Expires = DateTime.Now.AddMinutes(timeOut);
            HttpContext.Current.Response.Cookies.Add(cookie1);
        }

        public static void SetCookie(string key,string value, int timeOut)
        {
            string name = key;
            HttpCookie cookie1 = new HttpCookie(name);
            cookie1.Value = value;
            cookie1.Expires = DateTime.Now.AddMinutes(timeOut);
            HttpContext.Current.Response.Cookies.Add(cookie1);
        }

        public static void ClearCookie() {
            string name = Get_WEBSessionName;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                cookie.Values.Remove(name);
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cookie.Expires = DateTime.Now.Add(ts);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        public static void ClearCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                cookie.Values.Remove(key);
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cookie.Expires = DateTime.Now.Add(ts);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        #endregion

        #region 判断是否是移动设备
        public static Boolean IsMobileDevice()
        {
            string[] mobileAgents = { "iphone", "android", "phone", "mobile", "wap", "netfront", "java", "opera mobi", "opera mini", "ucweb", "windows ce", "symbian", "series", "webos", "sony", "blackberry", "dopod", "nokia", "samsung", "palmsource", "xda", "pieplus", "meizu", "midp", "cldc", "motorola", "foma", "docomo", "up.browser", "up.link", "blazer", "helio", "hosin", "huawei", "novarra", "coolpad", "webos", "techfaith", "palmsource", "alcatel", "amoi", "ktouch", "nexian", "ericsson", "philips", "sagem", "wellcom", "bunjalloo", "maui", "smartphone", "iemobile", "spice", "bird", "zte-", "longcos", "pantech", "gionee", "portalmmm", "jig browser", "hiptop", "benq", "haier", "^lct", "320x320", "240x320", "176x220", "w3c ", "acs-", "alav", "alca", "amoi", "audi", "avan", "benq", "bird", "blac", "blaz", "brew", "cell", "cldc", "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq", "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d", "lg-g", "lge-", "maui", "maxo", "midp", "mits", "mmef", "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", "oper", "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap", "sage", "sams", "sany", "sch-", "sec-", "send", "seri", "sgh-", "shar", "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo", "teli", "tim-", "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "Googlebot-Mobile" };
            bool isMoblie = false;
            if (HttpContext.Current.Request.UserAgent.ToString().ToLower() != null)
            {
                for (int i = 0; i < mobileAgents.Length; i++)
                {
                    if (HttpContext.Current.Request.UserAgent.ToString().ToLower().IndexOf(mobileAgents[i]) >= 0)
                    {
                        isMoblie = true;
                        break;
                    }
                }
            }
            if (isMoblie)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion


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

        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, Encoding charset)
        {
            string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";  
            HttpWebRequest request = null;
            //HTTPSQ请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
             
            request.UserAgent = DefaultUserAgent;
            //如果需要POST数据     
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = charset.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }     

        #region "获取WEBSession名称前辍"
        /// <summary>
        /// 获取WEBCache名称前辍
        /// </summary>
        private static string Get_WEBSessionName
        {
            get
            {
                return "FrameWork_SAISAILE_Lzppcc";
            }
        }
        #endregion


        #region MD5 加密转换为小写的
        /// <summary>
        /// MD5 加密转换为小写的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(string str)
        {
            string strMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            return strMD5.ToLower();
        } 
        #endregion


        #region 根据客户端IP获取到省市
        public static string GetIpDetails(string ip)
        {
            string url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
            CookieContainer cookie = null;
            string error = "";
            string str = Common.HttpRun("GET", "utf-8", url, "", ref cookie, 5000, "", "", "", ref error);
            int index = str.IndexOf("\"data\":");
            if (str != "" && index != -1)
            {
                index = index + 7;
                str = str.Substring(index);
                str = "[" + str.Substring(0, str.Length - 1) + "]";
            }
            else
            {
                str = "[]";
            }
            return str;
        } 
        #endregion


        #region MyRegion
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            try
            {
                byte[] bytes = encodeType.GetBytes(source);
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            try
            {
                byte[] bytes = Convert.FromBase64String(result);
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        } 
        #endregion
    }

    #region "枚举类型"
    /// <summary>
    /// 删除文件路径类型
    /// </summary>
    public enum DeleteFilePathType
    {
        /// <summary>
        /// 物理路径
        /// </summary>
        PhysicsPath = 1,
        /// <summary>
        /// 虚拟路径
        /// </summary>
        DummyPath = 2,
        /// <summary>
        /// 当前目录
        /// </summary>
        NowDirectoryPath = 3
    }

    /// <summary>
    /// 获取方式
    /// </summary>
    public enum MethodType
    {
        /// <summary>
        /// Post方式
        /// </summary>
        Post = 1,
        /// <summary>
        /// Get方式
        /// </summary>
        Get = 2
    }

    /// <summary>
    /// 获取数据类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 字符
        /// </summary>
        Str = 1,
        /// <summary>
        /// 日期
        /// </summary>
        Dat = 2,
        /// <summary>
        /// 整型
        /// </summary>
        Int = 3,
        /// <summary>
        /// 长整型
        /// </summary>
        Long = 4,
        /// <summary>
        /// 双精度小数
        /// </summary>
        Double = 5,
        /// <summary>
        /// 只限字符和数字
        /// </summary>
        CharAndNum = 6,
        /// <summary>
        /// 只限邮件地址
        /// </summary>
        Email = 7,
        /// <summary>
        /// 只限字符和数字和中文
        /// </summary>
        CharAndNumAndChinese = 8

    }

    /// <summary>
    /// 表操作方法
    /// </summary>
    public enum DataTable_Action
    {
        /// <summary>
        /// 插入
        /// </summary>
        Insert = 0,
        /// <summary>
        /// 更新
        /// </summary>
        Update = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2
    }
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum OnlineCountType
    {
        /// <summary>
        /// 缓存
        /// </summary>
        Cache = 0,
        /// <summary>
        /// 数据库
        /// </summary>
        DataBase = 1
    }
    #endregion
}