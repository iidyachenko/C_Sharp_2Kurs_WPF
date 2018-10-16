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
        ObservableCollection<Employee> items = new ObservableCollection<Employee>();

       public void FillList()
        {
            items.Add(new Employee() { Id = 1, Name = "Vasya", Age = 22, Salary = 3000 });
            items.Add(new Employee() { Id = 2, Name = "Petya", Age = 25, Salary = 6000 });
            items.Add(new Employee() { Id = 3, Name = "Kolya", Age = 23, Salary = 8000 });
            lvEmployee.ItemsSource = items;
        }



        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }

  

        private void lvEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString(),"Данные о работнике");
            
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new Employee() { Id = Convert.ToInt32(tbID.Text), Name = tbName.Text, Age = Convert.ToInt32(tbAge.Text), Salary = Convert.ToInt32(tbName_Salary.Text) });
        }
    }
}
