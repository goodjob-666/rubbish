/*
    Copyright (C) 2009 supesoft.com,All Rights Reserved						    
    File:																		
		    FrameWorkMenuTree.cs	                                           			
    Description:																
		     树状菜单html												    
    Author:																		
		    Lzppcc														        
		    Lzppcc@hotmail.com													
		    http://www.supesoft.com												
    Finish DateTime:															
		    2009年7月25日														
    History:																	
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FrameWork.Components;

namespace FrameWork
{
    /// <summary>
    /// 树状菜单html
    /// </summary>
    public class FrameWorkMenuTree
    {

        #region "获得模块所在树状级数"
        /// <summary>
        /// 获得模块所在树状级数
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <returns>所在级数</returns>
        public static int GetModuleLevel(int moduleid)
        {
            int level = 1;
            GetLevel(moduleid, ref level);
            return level;
        }

        /// <summary>
        /// 获得模块所在级别
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <param name="level">级别</param>
        private static void GetLevel(int moduleid, ref int level)
        {
            //BusinessFacade.sys_ModuleDisp(moduleid);
            sys_ModuleTable mt = new sys_ModuleTable();
            if (sys_Module_Cache.Sys_moduleCache.TryGetValue(moduleid, out mt))
            {
                level++;
                GetLevel(mt.M_ParentID, ref level);
            }
        }
        #endregion

        #region "根据模块id,获得所有子类值"
        /// <summary>
        /// 根据模块id,获得所有子类值
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <returns>模块集合</returns>
        public static List<sys_ModuleTable> GetAllSubModule(int moduleid)
        {
            List<sys_ModuleTable> lst = new List<sys_ModuleTable>();
            GetModule(moduleid, lst);
            sys_ModuleTable mt = sys_Module_Cache.Sys_moduleCache[moduleid]; //BusinessFacade.sys_ModuleDisp(moduleid);
            if (mt.ModuleID != 0)
                lst.Add(mt);
            return lst;
        }
        #endregion

        #region "获得子模块"
        /// <summary>
        /// 获得子模块
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <param name="modules">模块集合</param>
        private static void GetModule(int moduleid, List<sys_ModuleTable> modules)
        {
            /*
            QueryParam qp = new QueryParam();
            qp.Orderfld = " M_Applicationid,M_OrderLevel ";
            qp.OrderType = 0;
            qp.Where = string.Format("Where M_ParentID={0}", moduleid);
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
            */
            List<sys_ModuleTable> lst = sys_Module_Cache.Sys_moduleTreeCache[moduleid];
            int RecordCount = lst.Count;
            if (RecordCount > 0)
            {
                foreach (sys_ModuleTable var in lst)
                {
                    modules.Add(var);
                    GetModule(var.ModuleID, modules);
                }
            }

        }
        #endregion

        #region "获得树状菜单html"
        /// <summary>
        /// 获得树状菜单html
        /// </summary>
        /// <returns>菜单html</returns>
        public static string GetMenuTree()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<dl id=\"TopDL\">");
            /*
            QueryParam qp = new QueryParam();
            qp.Orderfld = " M_Applicationid,M_OrderLevel ";
            qp.OrderType = 0;
            qp.Where = Common.ApplicationID != 0 ? string.Format("Where M_Close=0 and M_ParentID=0 and M_ApplicationID ={0}", Common.ApplicationID) : "Where M_Close=0 and M_ParentID=0 ";
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                        foreach (sys_ModuleTable var in lst)
            {
                GetTree(var.ModuleID, sb, allowkey);
            }
             */
            SortedList<int, string> allowkey = GetUserAllMenuID;

            foreach (int var in sys_Module_Cache.Sys_moduletopCache.Keys)
            {
                if (Common.ApplicationID == 0)
                {
                    BuildTreeHtml(sb, var, allowkey, CheckTwoApplicationTree(allowkey));
                }
                else
                {
                    if (var == Common.ApplicationID)
                    {
                        BuildTreeHtml(sb, var, allowkey,false);
                    }
                }
            }

            sb.Append("</dl>");

            return sb.ToString();
        }

        private static void BuildTreeHtml(StringBuilder sb, int var, SortedList<int, string> allowkey,bool dispapplication)
        {
            if (CheckApplicationTree(var, allowkey))
            {
                if (dispapplication)
                {
                    sb.AppendFormat("<dd>{0}", BusinessFacade.sys_ApplicationsDisp(var).A_AppName);
                    sb.Append("<dl>");
                }
                foreach (sys_ModuleTable var2 in sys_Module_Cache.Sys_moduletopCache[var])
                {
                    GetTree(var2.ModuleID, sb, allowkey);
                }
                if (dispapplication)
                {
                    sb.Append("</dl>");
                    sb.Append("</dd>");
                }
            }
        }

        /// <summary>
        /// 检测当前用户是否具有多个应用权限
        /// </summary>
        /// <param name="allowkey">用户权限菜单id</param>
        /// <returns>成功/失败</returns>
        static bool CheckTwoApplicationTree(SortedList<int, string> allowkey)
        {
            int i = 0;
            foreach (int var in sys_Module_Cache.Sys_moduletopCache.Keys)
            {
                if (CheckApplicationTree(var, allowkey))
                {
                    i++;
                    if (i >= 2)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检测当前用户是否具有应用权限
        /// </summary>
        /// <param name="applicationid">应用id</param>
        /// <param name="allowkey">当前用户菜单id</param>
        /// <returns></returns>
        private static bool CheckApplicationTree(int applicationid, SortedList<int, string> allowkey)
        {
            bool rbool = false;
            foreach (sys_ModuleTable var2 in sys_Module_Cache.Sys_moduletopCache[applicationid])
            {
                if (allowkey.ContainsKey(var2.ModuleID))
                {
                    return true;
                }
            }
            return rbool;
        }

        /// <summary>
        /// 获得子分类html
        /// </summary>
        /// <param name="parentid">父级ID</param>
        /// <param name="sb">字符串</param>
        /// <param name="allowkey">允许的模块id</param>
        private static void GetTree(int parentid, StringBuilder sb, SortedList<int, string> allowkey)
        {
            if (allowkey.ContainsKey(parentid))
            {
                sys_ModuleTable mt = sys_Module_Cache.Sys_moduleCache[parentid]; //BusinessFacade.sys_ModuleDisp(parentid);
                if (mt.ModuleID != 0)
                {
                    //sb.AppendFormat("<dt><a href=\"{0}\" target=\"mainFrame\">{1}</a></dt>", mt.M_Directory, mt.M_CName);

                    /*
                    QueryParam qp = new QueryParam();
                    qp.Orderfld = " M_Applicationid,M_OrderLevel ";
                    qp.OrderType = 0;
                    qp.Where = string.Format("Where M_Close=0 and M_ParentID={0}", parentid);
                    int RecordCount = 0;
                    ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                    */
                    List<sys_ModuleTable> lst = sys_Module_Cache.Sys_moduleTreeCache[parentid];
                    int RecordCount = lst.Count;
                    if (RecordCount > 0)
                    {
                        sb.AppendFormat("<dd>{0}", mt.M_CName);
                        sb.Append("<dl>");
                        foreach (sys_ModuleTable var in lst)
                        {
                            GetTree(var.ModuleID, sb, allowkey);
                        }
                        sb.Append("</dl>");
                        sb.Append("</dd>");
                    }
                    else
                    {
                        //sb.AppendFormat("<dt><a href=\"{0}\" target=\"mainFrame\">{1}</a></dt>", mt.M_Directory, mt.M_CName);
                        sb.AppendFormat("<dt onclick=\"javascript:window.parent.frames['mainFrame'].location='{1}';\">{0}</dt>", mt.M_CName, mt.M_Directory);
                    }
                }
            }
        }

        /// <summary>
        /// 获得当前登陆用户允许权限的模块ID集合
        /// </summary>
        private static SortedList<int, string> GetUserAllMenuID
        {
            get
            {
                SortedList<int, string> lst = new SortedList<int, string>();
                /*
                QueryParam qp = new QueryParam();
                qp.Orderfld = " M_Applicationid,M_OrderLevel ";
                qp.OrderType = 0;
                qp.Where = Common.ApplicationID != 0 ? string.Format("Where M_Close=0 and M_ParentID=0 and M_ApplicationID ={0}", Common.ApplicationID) : "Where M_Close=0 and M_ParentID=0 ";
                int RecordCount = 0;
                ArrayList Alllst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                */
                List<sys_ModuleTable> Alllst = new List<sys_ModuleTable>();
                if (Common.ApplicationID != 0)
                {
                    foreach (sys_ModuleTable var in sys_Module_Cache.Sys_moduletopCache[Common.ApplicationID])
                    {
                        Alllst.Add(var);
                    }
                }
                else
                {
                    foreach (List<sys_ModuleTable> var in sys_Module_Cache.Sys_moduletopCache.Values)
                    {
                        foreach (sys_ModuleTable var1 in var)
                        {
                            Alllst.Add(var1);
                        }
                    }
                }

                List<sys_ModuleTable> lstLast;
                List<int> lstids = new List<int>();
                foreach (sys_ModuleTable var in Alllst)
                {
                    lstLast = GetModuleAllLastIDs(var.ModuleID);
                    foreach (sys_ModuleTable var2 in lstLast)
                    {
                        if (UserData.CheckPageCode(Common.Get_UserID, var2.M_ApplicationID, var2.M_PageCode))
                        {
                            lstids.Clear();
                            GetSubModuleIds(var2.ModuleID, lstids);
                            foreach (int x in lstids)
                            {
                                if (!lst.ContainsKey(x))
                                {
                                    lst.Add(x, x.ToString());
                                }
                            }
                        }
                    }
                }
                return lst;
            }
        }

        /// <summary>
        /// 根据模块ID,获取模块ID的全路径id集合
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="lst">路径id集合</param>
        /// <returns></returns>
        private static void GetSubModuleIds(int ModuleID, List<int> lst)
        {
            //sys_ModuleTable mt = BusinessFacade.sys_ModuleDisp(ModuleID);
            //if (mt.ModuleID > 0)
            sys_ModuleTable mt = new sys_ModuleTable();
            if (sys_Module_Cache.Sys_moduleCache.TryGetValue(ModuleID, out mt))
            {
                lst.Add(mt.ModuleID);
                if (mt.M_ParentID != 0)
                    GetSubModuleIds(mt.M_ParentID, lst);
            }
        }

        #endregion

        #region "判断当前模块id是否为最底层模块"
        /// <summary>
        /// 判断当前模块id是否为最底层模块
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <returns>是/否</returns>
        public static bool CheckModuleLastLevel(int moduleid)
        {
            bool rbool = true;
            /*
            QueryParam qp = new QueryParam();
            qp.Orderfld = " M_Applicationid,M_OrderLevel ";
            qp.OrderType = 0;
            qp.Where = string.Format("Where M_ParentID={0}", moduleid);
            int RecordCount = 0;
            ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                rbool = false;
            }
            */
            List<sys_ModuleTable> lst = sys_Module_Cache.Sys_moduleTreeCache[moduleid];
            if (lst.Count > 0)
                return false;
            return rbool;
        }
        #endregion

        #region "获得模块ID的所有叶节点"
        /// <summary>
        /// 获得模块ID的所有叶节点
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <returns>所有叶节点</returns>
        public static List<sys_ModuleTable> GetModuleAllLastIDs(int moduleid)
        {
            List<sys_ModuleTable> lst = new List<sys_ModuleTable>();
            //lst.Add((sys_Module_Cache.Sys_moduleCache[moduleid])); //增加当前自身id
            if (sys_Module_Cache.Sys_moduleTreeCache.ContainsKey(moduleid))
            {
                if (sys_Module_Cache.Sys_moduleTreeCache[moduleid].Count == 0)
                {
                    lst.Add((sys_Module_Cache.Sys_moduleCache[moduleid])); //增加当前自身id
                }
            }
            GetLastIDs(moduleid, lst);
            //UpdateLastIdName(lst);
            return lst;
        }

        /// <summary>
        /// 获得所有叶节点实体类
        /// </summary>
        /// <param name="moduleid">模块id</param>
        /// <param name="lastIds">节点实体类集合</param>
        private static void GetLastIDs(int moduleid, List<sys_ModuleTable> lastIds)
        {
            sys_ModuleTable mt = new sys_ModuleTable();
            if (sys_Module_Cache.Sys_moduleCache.TryGetValue(moduleid, out mt))
            {
                /*
                QueryParam qp = new QueryParam();
                qp.Orderfld = " M_Applicationid,M_OrderLevel ";
                qp.OrderType = 0;
                qp.Where = string.Format("Where M_ParentID={0}", moduleid);
                int RecordCount = 0;
                ArrayList lst = BusinessFacade.sys_ModuleList(qp, out RecordCount);
                */
                List<sys_ModuleTable> lst = sys_Module_Cache.Sys_moduleTreeCache[moduleid];
                if (lst.Count > 0)
                {
                    foreach (sys_ModuleTable var in lst)
                    {
                        GetLastIDs(var.ModuleID, lastIds);
                    }
                }
                else
                {
                    if (mt.M_ParentID != 0)
                        lastIds.Add(mt);
                }
            }
        }

        /// <summary>
        /// 更新叶节点的名称为全称
        /// </summary>
        /// <param name="lst">叶节点集合</param>
        private static void UpdateLastIdName(List<sys_ModuleTable> lst)
        {
            string title = "";
            foreach (sys_ModuleTable var in lst)
            {
                title = GetModuleTitle(var.ModuleID);
                var.M_CName = (title.Length > 0) ? title.Substring(1) : title;
            }
        }

        /// <summary>
        /// 获取模块标题路径
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public static string GetModuleTitle(int ModuleID)
        {
            /*
            int TotalRecord = 0;
            QueryParam qp = new QueryParam();
            qp.Where = " where ModuleID =  " + ModuleID;
            qp.PageIndex = 1;
            qp.PageSize = 1;
            ArrayList lst = BusinessFacade.sys_ModuleList(qp, out TotalRecord);
            if (TotalRecord == 1)
            {
                foreach (sys_ModuleTable x in lst)
                {
                    if (x.M_ParentID != 0)
                        return GetModuleTitle(x.M_ParentID) + ">" + x.M_CName;
                    else
                        return GetModuleTitle(x.M_ParentID);
                }
            }
            return "";
            */

            sys_ModuleTable x = new sys_ModuleTable();
            if (sys_Module_Cache.Sys_moduleCache.TryGetValue(ModuleID, out x))
            {

                if (x.M_ParentID != 0)
                    return GetModuleTitle(x.M_ParentID) + ">" + x.M_CName;
                else
                    return ">"+x.M_CName; //return "";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
