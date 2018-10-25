using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        Model M;

        public MainWindow()
        {
            InitializeComponent();
            M = new Model();
            lvEmployee.ItemsSource = Database.Empdt.DefaultView;
            lvDepartment.ItemsSource = Database.Depdt.DefaultView;
            lvEmpDep.ItemsSource = Database.EmpDepdt.DefaultView;

            btnDelDep.Click += delegate { M.RemoveDepDB((DataRowView)lvDepartment.SelectedItem); };
            btnDelEmp.Click += delegate { M.RemoveEmpDB((DataRowView)lvEmployee.SelectedItem); };
        }

        /// <summary>
        /// Переход на страницу с добавлением нового работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = Database.Empdt.NewRow();
            AddNewEmp WinEmp = new AddNewEmp(dataRow);
            WinEmp.Owner = this;
            WinEmp.btnAddEmp.Visibility = Visibility.Visible;
            WinEmp.ShowDialog();
        }

        /// <summary>
        /// Переход на страницу с редактированием сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)lvEmployee.SelectedItem;
            AddNewEmp WinEmp = new AddNewEmp(dataRow.Row);
            WinEmp.Owner = this;
            WinEmp.btnEditEmp.Visibility = Visibility.Visible;
            WinEmp.ShowDialog();
        }

        /// <summary>
        /// Переход на страницу с добавлением нового департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewDep_Click(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = Database.Depdt.NewRow();
            AddNewDep WinDep = new AddNewDep(dataRow);
            WinDep.Owner = this;
            WinDep.btnAddDep.Visibility = Visibility.Visible;
            WinDep.ShowDialog();

        }

        /// <summary>
        /// Переход на страницу с редактированием департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDep_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)lvDepartment.SelectedItem;
            AddNewDep WinDep = new AddNewDep(dataRow.Row);
            WinDep.Owner = this;
            WinDep.btnEditDep.Visibility = Visibility.Visible;
            WinDep.ShowDialog();
        }

    }
}
