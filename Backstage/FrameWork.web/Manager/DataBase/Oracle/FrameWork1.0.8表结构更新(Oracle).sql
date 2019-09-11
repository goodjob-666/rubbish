--FrameWork1.08表结构更新.sql by supesoft.com 2011/3/5
--sys_Module 表 增加 M_Info列
alter table SYS_MODULE add M_INFO VARCHAR2(500 BYTE);
--sys_Module 表修改M_PageCode长度为100
alter table SYS_MODULE modify (M_PAGECODE varchar2(100 BYTE));

--sys_User 表 增加 U_LoginType列
alter table SYS_USER add U_LOGINTYPE VARCHAR2(255 BYTE);
