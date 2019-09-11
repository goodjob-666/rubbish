/*
    Copyright (C) 2011 supesoft.com,All Rights Reserved						    
    File:																		
		    IAuthentication.cs	                                           			
    Description:																
		     认证接口											    
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
using System.Linq;
using System.Text;

namespace FrameWork
{
    /// <summary>
    /// 认证接口
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// 检测用户登入
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        bool checkLogin(string username, string password);

        
    }
}
