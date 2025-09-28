create procedure cp_persons_get
as
begin
	select * from vw_persons;
end;

exec cp_persons_get;



create procedure cp_deps_get
as
begin
	select name from deps;
end;



create procedure cp_post_get
as
begin
	select name from posts;
end;


create procedure cp_status_get
as
begin
	select name from status;
end;


exec cp_status_get;





create procedure cp_persons_get_filter_and_sort
@full_name nvarchar(100) = null,
@status_name nvarchar(100) = null,
@department_name nvarchar(100) = null,
@post_name nvarchar(100) = null,
@sortDir nvarchar(4) = null,
@sortColumn nvarchar(50) = null
as
begin
	declare @sql nvarchar(max)
	set @sql = 'select 
					p.ФИО,
					p.Статус,
					p.Отдел,
					p.Должность,
					p.Дата_приема_на_работу,
					p.Дата_увольнения
				from vw_persons p
				where 1 = 1 '

	if @full_name is not null set @sql += ' and p.ФИО like ''%'' + @full_name + ''%'' '
	if @status_name is not null set @sql += ' and p.Статус = @status_name '
	if @department_name is not null set @sql += ' and p.Отдел = @department_name '
	if @post_name is not null set @sql += ' and p.Должность = @post_name '

	if @sortColumn is not null and @sortDir is not null set @sql += ' order by ' + QUOTENAME(@sortColumn) + ' ' + @sortDir

	exec sp_executesql 
		@sql,
		N'@full_name nvarchar(100), @status_name nvarchar(100), @department_name nvarchar(100), @post_name nvarchar(100)', 
		@full_name, @status_name, @department_name, @post_name
	end

	drop procedure cp_persons_get_filter_and_sort;


	exec cp_persons_get_filter_and_sort @full_name = "с", @sortColumn = department_name, @sortDir = "ASC";



	create procedure cp_count_persons_by_status
		@status nvarchar(50)
	as 
	begin
		select COUNT(*) as persons from vw_persons where Статус = @status;
	end

	exec cp_count_persons_by_status @status = "стажировка";

	drop procedure cp_count_persons_by_status;


	create procedure cp_count_dismissed_hired_by_date
		@startDate datetime,
		@endDate datetime,
		@statusType nvarchar(50)
	as
	begin
		if @statusType = 'Стажировка'
		begin
			select 
				CAST(Дата_приема_на_работу as date) as EventDate,
				COUNT(*) as EmployeeCount
			from vw_persons
			where Статус = 'Стажировка'
			group by CAST(Дата_приема_на_работу as date)
			order by EventDate;
		end
		else if @statusType = 'Уволен'
		begin
			select
				CAST(Дата_увольнения as date) as EventDate,
				COUNT(*) as EmployeeCount
			from vw_persons
			where Статус = 'Уволен'
			group by CAST(Дата_увольнения as date)
			order by EventDate;
		end
	end


	declare @start datetime = CONVERT(datetime,'2020-01-01',120)
	declare @end datetime = CONVERT(datetime,'2025-09-28',120)

	exec cp_count_dismissed_hired_by_date
    @startDate = @start, 
    @endDate = @end, 
    @statusType = 'Уволен';

