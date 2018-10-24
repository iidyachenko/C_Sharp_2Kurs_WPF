using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
    }
}
