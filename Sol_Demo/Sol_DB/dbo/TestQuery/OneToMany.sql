

--SELECT 
--    TOP 2 
--        SOH.SalesOrderNumber,
--        SOH.OrderDate,
--        JSON_QUERY (

--                (
--                    SELECT 
--                        SOD.UnitPrice,
--                        SOD.OrderQty
--                    FROM
--                        Sales.SalesOrderDetail AS SOD WITH(NOLOCK)
--                    WHERE
--                        SOD.SalesOrderID=SOH.SalesOrderID
--                    FOR JSON PATH
--                )
--            ) AS SOD
--FROM 
--    Sales.SalesOrderHeader AS SOH WITH(NOLOCK)
--FOR JSON PATH
