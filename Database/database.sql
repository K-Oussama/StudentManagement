-- Table to store students' personal information
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_firstName NVARCHAR(50) NULL,
    student_lastName NVARCHAR(50) NULL,
    student_email NVARCHAR(50) NULL,
    year_level INT CHECK (year_level BETWEEN 1 AND 5),
    -- Add other personal information fields as needed
);

-- Table to store modules
CREATE TABLE Modules (
    module_id INT PRIMARY KEY,
    module_name VARCHAR(50),
    module_level INT CHECK (module_level BETWEEN 1 AND 5),
    passed Bit DEFAULT 0,
    -- Add other module-related fields as needed
);

-- Table to store courses associated with modules
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    module_id INT,
    course_name VARCHAR(50),
    course_hours INT,
    taught_by VARCHAR(50),
    FOREIGN KEY (module_id) REFERENCES Modules(module_id)
    -- Add other course-related fields as needed
);

-- Table to store evaluations for each course
CREATE TABLE Evaluations (
    evaluation_id INT PRIMARY KEY,
    course_id INT,
    student_id INT,
    evaluation_type VARCHAR(20), -- e.g., assignment, TP, exam
    score DECIMAL(4,2) CHECK (score BETWEEN 0 AND 20),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
    -- Add other evaluation-related fields as needed
);
GO -- Separate batch using GO


