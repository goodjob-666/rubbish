--FrameWork1.08数据更新.sql by supesoft.com 2011/3/5
--增加sys_Module 表 增加M_Info
Alter table sys_Module Add M_Info nvarchar(500) null
go
--修改sys_Module表修改M_PageCode长度为100
alter table sys_Module drop constraint PK_Sys_Module
go
Alter table sys_Module alter column M_PageCode varchar(100) not null
go
alter table sys_Module add constraint PK_Sys_Module primary key ([M_ApplicationID],[M_PageCode])
go
--增加sys_User 表 增加U_LoginType
Alter table sys_User Add U_LoginType varchar(255) null


