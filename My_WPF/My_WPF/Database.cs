using System;
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
        public static SqlConnection connection;
        public static SqlDataAdapter DepAdapter, EmpAdapter, EmpDepAdapter;
        public static DataTable Depdt, Empdt, EmpDepdt;

        static Database()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Lesson7"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            DepAdapter = new SqlDataAdapter();
            EmpAdapter = new SqlDataAdapter();
            EmpDepAdapter = new SqlDataAdapter();

//Select command

            // Департаменты
            SqlCommand command =
                new SqlCommand("SELECT Id, Name FROM Department",
                connection);
            DepAdapter.SelectCommand = command;

            Depdt = new DataTable();
            DepAdapter.Fill(Depdt);

            //Сотрудники
            command =
                new SqlCommand("SELECT Id, Name, Age, Salary, DepartmentID FROM Employe",
                connection);
            EmpAdapter.SelectCommand = command;

            Empdt = new DataTable();
            EmpAdapter.Fill(Empdt);

            //Отчет сотрудник-департамент
            command =
                new SqlCommand(@"SELECT e.Name as Emp, d.name as Dep FROM Employe e
                                   left join Department d
                                   on e.DepartmentID = d.Id",
                connection);
            EmpDepAdapter.SelectCommand = command;

            EmpDepdt = new DataTable();
            EmpDepAdapter.Fill(EmpDepdt);

 //Insert command

            //Департаменты
            command = new SqlCommand(@"INSERT INTO Department (Name) 
                          VALUES (@Name); SET @Id = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            DepAdapter.InsertCommand = command;

            //Сотрудники
            command = new SqlCommand(@"INSERT INTO Employe (Name,Age,Salary,DepartmentID) 
                          VALUES (@Name, @Age, @Salary,@DepartmentID); SET @Id = @@IDENTITY;",
              connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.Real, -1, "Salary");
            command.Parameters.Add("@DepartmentID", SqlDbType.Int, -1, "DepartmentID");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            EmpAdapter.InsertCommand = command;

 // Delete command
            
            // Департаменты
            command = new SqlCommand("DELETE FROM Department WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            DepAdapter.DeleteCommand = command;

            //Сотрудники
            command = new SqlCommand("DELETE FROM Employe WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            EmpAdapter.DeleteCommand = command;

 //Update command

            //Департаменты
            command = new SqlCommand(@"UPDATE Department SET  Name = @Name 
                                                WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            DepAdapter.UpdateCommand = command;

            //Сотрудники
            command = new SqlCommand(@"UPDATE Employe SET Name = @Name, Age = @Age, Salary = @Salary, DepartmentID =@DepartmentID 
                                                WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.Real, -1, "Salary");
            command.Parameters.Add("@DepartmentID", SqlDbType.Int, -1, "DepartmentID");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            EmpAdapter.UpdateCommand = command;
        }

    }
}
