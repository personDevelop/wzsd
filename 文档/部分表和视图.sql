    
 

CREATE TABLE dbo.RedeemRules
	(
	ID          CHAR (36) NOT NULL,
	RuleType    NVARCHAR (36) NOT NULL,
	Name        NVARCHAR (100) NOT NULL,
	BaseNum     INT NOT NULL,
	ReleNum     INT NOT NULL,
	BL          DECIMAL (9) NOT NULL,
	IsEnable    BIT NOT NULL,
	Remark      NVARCHAR (500),
	ComputeType INT NOT NULL,
	CONSTRAINT PK_RedeemRules PRIMARY KEY (ID)
	)
GO 
 
IF OBJECT_ID ('dbo.CouponRule') IS NOT NULL
	DROP TABLE dbo.CouponRule
GO

CREATE TABLE dbo.CouponRule
	(
	ID                   CHAR (36) NOT NULL,
	Name                 NVARCHAR (400) NOT NULL,
	CouponType           INT NOT NULL,
	ClassId              NVARCHAR (50) NOT NULL,
	UseType              INT NOT NULL,
	SendCount            INT NOT NULL,
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
	IsCanCombie          BIT NOT NULL,
	CONSTRAINT PK_CouponRule PRIMARY KEY (ID)
	)
GO

IF OBJECT_ID ('dbo.CouponUseRecord') IS NOT NULL
	DROP TABLE dbo.CouponUseRecord
GO

CREATE TABLE dbo.CouponUseRecord
	(
	ID             CHAR (36) NOT NULL,
	CouponUserID   NVARCHAR (50) NOT NULL,
	CreateDate     DATETIME NOT NULL,
	ActionType     INT NOT NULL,
	ActionDescribe NVARCHAR (50) NOT NULL,
	UserID         NVARCHAR (50) NOT NULL,
	CONSTRAINT PK_CouponUseRecord PRIMARY KEY (ID)
	)
GO

IF OBJECT_ID ('dbo.CusomerAndCoupon') IS NOT NULL
	DROP TABLE dbo.CusomerAndCoupon
GO

CREATE TABLE dbo.CusomerAndCoupon
	(
	ID         NVARCHAR (16) NOT NULL,
	CustomerID NVARCHAR (50) NOT NULL,
	CouponID   NVARCHAR (50) NOT NULL,
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
	CONSTRAINT PK_ShopPromotion PRIMARY KEY (ID)
	)
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

IF OBJECT_ID ('dbo.View_ProductInfoBySkuid') IS NOT NULL
	DROP VIEW dbo.View_ProductInfoBySkuid
GO

CREATE VIEW dbo.View_ProductInfoBySkuid
AS
SELECT DISTINCT 
                      dbo.ShopProductInfo.ID, dbo.ShopProductInfo.Code, dbo.ShopProductInfo.Name, dbo.ShopProductInfo.IsEnableSku, dbo.ShopProductInfo.Unit, 
                      ISNULL(dbo.ShopProductSKUInfo.SKU, dbo.ShopProductInfo.SKU) AS SKUCode, ISNULL(dbo.ShopProductSKUInfo.SalePrice, dbo.ShopProductInfo.SalePrice) 
                      AS SalePrice, ISNULL(dbo.ShopProductSKUInfo.Stock, dbo.ShopProductInfo.Stock) AS Stock, ISNULL(dbo.ShopProductSKUInfo.MarketPrice, 
                      dbo.ShopProductInfo.MarketPrice) AS MarketPrice, ISNULL(dbo.ShopProductSKUInfo.ID, '') AS SKUID, dbo.ShopProductInfo.SaleStatus, 
                      dbo.ShopProductSKUInfo.IsSale, dbo.ShopProductSKUInfo.Name AS SKUName, dbo.ShopProductInfo.Points, dbo.ShopProductInfo.TypeId, 
                      ISNULL(dbo.ShopProductSKUInfo.CostPrice, dbo.ShopProductInfo.CostPrice) AS CostPrice, dbo.ShopProductInfo.ShortDescription, 
                      ISNULL(dbo.ShopProductSKUInfo.Weight, dbo.ShopProductInfo.Weight) AS Weight, dbo.ShopProductInfo.IsVirtualProduct, dbo.ShopProductInfo.BrandId, 
                      dbo.ShopProductInfo.SupplierId
FROM         dbo.ShopProductInfo LEFT OUTER JOIN
                      dbo.ShopProductSKU ON dbo.ShopProductSKU.ProductId = dbo.ShopProductInfo.ID LEFT OUTER JOIN
                      dbo.ShopProductSKUInfo ON dbo.ShopProductSKU.ID = dbo.ShopProductSKUInfo.SKURelationID

GO


 
GO
 IF OBJECT_ID ('dbo.View_ShopPromotion') IS NOT NULL
	DROP VIEW dbo.View_ShopPromotion
GO

CREATE VIEW dbo.View_ShopPromotion
AS
SELECT     dbo.ShopPromotion.ID, dbo.ShopPromotion.RuleID, dbo.ShopPromotion.BuyCategoryId, dbo.ShopPromotion.BuyCategoryName, dbo.ShopPromotion.BuyProductId, 
                      dbo.ShopPromotion.BuyProductName, dbo.ShopPromotion.BuySKUID, dbo.ShopPromotion.BuyCount, dbo.ShopPromotion.HandsaleProductId, 
                      dbo.ShopPromotion.HandsaleProductSKUID, dbo.ShopPromotion.CouponID, dbo.ShopPromotion.CouponName, dbo.ShopPromotion.HandsaleMaxCount, 
                      dbo.ShopPromotion.HandsaleCount, dbo.ShopPromotion.MinPrice, dbo.ShopPromotion.MaxPrice, dbo.ShopPromotion.StartDate, dbo.ShopPromotion.EndDate, 
                      dbo.ShopPromotion.IsEnable, dbo.ShopPromotion.CreateUser, dbo.ShopPromotion.CreateDate, dbo.ShopPromotion.Note, dbo.ShopPromotion.ActionStatus, 
                      dbo.RedeemRules.RuleType, dbo.RedeemRules.Name, dbo.RedeemRules.BaseNum, dbo.RedeemRules.ReleNum, dbo.RedeemRules.BL, 
                      dbo.RedeemRules.ComputeType, dbo.CouponRule.JE AS CouponJe, dbo.CouponRule.Status, dbo.CouponRule.QxLx, dbo.CouponRule.StartDate AS Expr4, 
                      dbo.CouponRule.EndDate AS Expr5, dbo.CouponRule.IsCongZengSongKaiShi
FROM         dbo.ShopPromotion INNER JOIN
                      dbo.RedeemRules ON dbo.ShopPromotion.RuleID = dbo.RedeemRules.ID LEFT OUTER JOIN
                      dbo.CouponRule ON dbo.ShopPromotion.CouponID = dbo.CouponRule.ID
WHERE     (dbo.RedeemRules.IsEnable = 1) AND (dbo.ShopPromotion.ActionStatus = 0)

GO
 IF OBJECT_ID ('dbo.SerialNo') IS NOT NULL
	DROP TABLE dbo.SerialNo
GO

CREATE TABLE dbo.SerialNo
	(
	sCode    VARCHAR (50) NOT NULL,
	sName    VARCHAR (100) NOT NULL,
	sQZ      VARCHAR (50) NOT NULL,
	sValue   VARCHAR (100) NOT NULL,
	LsLength INT CONSTRAINT DF_SerialNo_LsLength DEFAULT ((4)) NOT NULL,
	LockTem  INT,
	CONSTRAINT PK_SerialNo PRIMARY KEY (sCode)
	)
GO


USE [福彩还原测试用]
GO

/****** Object:  StoredProcedure [dbo].[GetSerialNo]    Script Date: 09/03/2015 00:04:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('GetSerialNo') IS NOT NULL
	DROP procedure dbo.GetSerialNo
GO


CREATE procedure [dbo].[GetSerialNo]   
 (   
     @sCode varchar(50)   
 )   
  
   as 
 
 --exec GetSerialNo   
 
 begin 
 
   Declare @sValue  varchar(100),   
  
           @dToday   datetime,  
           @Csstr   varchar(8),   
           @lslength   int,  
            @sQZ  varchar(50)  --这个代表前缀 
  
    Begin Tran     
  
    Begin Try   
  
      -- 锁定该条记录，好多人用lock去锁，起始这里只要执行一句update就可以了 
     --在同一个事物中，执行了update语句之后就会启动锁 
     Update SerialNo set LockTem=1 where sCode=@sCode   
 
      Select @sValue = sValue,@sQZ = sQZ,@lslength=LsLength From SerialNo where sCode=@sCode   
   
        Select @Csstr =  convert(bigint, convert(varchar(6), getdate(), 12))
 
      -- 因子表中没有记录，插入初始值   
  
      If @sValue is null   
 
      Begin 
  set @lslength=4 
      Select @sValue =@Csstr + REPLICATE('0',  (@lslength-1))+'1'    
  set @sQZ=@sCode
  insert SerialNo(sCode   , sName  , sQZ     , sValue    , LsLength   , LockTem)VALUES
  (@sCode,@sCode,@sCode,@sValue,4,1)
       
 
      end else   
  
      Begin               --因子表中没有记录   
  
       Select @dToday = substring(@sValue,1,6)   
 
        --如果日期相等，则加1   
 
        If @dToday = convert(varchar(6), getdate(), 12)   
  
          Select @sValue = convert(varchar(50), (convert(bigint, @sValue) + 1))   
 
        else              --如果日期不相等，则先赋值日期，流水号从1开始   
 
          Select @sValue = @Csstr + REPLICATE('0',  (@lslength-1))+'1'    
  
            
 
       Update SerialNo set sValue =@sValue where sCode=@sCode   
 
     End 
 
     Select result = @sQZ+@sValue     
 
     Commit Tran   
  
    End Try   
  
  Begin Catch   
 
     Rollback Tran   
 
      Select result = 'Error' 
  
    End Catch   
 
 end 



GO


INSERT INTO dbo.CouponRule (ID, Name, CouponType, ClassId, UseType, SendCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note, IsCanCombie)
VALUES ('11f9308a-dd71-4977-a0c1-6926ee1c71ca', '面值20元优惠券', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 20, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:30.927', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, ClassId, UseType, SendCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note, IsCanCombie)
VALUES ('34691339-63bf-4b43-b601-eba4ad098652', '面值100元优惠券', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 100, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:03.487', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, ClassId, UseType, SendCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note, IsCanCombie)
VALUES ('ae73d0f9-4758-447c-af95-935eaf92b1e4', '面值10元优惠券', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 10, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:16.717', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('247cba5b-cf42-4412-9778-9b41591812fc', '3457d513-680e-4302-b360-377932ea3351', '满100赠送价值100元优惠券', 100, 100, 0, 1, '', 1)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('5be67eb6-32c7-4de7-b389-d22a46db0b29', 'a5c21066-8429-4f36-9103-150c46e5f7fb', '满额送精美礼品1份', 0, 0, 0, 1, '', 0)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('8994bbb9-725d-4936-b50b-95d58c22f0ec', '3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '满100赠送1000积分', 100, 1000, 0, 1, '', 1)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('94be3670-b394-4855-8f4e-73a94da85313', '5f3a2d88-6e40-469b-a130-136f6e15857e', '首单送100积分', 100, 0, 0, 1, '', 1)
GO
delete ParameterInfo
INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1583b6ae-0016-45e2-9206-12577d928665', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', '01', '业务初始化数据', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665', 0, 2, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1e423f5b-41f5-4c1a-9065-b76caa2e925e', '', '01', '系统内置参数', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 0, 1, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', '84e88925-afdb-4385-8622-acac8e689dee', 'SDMYF', '满额送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3457d513-680e-4302-b360-377932ea3351', '84e88925-afdb-4385-8622-acac8e689dee', 'MESYHQ', '满额送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3457d513-680e-4302-b360-377932ea3351', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '84e88925-afdb-4385-8622-acac8e689dee', 'MESFJ', '满额送赠品', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('482d62aa-5302-4773-b719-ae39acf012a5', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'yhqfl', '优惠券分类', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;482d62aa-5302-4773-b719-ae39acf012a5', 0, 2, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('5f3a2d88-6e40-469b-a130-136f6e15857e', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSJF', '满额免运费', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;5f3a2d88-6e40-469b-a130-136f6e15857e', 0, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('60544642-c2dd-411b-acdf-5ba2ca6c92b9', '1583b6ae-0016-45e2-9206-12577d928665', 'UserRegistContract', '用户注册协议', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;60544642-c2dd-411b-acdf-5ba2ca6c92b9', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: 微软雅黑; white-space: normal;">
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
VALUES ('78367a53-5026-4551-a741-5cc45157f5a3', '482d62aa-5302-4773-b719-ae39acf012a5', '02', '系统派发', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;78367a53-5026-4551-a741-5cc45157f5a3', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('84e88925-afdb-4385-8622-acac8e689dee', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'jffl', '促销规则', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;84e88925-afdb-4385-8622-acac8e689dee', 0, 2, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('8a8777e8-3737-4f92-b964-97e922024903', '84e88925-afdb-4385-8622-acac8e689dee', 'SDZP', '首单送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;8a8777e8-3737-4f92-b964-97e922024903', 0, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a5c21066-8429-4f36-9103-150c46e5f7fb', '84e88925-afdb-4385-8622-acac8e689dee', 'MEZP', '首单送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;a5c21066-8429-4f36-9103-150c46e5f7fb', 0, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSYHQ', '首单送赠品', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', 0, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('cb219364-886d-4965-bee2-dfef78bded00', '', '02', '用户自定义参数', '', '', 'cb219364-886d-4965-bee2-dfef78bded00', 0, 1, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce04cb8c-7d10-4b74-bb45-2c8fec920467', '1583b6ae-0016-45e2-9206-12577d928665', 'OrderStatus', '订单状态', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ce04cb8c-7d10-4b74-bb45-2c8fec920467', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d677d840-241f-439e-8025-2556a28ca523', '84e88925-afdb-4385-8622-acac8e689dee', 'RegsitJf', '首单免运费', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d677d840-241f-439e-8025-2556a28ca523', 0, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', '84e88925-afdb-4385-8622-acac8e689dee', 'FreeYF', '注册送优惠券', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', 0, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('e0bda09d-2396-4678-b13e-939b607eb4a2', '482d62aa-5302-4773-b719-ae39acf012a5', '03', '积分兑换', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;e0bda09d-2396-4678-b13e-939b607eb4a2', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('e8cb9a79-2b43-4792-b8a2-f5971c75e694', '482d62aa-5302-4773-b719-ae39acf012a5', '01', '购物', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', '84e88925-afdb-4385-8622-acac8e689dee', 'RegistToQuan', '注册送积分', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', 0, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', '1583b6ae-0016-45e2-9206-12577d928665', '01', '图片服务器地址', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('fb4704d4-b600-4f46-9b1f-0d68c3a299ed', '84e88925-afdb-4385-8622-acac8e689dee', 'MEMYF', '包邮', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;fb4704d4-b600-4f46-9b1f-0d68c3a299ed', 0, 3, 1, 1, 0, 1, '', 10, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('01f82ec6-785d-4ef6-9933-6a1b4c7fd1f1', '8994bbb9-725d-4936-b50b-95d58c22f0ec', '', '', '', '', '', 0, '', '', '', '', 0, 0, 100, 0, '2015-09-03', '2017-08-18', 1, '', '2015-09-03 00:14:13.98', '', 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('3bb67717-41b7-468f-ada4-53f474761800', '247cba5b-cf42-4412-9778-9b41591812fc', '', '', '', '', '', 0, '', '', '34691339-63bf-4b43-b601-eba4ad098652', '面值100元优惠券', 0, 0, 0, 0, '2015-09-03', '2016-01-01', 1, '', '2015-09-03 00:18:19.75', '', 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('bf178bd9-afab-4a38-a37d-10cae8f95e64', '94be3670-b394-4855-8f4e-73a94da85313', '', '', '', '', '', 0, '', '', '', '', 0, 0, 0, 0, '2015-09-03', '2099-12-28', 1, '', '2015-09-03 00:15:00.33', '', 0)
GO


