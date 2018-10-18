using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_WPF
{
    
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> itemsEmp = new ObservableCollection<Employee>();
        public ObservableCollection<Department> itemsDep = new ObservableCollection<Department>();

     

        /// <summary>
        /// Заполнение сотрудников базовыми значениями
        /// </summary>
        public void FillListEmp()
        {
            itemsEmp.Add(new Employee() { Id = 1, Name = "Vasya", Age = 22, DepartmentID = 1, Salary = 3000 });
            itemsEmp.Add(new Employee() { Id = 2, Name = "Petya", Age = 25, DepartmentID = 1, Salary = 6000 });
            itemsEmp.Add(new Employee() { Id = 3, Name = "Kolya", Age = 23, DepartmentID = 2, Salary = 8000 });
            lvEmployee.ItemsSource = itemsEmp;
        }

        /// <summary>
        /// Заполнение департаментов базовыми значениями
        /// </summary>
        public void FillListDep()
        {
            itemsDep.Add(new Department() { Id = 1, Name = "Sales"});
            itemsDep.Add(new Department() { Id = 2, Name = "Develop"});
            lvDepartment.ItemsSource = itemsDep;
        }

        public void FillEmpDep()
        {
            var result = from Emp in itemsEmp
                         join Dep in itemsDep on Emp.DepartmentID equals Dep.Id
                         select new { Emp = Emp.Name, Dep = Dep.Name };

            lvEmpDep.ItemsSource = result;
        }

        public MainWindow()
        {
            InitializeComponent();
            FillListEmp();
            FillListDep();
            //Связывание двух списков
            FillEmpDep();
           
        }


        private void lvEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void btnAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmp WinEmp = new AddNewEmp();
            WinEmp.Owner = this;
            WinEmp.Show();
        }



        private void btnDelEmp_Click(object sender, RoutedEventArgs e)
        {
            itemsEmp.Remove((Employee)lvEmployee.SelectedItem);
        }

        private void btnDelDep_Click(object sender, RoutedEventArgs e)
        {
            itemsDep.Remove((Department)lvDepartment.SelectedItem);
        }

        private void btnAddNewDep_Click(object sender, RoutedEventArgs e)
        {
            AddNewDep WinDep = new AddNewDep();
            WinDep.Owner = this;
            WinDep.Show();

        }

    }
}
