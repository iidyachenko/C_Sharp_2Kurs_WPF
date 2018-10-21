using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{
    class Presenter
    {
        Model M;

        public Presenter()
        {
          M = new Model();
          M.FillEmpDep();
        }

        public void RemoveDep(Department Dep)
        {
            M.RemoveDep(Dep);
            M.FillEmpDep();
        }

        public void RemoveEmp(Employee Emp)
        {
            M.RemoveEmp(Emp);
            M.FillEmpDep(); 
        }

        public void AddNewEmp(String ID, String Name, String Age, String DepartmentID, String Salary)
        {
            M.AddEmp(Convert.ToInt32(ID), Name, Convert.ToInt32(Age), Convert.ToInt32(DepartmentID), Convert.ToInt32(Salary)) ;
            M.FillEmpDep();
        }

        public void AddNewDep(String ID, String Name)
        {
            M.AddDep(Convert.ToInt32(ID), Name);
            M.FillEmpDep();
        }
    }
}
