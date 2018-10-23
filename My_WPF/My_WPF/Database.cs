﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{

    public static class Database
    {
        public static ObservableCollection<Employee> itemsEmp;

        public static ObservableCollection<Department> itemsDep;

        public static ObservableCollection<EmpDep> itemsEmpDep;

        public static SqlConnection connection;
        public static SqlDataAdapter DepAdapter, EmpAdapter;
        public static DataTable Depdt, Empdt;



        static Database()
        {
            itemsEmp = new ObservableCollection<Employee>();
            itemsDep = new ObservableCollection<Department>();
            itemsEmpDep = new ObservableCollection<EmpDep>();

            itemsEmp.Add(new Employee() { Id = 1, Name = "Василий Васин", Age = 22, DepartmentID = 1, Salary = 30000 });
            itemsEmp.Add(new Employee() { Id = 2, Name = "Иван Иванов", Age = 25, DepartmentID = 1, Salary = 60000 });
            itemsEmp.Add(new Employee() { Id = 3, Name = "Сергей Сергеев", Age = 23, DepartmentID = 2, Salary = 80000 });

            itemsDep.Add(new Department() { Id = 1, Name = "Продажи" });
            itemsDep.Add(new Department() { Id = 2, Name = "Разработка" });

            /// Переход на использование БД
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Lesson7"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            DepAdapter = new SqlDataAdapter();
            EmpAdapter = new SqlDataAdapter();

            //Select command
            SqlCommand command =
                new SqlCommand("SELECT Id, Name FROM Department",
                connection);
            DepAdapter.SelectCommand = command;

            Depdt = new DataTable();
            DepAdapter.Fill(Depdt);

            command =
                new SqlCommand("SELECT Id, Name, Age, Salary, DepartmentID FROM Employe",
                connection);
            EmpAdapter.SelectCommand = command;

            Empdt = new DataTable();
            EmpAdapter.Fill(Empdt);

            //Insert command

            command = new SqlCommand(@"INSERT INTO Department (Name) 
                          VALUES (@FIO); SET @Id = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");

            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");

            param.Direction = ParameterDirection.Output;

            DepAdapter.InsertCommand = command;
        }

    }
}
