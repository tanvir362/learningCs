USE [Practice]
GO
/****** Object:  StoredProcedure [dbo].[GetAllAND]    Script Date: 10/28/2019 2:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllAND]
	@Id int = null,
	@Name nvarchar(150) = null,
	@Price decimal(18,2) = null,
	@Description nvarchar(250) = null,
	@ImageUrl nvarchar(250) = null,
	@Category nvarchar(50) = null,
	@Rating decimal(18,2) = null,
	@IsAvailable bit = null,

	@Order nvarchar(50) = null,
	@PageIndex int = null,
	@PageSize int = null
	
AS
BEGIN
	declare @sql nvarchar(MAX),
	@paramlist nvarchar(MAX)
	
	SET NOCOUNT ON;
	set @sql = 'select * from Product where 1=1'

	if @Id is not null
		set @sql = @sql + ' and Id = @ID'

	if @Name is not null
		set @sql = @sql + ' and Name like ' + '''%'+@Name+'%'''
	if @Price is not null
		set @sql = @sql + ' and Price = @Price'
	if @Description is not null
		set @sql = @sql + ' and Description like ' + '''%'+@Description+'%'''
	if @ImageUrl is not null
		set @sql = @sql + ' and ImageUrl = @ImageUrl'
	if @Category is not null
		set @sql = @sql + ' and Category = @Category'
	if @Rating is not null
		set @sql = @sql + ' and Rating = @Rating'
	if @IsAvailable is not null
		set @sql = @sql + ' and IsAvailable = @IsAvailable'
	if @Order is not null
		set @sql = @sql + ' order by ' + QUOTENAME(@Order)

	if @PageSize is not null and @PageIndex is not null
		set @sql = @sql + ' offset @PageSize*(@PageIndex-1) row fetch next @PageSize rows only'


	select @paramlist = '@Id int, @Price decimal(18, 2), @ImageUrl nvarchar(250), @Category nvarchar(50), @Rating decimal(18, 2), @IsAvailable bit, @Order nvarchar(50), @PageSize int, @PageIndex int'

	exec sp_executesql @sql, @paramlist, @ID, @Price, @ImageUrl, @Category, @Rating, @IsAvailable, @Order, @PageSize, @PageIndex
    
	
END
print @sql
