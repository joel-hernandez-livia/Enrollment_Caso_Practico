USE Enrollment
GO

-- estudiantes de ejemplo
INSERT INTO Student (StudentName) VALUES 
('Ana Torres'),
('Luis Fernández'),
('María Gómez'),
('Carlos Ramírez'),
('Laura Méndez');

-- cursos de ejemplo
INSERT INTO Course (CourseName) VALUES 
('Matemáticas Básicas'),
('Introducción a la Programación'),
('Inglés Intermedio'),
('Historia Universal'),
('Física General')




SELECT * FROM Student
SELECT * FROM Course
SELECT * FROM Enrollment