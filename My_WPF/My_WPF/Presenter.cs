using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{
    class Presenter
    {
        Model M;
        public DataRow resultRow { get; set; }
        
        /// <summary>
        /// Добавить строки в БД департаментов
        /// </summary>
        /// <param name="ID">Номер Департамента</param>
        /// <param name="Name">Имя департамента</param>
        /// <param name="dataRow">Пустая строка таблицы департаментов</param>
        public void AddNewDepDB(String Name, DataRow dataRow)
        {
            resultRow = dataRow;
            resultRow[1] = Name;
            Database.Depdt.Rows.Add(resultRow);
            Database.DepAdapter.Update(Database.Depdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }

        /// <summary>
        /// Изменить строки в БД департаментов
        /// </summary>
        /// <param name="ID">Номер Департамента</param>
        /// <param name="Name">Имя департамента</param>
        /// <param name="dataRow">Выбранная строка таблицы департаментов</param>
        public void EditDepDB(String Name, DataRow dataRow)
        {
            dataRow.BeginEdit();
            dataRow[1] = Name;
            dataRow.EndEdit();
            Database.DepAdapter.Update(Database.Depdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }

        /// <summary>
        /// Изменить строки в БД сотрудников
        /// </summary>
        /// <param name="ID">Код сотрудника</param>
        /// <param name="Name">Имя сотрудника</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="DepartmentID">Код департамента</param>
        /// <param name="dataRow">Строка для изменения</param>
        public void EditEmpDB(String Name, String Age, String Salary, String DepartmentID, DataRow dataRow)
        {
            dataRow.BeginEdit();

            dataRow[1] = Name;
            dataRow[2] = Age;
            dataRow[3] = Salary;
            dataRow[4] = DepartmentID;
            dataRow.EndEdit();
            Database.EmpAdapter.Update(Database.Empdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }

        /// <summary>
        /// Добавить строки в БД сотрудников
        /// </summary>
        /// <param name="ID">Код сотрудника</param>
        /// <param name="Name">Имя сотрудника</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="DepartmentID">Код департамента</param>
        /// <param name="dataRow">Строка для вставки</param>
        public void AddNewEmpDB(String Name, String Age, String Salary, String DepartmentID, DataRow dataRow)
        {
            resultRow = dataRow;

            resultRow[1] = Name;
            resultRow[2] = Age;
            resultRow[3] = Salary;
            resultRow[4] = DepartmentID;
            Database.Empdt.Rows.Add(resultRow);
            Database.EmpAdapter.Update(Database.Empdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }

        /// <summary>
        /// Удаление департаментов
        /// </summary>
        /// <param name="NewRow">Строка к удалению</param>
        public void RemoveDepDB(DataRowView NewRow)
        {
            NewRow.Row.Delete();
            Database.DepAdapter.Update(Database.Depdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }


        /// <summary>
        /// Удаление сотрудников
        /// </summary>
        /// <param name="NewRow">Строка к удалению</param>
        public void RemoveEmpDB(DataRowView NewRow)
        {
            NewRow.Row.Delete();
            Database.EmpAdapter.Update(Database.Empdt);
            Database.EmpDepdt.Clear();
            Database.EmpDepAdapter.Fill(Database.EmpDepdt);
        }
    }
}
