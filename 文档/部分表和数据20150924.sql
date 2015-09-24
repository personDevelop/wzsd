IF OBJECT_ID ('dbo.ShopPaymentTypes') IS NOT NULL
	DROP TABLE dbo.ShopPaymentTypes
GO

CREATE TABLE dbo.ShopPaymentTypes
	(
	ID              CHAR (36) NOT NULL,
	ShortName       NVARCHAR (50),
	Name            NVARCHAR (200) NOT NULL,
	DrivePath       NVARCHAR (50) NOT NULL,
	Gateway         NVARCHAR (400),
	MerchantCode    NVARCHAR (600) NOT NULL,
	EmailAddress    NVARCHAR (510),
	SecretKey       NVARCHAR (4000),
	SecondKey       NVARCHAR (4000),
	Password        NVARCHAR (4000),
	Partner         NVARCHAR (600),
	IsEnable        BIT NOT NULL,
	DisplaySequence INT NOT NULL,
	Charge          DECIMAL (15, 2) NOT NULL,
	IsPercent       BIT NOT NULL,
	AllowRecharge   BIT NOT NULL,
	Logo            NVARCHAR (510),
	Description     TEXT,
	CONSTRAINT PK_ShopPaymentTypes PRIMARY KEY (ID)
	)
GO
 INSERT INTO dbo.ShopPaymentTypes (ID, ShortName, Name, DrivePath, Gateway, MerchantCode, EmailAddress, SecretKey, SecondKey, Password, Partner, IsEnable, DisplaySequence, Charge, IsPercent, AllowRecharge, Logo, Description)
VALUES ('a062e5b2-7fad-4979-9f60-6ab4b16657c6', '支付宝', '支付宝无线即时到账', '1', 'alipaydirect', '', '', '', '', '', '', 1, 0, 1000, 0, 0, NULL, '')
GO

