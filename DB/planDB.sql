/* 
* @Author: fuwei
* @Date:   2016-08-21 17:01:55
* @Last Modified by:   付威
* @Last Modified time: 2016-10-27 23:47:20
*/

--CREATE DATABASE PlanDB;
USE PlanDB
GO 
---Basic 
DROP TABLE dbo.Basic_UserInfo
CREATE TABLE Basic_UserInfo
    (
      Id INT PRIMARY KEY
             IDENTITY ,
    
      LoginName NVARCHAR(50) NOT NULL ,
      NickName NVARCHAR(50) NOT NULL ,
      UserEmail NVARCHAR(50) NOT NULL ,
      UserPwd NVARCHAR(100) NOT NULL ,
      RealName NVARCHAR(20) ,
      RegisterDevice NVARCHAR(500) ,
      RegisterIp NVARCHAR(10) ,
      RegiserHeader NVARCHAR(200) ,
      RegisterTime DATETIME ,
      UserStaus INT DEFAULT 1 ,
	        CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_Role
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      RoleName NVARCHAR(50) ,
      RoleStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_Menu
    (
      Id INT IDENTITY
             PRIMARY KEY ,
      MenuName NVARCHAR(50) ,
      MenuUrl NVARCHAR(100) ,
      MenuType NVARCHAR(10) ,
      MenuSort INT ,
      MenuParentId INT ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_UserRole
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      UserId INT NOT NULL ,
      RoleId INT NOT NULL ,
      MappingStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_Power
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      PoweName NVARCHAR(50) NOT NULL ,
      PowerStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_PowerRole
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      RoleId INT NOT NULL ,
      PowerId INT NOT NULL ,
      MappingStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );
 

CREATE TABLE Basic_LoginInfo
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      LoginUserId int not NULL,
      LoginName NVARCHAR(50) ,
      LoginTime DATETIME ,
      LoginStatus int not NULL DEFAULT(1),
      LoginType int not NULL DEFAULT(1),
      ExpireTime DATETIME ,
      LoginIp NVARCHAR(10) ,
      LoginHeader NVARCHAR(100) ,
      IsDelete BIT DEFAULT 0 ,
      LastUpdateTime DATETIME,
      LoginToken UNIQUEIDENTIFIER,
      CreateTime DATETIME
    );

CREATE TABLE Basic_MainData
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      MainKey NVARCHAR(20) NOT NULL ,
      MainCode NVARCHAR(20) NOT NULL ,
      MainData NVARCHAR(100) NOT NULL ,
      MainStatus BIT NOT NULL
                     DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

CREATE TABLE Basic_Dictionary
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      FieldName NVARCHAR(50) NOT NULL ,
      FieldRemark NVARCHAR(50) NOT NULL ,
      DicStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );

	DROP TABLE dbo.Basic_Register
CREATE TABLE Basic_Register
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      RegisterName NVARCHAR(50) NOT NULL ,
      RegisterPassword NVARCHAR(100) NOT NULL ,
   
      RegisterEmail nvarchar(50) not NULL,
      RegisterPhone nvarchar(20) not NULL,
      RegisterTime DATETIME ,
      Expiretime DATETIME ,
      RegisterStatus BIT DEFAULT 1 ,
      RegisterDevice NVARCHAR(500) NOT NULL ,
      RetisterIp NVARCHAR(10) NOT NULL,
        CreateTime DATETIME,
        RegisterToken UNIQUEIDENTIFIER
    );

CREATE TABLE Basic_Article
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      Title NVARCHAR(200) NOT NULL ,
      SubTitle NVARCHAR(200),
      Author NVARCHAR(50) NOT NULL ,
      Category NVARCHAR(50) NOT NULL ,
      Content NVARCHAR(MAX) NOT NULL ,
      Source NVARCHAR(100) NOT NULL ,
      SourceUrl NVARCHAR(100) NOT NULL ,
      Sort int not null DEFAULT 1,
      KeyWord NVARCHAR(50) ,
      CreateTime DATETIME ,
      ModifyTIme DATETIME ,
      ArticleStatus INT DEFAULT 1,
    );

CREATE TABLE Basic_Draft
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      Title NVARCHAR(200) ,
      Author NVARCHAR(50) ,
      Category NVARCHAR(50) ,
      Content NVARCHAR(MAX) ,
      Source NVARCHAR(100) ,
      KeyWord NVARCHAR(50) ,
      CreateTime DATETIME ,
      ModifyTIme DATETIME
    );


CREATE TABLE Basic_Task
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      TaskName NVARCHAR(20) NOT NULL ,
      StarTime DATETIME NOT NULL ,
      EndTime DATETIME NOT NULL ,
      TaskStatus BIT DEFAULT 1 ,
      ExecTime DATETIME ,
      ExecEndTime DATETIME ,
      ReturnMsg NVARCHAR(200)
    );

 
CREATE TABLE Basic_MessageBox
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      Title NVARCHAR(200) NOT NULL ,
      Content NVARCHAR(4000) NOT NULL ,
      MessageStatus INT DEFAULT 0 ,
      ToUserId INT NOT NULL ,
      ToUserName NVARCHAR(50) ,
      FromUserId INT NOT NULL ,
      FromUserName NVARCHAR(50) ,
      SentTime DATETIME NOT NULL
    );

CREATE TABLE Basic_Config
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      ConfigKey NVARCHAR(20) ,
      ConfigValue NVARCHAR(2000) ,
      CongfigStatus BIT DEFAULT 1 ,
      ConfigCategory NVARCHAR(50),
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );
    
CREATE TABLE [dbo].[Basic_Log](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [Level] [nvarchar](50) NULL,
  [Logger] [nvarchar](255) NULL,
  [Host] [nvarchar](50) NULL,
  [Date] [datetime] NULL,
  [Thread] [nvarchar](255) NULL,
  [Message] [nvarchar](max) NULL,
  [Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log4net] PRIMARY KEY CLUSTERED 
(
  [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

 CREATE TABLE Basic_Comment (
  Id int IDENTITY PRIMARY KEY,
  Content NVARCHAR(2000) not NULL,
  CommitUserName NVARCHAR(100) not null,
  CommitUserId int not null,
  CommitType int DEFAULT 1, --1,评论 2,赞 3，批
  CreateTime datetime DEFAULT getdate(),
  ModifyTime datetime DEFAULT getdate()

)


CREATE TABLE Basice_ActionHistory
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      ActionType NVARCHAR(50) NOT NULL ,
      ActionName NVARCHAR(50) NOT NULL ,
      ActionExcutorId NVARCHAR(50) NOT NULL ,
      ActionExcutorName NVARCHAR(50) NOT NULL ,
      ActionExcutorRole NVARCHAR(50) NOT NULL ,
      ActionBackPack NVARCHAR(MAX) ,
      ActionResult NVARCHAR(MAX) ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );
 
 
    CREATE TABLE Basic_DbMonitorLog
        (
          Id INT PRIMARY KEY
                 IDENTITY ,
		 ModuleId NVARCHAR(20),
          TableName NVARCHAR(100) NOT NULL ,
          DbName NVARCHAR(40) NOT NULL ,
          EventType NVARCHAR(20) NOT NULL ,
          NewValues NVARCHAR(MAX) NOT NULL ,
          UserName NVARCHAR(100) ,
		  ModuleName NVARCHAR(50), 
          CreateTime DATETIME ,
          ModifyTime DATETIME
        );
	

---config数据 
USE [PlanDB]
GO
SET IDENTITY_INSERT [dbo].[Basic_Config] ON 

INSERT [dbo].[Basic_Config] ([Id], [ConfigKey], [ConfigValue], [CongfigStatus], [ConfigCategory], [CreateTime], [ModifyTime]) VALUES (1, N'DaoConfig', N'<?xml version="1.0" encoding="utf-16"?>
<DaoConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" Log="ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=" BaseDao="ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=" BussinessDaoConfig="ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=">
  <Id>1</Id>
  <CreateTime>2016-08-27T23:43:21.3589883+08:00</CreateTime>
</DaoConfig>', 1, N'Dao', CAST(N'2016-08-27 00:00:00.000' AS DateTime), CAST(N'2016-08-27 00:00:00.000' AS DateTime))
INSERT [dbo].[Basic_Config] ([Id], [ConfigKey], [ConfigValue], [CongfigStatus], [ConfigCategory], [CreateTime], [ModifyTime]) VALUES (2, N'CacheConfig', N'<CacheConfig>
  <CacheProviderItems>
    <CacheProviderItem name="LocalCacheProvider" type="Core.Cache.LocalCacheProvider,Core.Cache" desc="本地缓存" />
  </CacheProviderItems>
  <CacheConfigItems>
    <CacheConfigItem desc="全局缓存" priority="0" keyRegex=".*" moduleRegex=".*" providerName="LocalCacheProvider" minitus="30" isAbsoluteExpiration="true" />
    <CacheConfigItem desc="LoginInfo缓存" priority="1" keyRegex="LoginInfo.*" moduleRegex=".*" providerName="LocalCacheProvider" minitus="10" isAbsoluteExpiration="true" />
  </CacheConfigItems>
</CacheConfig>', 1, N'Cache', CAST(N'2016-08-27 00:00:00.000' AS DateTime), CAST(N'2016-08-27 00:00:00.000' AS DateTime))
INSERT [dbo].[Basic_Config] ([Id], [ConfigKey], [ConfigValue], [CongfigStatus], [ConfigCategory], [CreateTime], [ModifyTime]) VALUES (3, N'SettingConfig', N' <SettingConfig > <WebSiteTitle>GMS管理系统</WebSiteTitle> </SettingConfig>', 1, N'Web', CAST(N'2016-08-27 00:00:00.000' AS DateTime), CAST(N'2016-08-27 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Basic_Config] OFF



--Update 

ALTER TABLE dbo.Basic_LoginInfo ADD LoginNickName NVARCHAR(50) 



---2016-10-27   
 
      ALTER  TABLE dbo.Basic_UserInfo ADD MobilePhone NVARCHAR(20);
   ALTER TABLE dbo.Basic_UserInfo ADD BirthDay DATETIME;
   ALTER TABLE dbo.Basic_UserInfo ADD QQ NVARCHAR(15);
   ALTER TABLE dbo.Basic_UserInfo ADD Weixin NVARCHAR(20);
   ALTER TABLE dbo.Basic_UserInfo ADD Addr NVARCHAR(100);
   ALTER TABLE dbo.Basic_UserInfo ADD OtherInfo NVARCHAR(100);
   ALTER TABLE dbo.Basic_UserInfo ADD Sex INT;


1 首页  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
2 热点  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
3 新闻  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
4 历史  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
5 国学  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
6 军事  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
7 话题  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
8 科技  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
9 关于我们  NULL  Nav 3 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
12  教程  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
13  社会  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
14  其它  NULL  Nav 1 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
16  占位  NULL  Nav 2 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
17  权限管理  javascript:void(0)  Group 1 0 2016-10-24 22:30:03.247 2016-10-27 22:46:44.070 1 icon-cog
18  菜单管理  Menu  Item  2 17  2016-10-24 22:30:03.247 2016-10-27 22:18:22.480 1 icon-reorder
19  用户管理  User  Item  1 17  2016-10-24 22:30:03.247 2016-10-27 22:43:36.373 1 icon-user
20  权限管理  Power Item  3 17  2016-10-24 22:30:03.247 2016-10-27 22:45:47.900 1 icon-filter
21  角色管理  Role  Item  4 17  2016-10-24 22:30:03.247 2016-10-27 22:47:16.860 1 icon-group
22  系统管理  NULL  Group 2 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
23  数据库管理 NULL  Item  1 22  2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
24  缓存管理  NULL  Item  2 22  2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
25  日志管理  NULL  Item  3 22  2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
26  系统设置  NULL  Item  4 22  2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
27  系统信息  NULL  Group 3 0 2016-10-24 22:30:03.247 2016-10-24 22:30:03.247 1 NULL
28  系统日志  aa  Item  1 22  2016-10-26 22:10:29.413 2016-10-26 22:10:29.413 0 NULL

