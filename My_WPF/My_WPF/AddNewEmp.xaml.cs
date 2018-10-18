using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace My_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddNewEmp.xaml
    /// </summary>
    public partial class AddNewEmp : Window
    {
        public AddNewEmp()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow; 
            mainWindow.itemsEmp.Add(new Employee() { Id = Convert.ToInt32(tbID.Text), Name = tbName.Text, Age = Convert.ToInt32(tbAge.Text), DepartmentID = Convert.ToInt32(tbIdDep.Text), Salary = Convert.ToInt32(tbName_Salary.Text) });
            mainWindow.FillEmpDep();
        }
    }
}
