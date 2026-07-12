create database QuizesSystem;

create table Admins(
 Id int primary key identity(1,1),
 Email varchar(250) unique not null ,
 Password varchar(20) not null
);

create table Teachers(
 Id int primary key identity(1,1),
 Name varchar(250) not null,
 Email varchar(250) not null unique,
 Password varchar(20) not null check(len(trim(Password))>10),
 title varchar(20) not null
);

create table Students(
 Id int primary key identity(1,1),
 Name varchar(250) not null,
 Email varchar(250) not null unique,
 Password varchar(20) not null check(len(trim(Password))>10),
 Grade int 
);

create table Courses(
 Id int primary key identity(1,1),
 AdminId int ,
 TeacherId int null,
 Name varchar(250) not null unique,
 Duration int ,
 NumberOfLessons int ,
 Category varchar(30) check(Category in ('Language','Programming','Natural Science','Computer Science')),
 foreign key (AdminId) references Admins(Id) ,
 foreign key (TeacherId) references Teachers(Id) 
);


create table CourseStudents(
 CourseId int,
 StudentId int,
 foreign key (CourseId) references Courses(Id),
 foreign key (StudentId) references Students(Id),
 primary key(CourseId,StudentId)
);

create table Quizes(
 Id int primary key identity(1,1),
 Name varchar(250),
 CourseId int,
 type varchar(30) not null check(type in ('True|False','Multiple Choice','Short Answer')),
 Duration int not null check(Duration > 0),
 totalScore int not null check(totalScore > 0),
 foreign key (CourseId) references Courses(Id),
);

create table QuizesQuestions(
 QuestionId int primary key identity(1,1),
 QuizeId int,
 Question varchar(max) not null,
 correctAnswer varchar(max) not null,
 foreign key (QuizeId) references Quizes(Id),

);

create table QuizeStudentsAndScores(
  QuizeId int,
  studentId int,
  StudentScore int not null ,
  foreign key (QuizeId) references Quizes(Id),
  foreign key (studentId) references Students(Id),
  primary key(QuizeId,studentId)

);

 --for multiple choice Quizes
create table AnswerChoices(
 Id int primary key identity(1,1),
 QuestionId int,
 Answar varchar(250) not null,
 foreign key (QuestionId) references QuizesQuestions(QuestionId)
);

create table StudentQuizeAnswers(
 QuizeId int,
 QuestionId int,
 StudentId int,
 foreign key (QuizeId) references Quizes(Id),
 foreign key (StudentId) references Students(Id),
 foreign key (QuestionId) references QuizesQuestions(QuestionId),
 primary key(QuizeId,StudentId,QuestionId),
 StudentAnswer varchar(max)
);

insert into Admins(Email,Password)
values  ('Admin1@gmail.com','asdfasdf123'),
		('Admin2@gmail.com','tyipm753985'),
		('Admin3@gmail.com','ghjkl456456'),
		('Admin4@gmail.com','qwertyui753'),
		('Admin5@gmail.com','qwertpi7512'),
		('Admin6@gmail.com','thjm,7539674')

alter table Teachers 
add constraint Title_Values check(title in ('Professor','Assistant Professor','instructor'))

insert into Teachers(Name,title,Email,Password)
values ('Ahmed Salah','Professor','ahmedsalah456@gmail.com','123hjk456tyu'),
		('Mona Ahmed','instructor','Mona@gmail.com','893po89iutyu'),
		('Hoda Ali','Professor','Hoda753@gmail.com','12uytre753yu'),
		('Ahmed Taha','Assistant Professor','ahmedpo56@gmail.com','17841k456tyu'),
		('Mohamed Fehmy','Professor','mohamed756@gmail.com','ujkjhg56tyu'),
		('Dalia Waleed','Assistant Professor','daliawaleed76@gmail.com','178234596yu'),
		('Omer Esam','instructor','Omeresam456@gmail.com','omer78k456tyu'),
		('Safaa Amin','Professor','SafaaAmin789@gmail.com','yhnmkl456tyu'),
		('Hanan Ahmed','Assistant Professor','hananahmed7845@gmail.com','123hjk456tyu'),
		('Dina Elsayed','Professor','DinaElsayed456@gmail.com','123ujhy6tyu'),
		('Mona Hassan','Assistant Professor','mona.hassan@gmail.com','abc456def789'),
		('Omar Khaled','Assistant Professor','omar.khaled@gmail.com','xyz123mno456'),
		('Sara Mostafa','Instructor','sara.mostafa@gmail.com','pass789qwe123'),
		('Youssef Adel','Assistant Professor','youssef.adel@gmail.com','asd456zxc789'),
		('Nourhan Ali','Instructor','nourhan.ali@gmail.com','qaz123wsx456'),
		('Mahmoud Ibrahim','Professor','mahmoud.ibrahim@gmail.com','poi789lkj123'),
		('Fatma Ahmed','Assistant Professor','fatma.ahmed@gmail.com','mnb456vcx789'),
		('Karim Tarek','Instructor','karim.tarek@gmail.com','rty123fgh456'),
		('Salma Hany','Professor','salma.hany@gmail.com','uio789jkl123');

insert into Students (Name,Email,Password,Grade)
values  ('Ali Dawood','alidawood@gmail.com','qwertyuiop789',0),
	    ('Mona Ahmed','mona.ahmed@gmail.com','pass123456789',0),
		('Omar Khaled','omar.khaled@gmail.com','securepass123',0),
		('Sara Mostafa','sara.mostafa@gmail.com','mypassword456',0),
		('Youssef Adel','youssef.adel@gmail.com','student789abc',0),
		('Nourhan Ali','nourhan.ali@gmail.com','gradepass123',0),
		('Mahmoud Ibrahim','mahmoud.ibrahim@gmail.com','learning4567',0),
		('Fatma Hassan','fatma.hassan@gmail.com','collegepass89',0),
		('Karim Tarek','karim.tarek@gmail.com','welcome12345',0),
		('Salma Hany','salma.hany@gmail.com','student2026ab',0),
		('Ahmed Samir','ahmed.samir@gmail.com','ahmedpass789',0),
		('Hoda Ali','hoda.ali@gmail.com','securegrade12',0),
		('Mostafa Nabil','mostafa.nabil@gmail.com','mypassword999',0),
		('Dina Elsayed','dina.elsayed@gmail.com','studentpass22',0),
		('Hassan Mohamed','hassan.mohamed@gmail.com','learningabc1',0),
		('Mariam Adel','mariam.adel@gmail.com','welcome2026xy',0),
		('Tarek Mahmoud','tarek.mahmoud@gmail.com','password7890a',0),
		('Aya Ibrahim','aya.ibrahim@gmail.com','college2026ab',0),
		('Khaled Fathy','khaled.fathy@gmail.com','education123',0),
		('Reem Ahmed','reem.ahmed@gmail.com','studyhard456',0),
		('Mohamed Ashraf','mohamed.ashraf@gmail.com','futurepass789',0),
		('Nadine Samy','nadine.samy@gmail.com','studentlife12',0),
		('Amr Wael','amr.wael@gmail.com','computer1234',0),
		('Menna Tarek','menna.tarek@gmail.com','database5678',0),
		('Shady Adel','shady.adel@gmail.com','networkpass1',0),
		('Farah Mohamed','farah.mohamed@gmail.com','software2026',0),
		('Islam Nasser','islam.nasser@gmail.com','security789ab',0),
		('Habiba Ali','habiba.ali@gmail.com','algorithms12',0),
		('Adham Yasser','adham.yasser@gmail.com','programming34',0),
		('Jana Khaled','jana.khaled@gmail.com','engineering56',0),
		('Ziad Ahmed','ziad.ahmed@gmail.com','technology78',0),
		('Malak Mostafa','malak.mostafa@gmail.com','innovation90',0),
		('Seif Mohamed','seif.mohamed@gmail.com','education321x',0),
		('Rana Adel','rana.adel@gmail.com','university654',0),
		('Anas Hassan','anas.hassan@gmail.com','student987zy',0),
		('Esraa Samir','esraa.samir@gmail.com','learning2468',0),
		('Walid Mahmoud','walid.mahmoud@gmail.com','knowledge135',0),
		('Nermine Ali','nermine.ali@gmail.com','computer246x',0),
		('Sherif Tarek','sherif.tarek@gmail.com','database789q',0),
		('Nada Ibrahim','nada.ibrahim@gmail.com','software456z',0);

insert into Courses (Name,Duration,Category,AdminId,TeacherId,NumberOfLessons)
values	('Operating Systems',3,'Computer Science',1,1,9),
		('Algorithms',3,'Computer Science',3,1,10),
		('Computer Vision',3,'Computer Science',5,6,8),
		('Computer Graphics',3,'Computer Science',2,null,10),
		('English',3,'Language',2,2,9),
		('Physics',3,'Natural Science',2,null,9),
		('Data Structures',3,'Computer Science',1,3,10),
		('Database Systems',3,'Computer Science',2,4,12),
		('Artificial Intelligence',4,'Computer Science',3,6,11),
		('Machine Learning',4,'Computer Science',4,7,12),
		('Cyber Security',3,'Computer Science',5,8,10),

		('Java Programming',3,'Programming',6,null,12),
		('C++ Programming',3,'Programming',2,13,11),
		('Python Programming',3,'Programming',3,null,13),
		('Web Development',4,'Programming',4,16,14),
		('Mobile App Development',4,'Programming',5,null,12),

		('French Language',3,'Language',1,17,10),
		('German Language',3,'Language',6,null,9),
		('Spanish Language',3,'Language',3,19,10),

		('Chemistry',3,'Natural Science',4,null,11),
		('Biology',3,'Natural Science',5,null,10)

insert into CourseStudents(CourseId,StudentId)
values  (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),

		(2,1),(2,2),(2,19),(2,20),(2,4),(2,3),(2,7),(2,8),(2,9),(2,10),(2,12),
		(2,11),(2,21),(2,30),(2,40),(2,33),

		(3,15),(3,16),(3,20),(3,23),(3,13),(3,31),(3,32),(3,39),(3,21),(3,22),
		(3,11),(3,24),(3,25),(3,26),(3,33),

		(5,1),(5,2),(5,4),(5,12),(5,13),(5,15),(5,16),(5,17),(5,18),(5,20),

		(7,3),(7,5),(7,6),(7,7),(7,8),(7,9),(7,10),(7,14),(7,19),(7,21),
		(7,22),(7,23),(7,27),(7,28),(7,29),(7,30),

		(8,1),(8,4),(8,5),(8,11),(8,12),(8,15),(8,18),(8,20),(8,24),(8,25),
		(8,26),(8,31),(8,32),(8,34),(8,35),(8,36),

		(9,2),(9,3),(9,6),(9,7),(9,8),(9,13),(9,14),(9,17),(9,19),(9,22),
		(9,23),(9,27),(9,28),(9,33),(9,37),(9,38),

		(10,1),(10,5),(10,9),(10,10),(10,11),(10,12),(10,15),(10,16),(10,18),(10,20),
		(10,21),(10,24),(10,25),(10,29),(10,30),(10,40),

		(11,2),(11,4),(11,6),(11,8),(11,13),(11,14),(11,17),(11,19),(11,22),(11,23),
		(11,26),(11,27),(11,31),(11,32),(11,35),(11,36),

		(13,1),(13,3),(13,5),(13,7),(13,9),(13,11),(13,15),(13,18),(13,20),(13,24),
		(13,25),(13,28),(13,30),(13,33),(13,37),(13,39),

		(15,2),(15,4),(15,6),(15,8),(15,10),(15,12),(15,14),(15,16),(15,19),(15,21),
		(15,23),(15,26),(15,29),(15,31),(15,34),(15,38),

		(17,1),(17,2),(17,3),(17,4),(17,5),(17,6),(17,7),(17,8),(17,9),(17,10),
		(17,11),(17,12),(17,13),(17,14),(17,15),(17,16),

		(19,20),(19,21),(19,22),(19,23),(19,24),(19,25),(19,26),(19,27),(19,28),(19,29),
		(19,30),(19,31),(19,32),(19,33),(19,34),(19,35)


insert into Quizes(Name,type,Duration,CourseId,totalScore)
values  ('quize 1 os','Multiple Choice',5,1,10),
		('quize 2 os','Short Answer',10,1,20),

		('quize 1 Algorithms','True|False',5,1,5),
		('Quiz 2 Algorithms','Multiple Choice',10,2,10),
		('Quiz 3 Algorithms','Short Answer',15,2,20),

		('Quiz 1 Computer Vision','Multiple Choice',10,3,15),
		('Quiz 2 Computer Vision','True|False',5,3,10),

		('Quiz 1 English','Short Answer',10,5,20),
		('Quiz 2 English','Multiple Choice',5,5,10),

		('Quiz 1 Data Structures','Multiple Choice',10,7,15),
		('Quiz 2 Data Structures','True|False',5,7,10),

		('Quiz 1 Database Systems','Multiple Choice',10,8,20),
		('Quiz 2 Database Systems','Short Answer',15,8,25),

		('Quiz 1 Artificial Intelligence','Multiple Choice',10,9,20),
		('Quiz 2 Artificial Intelligence','True|False',5,9,10),

		('Quiz 1 Machine Learning','Multiple Choice',15,10,25),
		('Quiz 2 Machine Learning','Short Answer',20,10,30),

		('Quiz 1 Cyber Security','True|False',5,11,10),
		('Quiz 2 Cyber Security','Multiple Choice',10,11,20),

		('Quiz 1 C++ Programming','Multiple Choice',10,13,15),
		('Quiz 2 C++ Programming','Short Answer',15,13,25)


INSERT INTO QuizesQuestions(QuizeId,Question,correctAnswer)
VALUES  (1,'What is the primary purpose of an operating system?','Resource Management'),
		(1,'What is a process?','A program in execution'),

		(2,'What is deadlock?','Processes waiting indefinitely'),
		(2,'What is virtual memory?','Memory management technique'),

		(3,'An algorithm must always terminate.','True'),
		(3,'Binary search works on unsorted arrays.','False'),

		(4,'What is the time complexity of binary search?','O(log n)'),
		(4,'Which data structure is used in BFS?','Queue'),

		(5,'What is the purpose of dynamic programming?','Optimization'),
		(5,'Merge sort uses which strategy?','Divide and Conquer'),

		(6,'What is a pixel?','Smallest image element'),
		(6,'What does RGB stand for?','Red Green Blue'),

		(7,'What is a stack?','LIFO Data Structure'),
		(7,'What is the worst-case complexity of linear search?','O(n)'),

		(8,'What is a primary key?','Unique Identifier'),
		(8,'SQL stands for?','Structured Query Language'),

		(9,'What is machine learning?','Learning from Data'),
		(9,'What is a training dataset?','Data used for training'),

		(10,'What is overfitting?','Poor Generalization'),
		(10,'Supervised learning requires labeled data.','True'),

		(11,'What is malware?','Malicious Software'),
		(11,'What does VPN stand for?','Virtual Private Network'),

		(12,'Java is a compiled language.','True'),
		(12,'Which keyword creates an object in Java?','new'),

		(13,'What is inheritance?','Code Reusability'),
		(13,'C++ supports polymorphism.','True'),

		(14,'Python uses indentation to define blocks.','True'),
		(14,'Which symbol starts a comment in Python?','#'),

		(15,'HTML stands for?','HyperText Markup Language'),
		(15,'CSS is used for styling web pages.','True'),

		(16,'Which platform is used for Android apps?','Android'),
		(16,'APK stands for?','Android Package Kit'),

		(17,'Bonjour means hello in French.','True'),
		(17,'What is the French word for thank you?','Merci'),

		(18,'German is spoken in Germany.','True'),
		(18,'What is the German word for yes?','Ja'),

		(19,'Hola is a Spanish greeting.','True'),
		(19,'What is the Spanish word for goodbye?','Adios'),

		(20,'Water chemical formula is?','H2O'),
		(20,'What gas do plants absorb?','Carbon Dioxide');

INSERT INTO AnswerChoices(QuestionId,Answar)
VALUES
		(1,'Resource Management'),
		(1,'Web Browsing'),
		(1,'Video Editing'),
		(1,'Game Development'),

		(2,'A program in execution'),
		(2,'A hardware device'),
		(2,'A network protocol'),
		(2,'A database'),

		(7,'O(log n)'),
		(7,'O(n)'),
		(7,'O(n²)'),
		(7,'O(1)'),

		(8,'Queue'),
		(8,'Stack'),
		(8,'Tree'),
		(8,'Heap'),

		(11,'Smallest image element'),
		(11,'Monitor'),
		(11,'Printer'),
		(11,'Color Model'),

		(12,'Red Green Blue'),
		(12,'Red Gray Black'),
		(12,'Random Graphic Buffer'),
		(12,'Real Green Brown'),

		(17,'Learning from Data'),
		(17,'Programming Language'),
		(17,'Operating System'),
		(17,'Database'),

		(18,'Data used for training'),
		(18,'Testing software'),
		(18,'Source code'),
		(18,'Database schema'),

		(19,'Poor Generalization'),
		(19,'Fast Execution'),
		(19,'Data Encryption'),
		(19,'Code Reuse'),

		(20,'True'),
		(20,'False'),

		(23,'True'),
		(23,'False'),

		(24,'new'),
		(24,'create'),
		(24,'object'),
		(24,'class'),

		(27,'True'),
		(27,'False'),

		(28,'#'),
		(28,'//'),
		(28,'/*'),
		(28,'--'),

		(31,'Android'),
		(31,'Windows'),
		(31,'Linux'),
		(31,'macOS'),

		(32,'Android Package Kit'),
		(32,'Android Program Key'),
		(32,'Application Package Kernel'),
		(32,'Android Package Kernel'),

		(37,'True'),
		(37,'False'),

		(38,'Adios'),
		(38,'Hola'),
		(38,'Gracias'),
		(38,'Si'),

		(39,'H2O'),
		(39,'CO2'),
		(39,'O2'),
		(39,'NaCl'),

		(40,'Carbon Dioxide'),
		(40,'Oxygen'),
		(40,'Nitrogen'),
		(40,'Hydrogen');
		
insert into StudentQuizeAnswers(QuizeId,QuestionId,StudentId,StudentAnswer)
values  (1,1,1,'Resource Management'),
		(1,2,1,'A program in execution'),

		(2,3,2,'Processes waiting indefinitely'),
		(2,4,2,'Cache management'),

		(3,5,3,'True'),
		(3,6,3,'True'),

		(4,7,4,'O(log n)'),
		(4,8,4,'Stack'),

		(5,9,7,'Optimization'),
		(5,10,7,'Divide and Conquer'),

		(6,11,15,'Smallest image element'),
		(6,12,15,'Red Green Blue'),

		(7,13,16,'LIFO Data Structure'),
		(7,14,16,'O(n²)'),

		(8,15,1,'Unique Identifier'),
		(8,16,1,'Structured Query Language'),

		(9,17,12,'Learning from Data'),
		(9,18,12,'Testing software'),

		(10,19,3,'Poor Generalization'),
		(10,20,3,'True'),

		(11,21,5,'Malicious Software'),
		(11,22,5,'Virtual Private Network'),

		(12,23,1,'True'),
		(12,24,1,'new'),

		(13,25,4,'Code Reusability'),
		(13,26,4,'False');

insert into QuizeStudentsAndScores(studentId,QuizeId,StudentScore)
values  (1,1,10),
		(1,8,20),
		(1,12,20),

		(2,1,8),
		(2,2,15),
		(2,8,20),

		(3,2,15),
		(3,3,5),
		(3,10,15),

		(4,3,5),
		(4,4,10),
		(4,13,20),

		(5,11,10),

		(6,10,12),

		(7,4,6),
		(7,5,20),

		(8,4,6),

		(9,5,18),
		(9,11,10),

		(11,12,15),

		(12,9,5),
		(12,13,20),

		(13,9,5),

		(15,6,15),

		(16,7,10),

		(20,6,10),

		(23,7,7);

update Students
set Grade = 7
where Id = 23;
update Students
set Grade = 50
where Id = 1;

update Students
set Grade = 43
where Id = 2;

update Students
set Grade = 35
where Id = 3;

update Students
set Grade = 12
where Id = 6;

update Students
set Grade = 35
where Id = 4;

update Students
set Grade = 10
where Id = 16;

update Students
set Grade = 10
where Id = 20;

update Students
set Grade = 70
where Id = 15;

update Students
set Grade = 70
where Id = 25;

update Students
set Grade = 78
where Id = 40;

update Students
set Grade = 80
where Id = 38;
go
CREATE VIEW AssignedCoures AS
select c.Name AS CourseName,c.Category,t.Name As TeacherName
from Courses as c join Teachers as t
on c.TeacherId  = t.Id
go

select* from AssignedCoures

go
CREATE VIEW QuizeQuestionsNumber AS
select q.Name AS QuizeName,COUNT(qq.QuizeId) As QuestionsNumber
from Quizes as q left join QuizesQuestions as qq
on q.Id= qq.QuizeId
group by q.Name
go

select* from QuizeQuestionsNumber

select * 
from [dbo].[GetCourseStudents](7)

select  [dbo].[getCourseQuizesNumber](2)

go
CREATE VIEW AllCourses AS
select c.Name AS CourseName,c.Category,t.Name As TeacherName
from Courses as c left join Teachers as t
on c.TeacherId  = t.Id
go

select * from AllCourses;

[dbo].[UpdateCourseDuration] @CourseId = 1 , @NewDuration = 5

[dbo].[DeleteQuize] @QuizeId = 21
select [dbo].[AvarageQuizeDuration]() as AvgQuizeDurationMinutes;

select [dbo].[AvgStudentsGradesPerAquize](3) as AvgStudentsGrades;

select * from [dbo].[ShowStudentAnswersPerAquize](3)

go
create view GetCoursesWithMoreThan5Students
as
select C.Id , C.Name , C.Category , Count(CS.StudentId) as StudentsCount
from Courses C join CourseStudents CS
on C.Id = CS.CourseId
group by C.Id, C.Name , C.Category
having Count(CS.StudentId) > 5
go

select * from GetCoursesWithMoreThan5Students;

go
create view GetCoursesWithQuizes
as
select C.Id ,C.Name ,C.Category 
from Courses C
where exists (select 1  from Quizes where CourseId = C.Id)
go
select * from GetCoursesWithQuizes;

alter table Admins
add Phone varchar(14);

alter table Admins
add Address varchar(250);

[dbo].[UpdateAdminPhone] @Email = 'Admin1@gmail.com',@Password ='asdfasdf123',@Phone = '02315968396385'
[dbo].[UpdateAdminAddress] @Email = 'Admin1@gmail.com',@Password ='asdfasdf123',@Address = 'Eygpt - Cairo - Alzamalik'

select * from [dbo].[ShowStudentReport](3);