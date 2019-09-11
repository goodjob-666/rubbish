/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved						    *
 *      File:																		*
 *				sys_ConfigDataTable.cs                                  			*
 *      Description:																*
 *				 系统配置表 		            								    *
 *      Author:																		*
 *				Lzppcc														        *
 *				Lzppcc@hotmail.com													*
 *				http://www.supesoft.com												*
 *      Finish DateTime:															*
 *				2007年8月6日														*
 *      History:																	*
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Components
{
    /// <summary>
    /// 系统配置表
    /// </summary>
    [Serializable]
    public class sys_ConfigDataTable
    {
        #region "Private Variables"
        private int _C_UpImgHeight = 120;
        private int _C_UpImgWidth = 180;
        private string _C_UploadPath = "/Manager/Public/";
        private int _C_UploadSizeKb = 1024;
        private string _C_UploadFileExt = "zip,rar,doc,jpg,png,gif,bmp,swf";
        private bool _C_RequestLog = false;
        private string _C_IPLookUrl = "http://www.yahoo.cn/s?p={0}";
        private int _C_LoginErrorDisableMinute = 60;
        private int _C_LoginErrorMaxNum = 20;
        private bool _C_HttpGZip = false;
        private bool _C_CheckUpdate = true;
        private string _C_DisableIp = "";
        private List<string> _C_DisableIpList = new List<string>();
        private bool _C_Enable_Ldap = false;
        private string _C_Ldap_Path = "LDAP://xxx.com.cn/DC=xxx,DC=com,DC=cn"; //LDAP://xxx.com.cn/DC=xxx,DC=com,DC=cn
        private string _C_Ldap_Domain = "xxx.com.cn"; //xxx.com.cn
        #endregion

        #region "Public Variables"

        /// <summary>
        /// 是否启用域认证
        /// </summary>
        public bool C_Enable_Ldap
        {
            get
            {
                return _C_Enable_Ldap;
            }
            set
            {
                _C_Enable_Ldap = value;
            }
        }
        /// <summary>
        /// 域路径
        /// </summary>
        public string C_Ldap_Path
        {
            get
            {
                return _C_Ldap_Path;
            }
            set
            {
                _C_Ldap_Path = value;
            }
        }

        /// <summary>
        /// 认证域
        /// </summary>
        public string C_Ldap_Domain
        {
            get
            {
                return _C_Ldap_Domain;
            }
            set
            {
                _C_Ldap_Domain = value;
            }
        }
        /// <summary>
        /// 禁止登入IP列表(每行一个IP,IP地址段以192.168.1.1-255)
        /// </summary>
        public string C_DisableIp
        {
            get
            {
                return _C_DisableIp;
            }
            set
            {
                _C_DisableIp = value;
                Set_C_DisableIp_List(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<string> C_DisableIpList
        {
            get
            {
                return _C_DisableIpList;
            }
        }



        /// <summary>
        /// 是否自动检测有新版本更新
        /// </summary>
        public bool C_CheckUpdate
        {
            get
            {
                return _C_CheckUpdate;
            }
            set
            {
                _C_CheckUpdate = value;
            }
        }
        /// <summary>
        /// 是否允许GZip压缩输出网页
        /// </summary>
        public bool C_HttpGZip
        {
            get
            {
                return _C_HttpGZip;
            }

            set
            {
                _C_HttpGZip = value;
            }
        }

        /// <summary>
        /// 同一IP同一帐号登入出错,禁止登入时间(默认60)分,设定此值需要重启动应用程序
        /// </summary>
        public int C_LoginErrorDisableMinute
        {
            get
            {
                return _C_LoginErrorDisableMinute;
            }
            set
            {
                _C_LoginErrorDisableMinute = value;
            }
        }
        /// <summary>
        /// 同一IP登入允许出错次数默认为20
        /// </summary>
        public int C_LoginErrorMaxNum
        {
            get
            {
                return _C_LoginErrorMaxNum;
            }
            set
            {
                _C_LoginErrorMaxNum = value;
            }
        }

        /// <summary>
        /// 上传文件扩展名 多个以,号分开
        /// </summary>
        public string C_UploadFileExt
        {
            get
            {
                return _C_UploadFileExt;
            }
            set
            {
                _C_UploadFileExt = value;
            }
        }

        /// <summary>
        /// 上传文件大小(Kb为单位)
        /// </summary>
        public int C_UploadSizeKb
        {
            get
            {
                return _C_UploadSizeKb;
            }
            set
            {
                _C_UploadSizeKb = value;
            }
        }

        /// <summary>
        /// 上传文件路径
        /// </summary>
        public string C_UploadPath
        {
            get
            {
                return _C_UploadPath;
            }
            set
            {
                _C_UploadPath = value;
            }
        }

        /// <summary>
        /// 上传图片缩图高度 默认120
        /// </summary>
        public int C_UpImgHeight
        {
            get
            {
                return _C_UpImgHeight;
            }
            set
            {
                _C_UpImgHeight = value;
            }
        }

        /// <summary>
        /// 上传图片缩图宽度 默认 180
        /// </summary>
        public int C_UpImgWidth
        {
            get
            {
                return _C_UpImgWidth;
            }
            set
            {
                _C_UpImgWidth = value;
            }
        }

        /// <summary>
        /// 是否启用户访问日志 默认为false
        /// </summary>
        public bool C_RequestLog
        {
            get
            {
                return _C_RequestLog;
            }
            set
            {
                _C_RequestLog = value;
            }
        }

        /// <summary>
        /// IP地址查询链接
        /// </summary>
        public string C_IPLookUrl
        {
            get
            {
                return _C_IPLookUrl;
            }
            set
            {
                _C_IPLookUrl = value;
            }
        }
        #endregion

        /// <summary>
        /// 将设置禁止ip转换为ip列表
        /// </summary>
        /// <param name="ip">要转换的ip</param>
        private void Set_C_DisableIp_List(string ip)
        {
            if (_C_DisableIpList == null)
                _C_DisableIpList = new List<string>();
            _C_DisableIpList.Clear();
            string[] ip_array = ip.Split('\n');

            string[] TempVar;
            int StartNum;
            int EndNum;
            string ForIp;
            string StartForIp;

            foreach (string var in ip_array)
            {
                TempVar = var.Split('-');
                if (TempVar.Length != 2)
                {
                    if (FrameWork.Common.CheckIp(TempVar[0].Trim()))
                    {
                        if (!_C_DisableIpList.Contains(TempVar[0].Trim()))
                        {
                            _C_DisableIpList.Add(TempVar[0].Trim());
                        }
                    }
                }
                else
                {
                    if (FrameWork.Common.CheckIp(TempVar[0].Trim()))
                    {
                        try
                        {
                            StartNum = Convert.ToInt32(TempVar[0].Substring(TempVar[0].LastIndexOf(".") + 1));
                            EndNum = Convert.ToInt32(TempVar[1]);
                            ForIp = TempVar[0].Remove(TempVar[0].LastIndexOf("."));
                            for (int i = StartNum; i <= EndNum; i++)
                            {
                                StartForIp = string.Format("{0}.{1}", ForIp, i);
                                if (FrameWork.Common.CheckIp(StartForIp))
                                {
                                    if (!_C_DisableIpList.Contains(StartForIp))
                                    {
                                        _C_DisableIpList.Add(StartForIp);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FrameWork.FileTxtLogs.WriteServiceLog(ex.ToString(), "导入IP出错!");
                        }

                    }
                }
            }
        }


    }
}
