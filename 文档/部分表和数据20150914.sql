
IF OBJECT_ID ('dbo.CouponRule') IS NOT NULL
	DROP TABLE dbo.CouponRule
GO

CREATE TABLE dbo.CouponRule
	(
	ID                   CHAR (36) NOT NULL,
	Name                 NVARCHAR (400) NOT NULL,
	CouponType           INT NOT NULL,
	CanMutilUse          BIT NOT NULL,
	IsCanCombie          BIT NOT NULL,
	SendCount            INT NOT NULL,
	MaxCount             INT NOT NULL,
	PreName              NVARCHAR (5),
	CpLength             INT NOT NULL,
	IsPwd                BIT NOT NULL,
	JE                   DECIMAL (9, 2) NOT NULL,
	NeedPoint            INT NOT NULL,
	QxLx                 INT NOT NULL,
	IsCongZengSongKaiShi BIT NOT NULL,
	StartDate            DATETIME,
	EndDate              DATETIME,
	QXTS                 INT NOT NULL,
	CategoryId           NVARCHAR (50),
	ProductId            NVARCHAR (50),
	ProductSku           NVARCHAR (50),
	ImageUrl             NVARCHAR (50),
	MinPrice             DECIMAL (15, 2) NOT NULL,
	MaxPrice             DECIMAL (15, 2) NOT NULL,
	IsEnable             BIT NOT NULL,
	CreateDate           DATETIME NOT NULL,
	Createor             NVARCHAR (50) NOT NULL,
	SupplierId           NVARCHAR (50),
	Status               INT NOT NULL,
	Note                 NVARCHAR (1000),
	CONSTRAINT PK_CouponRule PRIMARY KEY (ID)
	)
GO
IF OBJECT_ID ('dbo.ShopPromotion') IS NOT NULL
	DROP TABLE dbo.ShopPromotion
GO

CREATE TABLE dbo.ShopPromotion
	(
	ID                   CHAR (36) NOT NULL,
	RuleID               CHAR (36) NOT NULL,
	BuyCategoryId        NVARCHAR (50),
	BuyCategoryName      NVARCHAR (200),
	BuyProductId         NVARCHAR (50),
	BuyProductName       NVARCHAR (500),
	BuySKUID             NVARCHAR (50),
	BuyCount             DECIMAL (15, 2) NOT NULL,
	HandsaleProductId    NVARCHAR (50),
	HandsaleProductSKUID NVARCHAR (50),
	CouponID             NVARCHAR (50),
	CouponName           NVARCHAR (100),
	HandsaleMaxCount     DECIMAL (15, 2) NOT NULL,
	HandsaleCount        DECIMAL (15, 2) NOT NULL,
	MinPrice             DECIMAL (15, 2) NOT NULL,
	MaxPrice             DECIMAL (15, 2) NOT NULL,
	StartDate            DATETIME NOT NULL,
	EndDate              DATETIME NOT NULL,
	IsEnable             BIT NOT NULL,
	CreateUser           NVARCHAR (50) NOT NULL,
	CreateDate           DATETIME NOT NULL,
	Note                 NVARCHAR (500) NOT NULL,
	ActionStatus         INT NOT NULL,
	HasSendCount         INT CONSTRAINT DF_ShopPromotion_HasSendCount DEFAULT ((0)) NOT NULL,
	CONSTRAINT PK_ShopPromotion PRIMARY KEY (ID)
	)
GO
INSERT INTO dbo.CouponRule (ID, Name, CouponType, CanMutilUse, IsCanCombie, SendCount, MaxCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note)
VALUES ('3b4def8f-2ecf-410a-830c-66715c988d65', '面值10元优惠券', 0, 1, 0, 0, 10000, '', 10, 0, 10, 0, 0, 1, '2015-09-13', '2015-12-13', 0, '', '', '', NULL, 0, 0, 1, '2015-09-13 22:21:27.54', 'root', NULL, 0, '')
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, CanMutilUse, IsCanCombie, SendCount, MaxCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note)
VALUES ('a2ce1410-2299-499b-8a1a-d1c3b56c9361', '面值20元优惠券', 0, 1, 1, 0, 10000, '', 10, 0, 20, 0, 1, 1, '2015-09-13', '2015-12-13', 0, '', '', '', NULL, 0, 0, 1, '2015-09-13 22:20:58.647', 'root', NULL, 0, '')
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, CanMutilUse, IsCanCombie, SendCount, MaxCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note)
VALUES ('ec6351f8-eca9-408d-8cca-1c6b03fb0b70', '面值100元优惠券', 0, 1, 0, 0, 10000, '', 10, 0, 100, 0, 0, 1, '2015-09-13', '2015-12-13', 0, '', '', '', NULL, 0, 0, 1, '2015-09-13 22:21:15.88', 'root', NULL, 0, '')
GO
INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus, HasSendCount)
VALUES ('01f82ec6-785d-4ef6-9933-6a1b4c7fd1f1', '8994bbb9-725d-4936-b50b-95d58c22f0ec', '', '', '', '', '', 0, '', '', '', '', 0, 0, 100, 0, '2015-09-03', '2017-08-18', 1, '', '2015-09-03 00:14:13.98', '', 0, 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus, HasSendCount)
VALUES ('3bb67717-41b7-468f-ada4-53f474761800', '247cba5b-cf42-4412-9778-9b41591812fc', '', '', '', '', '', 0, '', '', '34691339-63bf-4b43-b601-eba4ad098652', '面值100元优惠券', 0, 0, 0, 0, '2015-09-03', '2016-01-01', 1, '', '2015-09-03 00:18:19.75', '', 0, 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus, HasSendCount)
VALUES ('bf178bd9-afab-4a38-a37d-10cae8f95e64', '94be3670-b394-4855-8f4e-73a94da85313', '', '', '', '', '', 0, '', '', '', '', 0, 0, 0, 0, '2015-09-03', '2099-12-28', 1, '', '2015-09-03 00:15:00.33', '', 0, 0)
GO
IF OBJECT_ID ('dbo.SysDeleteCasCheck') IS NOT NULL
	DROP TABLE dbo.SysDeleteCasCheck
GO

CREATE TABLE dbo.SysDeleteCasCheck
	(
	ID                 CHAR (36) NOT NULL,
	CheckTableName     NVARCHAR (50) NOT NULL,
	CheckExistSql      NVARCHAR (500),
	ErrorMsg           NVARCHAR (500),
	IsCascadeDelete    BIT NOT NULL,
	CascadeTableName   NVARCHAR (50) NOT NULL,
	CascadeTableKey    NVARCHAR (50) NOT NULL,
	CascadeTableRefKey NVARCHAR (50),
	CascadeDeleteSql   NVARCHAR (500),
	IsCascadeUpdate    BIT NOT NULL,
	UpdateMsg          NVARCHAR (500),
	UpdateField        NVARCHAR (500),
	IsEnable           BIT NOT NULL,
	Note               NVARCHAR (500),
	ISTree             BIT NOT NULL,
	TreeFjmField       NVARCHAR (50),
	CONSTRAINT PK_SysDeleteCasCheck PRIMARY KEY (ID)
	)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('0e8dc049-3503-498a-9512-1176ef8da7ac', 'cb219364-886d-4965-bee2-dfef78bded00', '01', '优惠券占总金额总比例', '100', '', 'cb219364-886d-4965-bee2-dfef78bded00;0e8dc049-3503-498a-9512-1176ef8da7ac', 1, 2, 1, 1, 0, 1, '100，表示订单金额可以为0，否则优惠券总金额只能占多少百分比
这个一般是用优惠券的时候，可能会导致订单金额为0', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 0, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.FunctionInfo (ID, Code, Name, FuncType, [Image], AccessType, URL, CallArea, CallControler, CallAction, [Enable], Visible, MultilInstance, ShowText, ParentID, ClassCode, OrderNo, IsMustNot, IsMust, Description, Js)
VALUES ('01d41db0-d04b-46d7-bcb4-d3907d2edaac', 'SysDeleteCasCheck', '数据删除检测', 0, NULL, 2, '', 'Admin', 'SysDeleteCasCheck', '', 1, 1, 0, '数据删除检测', '263a98cb-c749-43f4-8349-51bd4575e1fb', '3174ccff-b856-4feb-b3eb-f832bcdf1ac0;a4f31c07-5de1-4957-a5cd-e7039abfd44f;dee59f07-ff44-4d56-a072-e93df0aed418;263a98cb-c749-43f4-8349-51bd4575e1fb;01d41db0-d04b-46d7-bcb4-d3907d2edaac', 4, 0, 0, '', 5)
GO





