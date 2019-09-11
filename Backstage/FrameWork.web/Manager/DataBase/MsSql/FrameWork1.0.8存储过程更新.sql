--FrameWork1.0.7存储过程更新
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sys_ModuleInsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sys_ModuleInsertUpdateDelete]
GO

-- 创建更新删除
CREATE PROCEDURE [dbo].[sys_ModuleInsertUpdateDelete]
(	

	@ModuleID	 int = 0,	-- 功能模块ID号
	@M_ApplicationID	 int = 0,	-- 所属应用程序ID
	@M_ParentID	 int = 0,	-- 所属父级模块ID与ModuleID关联,0为顶级
	@M_PageCode	 varchar(100) = '',	-- 模块编码Parent为0,则为S00(xx),否则为S00M00(xx)
	@M_CName	 nvarchar(50) = '',	-- 模块/栏目名称当ParentID为0为模块名称
	@M_Directory	 nvarchar(255) = '',	-- 模块/栏目目录名
	@M_OrderLevel	 varchar(4) = '',	-- 当前所在排序级别支持双层99级菜单
	@M_IsSystem	 tinyint = 0,	-- 是否为系统模块1:是0:否如为系统则无法修改
	@M_Close	 tinyint = 0,	-- 是否关闭1:是0:否
	@M_Icon	 varchar(255) = '',	-- 模块Icon
	@M_Info	 nvarchar(500) = '',	-- 模块说明
	@DB_Option_Action_  nvarchar(20) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除 
)
AS
	DECLARE @ReturnValue int -- 返回操作结果
	
	SET @ReturnValue = -1
	
	-- 新增
	IF (@DB_Option_Action_='Insert')
	BEGIN
		INSERT INTO sys_Module( 
			M_ApplicationID,
			M_ParentID,
			M_PageCode,
			M_CName,
			M_Directory,
			M_OrderLevel,
			M_IsSystem,
			M_Close,
			M_Icon,
			M_Info
		) VALUES (	
			@M_ApplicationID,
			@M_ParentID,
			@M_PageCode,
			@M_CName,
			@M_Directory,
			@M_OrderLevel,
			@M_IsSystem,
			@M_Close,
			@M_Icon,
			@M_Info
		)
		SET @ReturnValue = @@IDENTITY
	END
	
	-- 更新
	IF (@DB_Option_Action_='Update')
	BEGIN
		UPDATE sys_Module SET	
			M_ApplicationID = @M_ApplicationID,
			M_ParentID = @M_ParentID,
			M_PageCode = @M_PageCode,
			M_CName = @M_CName,
			M_Directory = @M_Directory,
			M_OrderLevel = @M_OrderLevel,
			M_IsSystem = @M_IsSystem,
			M_Close = @M_Close,
			M_Icon = @M_Icon,
			M_Info = @M_Info
		WHERE (ModuleID = @ModuleID)
		
		SET @ReturnValue = @@ROWCOUNT
	END
	
	-- 删除
	IF (@DB_Option_Action_='Delete')
	BEGIN
		DELETE sys_Module	WHERE (ModuleID = @ModuleID)
		SET @ReturnValue = @@ROWCOUNT
  	END

SELECT @ReturnValue

go

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sys_UserInsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sys_UserInsertUpdateDelete]
GO

-- 创建更新删除
CREATE PROCEDURE [dbo].[sys_UserInsertUpdateDelete]
(	

	@UserID	 int = 0,	-- 用户ID号
	@U_LoginName	 nvarchar(20) = '',	-- 登陆名
	@U_Password	 varchar(32) = '',	-- 密码md5加密字符
	@U_CName	 nvarchar(20) = '',	-- 中文姓名
	@U_EName	 varchar(50) = '',	-- 英文名
	@U_GroupID	 int = 0,	-- 部门ID号与sys_Group表中GroupID关联
	@U_Email	 varchar(100) = '',	-- 电子邮件
	@U_Type	 tinyint = 0,	-- 用户类型0:超级用户1:普通用户
	@U_Status	 tinyint = 0,	-- 当前状态0:正常 1:禁止登陆 2:删除
	@U_Licence	 varchar(30) = '',	-- 用户序列号
	@U_Mac	 varchar(50) = '',	-- 锁定机器硬件地址
	@U_Remark	 nvarchar(200) = '',	-- 备注说明
	@U_IDCard	 varchar(30) = '',	-- 身份证号码
	@U_Sex	 tinyint = 0,	-- 性别1:男0:女
	@U_BirthDay	 datetime = Null,	-- 出生日期
	@U_MobileNo	 varchar(15) = '',	-- 手机号
	@U_UserNO	 varchar(20) = '',	-- 员工编号
	@U_WorkStartDate	 datetime = Null,	-- 到职日期
	@U_WorkEndDate	 datetime = Null,	-- 离职日期
	@U_CompanyMail	 varchar(255) = '',	-- 公司邮件地址
	@U_Title	 int = 0,	-- 职称与应用字段关联
	@U_Extension	 varchar(10) = '',	-- 分机号
	@U_HomeTel	 varchar(20) = '',	-- 家中电话
	@U_PhotoUrl	 nvarchar(255) = '',	-- 用户照片网址
	@U_DateTime	 datetime = Null,	-- 操作时间
	@U_LastIP	 varchar(15) = '',	-- 最后访问IP
	@U_LastDateTime	 datetime = Null,	-- 最后访问时间
	@U_ExtendField	 ntext  = '',	-- 扩展字段
	@U_LoginType	 varchar(255) = '',	-- 登入类型(为空系统认证,其它值为其它认证)
	@DB_Option_Action_  nvarchar(20) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除 
)
AS
	DECLARE @ReturnValue int -- 返回操作结果
	
	SET @ReturnValue = -1
	
	-- 新增
	IF (@DB_Option_Action_='Insert')
	BEGIN
		INSERT INTO sys_User( 
			U_LoginName,
			U_Password,
			U_CName,
			U_EName,
			U_GroupID,
			U_Email,
			U_Type,
			U_Status,
			U_Licence,
			U_Mac,
			U_Remark,
			U_IDCard,
			U_Sex,
			U_BirthDay,
			U_MobileNo,
			U_UserNO,
			U_WorkStartDate,
			U_WorkEndDate,
			U_CompanyMail,
			U_Title,
			U_Extension,
			U_HomeTel,
			U_PhotoUrl,
			U_DateTime,
			U_LastIP,
			U_LastDateTime,
			U_ExtendField,
			U_LoginType
		) VALUES (	
			@U_LoginName,
			@U_Password,
			@U_CName,
			@U_EName,
			@U_GroupID,
			@U_Email,
			@U_Type,
			@U_Status,
			@U_Licence,
			@U_Mac,
			@U_Remark,
			@U_IDCard,
			@U_Sex,
			@U_BirthDay,
			@U_MobileNo,
			@U_UserNO,
			@U_WorkStartDate,
			@U_WorkEndDate,
			@U_CompanyMail,
			@U_Title,
			@U_Extension,
			@U_HomeTel,
			@U_PhotoUrl,
			@U_DateTime,
			@U_LastIP,
			@U_LastDateTime,
			@U_ExtendField,
			@U_LoginType
		)
		SET @ReturnValue = @@IDENTITY
	END
	
	-- 更新
	IF (@DB_Option_Action_='Update')
	BEGIN
		UPDATE sys_User SET	
			U_LoginName = @U_LoginName,
			U_Password = @U_Password,
			U_CName = @U_CName,
			U_EName = @U_EName,
			U_GroupID = @U_GroupID,
			U_Email = @U_Email,
			U_Type = @U_Type,
			U_Status = @U_Status,
			U_Licence = @U_Licence,
			U_Mac = @U_Mac,
			U_Remark = @U_Remark,
			U_IDCard = @U_IDCard,
			U_Sex = @U_Sex,
			U_BirthDay = @U_BirthDay,
			U_MobileNo = @U_MobileNo,
			U_UserNO = @U_UserNO,
			U_WorkStartDate = @U_WorkStartDate,
			U_WorkEndDate = @U_WorkEndDate,
			U_CompanyMail = @U_CompanyMail,
			U_Title = @U_Title,
			U_Extension = @U_Extension,
			U_HomeTel = @U_HomeTel,
			U_PhotoUrl = @U_PhotoUrl,
			U_DateTime = @U_DateTime,
			U_LastIP = @U_LastIP,
			U_LastDateTime = @U_LastDateTime,
			U_ExtendField = @U_ExtendField,
			U_LoginType = @U_LoginType
		WHERE (UserID = @UserID)
		
		SET @ReturnValue = @@ROWCOUNT
	END
	
	-- 删除
	IF (@DB_Option_Action_='Delete')
	BEGIN
		DELETE sys_User	WHERE (UserID = @UserID)
		SET @ReturnValue = @@ROWCOUNT
  	END

SELECT @ReturnValue


GO

