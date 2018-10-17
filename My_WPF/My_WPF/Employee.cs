using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_WPF
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int DepartmentID { get; set; }
        public override string ToString()
        {
            return $" ID: {Id}\n Работник: {Name}\n Возраст: {Age}\n Зарплата: {Salary}";
        }


    }
}
