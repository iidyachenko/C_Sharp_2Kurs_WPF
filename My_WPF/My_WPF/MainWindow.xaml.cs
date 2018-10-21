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

        Presenter P;

        public MainWindow()
        {
            InitializeComponent();
            //Новая версия с MVP
            P = new Presenter();
            lvEmployee.ItemsSource = Database.itemsEmp;
            lvDepartment.ItemsSource = Database.itemsDep;
            lvEmpDep.ItemsSource = Database.itemsEmpDep;

            btnDelDep.Click += delegate { P.RemoveDep((Department)lvDepartment.SelectedItem); };
            btnDelEmp.Click += delegate { P.RemoveEmp((Employee)lvEmployee.SelectedItem); };
        }

        private void btnAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmp WinEmp = new AddNewEmp();
            WinEmp.Owner = this;
            WinEmp.Show();
        }

        private void btnAddNewDep_Click(object sender, RoutedEventArgs e)
        {
            AddNewDep WinDep = new AddNewDep();
            WinDep.Owner = this;
            WinDep.Show();

        }
    }
}
