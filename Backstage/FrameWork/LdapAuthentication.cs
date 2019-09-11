/*
    Copyright (C) 2011 supesoft.com,All Rights Reserved						    
    File:																		
		    WindowsDomainAuthentication.cs	                                           			
    Description:																
		     windows域认证												    
    Author:																		
		    Lzppcc														        
		    Lzppcc@hotmail.com													
		    http://www.supesoft.com												
    Finish DateTime:															
		    2011年3月6日														
    History:																	
*/
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using FrameWork.Components;

namespace FrameWork
{
    /// <summary>
    /// windows域认证
    /// </summary>
    public class LdapAuthentication:IAuthentication
    {
        /// <summary>
        /// 检测登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否登陆成功</returns>
        public bool checkLogin(string username, string password)
        {
            try
            {
                sys_ConfigDataTable dt = FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData;
                if (!dt.C_Enable_Ldap)
                {
                    return false;
                }
                string strUserName = string.Format("{0}@{1}",username,dt.C_Ldap_Domain);// username + "@xxx.com.cn";

                DirectoryEntry dir = new DirectoryEntry(dt.C_Ldap_Path, strUserName, password);

                int intCount = dir.Properties.Count;
            }
            catch(Exception ex)
            {
                FileTxtLogs.WriteLog(ex.ToString());
                return false;
            }
            return true;
        }
    } 
}
