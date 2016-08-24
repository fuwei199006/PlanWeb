/* 
* @Author: fuwei
* @Date:   2016-08-21 17:01:55
* @Last Modified by:   fuwei
* @Last Modified time: 2016-08-21 22:59:42
*/

--CREATE DATABASE PlanDB;

---Basic 
CREATE TABLE Basic_UserInfo
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      LoginName NVARCHAR(50) NOT NULL ,
      UserEmail NVARCHAR(50) NOT NULL ,
      UserPwd NVARCHAR(100) NOT NULL ,
      RealName NVARCHAR(20) ,
      RegisterDevice NVARCHAR(50) ,
      RegisterIp NVARCHAR(10) ,
      RegiserHeader NVARCHAR(200) ,
      RegisterTime DATETIME ,
      UserStaus INT DEFAULT 1 ,
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
      LoginName NVARCHAR(50) ,
      LoginTime DATETIME ,
      ExpireTime DATETIME ,
      LoginIp NVARCHAR(10) ,
      LoginHeader NVARCHAR(100) ,
      IsDelete BIT DEFAULT 1 ,
      LastUpdateTime DATETIME
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

CREATE TABLE Basic_Register
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      RegisterName NVARCHAR(50) NOT NULL ,
      RegisterTime DATETIME ,
      Expiretime DATETIME ,
      RegisterStatus BIT DEFAULT 1 ,
      RegisterDevice NVARCHAR(100) NOT NULL ,
      RetisterIp NVARCHAR(10) NOT NULL
    );

CREATE TABLE Basic_Article
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      Title NVARCHAR(200) NOT NULL ,
      Author NVARCHAR(50) NOT NULL ,
      Category NVARCHAR(50) NOT NULL ,
      Content NVARCHAR(MAX) NOT NULL ,
      Source NVARCHAR(100) NOT NULL ,
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

CREATE TABLE Config
    (
      Id INT PRIMARY KEY
             IDENTITY ,
      ConfigKey NVARCHAR(20) ,
      ConfigValue NVARCHAR(100) ,
      CongfigStatus BIT DEFAULT 1 ,
      CreateTime DATETIME ,
      ModifyTime DATETIME
    );