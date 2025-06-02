USE Enrollment
GO

CREATE PROCEDURE CreateEnrollment
    @StudentId INT,
    @CourseId INT,
    @Status VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Student WHERE StudentId = @StudentId)
    BEGIN
        RAISERROR('El estudiante no existe.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Course WHERE CourseId = @CourseId)
    BEGIN
        RAISERROR('El curso no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1 FROM Enrollment 
        WHERE StudentId = @StudentId AND CourseId = @CourseId
    )
    BEGIN
        RAISERROR('Ya existe una matrícula para este estudiante y curso.', 16, 1);
        RETURN;
    END

    INSERT INTO Enrollment (StudentId, CourseId, Status, EnrollmentDate)
    VALUES (@StudentId, @CourseId, @Status, GETDATE());
END


-- Cambia el estado
-- valida que no se puede pasar a "Cancelada" si ya está "Finalizada".
CREATE PROCEDURE UpdateEnrollmentStatus
    @EnrollmentId INT,
    @NewStatus VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentStatus VARCHAR(20);

    SELECT @CurrentStatus = Status FROM Enrollment WHERE EnrollmentId = @EnrollmentId;

    IF @CurrentStatus IS NULL
    BEGIN
        RAISERROR('La matrícula no existe.', 16, 1);
        RETURN;
    END

    IF @CurrentStatus = 'Finalizada' AND @NewStatus = 'Cancelada'
    BEGIN
        RAISERROR('No se puede cancelar una matrícula finalizada.', 16, 1);
        RETURN;
    END

    UPDATE Enrollment
    SET Status = @NewStatus
    WHERE EnrollmentId = @EnrollmentId;
END



-- Solo elimina si el estado es Cancelada.

CREATE PROCEDURE DeleteEnrollment
    @EnrollmentId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM Enrollment 
        WHERE EnrollmentId = @EnrollmentId AND Status = 'Cancelada'
    )
    BEGIN
        RAISERROR('Solo se pueden eliminar matrículas canceladas.', 16, 1);
        RETURN;
    END

    DELETE FROM Enrollment WHERE EnrollmentId = @EnrollmentId;
END


