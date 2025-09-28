create view vw_persons as select 
p.last_name + ' ' + LEFT(p.first_name, 1) + '.' + LEFT(p.second_name, 1) + '.' as 'ФИО',
s.[name] as 'Статус',
d.[name] as 'Отдел',
po.[name] as 'Должность',
p.date_employ as 'Дата_приема_на_работу',
p.date_uneploy as 'Дата_увольнения'
from persons p 
inner join status s on p.status = s.id
inner join deps d on p.id_dep = d.id
inner join posts po on p.id_post = po.id;

drop view vw_persons;

select * from vw_persons;
