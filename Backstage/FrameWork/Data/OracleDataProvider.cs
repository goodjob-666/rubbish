/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved					 
 *      File:																 
 *				OracleDataProvider.cs                     	                 
 *      Description:															 
 *				 Oracle数据库访问类    	   							         
 *      Author:																 
 *				Lzppcc														 
 *				Lzppcc@hotmail.com											 
 *				http://www.supesoft.com										 
 *      Finish DateTime:														 
 *				2008-2-7 16:24:10													 
 *      History:																 
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OracleClient;

using FrameWork.Components;


namespace FrameWork.Data
{
    /// <summary>
    /// Oracle数据库访问类
    /// </summary>
    public class OracleDataProvider : DataProvider
    {
        #region "OracleDataProvider"
        private string ConnString = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OracleDataProvider()
        {
            ConnString = Common.GetConnString;
        }

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <returns></returns>
        private OracleConnection GetSqlConnection()
        {
            try
            {
                return new OracleConnection(ConnString);
            }
            catch
            {
                throw new Exception("没有提供数据庫连接字符串！");
            }
        }
        #endregion

        #region "sys_Group - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Group
        /// </summary>
        /// <param name="fam">sys_GroupTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_GroupInsertUpdate(sys_GroupTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Group(GroupID,G_CName,G_ParentID,G_ShowOrder,G_Level,G_ChildCount,G_Delete)VALUES(SEQ_sys_Group_ID.NEXTVAL,:G_CName,:G_ParentID,:G_ShowOrder,:G_Level,:G_ChildCount,:G_Delete)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("G_CName", OracleType.NVarChar).Value = fam.G_CName + ""; //分类中文说明	
                    cmd.Parameters.Add("G_ParentID", OracleType.Int32).Value = fam.G_ParentID; //上级分类ID0:为最高级	
                    cmd.Parameters.Add("G_ShowOrder", OracleType.Int32).Value = fam.G_ShowOrder; //显示顺序	
                    cmd.Parameters.Add("G_Level", OracleType.Int32).Value = fam.G_Level; //当前分类所在层数	
                    cmd.Parameters.Add("G_ChildCount", OracleType.Int32).Value = fam.G_ChildCount; //当前分类子分类数
                    cmd.Parameters.Add("G_Delete", OracleType.SByte).Value = fam.G_Delete; //是否删除1:是0:否
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Group SET	G_CName = :G_CName,G_ParentID = :G_ParentID,G_ShowOrder = :G_ShowOrder,G_Level = :G_Level,G_ChildCount = :G_ChildCount,G_Delete = :G_Delete WHERE (GroupID = :GroupID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("G_CName", OracleType.NVarChar).Value = fam.G_CName + ""; //分类中文说明	
                    cmd.Parameters.Add("G_ParentID", OracleType.Int32).Value = fam.G_ParentID; //上级分类ID0:为最高级	
                    cmd.Parameters.Add("G_ShowOrder", OracleType.Int32).Value = fam.G_ShowOrder; //显示顺序	
                    cmd.Parameters.Add("G_Level", OracleType.Int32).Value = fam.G_Level; //当前分类所在层数	
                    cmd.Parameters.Add("G_ChildCount", OracleType.Int32).Value = fam.G_ChildCount; //当前分类子分类数
                    cmd.Parameters.Add("G_Delete", OracleType.SByte).Value = fam.G_Delete; //是否删除1:是0:否
                    cmd.Parameters.Add("GroupID", OracleType.Int32).Value = fam.GroupID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Group  WHERE (GroupID = :GroupID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("GroupID", OracleType.Int32).Value = fam.GroupID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Group_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_GroupTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_GroupTable实体类的ArrayList对象</returns>
        public override ArrayList sys_GroupList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Group);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion




        #region "sys_Module - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Module
        /// </summary>
        /// <param name="fam">sys_ModuleTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_ModuleInsertUpdate(sys_ModuleTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close,M_Icon,M_Info)VALUES(SEQ_sys_Module_ID.NEXTVAL,:M_ApplicationID,:M_ParentID,:M_PageCode,:M_CName,:M_Directory,:M_OrderLevel,:M_IsSystem,:M_Close,:M_Icon,:M_Info)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("M_ApplicationID", OracleType.Int32).Value = fam.M_ApplicationID; //所属应用程序ID	
                    cmd.Parameters.Add("M_ParentID", OracleType.Int32).Value = fam.M_ParentID; //所属父级模块ID与ModuleID关联,0为顶级	
                    cmd.Parameters.Add("M_PageCode", OracleType.VarChar).Value = fam.M_PageCode + ""; //模块编码Parent为0,则为S00(xx),否则为S00M00(xx)
                    cmd.Parameters.Add("M_CName", OracleType.NVarChar).Value = fam.M_CName + ""; //模块/栏目名称当ParentID为0为模块名称
                    cmd.Parameters.Add("M_Directory", OracleType.NVarChar).Value = fam.M_Directory + ""; //模块/栏目目录名	
                    cmd.Parameters.Add("M_OrderLevel", OracleType.VarChar).Value = fam.M_OrderLevel + ""; //当前所在排序级别支持双层99级菜单
                    cmd.Parameters.Add("M_IsSystem", OracleType.SByte).Value = fam.M_IsSystem; //是否为系统模块1:是0:否如为系统则无法修改
                    cmd.Parameters.Add("M_Close", OracleType.SByte).Value = fam.M_Close; //是否关闭1:是0:否	
                    cmd.Parameters.Add("M_Icon", OracleType.VarChar).Value = fam.M_Icon + ""; //模块Icon
                    cmd.Parameters.Add("M_Info", OracleType.NVarChar).Value = fam.M_Info + ""; //模块说明
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Module SET	M_ApplicationID = :M_ApplicationID,M_ParentID = :M_ParentID,M_PageCode = :M_PageCode,M_CName = :M_CName,M_Directory = :M_Directory,M_OrderLevel = :M_OrderLevel,M_IsSystem = :M_IsSystem,M_Close = :M_Close,M_Icon = :M_Icon,M_Info = :M_Info WHERE (ModuleID = :ModuleID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("M_ApplicationID", OracleType.Int32).Value = fam.M_ApplicationID; //所属应用程序ID	
                    cmd.Parameters.Add("M_ParentID", OracleType.Int32).Value = fam.M_ParentID; //所属父级模块ID与ModuleID关联,0为顶级	
                    cmd.Parameters.Add("M_PageCode", OracleType.VarChar).Value = fam.M_PageCode + ""; //模块编码Parent为0,则为S00(xx),否则为S00M00(xx)
                    cmd.Parameters.Add("M_CName", OracleType.NVarChar).Value = fam.M_CName + ""; //模块/栏目名称当ParentID为0为模块名称
                    cmd.Parameters.Add("M_Directory", OracleType.NVarChar).Value = fam.M_Directory + ""; //模块/栏目目录名	
                    cmd.Parameters.Add("M_OrderLevel", OracleType.VarChar).Value = fam.M_OrderLevel + ""; //当前所在排序级别支持双层99级菜单
                    cmd.Parameters.Add("M_IsSystem", OracleType.SByte).Value = fam.M_IsSystem; //是否为系统模块1:是0:否如为系统则无法修改
                    cmd.Parameters.Add("M_Close", OracleType.SByte).Value = fam.M_Close; //是否关闭1:是0:否	
                    cmd.Parameters.Add("M_Icon", OracleType.VarChar).Value = fam.M_Icon + ""; //模块Icon
                    cmd.Parameters.Add("M_Info", OracleType.NVarChar).Value = fam.M_Info + ""; //模块说明
                    cmd.Parameters.Add("ModuleID", OracleType.Int32).Value = fam.ModuleID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Module  WHERE (ModuleID = :ModuleID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("ModuleID", OracleType.Int32).Value = fam.ModuleID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Module_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_ModuleTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_ModuleTable实体类的ArrayList对象</returns>
        public override ArrayList sys_ModuleList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Module);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion


        #region "sys_RoleApplication - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_RoleApplication
        /// </summary>
        /// <param name="fam">sys_RoleApplicationTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_RoleApplicationInsertUpdate(sys_RoleApplicationTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_RoleApplication(A_RoleID,A_ApplicationID)VALUES(:A_RoleID,:A_ApplicationID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("A_RoleID", OracleType.Int32).Value = fam.A_RoleID; //角色ID与sys_Roles中RoleID相关	
                    cmd.Parameters.Add("A_ApplicationID", OracleType.Int32).Value = fam.A_ApplicationID; //应用ID与sys_Applications中Appl
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_RoleApplication SET	A_RoleID = :A_RoleID,A_ApplicationID = :A_ApplicationID WHERE (A_RoleID= :A_RoleID and A_ApplicationID = :A_ApplicationID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("A_RoleID", OracleType.Int32).Value = fam.A_RoleID; //角色ID与sys_Roles中RoleID相关	
                    cmd.Parameters.Add("A_ApplicationID", OracleType.Int32).Value = fam.A_ApplicationID; //应用ID与sys_Applications中Appl
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_RoleApplication  WHERE (A_RoleID= :A_RoleID and A_ApplicationID = :A_ApplicationID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("A_RoleID", OracleType.Int32).Value = fam.A_RoleID; //角色ID与sys_Roles中RoleID相关	
                    cmd.Parameters.Add("A_ApplicationID", OracleType.Int32).Value = fam.A_ApplicationID; //应用ID与sys_Applications中Appl
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_RoleApplicationTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_RoleApplicationTable实体类的ArrayList对象</returns>
        public override ArrayList sys_RoleApplicationList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_RoleApplication);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_RolePermission - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_RolePermission
        /// </summary>
        /// <param name="fam">sys_RolePermissionTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_RolePermissionInsertUpdate(sys_RolePermissionTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_RolePermission(PermissionID,P_RoleID,P_ApplicationID,P_PageCode,P_Value)VALUES(SEQ_sys_RolePermission_ID.NEXTVAL,:P_RoleID,:P_ApplicationID,:P_PageCode,:P_Value)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("P_RoleID", OracleType.Int32).Value = fam.P_RoleID; //角色ID与sys_Roles表中RoleID相	
                    cmd.Parameters.Add("P_ApplicationID", OracleType.Int32).Value = fam.P_ApplicationID; //角色所属应用ID与sys_Applicatio	
                    cmd.Parameters.Add("P_PageCode", OracleType.VarChar).Value = fam.P_PageCode + ""; //角色应用中页面权限代码	
                    cmd.Parameters.Add("P_Value", OracleType.Int32).Value = fam.P_Value; //权限值
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_RolePermission SET	P_RoleID = :P_RoleID,P_ApplicationID = :P_ApplicationID,P_PageCode = :P_PageCode,P_Value = :P_Value WHERE (PermissionID = :PermissionID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("P_RoleID", OracleType.Int32).Value = fam.P_RoleID; //角色ID与sys_Roles表中RoleID相	
                    cmd.Parameters.Add("P_ApplicationID", OracleType.Int32).Value = fam.P_ApplicationID; //角色所属应用ID与sys_Applicatio	
                    cmd.Parameters.Add("P_PageCode", OracleType.VarChar).Value = fam.P_PageCode + ""; //角色应用中页面权限代码	
                    cmd.Parameters.Add("P_Value", OracleType.Int32).Value = fam.P_Value; //权限值
                    cmd.Parameters.Add("PermissionID", OracleType.Int32).Value = fam.PermissionID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_RolePermission  WHERE (PermissionID = :PermissionID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("PermissionID", OracleType.Int32).Value = fam.PermissionID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_RolePermission_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_RolePermissionTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_RolePermissionTable实体类的ArrayList对象</returns>
        public override ArrayList sys_RolePermissionList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_RolePermission);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion


        #region "sys_Roles - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Roles
        /// </summary>
        /// <param name="fam">sys_RolesTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_RolesInsertUpdate(sys_RolesTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Roles(RoleID,R_UserID,R_RoleName,R_Description)VALUES(SEQ_sys_Roles_ID.NEXTVAL,:R_UserID,:R_RoleName,:R_Description)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("R_UserID", OracleType.Int32).Value = fam.R_UserID; //角角所属用户ID
                    cmd.Parameters.Add("R_RoleName", OracleType.NVarChar).Value = fam.R_RoleName + ""; //角色名称
                    cmd.Parameters.Add("R_Description", OracleType.NVarChar).Value = fam.R_Description + ""; //角色介绍
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Roles SET	R_UserID = :R_UserID,R_RoleName = :R_RoleName,R_Description = :R_Description WHERE (RoleID = :RoleID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("R_UserID", OracleType.Int32).Value = fam.R_UserID; //角角所属用户ID
                    cmd.Parameters.Add("R_RoleName", OracleType.NVarChar).Value = fam.R_RoleName + ""; //角色名称
                    cmd.Parameters.Add("R_Description", OracleType.NVarChar).Value = fam.R_Description + ""; //角色介绍
                    cmd.Parameters.Add("RoleID", OracleType.Int32).Value = fam.RoleID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Roles  WHERE (RoleID = :RoleID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("RoleID", OracleType.Int32).Value = fam.RoleID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Roles_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_RolesTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_RolesTable实体类的ArrayList对象</returns>
        public override ArrayList sys_RolesList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Roles);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion


        #region "sys_SystemInfo - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_SystemInfo
        /// </summary>
        /// <param name="fam">sys_SystemInfoTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_SystemInfoInsertUpdate(sys_SystemInfoTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_SystemInfo(SystemID,S_Name,S_Version,S_SystemConfigData,S_Licensed)VALUES(SEQ_sys_SystemInfo_ID.NEXTVAL,:S_Name,:S_Version,:S_SystemConfigData,:S_Licensed)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("S_Name", OracleType.NVarChar).Value = fam.S_Name + ""; //系统名称
                    cmd.Parameters.Add("S_Version", OracleType.NVarChar).Value = fam.S_Version + ""; //版本号
                    cmd.Parameters.Add("S_SystemConfigData", OracleType.LongRaw).Value = FrameSystemInfo.Serializable_sys_ConfigDataTable(fam.S_SystemConfigData);  //系统配置信息	
                    cmd.Parameters.Add("S_Licensed", OracleType.VarChar).Value = fam.S_Licensed + ""; //序列号
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_SystemInfo SET	S_Name = :S_Name,S_Version = :S_Version,S_SystemConfigData = :S_SystemConfigData,S_Licensed = :S_Licensed WHERE (SystemID = :SystemID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("S_Name", OracleType.NVarChar).Value = fam.S_Name + ""; //系统名称
                    cmd.Parameters.Add("S_Version", OracleType.NVarChar).Value = fam.S_Version + ""; //版本号
                    cmd.Parameters.Add("S_SystemConfigData", OracleType.LongRaw).Value = FrameSystemInfo.Serializable_sys_ConfigDataTable(fam.S_SystemConfigData);  //系统配置信息	
                    cmd.Parameters.Add("S_Licensed", OracleType.VarChar).Value = fam.S_Licensed + ""; //序列号
                    cmd.Parameters.Add("SystemID", OracleType.Int32).Value = fam.SystemID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_SystemInfo  WHERE (SystemID = :SystemID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("SystemID", OracleType.Int32).Value = fam.SystemID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_SystemInfo_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_SystemInfoTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_SystemInfoTable实体类的ArrayList对象</returns>
        public override ArrayList sys_SystemInfoList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_SystemInfo);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_User - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_User
        /// </summary>
        /// <param name="fam">sys_UserTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_UserInsertUpdate(sys_UserTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_User(UserID,U_LoginName,U_Password,U_CName,U_EName,U_GroupID,U_Email,U_Type,U_Status,U_Licence,U_Mac,U_Remark,U_IDCard,U_Sex,U_BirthDay,U_MobileNo,U_UserNO,U_WorkStartDate,U_WorkEndDate,U_CompanyMail,U_Title,U_Extension,U_HomeTel,U_PhotoUrl,U_DateTime,U_LastIP,U_LastDateTime,U_ExtendField,U_LoginType)VALUES(SEQ_sys_User_ID.NEXTVAL,:U_LoginName,:U_Password,:U_CName,:U_EName,:U_GroupID,:U_Email,:U_Type,:U_Status,:U_Licence,:U_Mac,:U_Remark,:U_IDCard,:U_Sex,:U_BirthDay,:U_MobileNo,:U_UserNO,:U_WorkStartDate,:U_WorkEndDate,:U_CompanyMail,:U_Title,:U_Extension,:U_HomeTel,:U_PhotoUrl,:U_DateTime,:U_LastIP,:U_LastDateTime,:U_ExtendField,:U_LoginType)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("U_LoginName", OracleType.NVarChar).Value = fam.U_LoginName + ""; //登陆名	
                    cmd.Parameters.Add("U_Password", OracleType.VarChar).Value = fam.U_Password + ""; //密码md5加密字符
                    cmd.Parameters.Add("U_CName", OracleType.NVarChar).Value = fam.U_CName + ""; //中文姓名	
                    cmd.Parameters.Add("U_EName", OracleType.VarChar).Value = fam.U_EName + ""; //英文名	
                    cmd.Parameters.Add("U_GroupID", OracleType.Int32).Value = fam.U_GroupID; //部门ID号与sys_Group表中GroupID关联	
                    cmd.Parameters.Add("U_Email", OracleType.VarChar).Value = fam.U_Email + ""; //电子邮件
                    cmd.Parameters.Add("U_Type", OracleType.SByte).Value = fam.U_Type; //用户类型0:超级用户1:普通用户
                    cmd.Parameters.Add("U_Status", OracleType.SByte).Value = fam.U_Status; //当前状态0:正常 1:禁止登陆 2:删除	
                    cmd.Parameters.Add("U_Licence", OracleType.VarChar).Value = fam.U_Licence + ""; //用户序列号	
                    cmd.Parameters.Add("U_Mac", OracleType.VarChar).Value = fam.U_Mac + ""; //锁定机器硬件地址
                    cmd.Parameters.Add("U_Remark", OracleType.NVarChar).Value = fam.U_Remark + ""; //备注说明	
                    cmd.Parameters.Add("U_IDCard", OracleType.VarChar).Value = fam.U_IDCard + ""; //身份证号码
                    cmd.Parameters.Add("U_Sex", OracleType.SByte).Value = fam.U_Sex; //性别1:男0:女	
                    if (fam.U_BirthDay.HasValue)
                        cmd.Parameters.Add("U_BirthDay", OracleType.DateTime).Value = fam.U_BirthDay; //出生日期	
                    else
                        cmd.Parameters.Add("U_BirthDay", OracleType.DateTime).Value = DBNull.Value; //出生日期	
                    cmd.Parameters.Add("U_MobileNo", OracleType.VarChar).Value = fam.U_MobileNo + ""; //手机号	
                    cmd.Parameters.Add("U_UserNO", OracleType.VarChar).Value = fam.U_UserNO + ""; //员工编号	
                    if (fam.U_WorkStartDate.HasValue)
                        cmd.Parameters.Add("U_WorkStartDate", OracleType.DateTime).Value = fam.U_WorkStartDate; //到职日期	
                    else
                        cmd.Parameters.Add("U_WorkStartDate", OracleType.DateTime).Value = DBNull.Value; //到职日期	
                    if (fam.U_WorkEndDate.HasValue)
                        cmd.Parameters.Add("U_WorkEndDate", OracleType.DateTime).Value = fam.U_WorkEndDate; //离职日期	
                    else
                        cmd.Parameters.Add("U_WorkEndDate", OracleType.DateTime).Value = DBNull.Value; //离职日期	
                    cmd.Parameters.Add("U_CompanyMail", OracleType.VarChar).Value = fam.U_CompanyMail + ""; //公司邮件地址	
                    cmd.Parameters.Add("U_Title", OracleType.Int32).Value = fam.U_Title; //职称与应用字段关联	
                    cmd.Parameters.Add("U_Extension", OracleType.VarChar).Value = fam.U_Extension + ""; //分机号	
                    cmd.Parameters.Add("U_HomeTel", OracleType.VarChar).Value = fam.U_HomeTel + ""; //家中电话
                    cmd.Parameters.Add("U_PhotoUrl", OracleType.NVarChar).Value = fam.U_PhotoUrl + ""; //用户照片网址	
                    cmd.Parameters.Add("U_DateTime", OracleType.DateTime).Value = fam.U_DateTime; //操作时间	
                    cmd.Parameters.Add("U_LastIP", OracleType.VarChar).Value = fam.U_LastIP + ""; //最后访问IP	
                    cmd.Parameters.Add("U_LastDateTime", OracleType.DateTime).Value = fam.U_LastDateTime; //最后访问时间
                    cmd.Parameters.Add("U_ExtendField", OracleType.VarChar).Value = fam.U_ExtendField + "";  //扩展字段
                    cmd.Parameters.Add("U_LoginType", OracleType.VarChar).Value = fam.U_LoginType + ""; //登入类型(为空系统认证,其它值为其它认证)
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_User SET	U_LoginName = :U_LoginName,U_Password = :U_Password,U_CName = :U_CName,U_EName = :U_EName,U_GroupID = :U_GroupID,U_Email = :U_Email,U_Type = :U_Type,U_Status = :U_Status,U_Licence = :U_Licence,U_Mac = :U_Mac,U_Remark = :U_Remark,U_IDCard = :U_IDCard,U_Sex = :U_Sex,U_BirthDay = :U_BirthDay,U_MobileNo = :U_MobileNo,U_UserNO = :U_UserNO,U_WorkStartDate = :U_WorkStartDate,U_WorkEndDate = :U_WorkEndDate,U_CompanyMail = :U_CompanyMail,U_Title = :U_Title,U_Extension = :U_Extension,U_HomeTel = :U_HomeTel,U_PhotoUrl = :U_PhotoUrl,U_DateTime = :U_DateTime,U_LastIP = :U_LastIP,U_LastDateTime = :U_LastDateTime,U_ExtendField = :U_ExtendField,U_LoginType=:U_LoginType WHERE (UserID = :UserID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("U_LoginName", OracleType.NVarChar).Value = fam.U_LoginName + ""; //登陆名	
                    cmd.Parameters.Add("U_Password", OracleType.VarChar).Value = fam.U_Password + ""; //密码md5加密字符
                    cmd.Parameters.Add("U_CName", OracleType.NVarChar).Value = fam.U_CName + ""; //中文姓名	
                    cmd.Parameters.Add("U_EName", OracleType.VarChar).Value = fam.U_EName + ""; //英文名	
                    cmd.Parameters.Add("U_GroupID", OracleType.Int32).Value = fam.U_GroupID; //部门ID号与sys_Group表中GroupID关联	
                    cmd.Parameters.Add("U_Email", OracleType.VarChar).Value = fam.U_Email + ""; //电子邮件
                    cmd.Parameters.Add("U_Type", OracleType.SByte).Value = fam.U_Type; //用户类型0:超级用户1:普通用户
                    cmd.Parameters.Add("U_Status", OracleType.SByte).Value = fam.U_Status; //当前状态0:正常 1:禁止登陆 2:删除	
                    cmd.Parameters.Add("U_Licence", OracleType.VarChar).Value = fam.U_Licence + ""; //用户序列号	
                    cmd.Parameters.Add("U_Mac", OracleType.VarChar).Value = fam.U_Mac + ""; //锁定机器硬件地址
                    cmd.Parameters.Add("U_Remark", OracleType.NVarChar).Value = fam.U_Remark + ""; //备注说明	
                    cmd.Parameters.Add("U_IDCard", OracleType.VarChar).Value = fam.U_IDCard + ""; //身份证号码
                    cmd.Parameters.Add("U_Sex", OracleType.SByte).Value = fam.U_Sex; //性别1:男0:女	
                    if (fam.U_BirthDay.HasValue)
                        cmd.Parameters.Add("U_BirthDay", OracleType.DateTime).Value = fam.U_BirthDay; //出生日期	
                    else
                        cmd.Parameters.Add("U_BirthDay", OracleType.DateTime).Value = DBNull.Value; //出生日期	
                    cmd.Parameters.Add("U_MobileNo", OracleType.VarChar).Value = fam.U_MobileNo + ""; //手机号	
                    cmd.Parameters.Add("U_UserNO", OracleType.VarChar).Value = fam.U_UserNO + ""; //员工编号	
                    if (fam.U_WorkStartDate.HasValue)
                        cmd.Parameters.Add("U_WorkStartDate", OracleType.DateTime).Value = fam.U_WorkStartDate; //到职日期	
                    else
                        cmd.Parameters.Add("U_WorkStartDate", OracleType.DateTime).Value = DBNull.Value; //到职日期	
                    if (fam.U_WorkEndDate.HasValue)
                        cmd.Parameters.Add("U_WorkEndDate", OracleType.DateTime).Value = fam.U_WorkEndDate; //离职日期	
                    else
                        cmd.Parameters.Add("U_WorkEndDate", OracleType.DateTime).Value = DBNull.Value; //离职日期	
                    cmd.Parameters.Add("U_CompanyMail", OracleType.VarChar).Value = fam.U_CompanyMail + ""; //公司邮件地址	
                    cmd.Parameters.Add("U_Title", OracleType.Int32).Value = fam.U_Title; //职称与应用字段关联	
                    cmd.Parameters.Add("U_Extension", OracleType.VarChar).Value = fam.U_Extension + ""; //分机号	
                    cmd.Parameters.Add("U_HomeTel", OracleType.VarChar).Value = fam.U_HomeTel + ""; //家中电话
                    cmd.Parameters.Add("U_PhotoUrl", OracleType.NVarChar).Value = fam.U_PhotoUrl + ""; //用户照片网址	
                    cmd.Parameters.Add("U_DateTime", OracleType.DateTime).Value = fam.U_DateTime; //操作时间	
                    cmd.Parameters.Add("U_LastIP", OracleType.VarChar).Value = fam.U_LastIP + ""; //最后访问IP	
                    cmd.Parameters.Add("U_LastDateTime", OracleType.DateTime).Value = fam.U_LastDateTime; //最后访问时间
                    cmd.Parameters.Add("U_ExtendField", OracleType.VarChar).Value = fam.U_ExtendField + "";  //扩展字段
                    cmd.Parameters.Add("U_LoginType", OracleType.VarChar).Value = fam.U_LoginType+""; //登入类型(为空系统认证,其它值为其它认证)
                    cmd.Parameters.Add("UserID", OracleType.Int32).Value = fam.UserID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_User  WHERE (UserID = :UserID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("UserID", OracleType.Int32).Value = fam.UserID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_User_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_UserTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_UserTable实体类的ArrayList对象</returns>
        public override ArrayList sys_UserList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_User);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_UserRoles - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_UserRoles
        /// </summary>
        /// <param name="fam">sys_UserRolesTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_UserRolesInsertUpdate(sys_UserRolesTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_UserRoles(R_UserID,R_RoleID)VALUES(:R_UserID,:R_RoleID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("R_UserID", OracleType.Int32).Value = fam.R_UserID; //用户ID与sys_User表中UserID相关	
                    cmd.Parameters.Add("R_RoleID", OracleType.Int32).Value = fam.R_RoleID; //用户所属角色ID与Sys_Roles关联
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_UserRoles SET	R_UserID = :R_UserID,R_RoleID = :R_RoleID WHERE (  R_UserID = :R_UserID and R_RoleID = :R_RoleID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("R_UserID", OracleType.Int32).Value = fam.R_UserID; //用户ID与sys_User表中UserID相关	
                    cmd.Parameters.Add("R_RoleID", OracleType.Int32).Value = fam.R_RoleID; //用户所属角色ID与Sys_Roles关联

                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_UserRoles  WHERE ( R_UserID = :R_UserID and R_RoleID = :R_RoleID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("R_UserID", OracleType.Int32).Value = fam.R_UserID; //用户ID与sys_User表中UserID相关	
                    cmd.Parameters.Add("R_RoleID", OracleType.Int32).Value = fam.R_RoleID; //用户所属角色ID与Sys_Roles关联
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_UserRolesTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_UserRolesTable实体类的ArrayList对象</returns>
        public override ArrayList sys_UserRolesList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_UserRoles);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_Applications - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Applications
        /// </summary>
        /// <param name="fam">sys_ApplicationsTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_ApplicationsInsertUpdate(sys_ApplicationsTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Applications(ApplicationID,A_AppName,A_AppDescription,A_AppUrl,A_Order)VALUES(SEQ_sys_Applications_ID.NEXTVAL,:A_AppName,:A_AppDescription,:A_AppUrl,:A_Order)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("A_Order", OracleType.Int32).Value = fam.A_Order;
                    cmd.Parameters.Add("A_AppName", OracleType.NVarChar).Value = fam.A_AppName + ""; //应用名称
                    cmd.Parameters.Add("A_AppDescription", OracleType.NVarChar).Value = fam.A_AppDescription + ""; //应用介绍	
                    cmd.Parameters.Add("A_AppUrl", OracleType.VarChar).Value = fam.A_AppUrl + ""; //应用Url地址
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Applications SET	A_Order = :A_Order,A_AppName = :A_AppName,A_AppDescription = :A_AppDescription,A_AppUrl = :A_AppUrl WHERE (ApplicationID = :ApplicationID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("A_Order", OracleType.Int32).Value = fam.A_Order;
                    cmd.Parameters.Add("A_AppName", OracleType.NVarChar).Value = fam.A_AppName + ""; //应用名称
                    cmd.Parameters.Add("A_AppDescription", OracleType.NVarChar).Value = fam.A_AppDescription + ""; //应用介绍	
                    cmd.Parameters.Add("A_AppUrl", OracleType.VarChar).Value = fam.A_AppUrl + ""; //应用Url地址
                    cmd.Parameters.Add("ApplicationID", OracleType.Int32).Value = fam.ApplicationID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Applications  WHERE (ApplicationID = :ApplicationID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("ApplicationID", OracleType.Int32).Value = fam.ApplicationID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Applications_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_ApplicationsTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_ApplicationsTable实体类的ArrayList对象</returns>
        public override ArrayList sys_ApplicationsList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Applications);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_Event - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Event
        /// </summary>
        /// <param name="fam">sys_EventTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_EventInsertUpdate(sys_EventTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Event(EventID,E_U_LoginName,E_UserID,E_DateTime,E_ApplicationID,E_A_AppName,E_M_Name,E_M_PageCode,E_From,E_Type,E_IP,E_Record)VALUES(SEQ_sys_Event_ID.NEXTVAL,:E_U_LoginName,:E_UserID,:E_DateTime,:E_ApplicationID,:E_A_AppName,:E_M_Name,:E_M_PageCode,:E_From,:E_Type,:E_IP,:E_Record)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("E_U_LoginName", OracleType.NVarChar).Value = fam.E_U_LoginName + ""; //用户名	
                    cmd.Parameters.Add("E_UserID", OracleType.Int32).Value = fam.E_UserID; //操作时用户ID与sys_Users中UserID	
                    cmd.Parameters.Add("E_DateTime", OracleType.DateTime).Value = fam.E_DateTime; //事件发生的日期及时间	
                    cmd.Parameters.Add("E_ApplicationID", OracleType.Int32).Value = fam.E_ApplicationID; //所属应用程序ID与sys_Applicatio
                    cmd.Parameters.Add("E_A_AppName", OracleType.NVarChar).Value = fam.E_A_AppName + ""; //所属应用名称
                    cmd.Parameters.Add("E_M_Name", OracleType.NVarChar).Value = fam.E_M_Name + ""; //PageCode模块名称与sys_Module相同	
                    cmd.Parameters.Add("E_M_PageCode", OracleType.VarChar).Value = fam.E_M_PageCode + ""; //发生事件时模块名称
                    cmd.Parameters.Add("E_From", OracleType.NVarChar).Value = fam.E_From + ""; //来源
                    cmd.Parameters.Add("E_Type", OracleType.SByte).Value = fam.E_Type; //日记类型,1:操作日记2:安全日志3	
                    cmd.Parameters.Add("E_IP", OracleType.VarChar).Value = fam.E_IP + ""; //客户端IP地址
                    cmd.Parameters.Add("E_Record", OracleType.NVarChar).Value = fam.E_Record + ""; //详细描述
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Event SET	E_U_LoginName = :E_U_LoginName,E_UserID = :E_UserID,E_DateTime = :E_DateTime,E_ApplicationID = :E_ApplicationID,E_A_AppName = :E_A_AppName,E_M_Name = :E_M_Name,E_M_PageCode = :E_M_PageCode,E_From = :E_From,E_Type = :E_Type,E_IP = :E_IP,E_Record = :E_Record WHERE (EventID = :EventID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("E_U_LoginName", OracleType.NVarChar).Value = fam.E_U_LoginName + ""; //用户名	
                    cmd.Parameters.Add("E_UserID", OracleType.Int32).Value = fam.E_UserID; //操作时用户ID与sys_Users中UserID	
                    cmd.Parameters.Add("E_DateTime", OracleType.DateTime).Value = fam.E_DateTime; //事件发生的日期及时间	
                    cmd.Parameters.Add("E_ApplicationID", OracleType.Int32).Value = fam.E_ApplicationID; //所属应用程序ID与sys_Applicatio
                    cmd.Parameters.Add("E_A_AppName", OracleType.NVarChar).Value = fam.E_A_AppName + ""; //所属应用名称
                    cmd.Parameters.Add("E_M_Name", OracleType.NVarChar).Value = fam.E_M_Name + ""; //PageCode模块名称与sys_Module相同	
                    cmd.Parameters.Add("E_M_PageCode", OracleType.VarChar).Value = fam.E_M_PageCode + ""; //发生事件时模块名称
                    cmd.Parameters.Add("E_From", OracleType.NVarChar).Value = fam.E_From + ""; //来源
                    cmd.Parameters.Add("E_Type", OracleType.SByte).Value = fam.E_Type; //日记类型,1:操作日记2:安全日志3	
                    cmd.Parameters.Add("E_IP", OracleType.VarChar).Value = fam.E_IP + ""; //客户端IP地址
                    cmd.Parameters.Add("E_Record", OracleType.NVarChar).Value = fam.E_Record + ""; //详细描述
                    cmd.Parameters.Add("EventID", OracleType.Int32).Value = fam.EventID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Event  WHERE (EventID = :EventID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("EventID", OracleType.Int32).Value = fam.EventID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Event_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_EventTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_EventTable实体类的ArrayList对象</returns>
        public override ArrayList sys_EventList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Event);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        /// <summary>
        /// 清空表sys_Event中的所有数据
        /// </summary>
        public override void sys_EventClearData()
        {
            using (OracleConnection Conn = GetSqlConnection())
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                cmd.CommandText = "truncate table sys_Event";
                Conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
        }

        #endregion

        #region "sys_Field - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Field
        /// </summary>
        /// <param name="fam">sys_FieldTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_FieldInsertUpdate(sys_FieldTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Field(FieldID,F_Key,F_CName,F_Remark)VALUES(SEQ_sys_Field_ID.NEXTVAL,:F_Key,:F_CName,:F_Remark)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("F_Key", OracleType.VarChar).Value = fam.F_Key + ""; //应用字段关键字
                    cmd.Parameters.Add("F_CName", OracleType.NVarChar).Value = fam.F_CName + ""; //应用字段中文说明
                    cmd.Parameters.Add("F_Remark", OracleType.NVarChar).Value = fam.F_Remark + ""; //描述说明
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Field SET	F_Key = :F_Key,F_CName = :F_CName,F_Remark = :F_Remark WHERE (FieldID = :FieldID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("F_Key", OracleType.VarChar).Value = fam.F_Key + ""; //应用字段关键字
                    cmd.Parameters.Add("F_CName", OracleType.NVarChar).Value = fam.F_CName + ""; //应用字段中文说明
                    cmd.Parameters.Add("F_Remark", OracleType.NVarChar).Value = fam.F_Remark + ""; //描述说明
                    cmd.Parameters.Add("FieldID", OracleType.Int32).Value = fam.FieldID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Field  WHERE (FieldID = :FieldID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("FieldID", OracleType.Int32).Value = fam.FieldID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Field_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_FieldTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_FieldTable实体类的ArrayList对象</returns>
        public override ArrayList sys_FieldList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Field);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_FieldValue - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_FieldValue
        /// </summary>
        /// <param name="fam">sys_FieldValueTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_FieldValueInsertUpdate(sys_FieldValueTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_FieldValue(ValueID,V_F_Key,V_Text,V_Code,V_ShowOrder)VALUES(SEQ_sys_FieldValue_ID.NEXTVAL,:V_F_Key,:V_Text,:V_Code,:V_ShowOrder)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("V_F_Key", OracleType.VarChar).Value = fam.V_F_Key + ""; //与sys_Field表中F_Key字段关联
                    cmd.Parameters.Add("V_Text", OracleType.NVarChar).Value = fam.V_Text + ""; //中文说明	
                    cmd.Parameters.Add("V_Code", OracleType.NVarChar).Value = fam.V_Code + ""; //编码	
                    cmd.Parameters.Add("V_ShowOrder", OracleType.Int32).Value = fam.V_ShowOrder; //同级显示顺序
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_FieldValue SET	V_F_Key = :V_F_Key,V_Text = :V_Text,V_Code = :V_Code,V_ShowOrder = :V_ShowOrder WHERE (ValueID = :ValueID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("V_F_Key", OracleType.VarChar).Value = fam.V_F_Key + ""; //与sys_Field表中F_Key字段关联
                    cmd.Parameters.Add("V_Text", OracleType.NVarChar).Value = fam.V_Text + ""; //中文说明	
                    cmd.Parameters.Add("V_Code", OracleType.NVarChar).Value = fam.V_Code + ""; //编码	
                    cmd.Parameters.Add("V_ShowOrder", OracleType.Int32).Value = fam.V_ShowOrder; //同级显示顺序
                    cmd.Parameters.Add("ValueID", OracleType.Int32).Value = fam.ValueID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_FieldValue  WHERE (ValueID = :ValueID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("ValueID", OracleType.Int32).Value = fam.ValueID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_FieldValue_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_FieldValueTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_FieldValueTable实体类的ArrayList对象</returns>
        public override ArrayList sys_FieldValueList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_FieldValue);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_Online - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_Online
        /// </summary>
        /// <param name="fam">sys_OnlineTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_OnlineInsertUpdate(sys_OnlineTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_Online(OnlineID,O_SessionID,O_UserName,O_Ip,O_LoginTime,O_LastTime,O_LastUrl)VALUES(SEQ_sys_Online_ID.NEXTVAL,:O_SessionID,:O_UserName,:O_Ip,:O_LoginTime,:O_LastTime,:O_LastUrl)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("O_SessionID", OracleType.VarChar).Value = fam.O_SessionID + ""; //用户SessionID
                    cmd.Parameters.Add("O_UserName", OracleType.NVarChar).Value = fam.O_UserName + ""; //用户名	
                    cmd.Parameters.Add("O_Ip", OracleType.VarChar).Value = fam.O_Ip + ""; //用户IP地址	
                    cmd.Parameters.Add("O_LoginTime", OracleType.DateTime).Value = fam.O_LoginTime; //登陆时间	
                    cmd.Parameters.Add("O_LastTime", OracleType.DateTime).Value = fam.O_LastTime; //最后访问时间
                    cmd.Parameters.Add("O_LastUrl", OracleType.NVarChar).Value = fam.O_LastUrl + ""; //最后请求网站
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_Online SET	O_SessionID = :O_SessionID,O_UserName = :O_UserName,O_Ip = :O_Ip,O_LoginTime = :O_LoginTime,O_LastTime = :O_LastTime,O_LastUrl = :O_LastUrl WHERE (OnlineID = :OnlineID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("O_SessionID", OracleType.VarChar).Value = fam.O_SessionID + ""; //用户SessionID
                    cmd.Parameters.Add("O_UserName", OracleType.NVarChar).Value = fam.O_UserName + ""; //用户名	
                    cmd.Parameters.Add("O_Ip", OracleType.VarChar).Value = fam.O_Ip + ""; //用户IP地址	
                    cmd.Parameters.Add("O_LoginTime", OracleType.DateTime).Value = fam.O_LoginTime; //登陆时间	
                    cmd.Parameters.Add("O_LastTime", OracleType.DateTime).Value = fam.O_LastTime; //最后访问时间
                    cmd.Parameters.Add("O_LastUrl", OracleType.NVarChar).Value = fam.O_LastUrl + ""; //最后请求网站
                    cmd.Parameters.Add("OnlineID", OracleType.Int32).Value = fam.OnlineID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_Online  WHERE (OnlineID = :OnlineID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("OnlineID", OracleType.Int32).Value = fam.OnlineID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_Online_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_OnlineTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_OnlineTable实体类的ArrayList对象</returns>
        public override ArrayList sys_OnlineList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_Online);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "sys_ModuleExtPermission - OracleDataProvider"
        /// <summary>
        /// 新增/删除/修改 sys_ModuleExtPermission
        /// </summary>
        /// <param name="fam">sys_ModuleExtPermissionTable实体类</param>
        /// <returns>返回0操正常</returns>
        public override int sys_ModuleExtPermissionInsertUpdate(sys_ModuleExtPermissionTable fam)
        {
            int rInt = 0;

            using (OracleConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Conn;
                if (fam.DB_Option_Action_ == "Insert")
                {
                    CommTxt = "Insert into 	sys_ModuleExtPermission(ExtPermissionID,ModuleID,PermissionName,PermissionValue)VALUES(SEQ_sys_ModuleExtPermission_ID.NEXTVAL,:ModuleID,:PermissionName,:PermissionValue)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("ModuleID", OracleType.Int32).Value = fam.ModuleID; //模块ID
                    cmd.Parameters.Add("PermissionName", OracleType.NVarChar).Value = fam.PermissionName + ""; //权限名称	
                    cmd.Parameters.Add("PermissionValue", OracleType.Int32).Value = fam.PermissionValue; //权限值
                }
                else if (fam.DB_Option_Action_ == "Update")
                {

                    CommTxt = "UPDATE sys_ModuleExtPermission SET	ModuleID = :ModuleID,PermissionName = :PermissionName,PermissionValue = :PermissionValue WHERE (ExtPermissionID = :ExtPermissionID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("ModuleID", OracleType.Int32).Value = fam.ModuleID; //模块ID
                    cmd.Parameters.Add("PermissionName", OracleType.NVarChar).Value = fam.PermissionName + ""; //权限名称	
                    cmd.Parameters.Add("PermissionValue", OracleType.Int32).Value = fam.PermissionValue; //权限值
                    cmd.Parameters.Add("ExtPermissionID", OracleType.Int32).Value = fam.ExtPermissionID;
                }
                else if (fam.DB_Option_Action_ == "Delete")
                {
                    CommTxt = "Delete from  sys_ModuleExtPermission  WHERE (ExtPermissionID = :ExtPermissionID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("ExtPermissionID", OracleType.Int32).Value = fam.ExtPermissionID;
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");
                Conn.Open();
                OracleTransaction Tran = Conn.BeginTransaction();
                cmd.Transaction = Tran;
                try
                {
                    rInt = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (fam.DB_Option_Action_ == "Insert")
                    {
                        cmd.CommandText = "select SEQ_sys_ModuleExtPermission_ID.CURRVAL from  dual";
                        rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Tran.Commit();
                }
                catch (Exception ex)
                {
                    Tran.Rollback();
                    throw new ApplicationException(ex.ToString());
                }
                finally
                {
                    Tran.Dispose();
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                }
            }
            return rInt;
        }

        /// <summary>
        /// 返回sys_ModuleExtPermissionTable实体类的ArrayList对象
        /// </summary>
        /// <param name="qp">查询类</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>sys_ModuleExtPermissionTable实体类的ArrayList对象</returns>
        public override ArrayList sys_ModuleExtPermissionList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate mypd = new PopulateDelegate(base.Populatesys_ModuleExtPermission);
            return this.GetObjectList(mypd, qp, out RecordCount);
        }

        #endregion

        #region "公共查询数据函数Oracle版"
        /// <summary>
        /// 公共查询数据函数Oracle版
        /// </summary>
        /// <param name="pd">委托对象</param>
        /// <param name="pp">查询字符串</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>返回记录集ArrayList</returns>
        private ArrayList GetObjectList(PopulateDelegate pd, QueryParam pp, out int RecordCount)
        {
            ArrayList lst = new ArrayList();
            RecordCount = 0;
            using (OracleConnection Conn = GetSqlConnection())
            {
                StringBuilder sb = new StringBuilder();
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr = null;
                cmd.Connection = Conn;

                int TotalRecordForPageIndex = pp.PageIndex * pp.PageSize;
                int FirstRecordForPageIndex = (pp.PageIndex - 1) * pp.PageSize;
                string OrderBy;
                if (pp.OrderType == 1)
                {
                    OrderBy = " Order by " + pp.Orderfld.Replace(",", " desc,") + " desc ";
                }
                else
                {
                    OrderBy = " Order by " + pp.Orderfld.Replace(",", " asc,") + " asc ";
                }
                sb.AppendFormat("SELECT * FROM (SELECT A.*, ROWNUM RN FROM (SELECT * FROM {0} {1} {2}) A WHERE ROWNUM <= {3})WHERE RN > {4} ", pp.TableName.ToUpper(), pp.Where, OrderBy, TotalRecordForPageIndex, FirstRecordForPageIndex);
                cmd.CommandText = sb.ToString();
                Conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(pd(dr));
                }
                dr.Close();
                cmd.Parameters.Clear();
                // 取记录总数
                cmd.CommandText = string.Format("SELECT Count(1) From {0} {1}", pp.TableName, pp.Where);
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                dr.Dispose();
                dr.Close();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return lst;
        }
        #endregion

        #region "获取表中字段值"
        /// <summary>
        /// 获取表中字段值
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <returns></returns>
        public override string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value)
        {
            where_value = Common.inSQL(where_value);
            string rStr = "";
            using (OracleConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("select {0} from {1} where upper({2})='{3}'", table_fileds, table_name.ToUpper(), where_fileds, where_value);
                OracleCommand cmd = new OracleCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rStr = dr[0].ToString();
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rStr;
        }
        #endregion

        #region "更新表中字段值"
        /// <summary>
        /// 更新表中字段值
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns></returns>
        public override int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            int rInt = 0;
            using (OracleConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("Update {0} Set {1}  Where {2}", Table.ToUpper(), Table_FiledsValue, Wheres);
                OracleCommand cmd = new OracleCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }
        #endregion
    }
}