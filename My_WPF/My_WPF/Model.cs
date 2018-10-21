using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{
    class Model
    {

        public void RemoveDep(Department Dep)
        {
            Database.itemsDep.Remove(Dep);
        }

        public void RemoveEmp(Employee Emp)
        {
            Database.itemsEmp.Remove(Emp);
        }

        public void AddEmp(int ID, String Name, int Age, int DepartmentID, int Salary)
        {
            Database.itemsEmp.Add(new Employee() { Id = ID, Name = Name, Age = Age, DepartmentID = DepartmentID, Salary = Salary });
        }

        public void AddDep(int ID, String Name)
        {
            Database.itemsDep.Add(new Department() { Id = ID, Name = Name});
        }

        public  void FillEmpDep()
        {
            Database.itemsEmpDep?.Clear();

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
