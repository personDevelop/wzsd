CREATE VIEW [dbo].[View_ProductInfoBySkuid]
AS
SELECT DISTINCT 
                      dbo.ShopProductInfo.ID, dbo.ShopProductInfo.Code, dbo.ShopProductInfo.Name, dbo.ShopProductInfo.IsEnableSku, dbo.ShopProductInfo.Unit, 
                      ISNULL(dbo.ShopProductSKUInfo.SKU, dbo.ShopProductInfo.SKU) AS SKUCode, ISNULL(dbo.ShopProductSKUInfo.SalePrice, dbo.ShopProductInfo.SalePrice) 
                      AS SalePrice, ISNULL(dbo.ShopProductSKUInfo.Stock, dbo.ShopProductInfo.Stock) AS Stock, ISNULL(dbo.ShopProductSKUInfo.MarketPrice, 
                      dbo.ShopProductInfo.MarketPrice) AS MarketPrice, ISNULL(dbo.ShopProductSKUInfo.ID, '') AS SKUID
FROM         dbo.ShopProductInfo LEFT OUTER JOIN
                      dbo.ShopProductSKU ON dbo.ShopProductSKU.ProductId = dbo.ShopProductInfo.ID LEFT OUTER JOIN
                      dbo.ShopProductSKUInfo ON dbo.ShopProductSKU.ID = dbo.ShopProductSKUInfo.SKURelationID

GO