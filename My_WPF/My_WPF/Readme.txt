///Создание базы данных со следующими параметрами:

Сервер: (localdb)\MSSQLLocalDB
Название: Lesson7

///Создание таблицы департаментов

CREATE TABLE [dbo].[Department] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

///Добавление департаментов
INSERT into Department (Id,Name) Values (1,'Sales');
INSERT into Department (Id,Name) Values (2,'Develop');

///Создание таблицы Сотрудников

CREATE TABLE [dbo].[Employe] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX)  NULL,
    [Age]          INT             NULL,
    [Salary]       NUMERIC (18, 2) NULL,
    [DepartmentID] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

///Добавление сотрудников
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (1,'Ivan Ivanov',21,20000,1);
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (2,'Petr Petrov',30,70000,1);
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (3,'Pavel Pavlov',25,50000,2);
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (4,'Den Denicov',23,30000,2);
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (5,'Ilidan Stormov',22,20000,2);
Insert into Employe (Id,Name,Age,Salary,DepartmentID) Values (6,'Bobr Bobrov',33,90000,2);