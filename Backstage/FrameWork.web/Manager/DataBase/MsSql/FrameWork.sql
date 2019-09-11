/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2011/3/10 21:56:33                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Applications')
            and   type = 'U')
   drop table dbo.sys_Applications
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Event')
            and   type = 'U')
   drop table dbo.sys_Event
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Field')
            and   type = 'U')
   drop table dbo.sys_Field
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_FieldValue')
            and   type = 'U')
   drop table dbo.sys_FieldValue
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Group')
            and   type = 'U')
   drop table dbo.sys_Group
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Module')
            and   type = 'U')
   drop table dbo.sys_Module
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_ModuleExtPermission')
            and   type = 'U')
   drop table dbo.sys_ModuleExtPermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Online')
            and   type = 'U')
   drop table dbo.sys_Online
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_RoleApplication')
            and   type = 'U')
   drop table dbo.sys_RoleApplication
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_RolePermission')
            and   type = 'U')
   drop table dbo.sys_RolePermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Roles')
            and   type = 'U')
   drop table dbo.sys_Roles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_SystemInfo')
            and   type = 'U')
   drop table dbo.sys_SystemInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_User')
            and   type = 'U')
   drop table dbo.sys_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_UserRoles')
            and   type = 'U')
   drop table dbo.sys_UserRoles
go

/*==============================================================*/
/* Table: sys_Applications                                      */
/*==============================================================*/
create table dbo.sys_Applications (
   ApplicationID        int                  identity,
   A_AppName            nvarchar(50)         null,
   A_AppDescription     nvarchar(200)        null,
   A_AppUrl             varchar(50)          null,
   A_Order              int                  null,
   constraint PK_SYS_APPLICATIONS primary key nonclustered (ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '应用表',
   'user', 'dbo', 'table', 'sys_Applications'
go

execute sp_addextendedproperty 'MS_Description', 
   '自动ID 1:为系统管理应用',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用名称',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppName'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用介绍',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppDescription'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用Url地址',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用排序',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_Order'
go

/*==============================================================*/
/* Table: sys_Event                                             */
/*==============================================================*/
create table dbo.sys_Event (
   EventID              int                  identity,
   E_U_LoginName        nvarchar(20)         null,
   E_UserID             int                  null,
   E_DateTime           datetime             not null default getdate(),
   E_ApplicationID      int                  null,
   E_A_AppName          nvarchar(50)         null,
   E_M_Name             nvarchar(50)         null,
   E_M_PageCode         varchar(6)           null,
   E_From               nvarchar(500)        null,
   E_Type               tinyint              not null default 1,
   E_IP                 varchar(15)          null,
   E_Record             nvarchar(500)        null,
   constraint PK_SYS_EVENT primary key nonclustered (EventID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '系统日记表',
   'user', 'dbo', 'table', 'sys_Event'
go

execute sp_addextendedproperty 'MS_Description', 
   '事件ID号',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'EventID'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_U_LoginName'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作时用户ID与sys_Users中UserID',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '事件发生的日期及时间',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_DateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属应用程序ID与sys_Applicatio',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属应用名称',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_A_AppName'
go

execute sp_addextendedproperty 'MS_Description', 
   'PageCode模块名称与sys_Module相同',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_M_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '发生事件时模块名称',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_M_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '来源',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_From'
go

execute sp_addextendedproperty 'MS_Description', 
   '日记类型,1:操作日记2:安全日志3',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '客户端IP地址',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_IP'
go

execute sp_addextendedproperty 'MS_Description', 
   '详细描述',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_Record'
go

/*==============================================================*/
/* Table: sys_Field                                             */
/*==============================================================*/
create table dbo.sys_Field (
   FieldID              int                  identity,
   F_Key                varchar(50)          null,
   F_CName              nvarchar(50)         null,
   F_Remark             nvarchar(200)        null,
   constraint PK_Sys_Field primary key nonclustered (FieldID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '系统应用字段',
   'user', 'dbo', 'table', 'sys_Field'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用字段ID号',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'FieldID'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用字段关键字',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_Key'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用字段中文说明',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '描述说明',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_Remark'
go

/*==============================================================*/
/* Table: sys_FieldValue                                        */
/*==============================================================*/
create table dbo.sys_FieldValue (
   ValueID              int                  identity,
   V_F_Key              varchar(50)          null,
   V_Text               nvarchar(100)        null,
   V_Code               varchar(100)         null,
   V_ShowOrder          int                  not null default 0,
   constraint PK_Sys_FieldValue primary key nonclustered (ValueID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '应用字段值',
   'user', 'dbo', 'table', 'sys_FieldValue'
go

execute sp_addextendedproperty 'MS_Description', 
   '索引ID号',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'ValueID'
go

execute sp_addextendedproperty 'MS_Description', 
   '与sys_Field表中F_Key字段关联',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_F_Key'
go

execute sp_addextendedproperty 'MS_Description', 
   '中文说明',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_Text'
go

execute sp_addextendedproperty 'MS_Description', 
   '编码',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_Code'
go

execute sp_addextendedproperty 'MS_Description', 
   '同级显示顺序',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_ShowOrder'
go

/*==============================================================*/
/* Table: sys_Group                                             */
/*==============================================================*/
create table dbo.sys_Group (
   GroupID              int                  identity,
   G_CName              nvarchar(50)         null,
   G_ParentID           int                  not null default 0,
   G_ShowOrder          int                  not null default 0,
   G_Level              int                  null,
   G_ChildCount         int                  null,
   G_Delete             tinyint              null,
   constraint PK_SYS_GROUP primary key nonclustered (GroupID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '部门',
   'user', 'dbo', 'table', 'sys_Group'
go

execute sp_addextendedproperty 'MS_Description', 
   '分类ID号',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '分类中文说明',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '上级分类ID0:为最高级',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示顺序',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ShowOrder'
go

execute sp_addextendedproperty 'MS_Description', 
   '当前分类所在层数',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_Level'
go

execute sp_addextendedproperty 'MS_Description', 
   '当???分类子分类数',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ChildCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否删除1:是0:否',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_Delete'
go

/*==============================================================*/
/* Table: sys_Module                                            */
/*==============================================================*/
create table dbo.sys_Module (
   ModuleID             int                  identity,
   M_ApplicationID      int                  not null,
   M_ParentID           int                  not null,
   M_PageCode           varchar(100)         not null,
   M_CName              nvarchar(50)         null,
   M_Directory          nvarchar(255)        null,
   M_OrderLevel         varchar(4)           null,
   M_IsSystem           tinyint              null,
   M_Close              tinyint              null,
   M_Icon               varchar(255)         null,
   M_Info               nvarchar(500)        null,
   constraint PK_Sys_Module primary key nonclustered (M_PageCode, M_ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '功能模块',
   'user', 'dbo', 'table', 'sys_Module'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能模块ID号',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'ModuleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属应用程序ID',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属父级模块ID与ModuleID关联,0为顶级',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块编码Parent为0,则为S00(xx),否则为S00M00(xx)',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块/栏目名称当ParentID为0为模块名称',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块/栏目???录名',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Directory'
go

execute sp_addextendedproperty 'MS_Description', 
   '当前所在排序级别支持双层99级菜单',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_OrderLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否为系统模块1:是0:否如为系统则无法修改',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_IsSystem'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否关闭1:是0:否',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Close'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块Icon',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Icon'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块说明',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Info'
go

/*==============================================================*/
/* Table: sys_ModuleExtPermission                               */
/*==============================================================*/
create table dbo.sys_ModuleExtPermission (
   ExtPermissionID      int                  identity,
   ModuleID             int                  not null,
   PermissionName       nvarchar(100)        not null,
   PermissionValue      int                  not null,
   constraint PK_SYS_MODULEEXTPERMISSION primary key nonclustered (ModuleID, PermissionValue)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '模块扩展权限',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission'
go

execute sp_addextendedproperty 'MS_Description', 
   '扩展权限ID',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'ExtPermissionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '模块ID',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'ModuleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '权限名称',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'PermissionName'
go

execute sp_addextendedproperty 'MS_Description', 
   '权限值',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'PermissionValue'
go

/*==============================================================*/
/* Table: sys_Online                                            */
/*==============================================================*/
create table dbo.sys_Online (
   OnlineID             int                  identity,
   O_SessionID          varchar(24)          not null,
   O_UserName           nvarchar(20)         not null,
   O_Ip                 varchar(15)          not null,
   O_LoginTime          datetime             not null,
   O_LastTime           datetime             not null,
   O_LastUrl            nvarchar(500)        not null,
   constraint PK_SYS_ONLINE primary key nonclustered (O_SessionID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '在线用户表',
   'user', 'dbo', 'table', 'sys_Online'
go

execute sp_addextendedproperty 'MS_Description', 
   '自动ID',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'OnlineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户SessionID',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_SessionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_UserName'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户IP地址',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_Ip'
go

execute sp_addextendedproperty 'MS_Description', 
   '登陆时间',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LoginTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后访问时间',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LastTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后请求网站',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LastUrl'
go

/*==============================================================*/
/* Table: sys_RoleApplication                                   */
/*==============================================================*/
create table dbo.sys_RoleApplication (
   A_RoleID             int                  not null,
   A_ApplicationID      int                  not null,
   constraint PK_SYS_ROLEAPPLICATION primary key nonclustered (A_RoleID, A_ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色应用表',
   'user', 'dbo', 'table', 'sys_RoleApplication'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID与sys_Roles中RoleID相关',
   'user', 'dbo', 'table', 'sys_RoleApplication', 'column', 'A_RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '应用ID与sys_Applications中Appl',
   'user', 'dbo', 'table', 'sys_RoleApplication', 'column', 'A_ApplicationID'
go

/*==============================================================*/
/* Table: sys_RolePermission                                    */
/*==============================================================*/
create table dbo.sys_RolePermission (
   PermissionID         int                  identity,
   P_RoleID             int                  not null,
   P_ApplicationID      int                  not null,
   P_PageCode           varchar(20)          not null,
   P_Value              int                  null,
   constraint PK_sys_RolePermission primary key nonclustered (P_RoleID, P_ApplicationID, P_PageCode)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色应用权限表',
   'user', 'dbo', 'table', 'sys_RolePermission'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色应用权限自动ID',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'PermissionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID与sys_Roles表中RoleID相',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色所属应用ID与sys_Applicatio',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色应用中页面权限代码',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '权限值',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_Value'
go

/*==============================================================*/
/* Table: sys_Roles                                             */
/*==============================================================*/
create table dbo.sys_Roles (
   RoleID               int                  identity,
   R_UserID             int                  not null,
   R_RoleName           nvarchar(50)         not null,
   R_Description        nvarchar(255)        null,
   constraint PK_sys_Roles primary key nonclustered (RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色表',
   'user', 'dbo', 'table', 'sys_Roles'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色ID自动ID',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角角所属用户ID',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_RoleName'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色介绍',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_Description'
go

/*==============================================================*/
/* Table: sys_SystemInfo                                        */
/*==============================================================*/
create table dbo.sys_SystemInfo (
   SystemID             int                  identity,
   S_Name               nvarchar(50)         null,
   S_Version            nvarchar(50)         null,
   S_SystemConfigData   image                null,
   S_Licensed           varchar(50)          null,
   constraint PK_SYS_SYSTEMINFO primary key nonclustered (SystemID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '系统信息表',
   'user', 'dbo', 'table', 'sys_SystemInfo'
go

execute sp_addextendedproperty 'MS_Description', 
   '自动ID',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'SystemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '系统名称',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Version'
go

execute sp_addextendedproperty 'MS_Description', 
   '系统配置信息',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_SystemConfigData'
go

execute sp_addextendedproperty 'MS_Description', 
   '序列号',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Licensed'
go

/*==============================================================*/
/* Table: sys_User                                              */
/*==============================================================*/
create table dbo.sys_User (
   UserID               int                  identity,
   U_LoginName          nvarchar(20)         not null,
   U_Password           varchar(32)          not null,
   U_CName              nvarchar(20)         null,
   U_EName              varchar(50)          null,
   U_GroupID            int                  not null,
   U_Email              varchar(100)         null,
   U_Type               tinyint              not null default 1,
   U_Status             tinyint              not null default 1,
   U_Licence            varchar(30)          null,
   U_Mac                varchar(50)          null,
   U_Remark             nvarchar(200)        null,
   U_IDCard             varchar(30)          null,
   U_Sex                tinyint              null,
   U_BirthDay           datetime             null,
   U_MobileNo           varchar(15)          null,
   U_UserNO             varchar(20)          null,
   U_WorkStartDate      datetime             null,
   U_WorkEndDate        datetime             null,
   U_CompanyMail        varchar(255)         null,
   U_Title              int                  null,
   U_Extension          varchar(10)          null,
   U_HomeTel            varchar(20)          null,
   U_PhotoUrl           nvarchar(255)        null,
   U_DateTime           datetime             null,
   U_LastIP             varchar(15)          null,
   U_LastDateTime       datetime             null,
   U_ExtendField        ntext                null,
   U_LoginType          varchar(255)         null,
   constraint PK_Sys_User primary key nonclustered (UserID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '用户表',
   'user', 'dbo', 'table', 'sys_User'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户ID号',
   'user', 'dbo', 'table', 'sys_User', 'column', 'UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '登陆名',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LoginName'
go

execute sp_addextendedproperty 'MS_Description', 
   '密码md5加密字符',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Password'
go

execute sp_addextendedproperty 'MS_Description', 
   '中文姓名',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '英文名',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_EName'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门ID号与sys_Group表中GroupID关联',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '电子邮件',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Email'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户类型0:超级用户1:普通用户',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '当前状态0:正常 1:禁止登陆 2:删除',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Status'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户序列号',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Licence'
go

execute sp_addextendedproperty 'MS_Description', 
   '锁定机器硬件地址',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Mac'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注说明',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '身份证号码',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_IDCard'
go

execute sp_addextendedproperty 'MS_Description', 
   '性别1:男0:女',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '出生日期',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_BirthDay'
go

execute sp_addextendedproperty 'MS_Description', 
   '手机号',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_MobileNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工编号',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_UserNO'
go

execute sp_addextendedproperty 'MS_Description', 
   '到职日期',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_WorkStartDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '离职日期',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_WorkEndDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '公司邮件地址',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_CompanyMail'
go

execute sp_addextendedproperty 'MS_Description', 
   '职称与应用字段关联',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Title'
go

execute sp_addextendedproperty 'MS_Description', 
   '分机号',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Extension'
go

execute sp_addextendedproperty 'MS_Description', 
   '家中电话',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_HomeTel'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户照片网址',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_PhotoUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作时间',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_DateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后访问IP',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LastIP'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后访问时间',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LastDateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '扩展字段',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_ExtendField'
go

execute sp_addextendedproperty 'MS_Description', 
   '登入类型(为空系统认证,其它值为其它认证)',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LoginType'
go

/*==============================================================*/
/* Table: sys_UserRoles                                         */
/*==============================================================*/
create table dbo.sys_UserRoles (
   R_UserID             int                  not null,
   R_RoleID             int                  not null,
   constraint PK_SYS_USERROLES primary key nonclustered (R_UserID, R_RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '用户角色表',
   'user', 'dbo', 'table', 'sys_UserRoles'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户ID与sys_User表中UserID相关',
   'user', 'dbo', 'table', 'sys_UserRoles', 'column', 'R_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户所属角色ID与Sys_Roles关联',
   'user', 'dbo', 'table', 'sys_UserRoles', 'column', 'R_RoleID'
go

