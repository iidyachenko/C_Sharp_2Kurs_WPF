using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace My_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddNewEmp.xaml
    /// </summary>
    public partial class AddNewEmp : Window
    {
        Presenter P;

        public AddNewEmp(DataRow dataRow)
        {
            InitializeComponent();
            P = new Presenter();
            btnAddEmp.Click += delegate { P.AddNewEmpDB(tbID.Text, tbName.Text, tbAge.Text, tbIdDep.Text, tbName_Salary.Text, dataRow); };
        }

    }
}
