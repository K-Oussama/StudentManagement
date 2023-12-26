-- View to calculate the module score for each student
CREATE VIEW ModuleScores AS
SELECT s.student_id, m.module_id, AVG(e.score) AS module_score
FROM Students s
JOIN Courses c ON s.student_id = e.student_id
JOIN Modules m ON c.module_id = m.module_id
JOIN Evaluations e ON c.course_id = e.course_id
GROUP BY s.student_id, m.module_id;
GO -- Separate batch using GO

-- Create or alter the function for updating module pass status
IF OBJECT_ID('UpdateModulePassedStatus', 'FN') IS NOT NULL
    DROP FUNCTION UpdateModulePassedStatus;
GO

CREATE FUNCTION UpdateModulePassedStatus()
RETURNS @Result TABLE (dummyColumn INT) -- The function returns a table variable
AS
BEGIN
    DECLARE @ModuleID INT;

    -- Get the Module ID from the INSERTED table (assuming it's an AFTER INSERT trigger)
    SELECT @ModuleID = module_id FROM INSERTED;

    IF (
        SELECT AVG(score) FROM Evaluations
        WHERE course_id IN (
            SELECT course_id FROM Courses WHERE module_id = @ModuleID
        )
    ) >= 10
    BEGIN
        -- Update Modules table if condition is met
        UPDATE Modules
        SET passed = 1 -- Use 1 for TRUE, 0 for FALSE if using BIT data type
        WHERE module_id = @ModuleID;
    END;

    -- Dummy SELECT to return from function (table variable)
    INSERT INTO @Result VALUES (1); -- You can insert any value into the dummy column
    RETURN;
END;
GO

-- Create the trigger to update the passed status of modules based on scores
IF OBJECT_ID('ModuleEvaluationTrigger', 'TR') IS NOT NULL
    DROP TRIGGER ModuleEvaluationTrigger;
GO

CREATE TRIGGER ModuleEvaluationTrigger
ON Evaluations
AFTER INSERT, UPDATE
AS
BEGIN
    -- Execute the function within the trigger
    DECLARE @DummyVariable INT;
    EXEC @DummyVariable = UpdateModulePassedStatus;
END;
GO