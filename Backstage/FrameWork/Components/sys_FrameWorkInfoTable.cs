/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved						    *
 *      File:																		*
 *				sys_FrameWorkInfoTable.cs                         		        	*
 *      Description:																*
 *				 基础模组版本信息 		            							    *
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
using System.Management;

namespace FrameWork.Components
{
    /// <summary>
    /// 基础模组版本信息
    /// </summary>
    [Serializable]
    public class sys_FrameWorkInfoTable
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public sys_FrameWorkInfoTable()
        {
            try
            {            
                ManagementClass mc = new ManagementClass("Win32_Processor");

                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    _S_RegsionGUID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                mc.Dispose();
            }
            catch (Exception ex)
            {
                _S_RegsionGUID = Common.EnBase64(AppDomain.CurrentDomain.BaseDirectory);
                FileTxtLogs.WriteServiceLog(ex.ToString(), "LoadFrameWorkInfoTable");
            }
        }

        #region "Private Variables"
        private int _S_ProductID = 1;
        private string _S_Name = "Supesoft权限管理系统(FrameWork)";
        private string _S_Version = "1.0.9";
        private S_VersionType _S_Type = S_VersionType.Release;
        private string _S_Licensed = "";
        private string _S_RegsionSystem = Common.GetServerOS;
        private string _S_RegsionIp = Common.GetServerIp;
        private string _S_RegsionDomain = Common.GetServerHost;
        private string _S_RegsionGUID;
        private string _S_RegsionUrl = "http://FrameWork.supesoft.com/";
        private string _S_UpdateUrl = "http://FrameWork.supesoft.com/Manager/UpdateFrameWork.aspx";
        //private string _S_UpdateUrl = "http://localhost:1301/UpdateFrameWork.aspx";
        private string _S_CheckLicensed = "http://FrameWork.supesoft.com/Manager/check.aspx";
        #endregion

        #region "Public Variables"
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductID
        {
            get {
                return _S_ProductID;
            }
        }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string S_Name
        {
            get
            {
                return _S_Name;
            }
            set
            {
                _S_Name = value;
            }
        }
        /// <summary>
        /// 当前版本号
        /// </summary>
        public string S_Version
        {
            get
            {
                return _S_Version;
            }
            set
            {
                _S_Version = value;
            }
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        public S_VersionType S_Type
        {
            get
            {
                return _S_Type;
            }
            set
            {
                _S_Type = value;
            }
        }
        /// <summary>
        /// 产品序列号
        /// </summary>
        public string S_Licensed
        {
            get
            {
                return _S_Licensed;
            }
            set
            {
                _S_Licensed = value;
            }
        }
        /// <summary>
        /// 注册操作系统名称
        /// </summary>
        public string S_RegsionSystem
        {
            get
            {
                return _S_RegsionSystem;
            }
            set
            {
                _S_RegsionSystem = value;
            }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string S_RegsionIp
        {
            get
            {
                return _S_RegsionIp;
            }
            set
            {
                _S_RegsionIp = value;
            }
        }
        /// <summary>
        /// 注册域名
        /// </summary>
        public string S_RegsionDomain
        {
            get
            {
                return _S_RegsionDomain;
            }
            set
            {
                _S_RegsionDomain = value;
            }
        }
        /// <summary>
        /// 注册GUID
        /// </summary>
        public string S_RegsionGUID
        {
            get
            {
                return _S_RegsionGUID;
            }
        }

        /// <summary>
        /// 在线检测更新地址多个以,号分开
        /// </summary>
        public string S_UpdateUrl
        {
            get
            {
                return _S_UpdateUrl;
            }
            set
            {
                _S_UpdateUrl = value;
            }
        }
        /// <summary>
        /// 注册网址
        /// </summary>
        public string S_RegsionUrl
        {
            get
            {
                return _S_RegsionUrl;
            }
            set
            {
                _S_RegsionUrl = value;
            }
        }
        /// <summary>
        /// 检测序列号网址
        /// </summary>
        public string S_CheckLicensed
        {
            get {
                return _S_CheckLicensed;
            }
            set {
                _S_CheckLicensed = value;
            }
        }

        #endregion
    }


    /// <summary>
    /// 版本信息
    /// </summary>
    [Serializable]
    public enum S_VersionType
    {
        /// <summary>
        /// 测试版
        /// </summary>
        Beta = 0,
        /// <summary>
        /// 试用版
        /// </summary>
        Trail = 1,
        /// <summary>
        /// 正式版
        /// </summary>
        Release = 2
    }
}
