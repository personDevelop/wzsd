alter table ShopOrder add PublishDateTime datetime  null 
GO
IF OBJECT_ID ('dbo.AccountRange') IS NOT NULL
	DROP TABLE dbo.AccountRange
GO

CREATE TABLE dbo.AccountRange
	(
	ID           CHAR (36) NOT NULL,
	AccountID    NVARCHAR (50) NOT NULL,
	RangeID      NVARCHAR (50) NOT NULL,
	GetRangeTime DATETIME NOT NULL,
	GrowthValue  INT NOT NULL,
	JF           DECIMAL (15, 2) NOT NULL,
	CONSTRAINT PK_AccountRange PRIMARY KEY (ID)
	)
GO
IF OBJECT_ID ('dbo.AccuountRangeChange') IS NOT NULL
	DROP TABLE dbo.AccuountRangeChange
GO

CREATE TABLE dbo.AccuountRangeChange
	(
	ID             NVARCHAR (50) NOT NULL,
	PriRangeID     NVARCHAR (50),
	CurrentRangeID NVARCHAR (50) NOT NULL,
	ChangeTime     DATETIME NOT NULL,
	ChangeingValue INT NOT NULL,
	ChangedValue   INT NOT NULL,
	CONSTRAINT PK_AccuountRangeChange PRIMARY KEY (ID)
	)
GO

IF OBJECT_ID ('dbo.CusomerAndCoupon') IS NOT NULL
	DROP TABLE dbo.CusomerAndCoupon
GO

CREATE TABLE dbo.CusomerAndCoupon
	(
	ID         NVARCHAR (16) NOT NULL,
	Code       NVARCHAR (50) NOT NULL,
	CustomerID CHAR (36) NOT NULL,
	CouponID   CHAR (36) NOT NULL,
	UsedCount  INT NOT NULL,
	IsOutDate  BIT NOT NULL,
	HaveCount  INT NOT NULL,
	HasDate    DATETIME NOT NULL,
	CardValue  DECIMAL (15, 2) NOT NULL,
	CardPwd    NVARCHAR (50),
	EndDate    DATETIME NOT NULL,
	Remark     NVARCHAR (200) NOT NULL,
	CONSTRAINT PK_CusomerAndCoupon PRIMARY KEY (ID)
	)
GO
DELETE FunctionInfo
GO
INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('01d41db0-d04b-46d7-bcb4-d3907d2edaac', 'SysDeleteCasCheck', '数据删除检测', 0, NULL, 2, '', 'Admin', 'SysDeleteCasCheck', '', 1, 1, 0, '数据删除检测', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;01d41db0-d04b-46d7-bcb4-d3907d2edaac', 4, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('136b2cff-bb11-40df-ac0e-9d5852c84a88', 'OrderSet', '订单设置 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '订单设置 ', '2d7b69ad-9f65-42d6-a59e-b456c8d46d18', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('15b5b106-cc44-4324-b81f-aafae31ef87e', 'BrandInfo', '品牌管理', 0, NULL, 2, '', 'admin', 'ShopBrandInfo', '', 1, 1, 0, '品牌管理', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;15b5b106-cc44-4324-b81f-aafae31ef87e', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('1e207e56-83b9-4d44-9f96-649d446e97e1', 'Role', '角色管理', 0, NULL, 2, '', '', '', '', 1, 1, 0, '角色管理', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;1e207e56-83b9-4d44-9f96-649d446e97e1', 1, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('23258056-cd6b-4a18-a1ef-cc8004bce9c9', 'RedeemRules', '积分规则', 0, NULL, 2, '', 'admin', 'RedeemRules', '', 1, 1, 0, '积分规则', '45bb1151-b150-4d1c-afb0-6f1e02e0492e', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e;23258056-cd6b-4a18-a1ef-cc8004bce9c9', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('263a98cb-c749-43f4-8349-51bd4575e1fb', 'SystemSet', '系统设置 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '系统设置 ', 'dee59f07-ff44-4d56-a072-e93df0aed418', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb', 0, 0, 1, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('2d5ffa47-8639-4bfa-bc89-40063bd280dd', 'ShopProduct', '商品管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '商品管理', 'daf681f0-5160-4c81-8286-ae8230384117', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('2d7b69ad-9f65-42d6-a59e-b456c8d46d18', 'OrderManager', '订单管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '订单管理', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('3174ccff-b856-4feb-b3eb-f832bcdf1ac0', 'WebSiteSet', '站点', 0, NULL, 0, '', '', '', '', 1, 1, 0, '站点', '', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0', 0, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('3ae400a2-f5f9-4cdf-b687-d55835315bd3', 'ShopExpress', '物流公司', 0, NULL, 2, '', 'admin', 'ShopExpress', '', 1, 1, 0, '物流公司设置', '136b2cff-bb11-40df-ac0e-9d5852c84a88', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88;3ae400a2-f5f9-4cdf-b687-d55835315bd3', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('457eb3d7-4a1a-4fbb-97c5-89c70767afbc', 'OrderManager', '订单管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '订单管理', '2d7b69ad-9f65-42d6-a59e-b456c8d46d18', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('45bb1151-b150-4d1c-afb0-6f1e02e0492e', 'BasicSet', '基础设置', 0, NULL, 1, '', '', '', '', 1, 1, 0, '基础设置', 'a0d08689-d0dd-428d-ba6f-17d45106fc49', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('59b848a1-0f89-4cf5-a822-c01cb84cd343', 'ShopProductStationMode', '商品推荐', 0, NULL, 2, '', 'admin', 'ShopProductStationMode', '', 1, 1, 0, '商品推荐', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;59b848a1-0f89-4cf5-a822-c01cb84cd343', 4, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('602d81ca-742b-4c48-a61c-6f98746d8071', 'NewsManager', '新闻管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '新闻管理', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('67a5072a-bed6-47fe-b6fc-590e66c866a5', 'RangeDict', '会员等级字典', 0, NULL, 2, '', 'admin', 'RangeDict', '', 1, 1, 0, '会员等级字典', '708ab1ee-bc31-4b52-b5a9-435dc0095c94', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94;67a5072a-bed6-47fe-b6fc-590e66c866a5', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('6b013aa9-b469-4da9-983f-9b1c6f9ea0f6', 'ManagerUserInfo', '会员管理', 0, NULL, 2, '', 'admin', 'ManagerUserInfo', '', 1, 1, 0, '会员管理', '708ab1ee-bc31-4b52-b5a9-435dc0095c94', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94;6b013aa9-b469-4da9-983f-9b1c6f9ea0f6', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('708271ef-2961-4037-ae8d-9990e7419bff', 'OprLog', '操作日志', 0, NULL, 2, '', '', '', '', 1, 1, 0, '操作日志', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;708271ef-2961-4037-ae8d-9990e7419bff', 3, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('708ab1ee-bc31-4b52-b5a9-435dc0095c94', '会员管理', '会员管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '会员管理', '932ef051-e037-48b5-aa11-7f567c9b328e', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('75cf5fbb-8398-4b39-8f70-1b2956f8b18b', 'Order', '订单', 0, NULL, 0, '', '', '', '', 1, 1, 0, '订单', '', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b', 3, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('7c79b55d-4634-4456-bb89-56db03890675', 'Sail', '营销', 0, NULL, 0, '', '', '', '', 1, 1, 0, '营销', '', '7c79b55d-4634-4456-bb89-56db03890675', 4, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('81711aa4-f511-4f29-8e63-e9b96d945df5', 'NewsManager', '新闻管理 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '新闻管理 ', '602d81ca-742b-4c48-a61c-6f98746d8071', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('858a5567-37d9-43ad-9efa-359f835c5c30', 'ShopPorductType', '商品类型', 0, NULL, 2, '', 'admin', 'ShopProductType', '', 1, 1, 0, '商品类型', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;858a5567-37d9-43ad-9efa-359f835c5c30', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('86240fd2-653d-4e7d-a6b8-11cee301338b', 'Regions', '行政区域', 0, NULL, 2, '', 'admin', 'Regions', '', 1, 1, 0, '行政区域', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;86240fd2-653d-4e7d-a6b8-11cee301338b', 1, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('87527639-cf7e-44bd-be04-ed86f49d69c0', 'NewsCategory', '新闻分类定义', 0, NULL, 2, '', 'admin', 'NewsCategory', '', 1, 1, 0, '新闻分类', '81711aa4-f511-4f29-8e63-e9b96d945df5', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5;87527639-cf7e-44bd-be04-ed86f49d69c0', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('88cd9499-a1f0-4326-9b4c-9c1a443a6cad', 'ShopCategory', '商品分类', 0, NULL, 2, '', 'admin', 'ShopCategory', '', 1, 1, 0, '商品分类', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;88cd9499-a1f0-4326-9b4c-9c1a443a6cad', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('932ef051-e037-48b5-aa11-7f567c9b328e', 'ManagerInfo', '会员管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '会员管理', '996006a1-f179-4799-aa2c-48ef36988091', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('996006a1-f179-4799-aa2c-48ef36988091', 'MemberInfo', '会员', 0, NULL, 0, '', '', '', '', 1, 1, 0, '会员', '', '996006a1-f179-4799-aa2c-48ef36988091', 5, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', 'Shop', '商城', 0, NULL, 0, '', '', '', '', 1, 1, 0, '商城', '', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', 2, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('9f0fa643-c6c0-41dc-b671-379325c3b60b', '会员日志 ', '会员日志 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '会员日志 ', '932ef051-e037-48b5-aa11-7f567c9b328e', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;9f0fa643-c6c0-41dc-b671-379325c3b60b', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a0d08689-d0dd-428d-ba6f-17d45106fc49', 'SaileManager', '营销管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '营销管理', '7c79b55d-4634-4456-bb89-56db03890675', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a13c7ef0-912e-45eb-891c-5ba63427eea8', 'cxhd', '促销活动', 0, NULL, 2, '', 'Admin', 'ShopPromotion', '', 1, 1, 0, '促销活动', 'da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;da44f2c6-4f11-4dc2-aed5-5d83e3fb5655;a13c7ef0-912e-45eb-891c-5ba63427eea8', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a25e81b9-11a6-4fd9-bcb7-9b262f515744', 'NewsMangaer', '新闻管理', 0, NULL, 0, '', '', '', '', 1, 1, 0, '新闻管理', '', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744', 1, 0, 0, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a4f31c07-5de1-4957-a5cd-e7039abfd44f', 'SitManager', '站点管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '站点管理', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f', 0, 0, 1, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a7733e34-c94b-486e-b03c-37e5d2cec1fb', 'FunctionInfo', '功能管理', 0, NULL, 2, '', 'admin', 'FunctionInfo', '', 1, 1, 0, '功能管理', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;a7733e34-c94b-486e-b03c-37e5d2cec1fb', 2, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('ac844826-2534-429b-8ccb-80605a67a6e5', 'ConfirmOrder', '待确认订单', 0, NULL, 2, '', 'Admin', 'ShopOrder', '', 1, 1, 0, '待确认订单', '457eb3d7-4a1a-4fbb-97c5-89c70767afbc', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc;ac844826-2534-429b-8ccb-80605a67a6e5', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('af4ec15d-e0fc-4708-905a-83949e551cd0', 'SystemParaSet', '系统参数设置', 0, NULL, 2, '', 'admin', 'ParameterInfo', '', 1, 1, 0, '系统参数设置', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;af4ec15d-e0fc-4708-905a-83949e551cd0', 0, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('c3e23c63-229d-4391-be5d-77e7e69984a2', 'AllOrder', '全部订单', 0, NULL, 2, '', 'admin', 'ShopOrder', '', 1, 1, 0, '全部订单', '457eb3d7-4a1a-4fbb-97c5-89c70767afbc', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc;c3e23c63-229d-4391-be5d-77e7e69984a2', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('d81eb0fa-165f-4cda-8679-c3e5506224c2', 'NewsEdit', '新闻管理', 0, NULL, 2, '', 'admin', 'NewsInfo', '', 1, 1, 0, '新闻管理', '81711aa4-f511-4f29-8e63-e9b96d945df5', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5;d81eb0fa-165f-4cda-8679-c3e5506224c2', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', 'CXGL', '促销管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '促销管理', 'a0d08689-d0dd-428d-ba6f-17d45106fc49', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('daf681f0-5160-4c81-8286-ae8230384117', 'ShopManager', '商城管理', 0, NULL, 1, '', '', '', '', 1, 1, 0, '商城管理', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('dee59f07-ff44-4d56-a072-e93df0aed418', 'DeafultSite', '默认站点 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '默认站点 ', 'a4f31c07-5de1-4957-a5cd-e7039abfd44f', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418', 0, 0, 1, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('df157095-7bf9-44d4-bc44-ee5edba2775b', 'manager', '管理员管理', 0, NULL, 2, '', '', '', '', 1, 1, 0, '管理员管理', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;df157095-7bf9-44d4-bc44-ee5edba2775b', 0, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('eae32f0b-ca8c-4bfa-90bb-937431555b66', 'ShopPaymentTypes', '支付方式', 0, NULL, 2, '', 'admin', 'ShopPaymentTypes', '', 1, 1, 0, '支付方式', '136b2cff-bb11-40df-ac0e-9d5852c84a88', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88;eae32f0b-ca8c-4bfa-90bb-937431555b66', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f178f88b-5c20-499a-82bb-c3386dc9b306', 'YHQ', '优惠券', 0, NULL, 2, '', 'Admin', 'CouponRule', '', 1, 1, 0, '优惠券管理', '45bb1151-b150-4d1c-afb0-6f1e02e0492e', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e;f178f88b-5c20-499a-82bb-c3386dc9b306', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f696e2ff-22a0-4432-9bb4-4463ac422c03', 'SystemUser', '系统用户 ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '系统用户 ', 'dee59f07-ff44-4d56-a072-e93df0aed418', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f83be2b6-cfbb-485f-a095-746966ba0ead', 'ShopProduct', '商品维护', 0, NULL, 2, '', 'admin', 'ShopProductInfo', '', 1, 1, 0, '商品维护', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;f83be2b6-cfbb-485f-a095-746966ba0ead', 3, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f95979ca-0026-435e-8caf-dc6887095a1a', 'RoleRight', '角色授权', 0, NULL, 2, '', '', '', '', 1, 1, 0, '角色授权', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;f95979ca-0026-435e-8caf-dc6887095a1a', 2, 0, 0, '', 5)
GO

IF OBJECT_ID ('dbo.JFHistory') IS NOT NULL
	DROP TABLE dbo.JFHistory
GO

CREATE TABLE dbo.JFHistory
	(
	ID            NVARCHAR (36) NOT NULL,
	MemberID      NVARCHAR (36) NOT NULL,
	FX            INT NOT NULL,
	JFSouce       NVARCHAR (40) NOT NULL,
	JFSouceMainID NVARCHAR (50) NOT NULL,
	JFSouceSubID  NVARCHAR (36),
	JFCount       DECIMAL (9, 2) NOT NULL,
	JFState       INT NOT NULL,
	CreateDate    DATETIME NOT NULL,
	JFType        INT NOT NULL,
	CouponID      NVARCHAR (50),
	UserCouponID  NVARCHAR (50),
	ActivityID    NVARCHAR (50),
	CONSTRAINT PK_JFHistory PRIMARY KEY (ID)
	)
GO
DELETE ParameterInfo
GO
INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('0e8dc049-3503-498a-9512-1176ef8da7ac', 'cb219364-886d-4965-bee2-dfef78bded00', '01', '优惠券占总金额总比例', '100', '', 'cb219364-886d-4965-bee2-dfef78bded00;0e8dc049-3503-498a-9512-1176ef8da7ac', 1, 2, 1, 1, 0, 1, '100，表示订单金额可以为0，否则优惠券总金额只能占多少百分比
这个一般是用优惠券的时候，可能会导致订单金额为0', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 0, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('12c70a2b-1252-4b8f-a8f9-d0408165f380', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '01', '购物成长值兑换规则', '100', '100', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;12c70a2b-1252-4b8f-a8f9-d0408165f380', 1, 3, 1, 1, 0, 1, '值1 标示购物金额100 则获得成长值（值2）100', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1583b6ae-0016-45e2-9206-12577d928665', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', '01', '业务初始化数据', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665', 0, 2, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('16d17df6-c32f-4b3f-a6ad-ef8e15205afa', 'cb219364-886d-4965-bee2-dfef78bded00', '02', '成长值计算规则', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa', 0, 2, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1e423f5b-41f5-4c1a-9065-b76caa2e925e', '', '01', '系统内置参数', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 0, 1, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2227c7a6-9b63-456d-a756-0e503fa1a776', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '07', '生日礼包', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;2227c7a6-9b63-456d-a756-0e503fa1a776', 1, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', '84e88925-afdb-4385-8622-acac8e689dee', 'SDMYF', '满额送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', 1, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('317d28ca-83e3-4a50-9663-9831e3210016', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '04', '评价商品获得成长值', '20', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;317d28ca-83e3-4a50-9663-9831e3210016', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3457d513-680e-4302-b360-377932ea3351', '84e88925-afdb-4385-8622-acac8e689dee', 'MESYHQ', '满额送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3457d513-680e-4302-b360-377932ea3351', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '84e88925-afdb-4385-8622-acac8e689dee', 'MESFJ', '满额送赠品', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3c62b4ed-e42a-4155-a14a-188fbae6dcb0', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '01', '售后免运费', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;3c62b4ed-e42a-4155-a14a-188fbae6dcb0', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('454d745a-9f45-4ebc-928c-75e949118456', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '09', 'VIP贵宾专线', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;454d745a-9f45-4ebc-928c-75e949118456', 1, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('4f2bc1e9-cd6d-4ad8-bfb2-a16df43b36f3', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '03', '登陆获得成长值', '10', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;4f2bc1e9-cd6d-4ad8-bfb2-a16df43b36f3', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('4fb99cf2-37b9-4bf9-803a-126847ead445', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '04', '银牌会员特价', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;4fb99cf2-37b9-4bf9-803a-126847ead445', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('574da536-3d2f-4eaa-9215-ff6b31afa518', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '05', '金牌会员特价', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;574da536-3d2f-4eaa-9215-ff6b31afa518', 1, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('5f3a2d88-6e40-469b-a130-136f6e15857e', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSJF', '满额免运费', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;5f3a2d88-6e40-469b-a130-136f6e15857e', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('60544642-c2dd-411b-acdf-5ba2ca6c92b9', '1583b6ae-0016-45e2-9206-12577d928665', 'UserRegistContract', '用户注册协议', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;60544642-c2dd-411b-acdf-5ba2ca6c92b9', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    一、本站服务条款的确认和接纳本站的各项电子服务的所有权和运作权归本站。本站提供的服务将完全按照其发布的服务条款和操作规则严格执行。用户同意所有服 务条款并完成注册程序，才能成为本站的正式用户。用户确认：本协议条款是处理双方权利义务的约定，除非违反国家强制性法律，否则始终有效。在下订单的同 时，您也同时承认了您拥有购买这些产品的权利能力和行为能力，并且将您对您在订单中提供的所有信息的真实性负责。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    二、服务简介本站运用自己的操作系统通过 国际互联网络为用户提供网络服务。同时，用户必须： (1)自行配备上网的所需设备，包括个人电脑、调制解调器或其它必备上网装置。 (2)自行负担个人上网所支付的与此服务有关的电话费用、网络费用。基于本站所提供的网络服务的重要性，用户应同意 (1)提供详尽、准确的个人资料。 (2)不断更新注册资料，符合及时、详尽、准确的要求。本站不公开用户的姓名、地址、电子邮箱和笔名， 除以下情况外： (1)用户授权本站透露这些信息。 (2)相应的法律及程序要求本站提供用户的个人资料。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    三、价格和数量本站将尽最大努力保证您所购商品与网站上公布的价格一致。产品的价格和可获性都在本站 上指明，这类信息将随时更改。您所订购的商品，如果发生缺货，您有权取消定单。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    四、送货及费用本站将会把产品送到您所指定的送货地址。所有在本站上列出的 送货时间为参考时间，参考时间的计算是根据库存状况、正常的处理过程和送货时间、送货地点的基础上估计得出的。送货费用根据您选择的配送方式的不同而异。 请清楚准确地填写您的真实姓名、送货地址及联系方式。因如下情况造成订单延迟或无法配送等，本站将不迟延配送的责任： (1)客户提供错误信息和不详细的地址； (2)货物送达无人签收，由此造成的重复配送所产生的费用及相关的后果。 (3)不可抗力，例如：自然灾害、交通戒严、突发战争等。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    五、服务条款的修改本站将可能不定期的修改本用户协议的有关条款，一旦条款及服务内容产生变动， 本站将会在重要页面上提示修改内容。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    六、用户隐私制度尊重用户个人隐私是本站的一项基本政策。所以，作为对以上第二点人注册资料分析的补充，本站一定不会 在未经合法用户授权时公开、编辑或透露其注册资料及保存在本站中的非公开内容，除非有法律许可要求或本站在诚信的基础上认为透露这些信件在以下四种情况是 必要的。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    七、用户的帐号，密码和安全性用户一旦注册成功，成为本站的合法用户，将得到一个密码和用户名。您可随时根据指示改变您的密码。用户需谨慎合理的 保存、使用用户名和密码。用户若发现任何非法使用用户帐号或存在安全漏洞的情况，请立即通知本站和向公安机关报案。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    八、对用户信息的存储和限制本站有判定 用户的行为是否符合国家法律法规规定及本站服务条款权利，如果用户违背了国家法律法规规定或服务条款的规定，本站有中断对其提供网络服务的权利。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    九、用户 管理用户单独承担发布内容的责任。用户对服务的使用是根据所有适用于本站的国家法律、地方法律和国际法律标准的。用户必须遵循： (1)从中国境内向外传输技术性资料时必须符合中国有关法规。 (2)使用网络服务不作非法用途。 (3)不干扰或混乱网络服务。 (4)遵守所有使用网络服务的网络协议、规定、程序和惯例。用户须承诺不传输任何非法的、骚扰性的、中伤他人的、辱骂性的、恐性的、伤害性的、庸俗的，淫 秽等信息资料。另外，用户也不能传输何教唆他人构成犯罪行为的资料；不能传输助长国内不利条件和涉及国家安全的资料；不能传输任何不符合当地法规、国家法 律和国际法律的资料。未经许可而非法进入其它电脑系统是禁止的。若用户的行为不符合以上提到的服务条款，本站将作出独立判断立即取消用户服务帐号。用户需 对自己在网上的行为承担法律责任。用户若在本站上散布和传播反动、色情或其它违反国家法律的信息，本站的系统记录有可能作为用户违反法律的证据。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    十、通告 所有发给用户的通告都可通过重要页面的公告或电子邮件或常规的信件传送。用户协议条款的修改、服务变更、或其它重要事件的通告都会以此形式进行。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    十一、参 与广告策划用户在他们发表的信息中加入宣传资料或参与广告策划，在本站的免费服务上展示他们的产品，任何这类促销方法，包括运输货物、付款、服务、商业条 件、担保及与广告有关的描述都只是在相应的用户和广告销售商之间发生。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    十二、网络服务内容的所有权本站定义的网络服务内容包括：文字、软件、声音、图片、 录象、图表、广告中的全部内容；电子邮件的全部内容；本站为用户提供的其它信息。所有这些内容受版权、商标、标签和其它财产所有权法律的保护。所以，用户 只能在本站和广告商授权下才能使用这些内容，而不能擅自复制、再造这些内容、或创造与内容有关的派生产品。本站所有的文章版权归原文作者和本站共同所有， 任何人需要转载本站的文章，必须征得原文作者或本站授权。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    十三、责任限制如因不可抗力或其它本站无法控制的原因使本站销售系统崩溃或无法正常使用导致网上 交易无法完成或丢失有关的信息、记录等本站会尽可能合理地协助处理善后事宜，并努力使客户免受经济损失。
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
    十四、法律管辖和适用本协议的订立、执行和解释及 争议的解决均应适用中国法律。如发生本站服务条款与中国法律相抵触时，则这些条款将完全按法律规定重新解释，而其它合法条款则依旧保持对用户产生法律效力 和影响。本协议的规定是可分割的，如本协议任何规定被裁定为无效或不可执行，该规定可被删除而其余条款应予以执行。如双方就本协议内容或其执行发生任何争 议，双方应尽力友好协商解决；协商不成时，任何一方均可向本站所在地的人民法院提起诉讼。
</p>
<p>
    <br/>
</p>', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('749a6e17-8cec-4cc8-9009-00ee0a073f7b', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '02', '评论奖励', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;749a6e17-8cec-4cc8-9009-00ee0a073f7b', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('84e88925-afdb-4385-8622-acac8e689dee', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'jffl', '促销规则', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;84e88925-afdb-4385-8622-acac8e689dee', 0, 2, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('8a8777e8-3737-4f92-b964-97e922024903', '84e88925-afdb-4385-8622-acac8e689dee', 'SDZP', '首单送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;8a8777e8-3737-4f92-b964-97e922024903', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a0a119af-f3b2-474b-81ce-8d68875d7615', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '06', '全部会员特价优惠', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;a0a119af-f3b2-474b-81ce-8d68875d7615', 1, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a5c21066-8429-4f36-9103-150c46e5f7fb', '84e88925-afdb-4385-8622-acac8e689dee', 'MEZP', '首单送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;a5c21066-8429-4f36-9103-150c46e5f7fb', 1, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a87fed1e-ef6c-49af-8278-9674a5eaf45f', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '08', '专享礼包', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;a87fed1e-ef6c-49af-8278-9674a5eaf45f', 1, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSYHQ', '首单送赠品', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', 1, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('cb219364-886d-4965-bee2-dfef78bded00', '', '02', '用户自定义参数', '', '', 'cb219364-886d-4965-bee2-dfef78bded00', 0, 1, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce04cb8c-7d10-4b74-bb45-2c8fec920467', '1583b6ae-0016-45e2-9206-12577d928665', 'OrderStatus', '订单状态', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ce04cb8c-7d10-4b74-bb45-2c8fec920467', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce9c37da-1c7e-4216-96d3-2151e39db16c', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '03', '铜牌会员特价', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;ce9c37da-1c7e-4216-96d3-2151e39db16c', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d6070e00-f3b1-47ad-a55a-673fb3cec6c5', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '02', '注册获得成长值', '20', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;d6070e00-f3b1-47ad-a55a-673fb3cec6c5', 1, 3, 1, 1, 0, 1, '注册获得成长值', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d677d840-241f-439e-8025-2556a28ca523', '84e88925-afdb-4385-8622-acac8e689dee', 'RegsitJf', '首单免运费', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d677d840-241f-439e-8025-2556a28ca523', 1, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', '84e88925-afdb-4385-8622-acac8e689dee', 'FreeYF', '注册送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', 1, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', '84e88925-afdb-4385-8622-acac8e689dee', 'RegistToQuan', '注册送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', 1, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', '1583b6ae-0016-45e2-9206-12577d928665', '01', '图片服务器地址', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', 1, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('f339c10e-0106-47b1-b16f-95eb9702d6a5', 'cb219364-886d-4965-bee2-dfef78bded00', '03', '会员服务', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5', 0, 2, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('fb4704d4-b600-4f46-9b1f-0d68c3a299ed', '84e88925-afdb-4385-8622-acac8e689dee', 'MEMYF', '包邮', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;fb4704d4-b600-4f46-9b1f-0d68c3a299ed', 1, 3, 1, 1, 0, 1, '', 10, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

IF OBJECT_ID ('dbo.RangeDict') IS NOT NULL
	DROP TABLE dbo.RangeDict
GO

CREATE TABLE dbo.RangeDict
	(
	ID          CHAR (36) NOT NULL,
	RankLevel   NVARCHAR (50) NOT NULL,
	Name        NVARCHAR (100) NOT NULL,
	Img         CHAR (36),
	MinVal      DECIMAL (15, 2) NOT NULL,
	MaxVal      DECIMAL (15, 2) NOT NULL,
	IsEnable    BIT NOT NULL,
	Note        NVARCHAR (500),
	LevelYear   INT NOT NULL,
	ReduceValue INT NOT NULL,
	HasService  NVARCHAR (500) NOT NULL,
	CONSTRAINT PK_RangeDict PRIMARY KEY (ID)
	)
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('168a2a81-b4b2-4ba2-958a-aa19b511552c', '4', '金牌会员', NULL, 10000, 30000, 1, '成长值大于10000，且小于30000', 1, 4000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,574da536-3d2f-4eaa-9215-ff6b31afa518,2227c7a6-9b63-456d-a756-0e503fa1a776,a87fed1e-ef6c-49af-8278-9674a5eaf45f')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('4b033ff0-a5a4-49a0-a348-dd250ae61328', '3', '银牌会员', NULL, 2000, 10000, 1, '成长值大于2000 且小于10000', 1, 1000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,2227c7a6-9b63-456d-a756-0e503fa1a776')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('889248a7-cd25-40f6-a65c-68fa056c4ee2', '5', '钻石会员', NULL, 30000, 0, 1, '成长值大于30000', 1, 10000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,574da536-3d2f-4eaa-9215-ff6b31afa518,a0a119af-f3b2-474b-81ce-8d68875d7615,2227c7a6-9b63-456d-a756-0e503fa1a776,a87fed1e-ef6c-49af-8278-9674a5eaf45f,454d745a-9f45-4ebc-928c-75e949118456')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('98dcdebe-93b3-494b-ba7c-20b9dbc1673d', '1', '注册会员', NULL, 0, 1, 1, '注册成功后即成为会员', 0, 0, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('aa026f72-0ffd-4b70-a439-774e298cbad6', '2', '铜牌会员', NULL, 1, 2000, 1, '成长值大于0且小于2000', 0, 0, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c')
GO

IF OBJECT_ID ('dbo.ShopExpress') IS NOT NULL
	DROP TABLE dbo.ShopExpress
GO

CREATE TABLE dbo.ShopExpress
	(
	ID       CHAR (36) NOT NULL,
	Code     NVARCHAR (50) NOT NULL,
	Name     NVARCHAR (100) NOT NULL,
	IsEnable BIT NOT NULL,
	CONSTRAINT PK_ShopExpress PRIMARY KEY (ID)
	)
GO
INSERT INTO dbo.ShopExpress (ID, Code, Name, IsEnable)
VALUES ('7f283c53-7531-4799-9a2f-e63d70b62579', 'HHWL', '海虹物流', 1)
GO

INSERT INTO dbo.ShopExpress (ID, Code, Name, IsEnable)
VALUES ('f0d1ff81-8334-4c97-b6b8-f9839c1f27b2', 'Express', '顺丰快递', 1)
GO

 
  IF OBJECT_ID ('dbo.ShopOrderAction') IS NOT NULL
	DROP TABLE dbo.ShopOrderAction
GO

CREATE TABLE dbo.ShopOrderAction
	(
	ID         CHAR (36) NOT NULL,
	OrderId    NVARCHAR (50) NOT NULL,
	UserId     CHAR (36) NOT NULL,
	Username   NVARCHAR (50) NOT NULL,
	ActionCode NVARCHAR (50) NOT NULL,
	ActionDate DATETIME NOT NULL,
	Remark     NVARCHAR (500),
	ActionName NVARCHAR (50) NOT NULL,
	CONSTRAINT PK_ShopOrderAction PRIMARY KEY (ID)
	)
GO





