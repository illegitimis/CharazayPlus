USE [CharazayTM]
GO

/****** Object:  StoredProcedure [dbo].[GetWeightedPrices]    Script Date: 07/18/2015 10:33:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetWeightedPrices] (
	@Position char(1) = null,
	@ForVisualStudio bit = 0
)
as 
begin
	if (@Position is not null AND upper(@Position) not in ('G','F','C'))
		return;
		
	declare @NoDaysDifference int, @DaysFactor int;
	select @NoDaysDifference = max (datediff (day,Day,GETUTCDATE())) from History;
	select @DaysFactor = case 
		when @NoDaysDifference between 0 and 499 then 500
		when @NoDaysDifference between 500 and 999 then 1000
		when @NoDaysDifference between 1000 and 1499 then 1500
		when @NoDaysDifference between 1500 and 1999 then 2000
		else @NoDaysDifference + 500
	end
	
	if (@Position is null and @ForVisualStudio=0)	
		select 
			Age
			,PosId
			,AgeValueIndex
			,SUM(Price* (@DaysFactor-datediff(day,Day,GETUTCDATE()))) / SUM( @DaysFactor-datediff(day,Day,GETUTCDATE()) ) as WEIGHTED_PRICE
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
			,SUM(Price* (@DaysFactor-datediff(day,Day,GETUTCDATE()))) / SUM( @DaysFactor-datediff(day,Day,GETUTCDATE()) ) as WEIGHTED_PRICE
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
			,SUM(Price* (@DaysFactor-datediff(day,Day,GETUTCDATE()))) / SUM( @DaysFactor-datediff(day,Day,GETUTCDATE()) ) as WEIGHTED_PRICE
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
			,SUM(Price* (@DaysFactor-datediff(day,Day,GETUTCDATE()))) / SUM( @DaysFactor-datediff(day,Day,GETUTCDATE()) ) as WEIGHTED_PRICE
			,'f, '
			,COUNT(*) as COUNT 
			, ' },' 
		from History
		where upper(PosId) = UPPER(@Position)
		group by Age,PosId,AgeValueIndex
		order by Age,PosId,AgeValueIndex;
		
		
		
end
GO

