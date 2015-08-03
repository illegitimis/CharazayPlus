USE [CharazayTM]
GO

/****** Object:  StoredProcedure [dbo].[GetAveragePrices]    Script Date: 07/18/2015 10:32:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery1.sql|6|0|C:\Users\Illegitimis\AppData\Local\Temp\~vs5C0F.sql

CREATE procedure [dbo].[GetAveragePrices] (
	@Position char(1) = null,
	@ForVisualStudio bit = 0
)
as 
begin
	if (@Position is not null and upper(@Position) not in ('G','F','C'))
		return;
		
	if (@Position is null and @ForVisualStudio=0)	
		select 
			Age
			,PosId
			,AgeValueIndex
			,AVG(Price) AS AVERAGE_PRICE
			,COUNT(*) as COUNT 
		from History
		group by Age,PosId,AgeValueIndex
		order by Age,PosId,AgeValueIndex;
	
	if (@Position is null and @ForVisualStudio=1)		
		select 
			'{(byte)'
			,Age
			,', '
			,PosId
			,' '
			,AgeValueIndex
			,'f, '
			--,SUM(Price* (1200-datediff(day,Day,GETUTCDATE()))) / SUM( 1200-datediff(day,Day,GETUTCDATE()) ) as WEIGHTED_PRICE
			--,'f, '
			,AVG(Price) AS AVERAGE_PRICE
			,'f, '
			,COUNT(*) as COUNT 
			, ' },' 
		from History
		group by Age,PosId,AgeValueIndex
		order by Age,PosId,AgeValueIndex;
	
	if (@Position is not null and @ForVisualStudio=0)
		select 
			Age
			,AgeValueIndex
			,AVG(Price) AS AVERAGE_PRICE
			,COUNT(*) as COUNT 
		from History
		where upper(PosId) = UPPER(@Position)
		group by Age,PosId,AgeValueIndex
		order by Age,PosId,AgeValueIndex;
	
	if (@Position is not null and @ForVisualStudio=1)
		select 
			'{(byte)'
			,Age
			,', '
			,AgeValueIndex
			,'f, '
			,AVG(Price) AS AVERAGE_PRICE
			,'f, '
			,COUNT(*) as COUNT 
			, ' },' 
		from History
		where upper(PosId) = UPPER(@Position)
		group by Age,PosId,AgeValueIndex
		order by Age,PosId,AgeValueIndex;
		
		
		
end

GO

