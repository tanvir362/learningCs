select * from Student order by Department_Name desc, id desc
select * from Course
select Name, Course_Title 
from (Student left join CourseTaken  on Student.ID = CourseTaken.Student_ID) left join Course on CourseTaken.Course_ID = Course.Course_ID;

select id, name, Salary from Instructor where Department_Name = 'CSE' and Salary > 30000;

select id, name from Student as s inner join CourseTaken as c on s.ID = c.Student_ID
where Course_ID = 'CSE-465' and Department_Name = 'CSE';

select id, name, ct.Course_ID, Course_Title
from ( Student as s inner join CourseTaken as ct on s.ID = ct.Student_ID ) inner join Course as c on ct.Course_ID = c.Course_ID
where id = 110 and Semester = 'Summer' and Year = 2019;

select Name from Instructor where Salary = (select max(Salary) from Instructor);

update Instructor set Salary = Salary + 5000 where Department_Name = 'cse';

select Department_Name, count(distinct ID) as [Number of Student]
from Student as s inner join CourseTaken as ct on s.ID = ct.Student_ID
where Semester = 'Summer' and Year = 2019
group by Department_Name;

select course_id, course_title from Course where Department_Name = 'cse' and Credits = 3.0;

select *
from Student
where ID in ( select Student_ID from CourseTaken where Course_ID = 'CSE-465') 
	and 
		ID not in (select Student_ID from CourseTaken where Course_ID = 'CSE-467');

select Department_name, AVG(salary) as [Avg. Salary]
from Instructor
group by Department_Name;

select * 
from Student
where Name like 'f%d';