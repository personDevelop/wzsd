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
VALUES ('01d41db0-d04b-46d7-bcb4-d3907d2edaac', 'SysDeleteCasCheck', '����ɾ�����', 0, NULL, 2, '', 'Admin', 'SysDeleteCasCheck', '', 1, 1, 0, '����ɾ�����', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;01d41db0-d04b-46d7-bcb4-d3907d2edaac', 4, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('136b2cff-bb11-40df-ac0e-9d5852c84a88', 'OrderSet', '�������� ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '�������� ', '2d7b69ad-9f65-42d6-a59e-b456c8d46d18', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('15b5b106-cc44-4324-b81f-aafae31ef87e', 'BrandInfo', 'Ʒ�ƹ���', 0, NULL, 2, '', 'admin', 'ShopBrandInfo', '', 1, 1, 0, 'Ʒ�ƹ���', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;15b5b106-cc44-4324-b81f-aafae31ef87e', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('1e207e56-83b9-4d44-9f96-649d446e97e1', 'Role', '��ɫ����', 0, NULL, 2, '', '', '', '', 1, 1, 0, '��ɫ����', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;1e207e56-83b9-4d44-9f96-649d446e97e1', 1, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('23258056-cd6b-4a18-a1ef-cc8004bce9c9', 'RedeemRules', '���ֹ���', 0, NULL, 2, '', 'admin', 'RedeemRules', '', 1, 1, 0, '���ֹ���', '45bb1151-b150-4d1c-afb0-6f1e02e0492e', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e;23258056-cd6b-4a18-a1ef-cc8004bce9c9', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('263a98cb-c749-43f4-8349-51bd4575e1fb', 'SystemSet', 'ϵͳ���� ', 0, NULL, 1, '', '', '', '', 1, 1, 0, 'ϵͳ���� ', 'dee59f07-ff44-4d56-a072-e93df0aed418', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb', 0, 0, 1, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('2d5ffa47-8639-4bfa-bc89-40063bd280dd', 'ShopProduct', '��Ʒ����', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��Ʒ����', 'daf681f0-5160-4c81-8286-ae8230384117', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('2d7b69ad-9f65-42d6-a59e-b456c8d46d18', 'OrderManager', '��������', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��������', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('3174ccff-b856-4feb-b3eb-f832bcdf1ac0', 'WebSiteSet', 'վ��', 0, NULL, 0, '', '', '', '', 1, 1, 0, 'վ��', '', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0', 0, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('3ae400a2-f5f9-4cdf-b687-d55835315bd3', 'ShopExpress', '������˾', 0, NULL, 2, '', 'admin', 'ShopExpress', '', 1, 1, 0, '������˾����', '136b2cff-bb11-40df-ac0e-9d5852c84a88', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88;3ae400a2-f5f9-4cdf-b687-d55835315bd3', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('457eb3d7-4a1a-4fbb-97c5-89c70767afbc', 'OrderManager', '��������', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��������', '2d7b69ad-9f65-42d6-a59e-b456c8d46d18', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('45bb1151-b150-4d1c-afb0-6f1e02e0492e', 'BasicSet', '��������', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��������', 'a0d08689-d0dd-428d-ba6f-17d45106fc49', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('59b848a1-0f89-4cf5-a822-c01cb84cd343', 'ShopProductStationMode', '��Ʒ�Ƽ�', 0, NULL, 2, '', 'admin', 'ShopProductStationMode', '', 1, 1, 0, '��Ʒ�Ƽ�', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;59b848a1-0f89-4cf5-a822-c01cb84cd343', 4, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('602d81ca-742b-4c48-a61c-6f98746d8071', 'NewsManager', '���Ź���', 0, NULL, 1, '', '', '', '', 1, 1, 0, '���Ź���', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('67a5072a-bed6-47fe-b6fc-590e66c866a5', 'RangeDict', '��Ա�ȼ��ֵ�', 0, NULL, 2, '', 'admin', 'RangeDict', '', 1, 1, 0, '��Ա�ȼ��ֵ�', '708ab1ee-bc31-4b52-b5a9-435dc0095c94', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94;67a5072a-bed6-47fe-b6fc-590e66c866a5', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('6b013aa9-b469-4da9-983f-9b1c6f9ea0f6', 'ManagerUserInfo', '��Ա����', 0, NULL, 2, '', 'admin', 'ManagerUserInfo', '', 1, 1, 0, '��Ա����', '708ab1ee-bc31-4b52-b5a9-435dc0095c94', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94;6b013aa9-b469-4da9-983f-9b1c6f9ea0f6', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('708271ef-2961-4037-ae8d-9990e7419bff', 'OprLog', '������־', 0, NULL, 2, '', '', '', '', 1, 1, 0, '������־', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;708271ef-2961-4037-ae8d-9990e7419bff', 3, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('708ab1ee-bc31-4b52-b5a9-435dc0095c94', '��Ա����', '��Ա����', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��Ա����', '932ef051-e037-48b5-aa11-7f567c9b328e', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;708ab1ee-bc31-4b52-b5a9-435dc0095c94', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('75cf5fbb-8398-4b39-8f70-1b2956f8b18b', 'Order', '����', 0, NULL, 0, '', '', '', '', 1, 1, 0, '����', '', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b', 3, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('7c79b55d-4634-4456-bb89-56db03890675', 'Sail', 'Ӫ��', 0, NULL, 0, '', '', '', '', 1, 1, 0, 'Ӫ��', '', '7c79b55d-4634-4456-bb89-56db03890675', 4, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('81711aa4-f511-4f29-8e63-e9b96d945df5', 'NewsManager', '���Ź��� ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '���Ź��� ', '602d81ca-742b-4c48-a61c-6f98746d8071', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5', 0, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('858a5567-37d9-43ad-9efa-359f835c5c30', 'ShopPorductType', '��Ʒ����', 0, NULL, 2, '', 'admin', 'ShopProductType', '', 1, 1, 0, '��Ʒ����', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;858a5567-37d9-43ad-9efa-359f835c5c30', 2, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('86240fd2-653d-4e7d-a6b8-11cee301338b', 'Regions', '��������', 0, NULL, 2, '', 'admin', 'Regions', '', 1, 1, 0, '��������', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;86240fd2-653d-4e7d-a6b8-11cee301338b', 1, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('87527639-cf7e-44bd-be04-ed86f49d69c0', 'NewsCategory', '���ŷ��ඨ��', 0, NULL, 2, '', 'admin', 'NewsCategory', '', 1, 1, 0, '���ŷ���', '81711aa4-f511-4f29-8e63-e9b96d945df5', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5;87527639-cf7e-44bd-be04-ed86f49d69c0', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('88cd9499-a1f0-4326-9b4c-9c1a443a6cad', 'ShopCategory', '��Ʒ����', 0, NULL, 2, '', 'admin', 'ShopCategory', '', 1, 1, 0, '��Ʒ����', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;88cd9499-a1f0-4326-9b4c-9c1a443a6cad', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('932ef051-e037-48b5-aa11-7f567c9b328e', 'ManagerInfo', '��Ա����', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��Ա����', '996006a1-f179-4799-aa2c-48ef36988091', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('996006a1-f179-4799-aa2c-48ef36988091', 'MemberInfo', '��Ա', 0, NULL, 0, '', '', '', '', 1, 1, 0, '��Ա', '', '996006a1-f179-4799-aa2c-48ef36988091', 5, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', 'Shop', '�̳�', 0, NULL, 0, '', '', '', '', 1, 1, 0, '�̳�', '', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', 2, 0, 1, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('9f0fa643-c6c0-41dc-b671-379325c3b60b', '��Ա��־ ', '��Ա��־ ', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��Ա��־ ', '932ef051-e037-48b5-aa11-7f567c9b328e', '996006a1-f179-4799-aa2c-48ef36988091;932ef051-e037-48b5-aa11-7f567c9b328e;9f0fa643-c6c0-41dc-b671-379325c3b60b', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a0d08689-d0dd-428d-ba6f-17d45106fc49', 'SaileManager', 'Ӫ������', 0, NULL, 1, '', '', '', '', 1, 1, 0, 'Ӫ������', '7c79b55d-4634-4456-bb89-56db03890675', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a13c7ef0-912e-45eb-891c-5ba63427eea8', 'cxhd', '�����', 0, NULL, 2, '', 'Admin', 'ShopPromotion', '', 1, 1, 0, '�����', 'da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;da44f2c6-4f11-4dc2-aed5-5d83e3fb5655;a13c7ef0-912e-45eb-891c-5ba63427eea8', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a25e81b9-11a6-4fd9-bcb7-9b262f515744', 'NewsMangaer', '���Ź���', 0, NULL, 0, '', '', '', '', 1, 1, 0, '���Ź���', '', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744', 1, 0, 0, '', 1)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a4f31c07-5de1-4957-a5cd-e7039abfd44f', 'SitManager', 'վ�����', 0, NULL, 1, '', '', '', '', 1, 1, 0, 'վ�����', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f', 0, 0, 1, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('a7733e34-c94b-486e-b03c-37e5d2cec1fb', 'FunctionInfo', '���ܹ���', 0, NULL, 2, '', 'admin', 'FunctionInfo', '', 1, 1, 0, '���ܹ���', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;a7733e34-c94b-486e-b03c-37e5d2cec1fb', 2, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('ac844826-2534-429b-8ccb-80605a67a6e5', 'ConfirmOrder', '��ȷ�϶���', 0, NULL, 2, '', 'Admin', 'ShopOrder', '', 1, 1, 0, '��ȷ�϶���', '457eb3d7-4a1a-4fbb-97c5-89c70767afbc', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc;ac844826-2534-429b-8ccb-80605a67a6e5', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('af4ec15d-e0fc-4708-905a-83949e551cd0', 'SystemParaSet', 'ϵͳ��������', 0, NULL, 2, '', 'admin', 'ParameterInfo', '', 1, 1, 0, 'ϵͳ��������', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;af4ec15d-e0fc-4708-905a-83949e551cd0', 0, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('c3e23c63-229d-4391-be5d-77e7e69984a2', 'AllOrder', 'ȫ������', 0, NULL, 2, '', 'admin', 'ShopOrder', '', 1, 1, 0, 'ȫ������', '457eb3d7-4a1a-4fbb-97c5-89c70767afbc', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;457eb3d7-4a1a-4fbb-97c5-89c70767afbc;c3e23c63-229d-4391-be5d-77e7e69984a2', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('d81eb0fa-165f-4cda-8679-c3e5506224c2', 'NewsEdit', '���Ź���', 0, NULL, 2, '', 'admin', 'NewsInfo', '', 1, 1, 0, '���Ź���', '81711aa4-f511-4f29-8e63-e9b96d945df5', 'a25e81b9-11a6-4fd9-bcb7-9b262f515744;602d81ca-742b-4c48-a61c-6f98746d8071;81711aa4-f511-4f29-8e63-e9b96d945df5;d81eb0fa-165f-4cda-8679-c3e5506224c2', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', 'CXGL', '��������', 0, NULL, 1, '', '', '', '', 1, 1, 0, '��������', 'a0d08689-d0dd-428d-ba6f-17d45106fc49', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;da44f2c6-4f11-4dc2-aed5-5d83e3fb5655', 1, 0, 0, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('daf681f0-5160-4c81-8286-ae8230384117', 'ShopManager', '�̳ǹ���', 0, NULL, 1, '', '', '', '', 1, 1, 0, '�̳ǹ���', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117', 0, 0, 0, '', 2)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('dee59f07-ff44-4d56-a072-e93df0aed418', 'DeafultSite', 'Ĭ��վ�� ', 0, NULL, 1, '', '', '', '', 1, 1, 0, 'Ĭ��վ�� ', 'a4f31c07-5de1-4957-a5cd-e7039abfd44f', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418', 0, 0, 1, '', 3)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('df157095-7bf9-44d4-bc44-ee5edba2775b', 'manager', '����Ա����', 0, NULL, 2, '', '', '', '', 1, 1, 0, '����Ա����', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;df157095-7bf9-44d4-bc44-ee5edba2775b', 0, 0, 0, '', 5)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('eae32f0b-ca8c-4bfa-90bb-937431555b66', 'ShopPaymentTypes', '֧����ʽ', 0, NULL, 2, '', 'admin', 'ShopPaymentTypes', '', 1, 1, 0, '֧����ʽ', '136b2cff-bb11-40df-ac0e-9d5852c84a88', '75cf5fbb-8398-4b39-8f70-1b2956f8b18b;2d7b69ad-9f65-42d6-a59e-b456c8d46d18;136b2cff-bb11-40df-ac0e-9d5852c84a88;eae32f0b-ca8c-4bfa-90bb-937431555b66', 0, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f178f88b-5c20-499a-82bb-c3386dc9b306', 'YHQ', '�Ż�ȯ', 0, NULL, 2, '', 'Admin', 'CouponRule', '', 1, 1, 0, '�Ż�ȯ����', '45bb1151-b150-4d1c-afb0-6f1e02e0492e', '7c79b55d-4634-4456-bb89-56db03890675;a0d08689-d0dd-428d-ba6f-17d45106fc49;45bb1151-b150-4d1c-afb0-6f1e02e0492e;f178f88b-5c20-499a-82bb-c3386dc9b306', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f696e2ff-22a0-4432-9bb4-4463ac422c03', 'SystemUser', 'ϵͳ�û� ', 0, NULL, 1, '', '', '', '', 1, 1, 0, 'ϵͳ�û� ', 'dee59f07-ff44-4d56-a072-e93df0aed418', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03', 1, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f83be2b6-cfbb-485f-a095-746966ba0ead', 'ShopProduct', '��Ʒά��', 0, NULL, 2, '', 'admin', 'ShopProductInfo', '', 1, 1, 0, '��Ʒά��', '2d5ffa47-8639-4bfa-bc89-40063bd280dd', '9ed644c4-743d-4ee3-9f13-cee95e6aeaa8;daf681f0-5160-4c81-8286-ae8230384117;2d5ffa47-8639-4bfa-bc89-40063bd280dd;f83be2b6-cfbb-485f-a095-746966ba0ead', 3, 0, 0, '', 4)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('f95979ca-0026-435e-8caf-dc6887095a1a', 'RoleRight', '��ɫ��Ȩ', 0, NULL, 2, '', '', '', '', 1, 1, 0, '��ɫ��Ȩ', 'f696e2ff-22a0-4432-9bb4-4463ac422c03', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;f696e2ff-22a0-4432-9bb4-4463ac422c03;f95979ca-0026-435e-8caf-dc6887095a1a', 2, 0, 0, '', 5)
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
VALUES ('0e8dc049-3503-498a-9512-1176ef8da7ac', 'cb219364-886d-4965-bee2-dfef78bded00', '01', '�Ż�ȯռ�ܽ���ܱ���', '100', '', 'cb219364-886d-4965-bee2-dfef78bded00;0e8dc049-3503-498a-9512-1176ef8da7ac', 1, 2, 1, 1, 0, 1, '100����ʾ����������Ϊ0�������Ż�ȯ�ܽ��ֻ��ռ���ٰٷֱ�
���һ�������Ż�ȯ��ʱ�򣬿��ܻᵼ�¶������Ϊ0', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 0, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('12c70a2b-1252-4b8f-a8f9-d0408165f380', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '01', '����ɳ�ֵ�һ�����', '100', '100', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;12c70a2b-1252-4b8f-a8f9-d0408165f380', 1, 3, 1, 1, 0, 1, 'ֵ1 ��ʾ������100 ���óɳ�ֵ��ֵ2��100', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1583b6ae-0016-45e2-9206-12577d928665', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', '01', 'ҵ���ʼ������', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665', 0, 2, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('16d17df6-c32f-4b3f-a6ad-ef8e15205afa', 'cb219364-886d-4965-bee2-dfef78bded00', '02', '�ɳ�ֵ�������', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa', 0, 2, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1e423f5b-41f5-4c1a-9065-b76caa2e925e', '', '01', 'ϵͳ���ò���', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 0, 1, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2227c7a6-9b63-456d-a756-0e503fa1a776', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '07', '�������', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;2227c7a6-9b63-456d-a756-0e503fa1a776', 1, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', '84e88925-afdb-4385-8622-acac8e689dee', 'SDMYF', '�������Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', 1, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('317d28ca-83e3-4a50-9663-9831e3210016', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '04', '������Ʒ��óɳ�ֵ', '20', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;317d28ca-83e3-4a50-9663-9831e3210016', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3457d513-680e-4302-b360-377932ea3351', '84e88925-afdb-4385-8622-acac8e689dee', 'MESYHQ', '�����ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3457d513-680e-4302-b360-377932ea3351', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '84e88925-afdb-4385-8622-acac8e689dee', 'MESFJ', '��������Ʒ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3c62b4ed-e42a-4155-a14a-188fbae6dcb0', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '01', '�ۺ����˷�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;3c62b4ed-e42a-4155-a14a-188fbae6dcb0', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('454d745a-9f45-4ebc-928c-75e949118456', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '09', 'VIP���ר��', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;454d745a-9f45-4ebc-928c-75e949118456', 1, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('4f2bc1e9-cd6d-4ad8-bfb2-a16df43b36f3', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '03', '��½��óɳ�ֵ', '10', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;4f2bc1e9-cd6d-4ad8-bfb2-a16df43b36f3', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('4fb99cf2-37b9-4bf9-803a-126847ead445', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '04', '���ƻ�Ա�ؼ�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;4fb99cf2-37b9-4bf9-803a-126847ead445', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('574da536-3d2f-4eaa-9215-ff6b31afa518', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '05', '���ƻ�Ա�ؼ�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;574da536-3d2f-4eaa-9215-ff6b31afa518', 1, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('5f3a2d88-6e40-469b-a130-136f6e15857e', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSJF', '�������˷�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;5f3a2d88-6e40-469b-a130-136f6e15857e', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('60544642-c2dd-411b-acdf-5ba2ca6c92b9', '1583b6ae-0016-45e2-9206-12577d928665', 'UserRegistContract', '�û�ע��Э��', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;60544642-c2dd-411b-acdf-5ba2ca6c92b9', 1, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    һ����վ���������ȷ�Ϻͽ��ɱ�վ�ĸ�����ӷ��������Ȩ������Ȩ�鱾վ����վ�ṩ�ķ�����ȫ�����䷢���ķ�������Ͳ��������ϸ�ִ�С��û�ͬ�����з� ��������ע����򣬲��ܳ�Ϊ��վ����ʽ�û����û�ȷ�ϣ���Э�������Ǵ���˫��Ȩ�������Լ��������Υ������ǿ���Է��ɣ�����ʼ����Ч�����¶�����ͬ ʱ����Ҳͬʱ��������ӵ�й�����Щ��Ʒ��Ȩ����������Ϊ���������ҽ��������ڶ������ṩ��������Ϣ����ʵ�Ը���
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ���������鱾վ�����Լ��Ĳ���ϵͳͨ�� ���ʻ�������Ϊ�û��ṩ�������ͬʱ���û����룺 (1)�����䱸�����������豸���������˵��ԡ����ƽ�����������ر�����װ�á� (2)���и�������������֧������˷����йصĵ绰���á�������á����ڱ�վ���ṩ������������Ҫ�ԣ��û�Ӧͬ�� (1)�ṩ�꾡��׼ȷ�ĸ������ϡ� (2)���ϸ���ע�����ϣ����ϼ�ʱ���꾡��׼ȷ��Ҫ�󡣱�վ�������û�����������ַ����������ͱ����� ����������⣺ (1)�û���Ȩ��վ͸¶��Щ��Ϣ�� (2)��Ӧ�ķ��ɼ�����Ҫ��վ�ṩ�û��ĸ������ϡ�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �����۸��������վ�������Ŭ����֤��������Ʒ����վ�Ϲ����ļ۸�һ�¡���Ʒ�ļ۸�Ϳɻ��Զ��ڱ�վ ��ָ����������Ϣ����ʱ���ġ�������������Ʒ���������ȱ��������Ȩȡ��������
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �ġ��ͻ������ñ�վ����Ѳ�Ʒ�͵�����ָ�����ͻ���ַ�������ڱ�վ���г��� �ͻ�ʱ��Ϊ�ο�ʱ�䣬�ο�ʱ��ļ����Ǹ��ݿ��״���������Ĵ�����̺��ͻ�ʱ�䡢�ͻ��ص�Ļ����Ϲ��Ƶó��ġ��ͻ����ø�����ѡ������ͷ�ʽ�Ĳ�ͬ���졣 �����׼ȷ����д������ʵ�������ͻ���ַ����ϵ��ʽ�������������ɶ����ӳٻ��޷����͵ȣ���վ�����������͵����Σ� (1)�ͻ��ṩ������Ϣ�Ͳ���ϸ�ĵ�ַ�� (2)�����ʹ�����ǩ�գ��ɴ���ɵ��ظ������������ķ��ü���صĺ���� (3)���ɿ��������磺��Ȼ�ֺ�����ͨ���ϡ�ͻ��ս���ȡ�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �塢����������޸ı�վ�����ܲ����ڵ��޸ı��û�Э����й����һ������������ݲ����䶯�� ��վ��������Ҫҳ������ʾ�޸����ݡ�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �����û���˽�ƶ������û�������˽�Ǳ�վ��һ��������ߡ����ԣ���Ϊ�����ϵڶ�����ע�����Ϸ����Ĳ��䣬��վһ������ ��δ���Ϸ��û���Ȩʱ�������༭��͸¶��ע�����ϼ������ڱ�վ�еķǹ������ݣ������з������Ҫ���վ�ڳ��ŵĻ�������Ϊ͸¶��Щ�ż���������������� ��Ҫ�ġ�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �ߡ��û����ʺţ�����Ͱ�ȫ���û�һ��ע��ɹ�����Ϊ��վ�ĺϷ��û������õ�һ��������û�����������ʱ����ָʾ�ı��������롣�û����������� ���桢ʹ���û��������롣�û��������κηǷ�ʹ���û��ʺŻ���ڰ�ȫ©���������������֪ͨ��վ���򹫰����ر�����
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �ˡ����û���Ϣ�Ĵ洢�����Ʊ�վ���ж� �û�����Ϊ�Ƿ���Ϲ��ҷ��ɷ���涨����վ��������Ȩ��������û�Υ���˹��ҷ��ɷ���涨���������Ĺ涨����վ���ж϶����ṩ��������Ȩ����
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    �š��û� �����û������е��������ݵ����Ρ��û��Է����ʹ���Ǹ������������ڱ�վ�Ĺ��ҷ��ɡ��ط����ɺ͹��ʷ��ɱ�׼�ġ��û�������ѭ�� (1)���й��������⴫�似��������ʱ��������й��йط��档 (2)ʹ������������Ƿ���;�� (3)�����Ż����������� (4)��������ʹ��������������Э�顢�涨������͹������û����ŵ�������κηǷ��ġ�ɧ���Եġ��������˵ġ������Եġ����Եġ��˺��Եġ�ӹ�׵ģ��� �����Ϣ���ϡ����⣬�û�Ҳ���ܴ���ν������˹��ɷ�����Ϊ�����ϣ����ܴ����������ڲ����������漰���Ұ�ȫ�����ϣ����ܴ����κβ����ϵ��ط��桢���ҷ� �ɺ͹��ʷ��ɵ����ϡ�δ����ɶ��Ƿ�������������ϵͳ�ǽ�ֹ�ġ����û�����Ϊ�����������ᵽ�ķ��������վ�����������ж�����ȡ���û������ʺš��û��� ���Լ������ϵ���Ϊ�е��������Ρ��û����ڱ�վ��ɢ���ʹ���������ɫ�������Υ�����ҷ��ɵ���Ϣ����վ��ϵͳ��¼�п�����Ϊ�û�Υ�����ɵ�֤�ݡ�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ʮ��ͨ�� ���з����û���ͨ�涼��ͨ����Ҫҳ��Ĺ��������ʼ��򳣹���ż����͡��û�Э��������޸ġ�����������������Ҫ�¼���ͨ�涼���Դ���ʽ���С�
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ʮһ���� ����߻��û������Ƿ������Ϣ�м����������ϻ������߻����ڱ�վ����ѷ�����չʾ���ǵĲ�Ʒ���κ���������������������������������ҵ�� ���������������йص�������ֻ������Ӧ���û��͹��������֮�䷢����
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ʮ��������������ݵ�����Ȩ��վ���������������ݰ��������֡������������ͼƬ�� ¼��ͼ������е�ȫ�����ݣ������ʼ���ȫ�����ݣ���վΪ�û��ṩ��������Ϣ��������Щ�����ܰ�Ȩ���̱ꡢ��ǩ�������Ʋ�����Ȩ���ɵı��������ԣ��û� ֻ���ڱ�վ�͹������Ȩ�²���ʹ����Щ���ݣ����������Ը��ơ�������Щ���ݡ������������йص�������Ʒ����վ���е����°�Ȩ��ԭ�����ߺͱ�վ��ͬ���У� �κ�����Ҫת�ر�վ�����£���������ԭ�����߻�վ��Ȩ��
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ʮ���������������򲻿ɿ�����������վ�޷����Ƶ�ԭ��ʹ��վ����ϵͳ�������޷�����ʹ�õ������� �����޷���ɻ�ʧ�йص���Ϣ����¼�ȱ�վ�ᾡ���ܺ����Э�������ƺ����ˣ���Ŭ��ʹ�ͻ����ܾ�����ʧ��
</p>
<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
    ʮ�ġ����ɹ�Ͻ�����ñ�Э��Ķ�����ִ�кͽ��ͼ� ����Ľ����Ӧ�����й����ɡ��緢����վ�����������й�������ִ�ʱ������Щ�����ȫ�����ɹ涨���½��ͣ��������Ϸ����������ɱ��ֶ��û���������Ч�� ��Ӱ�졣��Э��Ĺ涨�ǿɷָ�ģ��籾Э���κι涨���ö�Ϊ��Ч�򲻿�ִ�У��ù涨�ɱ�ɾ������������Ӧ����ִ�С���˫���ͱ�Э�����ݻ���ִ�з����κ��� �飬˫��Ӧ�����Ѻ�Э�̽����Э�̲���ʱ���κ�һ��������վ���ڵص�����Ժ�������ϡ�
</p>
<p>
    <br/>
</p>', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('749a6e17-8cec-4cc8-9009-00ee0a073f7b', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '02', '���۽���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;749a6e17-8cec-4cc8-9009-00ee0a073f7b', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('84e88925-afdb-4385-8622-acac8e689dee', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'jffl', '��������', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;84e88925-afdb-4385-8622-acac8e689dee', 0, 2, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('8a8777e8-3737-4f92-b964-97e922024903', '84e88925-afdb-4385-8622-acac8e689dee', 'SDZP', '�׵����Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;8a8777e8-3737-4f92-b964-97e922024903', 1, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a0a119af-f3b2-474b-81ce-8d68875d7615', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '06', 'ȫ����Ա�ؼ��Ż�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;a0a119af-f3b2-474b-81ce-8d68875d7615', 1, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a5c21066-8429-4f36-9103-150c46e5f7fb', '84e88925-afdb-4385-8622-acac8e689dee', 'MEZP', '�׵��ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;a5c21066-8429-4f36-9103-150c46e5f7fb', 1, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a87fed1e-ef6c-49af-8278-9674a5eaf45f', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '08', 'ר�����', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;a87fed1e-ef6c-49af-8278-9674a5eaf45f', 1, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSYHQ', '�׵�����Ʒ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', 1, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('cb219364-886d-4965-bee2-dfef78bded00', '', '02', '�û��Զ������', '', '', 'cb219364-886d-4965-bee2-dfef78bded00', 0, 1, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce04cb8c-7d10-4b74-bb45-2c8fec920467', '1583b6ae-0016-45e2-9206-12577d928665', 'OrderStatus', '����״̬', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ce04cb8c-7d10-4b74-bb45-2c8fec920467', 1, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce9c37da-1c7e-4216-96d3-2151e39db16c', 'f339c10e-0106-47b1-b16f-95eb9702d6a5', '03', 'ͭ�ƻ�Ա�ؼ�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5;ce9c37da-1c7e-4216-96d3-2151e39db16c', 1, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d6070e00-f3b1-47ad-a55a-673fb3cec6c5', '16d17df6-c32f-4b3f-a6ad-ef8e15205afa', '02', 'ע���óɳ�ֵ', '20', '', 'cb219364-886d-4965-bee2-dfef78bded00;16d17df6-c32f-4b3f-a6ad-ef8e15205afa;d6070e00-f3b1-47ad-a55a-673fb3cec6c5', 1, 3, 1, 1, 0, 1, 'ע���óɳ�ֵ', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d677d840-241f-439e-8025-2556a28ca523', '84e88925-afdb-4385-8622-acac8e689dee', 'RegsitJf', '�׵����˷�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d677d840-241f-439e-8025-2556a28ca523', 1, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', '84e88925-afdb-4385-8622-acac8e689dee', 'FreeYF', 'ע�����Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', 1, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', '84e88925-afdb-4385-8622-acac8e689dee', 'RegistToQuan', 'ע���ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', 1, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', '1583b6ae-0016-45e2-9206-12577d928665', '01', 'ͼƬ��������ַ', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', 1, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('f339c10e-0106-47b1-b16f-95eb9702d6a5', 'cb219364-886d-4965-bee2-dfef78bded00', '03', '��Ա����', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;f339c10e-0106-47b1-b16f-95eb9702d6a5', 0, 2, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('fb4704d4-b600-4f46-9b1f-0d68c3a299ed', '84e88925-afdb-4385-8622-acac8e689dee', 'MEMYF', '����', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;fb4704d4-b600-4f46-9b1f-0d68c3a299ed', 1, 3, 1, 1, 0, 1, '', 10, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
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
VALUES ('168a2a81-b4b2-4ba2-958a-aa19b511552c', '4', '���ƻ�Ա', NULL, 10000, 30000, 1, '�ɳ�ֵ����10000����С��30000', 1, 4000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,574da536-3d2f-4eaa-9215-ff6b31afa518,2227c7a6-9b63-456d-a756-0e503fa1a776,a87fed1e-ef6c-49af-8278-9674a5eaf45f')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('4b033ff0-a5a4-49a0-a348-dd250ae61328', '3', '���ƻ�Ա', NULL, 2000, 10000, 1, '�ɳ�ֵ����2000 ��С��10000', 1, 1000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,2227c7a6-9b63-456d-a756-0e503fa1a776')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('889248a7-cd25-40f6-a65c-68fa056c4ee2', '5', '��ʯ��Ա', NULL, 30000, 0, 1, '�ɳ�ֵ����30000', 1, 10000, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c,4fb99cf2-37b9-4bf9-803a-126847ead445,574da536-3d2f-4eaa-9215-ff6b31afa518,a0a119af-f3b2-474b-81ce-8d68875d7615,2227c7a6-9b63-456d-a756-0e503fa1a776,a87fed1e-ef6c-49af-8278-9674a5eaf45f,454d745a-9f45-4ebc-928c-75e949118456')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('98dcdebe-93b3-494b-ba7c-20b9dbc1673d', '1', 'ע���Ա', NULL, 0, 1, 1, 'ע��ɹ��󼴳�Ϊ��Ա', 0, 0, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0')
GO

INSERT INTO dbo.RangeDict (ID, RankLevel, Name, Img, MinVal, MaxVal, IsEnable, Note, LevelYear, ReduceValue, HasService)
VALUES ('aa026f72-0ffd-4b70-a439-774e298cbad6', '2', 'ͭ�ƻ�Ա', NULL, 1, 2000, 1, '�ɳ�ֵ����0��С��2000', 0, 0, '3c62b4ed-e42a-4155-a14a-188fbae6dcb0,749a6e17-8cec-4cc8-9009-00ee0a073f7b,ce9c37da-1c7e-4216-96d3-2151e39db16c')
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
VALUES ('7f283c53-7531-4799-9a2f-e63d70b62579', 'HHWL', '��������', 1)
GO

INSERT INTO dbo.ShopExpress (ID, Code, Name, IsEnable)
VALUES ('f0d1ff81-8334-4c97-b6b8-f9839c1f27b2', 'Express', '˳����', 1)
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





