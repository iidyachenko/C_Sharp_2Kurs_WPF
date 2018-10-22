using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{
    class Model
    {

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="Dep">Департамент к удалению</param>
        public void RemoveDep(Department Dep)
        {
            Database.itemsDep.Remove(Dep);
        }

        /// <summary>
        /// Удалению сотрудников
        /// </summary>
        /// <param name="Emp">Сотрудник к удалению</param>
        public void RemoveEmp(Employee Emp)
        {
            Database.itemsEmp.Remove(Emp);
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="ID">Идентификатор сотрудника</param>
        /// <param name="Name">Имя сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="DepartmentID">Код департамента</param>
        /// <param name="Salary">Зарплата</param>
        public void AddEmp(int ID, String Name, int Age, int DepartmentID, int Salary)
        {
            Database.itemsEmp.Add(new Employee() { Id = ID, Name = Name, Age = Age, DepartmentID = DepartmentID, Salary = Salary });
        }

        /// <summary>
        /// Создание нового департмента
        /// </summary>
        /// <param name="ID">Код департамента</param>
        /// <param name="Name">Название департамента</param>
        public void AddDep(int ID, String Name)
        {
            Database.itemsDep.Add(new Department() { Id = ID, Name = Name});
        }

        /// <summary>
        /// Заполнение таблицы связи сотрудника и департамента
        /// </summary>
        public  void FillEmpDep()
        {
            var result = from Emp in Database.itemsEmp
                         join Dep in Database.itemsDep on Emp.DepartmentID equals Dep.Id
                         select new { Emp = Emp.Name, Dep = Dep.Name };

            foreach (var r in result)
            {
                
                Database.itemsEmpDep.Add(new EmpDep() { Emp = r.Emp, Dep = r.Dep });
            }
        }
    }
}
