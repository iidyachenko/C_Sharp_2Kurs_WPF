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
        Model M;

        public AddNewEmp(DataRow dataRow)
        {
            InitializeComponent();
            tbName.Text = dataRow[1].ToString();
            tbAge.Text = dataRow[2].ToString();
            tbName_Salary.Text = dataRow[3].ToString();
            tbIdDep.Text = dataRow[4].ToString();
            M = new Model();
            btnAddEmp.Click += delegate { M.AddNewEmpDB(tbName.Text, tbAge.Text, tbName_Salary.Text, tbIdDep.Text, dataRow); this.DialogResult = true; };
            btnEditEmp.Click += delegate { M.EditEmpDB(tbName.Text, tbAge.Text, tbName_Salary.Text, tbIdDep.Text, dataRow); };
        }

    }
}
