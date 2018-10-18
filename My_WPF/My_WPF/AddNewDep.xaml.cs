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
using System.Windows.Shapes;

namespace My_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddNewDep.xaml
    /// </summary>
    public partial class AddNewDep : Window
    {
        public AddNewDep()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonClicked;

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            mainWindow.itemsDep.Add(new Department() { Id = Convert.ToInt32(tbID_Dep.Text), Name = tbName_Dep.Text });
        }
    }
}
