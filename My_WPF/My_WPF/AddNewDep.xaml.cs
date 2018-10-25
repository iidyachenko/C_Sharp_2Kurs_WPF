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
using System.Windows.Shapes;

namespace My_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddNewDep.xaml
    /// </summary>
    public partial class AddNewDep : Window
    {
        Model M;

        public AddNewDep(DataRow dataRow)
        {
            InitializeComponent();
            M = new Model();
            tbName_Dep.Text = dataRow[1].ToString();
            btnAddDep.Click += delegate { M.AddNewDepDB(tbName_Dep.Text, dataRow); this.DialogResult = true; };
            btnEditDep.Click += delegate { M.EditDepDB(tbName_Dep.Text, dataRow); };
        }
    }
}
