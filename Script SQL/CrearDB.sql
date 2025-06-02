CREATE DATABASE Enrollment
GO

USE Enrollment
GO

-- Tabla de estudiantes
CREATE TABLE Student (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(100) NOT NULL
)

-- Tabla de cursos
CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100) NOT NULL
)

-- Tabla de matrículas
CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY IDENTITY(1,1),
    Status VARCHAR(20) NOT NULL CHECK (Status IN ('Activa', 'Cancelada', 'Finalizada')),
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE(),
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    CONSTRAINT FK_Enrollment_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
    CONSTRAINT UQ_Student_Course UNIQUE (StudentId, CourseId)
)
