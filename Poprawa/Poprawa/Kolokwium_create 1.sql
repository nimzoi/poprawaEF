-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-06-22 12:51:25.819

-- tables
-- Table: Access
CREATE TABLE Access (
    IdUser int  NOT NULL,
    IdProject int  NOT NULL,
    CONSTRAINT Access_pk PRIMARY KEY  (IdUser,IdProject)
);

-- Table: Project
CREATE TABLE Project (
    IdProject int  NOT NULL IDENTITY(1,1),
    Name varchar(200)  NOT NULL,
    IdDefaultAssignee int  NOT NULL,
    CONSTRAINT Project_pk PRIMARY KEY  (IdProject)
);

-- Table: Task
CREATE TABLE Task (
    IdTask int  NOT NULL IDENTITY(1,1),
    Name varchar(200)  NOT NULL,
    Description varchar(1000)  NOT NULL,
    CreatedAt datetime  NOT NULL,
    IdProject int  NOT NULL,
    IdReporter int  NOT NULL,
    IdAssignee int  NOT NULL,
    CONSTRAINT Task_pk PRIMARY KEY  (IdTask)
);

-- Table: User
CREATE TABLE "User" (
    IdUser int  NOT NULL IDENTITY(1,1),
    FirstName varchar(200)  NOT NULL,
    LastName varchar(200)  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (IdUser)
);

-- foreign keys
-- Reference: ProjectAccess_Project (table: Access)
ALTER TABLE Access ADD CONSTRAINT ProjectAccess_Project
    FOREIGN KEY (IdProject)
    REFERENCES Project (IdProject);

-- Reference: ProjectAccess_User (table: Access)
ALTER TABLE Access ADD CONSTRAINT ProjectAccess_User
    FOREIGN KEY (IdUser)
    REFERENCES "User" (IdUser);

-- Reference: Project_User (table: Project)
ALTER TABLE Project ADD CONSTRAINT Project_User
    FOREIGN KEY (IdDefaultAssignee)
    REFERENCES "User" (IdUser);

-- Reference: Task_Project (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_Project
    FOREIGN KEY (IdProject)
    REFERENCES Project (IdProject);

-- Reference: Task_User_Assignee (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_User_Assignee
    FOREIGN KEY (IdAssignee)
    REFERENCES "User" (IdUser);

-- Reference: Task_User_Reporter (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_User_Reporter
    FOREIGN KEY (IdReporter)
    REFERENCES "User" (IdUser);

-- End of file.

