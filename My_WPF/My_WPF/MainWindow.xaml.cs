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
        ObservableCollection<Employee> itemsEmp = new ObservableCollection<Employee>();
        ObservableCollection<Department> itemsDep = new ObservableCollection<Department>();

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

        public MainWindow()
        {
            InitializeComponent();
            FillListEmp();
            FillListDep();
        }

  

        private void lvEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            itemsEmp.Add(new Employee() { Id = Convert.ToInt32(tbID.Text), Name = tbName.Text, Age = Convert.ToInt32(tbAge.Text), DepartmentID = Convert.ToInt32(tbIdDep.Text), Salary = Convert.ToInt32(tbName_Salary.Text) });
        }


        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            itemsDep.Add(new Department() { Id = Convert.ToInt32(tbID_Dep.Text), Name = tbName_Dep.Text });
        }

        private void btnDelEmp_Click(object sender, RoutedEventArgs e)
        {
            itemsEmp.Remove((Employee)lvEmployee.SelectedItem);
        }

        private void btnDelDep_Click(object sender, RoutedEventArgs e)
        {
            itemsDep.Remove((Department)lvDepartment.SelectedItem);
        }
    }
}
