    
 

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


USE [���ʻ�ԭ������]
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
            @sQZ  varchar(50)  --�������ǰ׺ 
  
    Begin Tran     
  
    Begin Try   
  
      -- ����������¼���ö�����lockȥ������ʼ����ֻҪִ��һ��update�Ϳ����� 
     --��ͬһ�������У�ִ����update���֮��ͻ������� 
     Update SerialNo set LockTem=1 where sCode=@sCode   
 
      Select @sValue = sValue,@sQZ = sQZ,@lslength=LsLength From SerialNo where sCode=@sCode   
   
        Select @Csstr =  convert(bigint, convert(varchar(6), getdate(), 12))
 
      -- ���ӱ���û�м�¼�������ʼֵ   
  
      If @sValue is null   
 
      Begin 
  set @lslength=4 
      Select @sValue =@Csstr + REPLICATE('0',  (@lslength-1))+'1'    
  set @sQZ=@sCode
  insert SerialNo(sCode   , sName  , sQZ     , sValue    , LsLength   , LockTem)VALUES
  (@sCode,@sCode,@sCode,@sValue,4,1)
       
 
      end else   
  
      Begin               --���ӱ���û�м�¼   
  
       Select @dToday = substring(@sValue,1,6)   
 
        --���������ȣ����1   
 
        If @dToday = convert(varchar(6), getdate(), 12)   
  
          Select @sValue = convert(varchar(50), (convert(bigint, @sValue) + 1))   
 
        else              --������ڲ���ȣ����ȸ�ֵ���ڣ���ˮ�Ŵ�1��ʼ   
 
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
VALUES ('11f9308a-dd71-4977-a0c1-6926ee1c71ca', '��ֵ20Ԫ�Ż�ȯ', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 20, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:30.927', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, ClassId, UseType, SendCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note, IsCanCombie)
VALUES ('34691339-63bf-4b43-b601-eba4ad098652', '��ֵ100Ԫ�Ż�ȯ', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 100, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:03.487', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.CouponRule (ID, Name, CouponType, ClassId, UseType, SendCount, PreName, CpLength, IsPwd, JE, NeedPoint, QxLx, IsCongZengSongKaiShi, StartDate, EndDate, QXTS, CategoryId, ProductId, ProductSku, ImageUrl, MinPrice, MaxPrice, IsEnable, CreateDate, Createor, SupplierId, Status, Note, IsCanCombie)
VALUES ('ae73d0f9-4758-447c-af95-935eaf92b1e4', '��ֵ10Ԫ�Ż�ȯ', 0, 'e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 10000, '', 10, 0, 10, 0, 0, 1, '2015-09-03', '2015-12-03', 0, '', '', '', NULL, 0, 0, 1, '2015-09-03 00:17:16.717', '', NULL, 0, '', 0)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('247cba5b-cf42-4412-9778-9b41591812fc', '3457d513-680e-4302-b360-377932ea3351', '��100���ͼ�ֵ100Ԫ�Ż�ȯ', 100, 100, 0, 1, '', 1)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('5be67eb6-32c7-4de7-b389-d22a46db0b29', 'a5c21066-8429-4f36-9103-150c46e5f7fb', '�����;�����Ʒ1��', 0, 0, 0, 1, '', 0)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('8994bbb9-725d-4936-b50b-95d58c22f0ec', '3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '��100����1000����', 100, 1000, 0, 1, '', 1)
GO

INSERT INTO dbo.RedeemRules (ID, RuleType, Name, BaseNum, ReleNum, BL, IsEnable, Remark, ComputeType)
VALUES ('94be3670-b394-4855-8f4e-73a94da85313', '5f3a2d88-6e40-469b-a130-136f6e15857e', '�׵���100����', 100, 0, 0, 1, '', 1)
GO
delete ParameterInfo
INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1583b6ae-0016-45e2-9206-12577d928665', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', '01', 'ҵ���ʼ������', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665', 0, 2, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('1e423f5b-41f5-4c1a-9065-b76caa2e925e', '', '01', 'ϵͳ���ò���', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 0, 1, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', '84e88925-afdb-4385-8622-acac8e689dee', 'SDMYF', '�������Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;2ebcbf1d-e39f-4ada-afa0-2da25a31ce33', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3457d513-680e-4302-b360-377932ea3351', '84e88925-afdb-4385-8622-acac8e689dee', 'MESYHQ', '�����ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3457d513-680e-4302-b360-377932ea3351', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', '84e88925-afdb-4385-8622-acac8e689dee', 'MESFJ', '��������Ʒ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;3b88b6f3-c3c2-4245-b6b2-5fcdce1b0b93', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('482d62aa-5302-4773-b719-ae39acf012a5', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'yhqfl', '�Ż�ȯ����', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;482d62aa-5302-4773-b719-ae39acf012a5', 0, 2, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('5f3a2d88-6e40-469b-a130-136f6e15857e', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSJF', '�������˷�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;5f3a2d88-6e40-469b-a130-136f6e15857e', 0, 3, 1, 1, 0, 1, '', 3, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('60544642-c2dd-411b-acdf-5ba2ca6c92b9', '1583b6ae-0016-45e2-9206-12577d928665', 'UserRegistContract', '�û�ע��Э��', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;60544642-c2dd-411b-acdf-5ba2ca6c92b9', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '<p style="padding: 0px; margin-top: 0px; margin-bottom: 0px; font-size: 12px; color: rgb(79, 79, 79); font-family: ΢���ź�; white-space: normal;">
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
VALUES ('78367a53-5026-4551-a741-5cc45157f5a3', '482d62aa-5302-4773-b719-ae39acf012a5', '02', 'ϵͳ�ɷ�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;78367a53-5026-4551-a741-5cc45157f5a3', 0, 3, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('84e88925-afdb-4385-8622-acac8e689dee', '1e423f5b-41f5-4c1a-9065-b76caa2e925e', 'jffl', '��������', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;84e88925-afdb-4385-8622-acac8e689dee', 0, 2, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('8a8777e8-3737-4f92-b964-97e922024903', '84e88925-afdb-4385-8622-acac8e689dee', 'SDZP', '�׵����Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;8a8777e8-3737-4f92-b964-97e922024903', 0, 3, 1, 1, 0, 1, '', 4, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('a5c21066-8429-4f36-9103-150c46e5f7fb', '84e88925-afdb-4385-8622-acac8e689dee', 'MEZP', '�׵��ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;a5c21066-8429-4f36-9103-150c46e5f7fb', 0, 3, 1, 1, 0, 1, '', 5, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', '84e88925-afdb-4385-8622-acac8e689dee', 'SDSYHQ', '�׵�����Ʒ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;c4b49bbe-32c4-44b2-b5d2-522bbbf168f1', 0, 3, 1, 1, 0, 1, '', 6, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('cb219364-886d-4965-bee2-dfef78bded00', '', '02', '�û��Զ������', '', '', 'cb219364-886d-4965-bee2-dfef78bded00', 0, 1, 1, 1, 0, 1, '', 1, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ce04cb8c-7d10-4b74-bb45-2c8fec920467', '1583b6ae-0016-45e2-9206-12577d928665', 'OrderStatus', '����״̬', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ce04cb8c-7d10-4b74-bb45-2c8fec920467', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d677d840-241f-439e-8025-2556a28ca523', '84e88925-afdb-4385-8622-acac8e689dee', 'RegsitJf', '�׵����˷�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d677d840-241f-439e-8025-2556a28ca523', 0, 3, 1, 1, 0, 1, '', 7, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', '84e88925-afdb-4385-8622-acac8e689dee', 'FreeYF', 'ע�����Ż�ȯ', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;d7736e27-17b6-4416-a3f7-9d5c71cfc9a6', 0, 3, 1, 1, 0, 1, '', 8, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('e0bda09d-2396-4678-b13e-939b607eb4a2', '482d62aa-5302-4773-b719-ae39acf012a5', '03', '���ֶһ�', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;e0bda09d-2396-4678-b13e-939b607eb4a2', 0, 3, 1, 1, 0, 1, '', 2, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('e8cb9a79-2b43-4792-b8a2-f5971c75e694', '482d62aa-5302-4773-b719-ae39acf012a5', '01', '����', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;482d62aa-5302-4773-b719-ae39acf012a5;e8cb9a79-2b43-4792-b8a2-f5971c75e694', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', '84e88925-afdb-4385-8622-acac8e689dee', 'RegistToQuan', 'ע���ͻ���', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;ef1fbe7f-8b6b-40a8-a40e-b4274bf262cd', 0, 3, 1, 1, 0, 1, '', 9, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', '1583b6ae-0016-45e2-9206-12577d928665', '01', 'ͼƬ��������ַ', '', '', '1e423f5b-41f5-4c1a-9065-b76caa2e925e;1583b6ae-0016-45e2-9206-12577d928665;ef7bd99f-45a9-4b9e-8db5-4b5bc0286932', 0, 3, 1, 1, 0, 1, '', 0, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ParameterInfo (ID, ParentID, Code, Name, Value, Value2, ClassCode, IsDetails, Series, IsSystem, IsEdit, IsDelete, IsEnable, Note, OrderNo, V1Type, V2Type, Img1, Img2, Img3, Value3, V3Type, V4Type, Value4, V5Type, Value5, IsCanHasLeaf, V1Note, V2Note, V3Note, V4Note, V5Note)
VALUES ('fb4704d4-b600-4f46-9b1f-0d68c3a299ed', '84e88925-afdb-4385-8622-acac8e689dee', 'MEMYF', '����', '', '', 'cb219364-886d-4965-bee2-dfef78bded00;84e88925-afdb-4385-8622-acac8e689dee;fb4704d4-b600-4f46-9b1f-0d68c3a299ed', 0, 3, 1, 1, 0, 1, '', 10, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, '', NULL, '', 1, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('01f82ec6-785d-4ef6-9933-6a1b4c7fd1f1', '8994bbb9-725d-4936-b50b-95d58c22f0ec', '', '', '', '', '', 0, '', '', '', '', 0, 0, 100, 0, '2015-09-03', '2017-08-18', 1, '', '2015-09-03 00:14:13.98', '', 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('3bb67717-41b7-468f-ada4-53f474761800', '247cba5b-cf42-4412-9778-9b41591812fc', '', '', '', '', '', 0, '', '', '34691339-63bf-4b43-b601-eba4ad098652', '��ֵ100Ԫ�Ż�ȯ', 0, 0, 0, 0, '2015-09-03', '2016-01-01', 1, '', '2015-09-03 00:18:19.75', '', 0)
GO

INSERT INTO dbo.ShopPromotion (ID, RuleID, BuyCategoryId, BuyCategoryName, BuyProductId, BuyProductName, BuySKUID, BuyCount, HandsaleProductId, HandsaleProductSKUID, CouponID, CouponName, HandsaleMaxCount, HandsaleCount, MinPrice, MaxPrice, StartDate, EndDate, IsEnable, CreateUser, CreateDate, Note, ActionStatus)
VALUES ('bf178bd9-afab-4a38-a37d-10cae8f95e64', '94be3670-b394-4855-8f4e-73a94da85313', '', '', '', '', '', 0, '', '', '', '', 0, 0, 0, 0, '2015-09-03', '2099-12-28', 1, '', '2015-09-03 00:15:00.33', '', 0)
GO


