-- ALL 

DECLARE @datetime AS DATETIME2(0) = '2018-03-01 17:44:04';
  
SELECT * FROM dbo.Orders FOR SYSTEM_TIME ALL ORDER BY validTo DESC;

-- ALL
DECLARE @datetime AS DATETIME2(0) = '2018-03-01 17:44:04';
 
SELECT * FROM dbo.Orders WHERE validFrom <= @datetime AND validTo > @datetime  
UNION ALL
SELECT * FROM dbo.OrdersHistory WHERE validFrom <= @datetime AND validTo > @datetime;
------------------------------------

-- FROM TO
DECLARE
  @start AS DATETIME2(0)= '2018-01-31 17:44:04',
  @end   AS DATETIME2(0)= '2018-03-01 17:44:04',
  @id AS INT = 9;
 
SELECT * FROM dbo.Orders FOR SYSTEM_TIME FROM @start TO @end WHERE id = @id;
 
-- Equivalent Union Query
SELECT * FROM dbo.Orders WHERE id = @id AND validFrom < @end AND validTo > @start
UNION ALL
SELECT * FROM dbo.OrdersHistory WHERE id = @id AND validFrom < @end   AND validTo > @start;
GO
------------------------------------

-- BETWEEN
DECLARE
  @start AS DATETIME2(0)= '2018-01-31 17:44:04', -- time of Eva's first assignment
  @end   AS DATETIME2(0)= '2018-03-01 17:44:04',  -- time of Eva's current assignment
  @id AS INT = 9;
 
SELECT * FROM dbo.Orders FOR SYSTEM_TIME BETWEEN @start AND @end WHERE id = @id;
 
-- UNION ALL equivalent
SELECT * FROM dbo.Orders WHERE id = @id AND validFrom < = @end AND validTo > @start
UNION ALL
SELECT * FROM dbo.OrdersHistory WHERE id = @id AND validFrom < = @end AND validTo > @start;
GO



----------------------------------
-- CONTAINED
DECLARE
  @start AS DATETIME2(0)= '2018-01-31 17:44:04', -- time of Eva's first assignment
  @end AS DATETIME2(0)= '2018-03-01 17:44:04', -- time of Eva's current assignment
  @id AS INT = 9;
 
SELECT * FROM dbo.Orders FOR SYSTEM_TIME CONTAINED IN ( @start , @end ) WHERE id = @id;
 
-- Equivalent UNION ALL query
SELECT * FROM dbo.Orders WHERE id = @id AND validFrom > = @start AND validTo < = @end
UNION ALL
SELECT * FROM dbo.OrdersHistory WHERE id = @id AND validFrom > = @start AND validTo < = @end