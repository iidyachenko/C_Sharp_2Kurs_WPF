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
        /// Конструктор презентера
        /// </summary>
        public Presenter()
        {
          M = new Model();
          FillED();
        }

        /// <summary>
        /// Заполнение таблицы связи сотрудника и департамента
        /// </summary>
        public void FillED()
        {
            Database.itemsEmpDep?.Clear();
            M.FillEmpDep();
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="Dep">Департамент к удалению</param>
        public void RemoveDep(Department Dep)
        {
            M.RemoveDep(Dep);
            FillED();
        }

        /// <summary>
        /// Удалению сотрудников
        /// </summary>
        /// <param name="Emp">Сотрудник к удалению</param>
        public void RemoveEmp(Employee Emp)
        {
            M.RemoveEmp(Emp);
            FillED();
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="ID">Идентификатор сотрудника</param>
        /// <param name="Name">Имя сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="DepartmentID">Код департамента</param>
        /// <param name="Salary">Зарплата</param>
        public void AddNewEmp(String ID, String Name, String Age, String DepartmentID, String Salary)
        {
            try
            {
                M.AddEmp(Convert.ToInt32(ID), Name, Convert.ToInt32(Age), Convert.ToInt32(DepartmentID), Convert.ToInt32(Salary));
            }
            catch(Exception FormatExseption)
            {
                System.Windows.MessageBox.Show("Неверный формат ввода");
            }
            FillED();
        }

        /// <summary>
        /// Создание нового департмента
        /// </summary>
        /// <param name="ID">Код департамента</param>
        /// <param name="Name">Название департамента</param>
        public void AddNewDep(String ID, String Name)
        {
            try
            {
                M.AddDep(Convert.ToInt32(ID), Name);
            }
            catch (Exception FormatExseption)
            {
                System.Windows.MessageBox.Show("Неверный формат ввода");
            }
                FillED();
        }

        /// <summary>
        /// Добавить строки в БД департаментов
        /// </summary>
        /// <param name="ID">Номер Департамента</param>
        /// <param name="Name">Имя департамента</param>
        /// <param name="dataRow">Пустая строка таблицы департаментов</param>
        public void AddNewDepDB(String ID, String Name, DataRow dataRow)
        {
            resultRow = dataRow;
            resultRow[0] = ID;
            resultRow[1] = Name;
            Database.Depdt.Rows.Add(resultRow);
            Database.DepAdapter.Update(Database.Depdt);
        }

        /// <summary>
        /// Добавить строки в БД департаментов
        /// </summary>
        /// <param name="ID">Номер Департамента</param>
        /// <param name="Name">Имя департамента</param>
        /// <param name="dataRow">Пустая строка таблицы департаментов</param>
        public void AddNewEmpDB(String ID, String Name, String Age, String Salary, String DepartmentID, DataRow dataRow)
        {
            resultRow = dataRow;
            resultRow[0] = ID;
            resultRow[1] = Name;
            resultRow[2] = Age;
            resultRow[3] = Salary;
            resultRow[4] = DepartmentID;
            Database.Empdt.Rows.Add(resultRow);
            Database.DepAdapter.Update(Database.Depdt);
        }

    }
}
