USE Enrollment
GO

-- estudiantes de ejemplo
INSERT INTO Student (StudentName) VALUES 
('Ana Torres'),
('Luis Fern�ndez'),
('Mar�a G�mez'),
('Carlos Ram�rez'),
('Laura M�ndez');

-- cursos de ejemplo
INSERT INTO Course (CourseName) VALUES 
('Matem�ticas B�sicas'),
('Introducci�n a la Programaci�n'),
('Ingl�s Intermedio'),
('Historia Universal'),
('F�sica General')




SELECT * FROM Student
SELECT * FROM Course
SELECT * FROM Enrollment