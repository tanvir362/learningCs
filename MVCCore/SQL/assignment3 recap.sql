select id, name from Instructor where Department_Name = 'cse' and Salary>3000

select id, name, Course_ID from (Student inner join CourseTaken on Student.ID = CourseTaken.Student_ID) where Course_ID = 'cse-465'

select id, name, Course.course_id, course_title, Course.Department_name from (Student inner join CourseTaken on Student.ID = CourseTaken.Student_ID) inner join Course on CourseTaken.Course_ID = Course.Course_ID where Semester = 'summer' and Student_ID = '110' and Year = 2019

select id, name from Instructor where Salary = ( select max(salary) from Instructor)

update Instructor set Salary = Salary + 5000 where Department_Name = 'cse' 

select s.Department_Name, count(distinct ID) as [Number of Student] from (Student as s inner join CourseTaken as ct on s.ID = ct.Student_ID) where Semester = 'summer' and year = 2019 group by s.Department_Name

select course_id, course_title from Course where Department_Name = 'cse' and Credits = 3

select * from student where id = (select student_ID from CourseTaken where Course_ID = 'cse-465' and Student_ID not in (select Student_ID from CourseTaken where Course_ID = 'cse-467'))

select Department_Name, AVG(salary) as [Average salary] from Instructor group by Department_Name

select name from student where name like 'f%d'