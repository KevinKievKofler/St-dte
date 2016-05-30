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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;

namespace Städte
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_EUStaaten.mdb";
        string cmd = "SELECT * FROM tbl_EUStaaten";
        DataSet ds = new DataSet();
        DataSet dx = new DataSet();
        string landkurz;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(cmd, conn);
                da.Fill(ds, "tbl_Land");
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
                this.Close();
            }
            DataTable tbl1 = ds.Tables["tbl_Land"];
            cmb.ItemsSource = tbl1.DefaultView;
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            landkurz = (string)cmb.SelectedValue;
            cmd = string.Format("SELECT * FROM tbl_Staedte WHERE Land = \"{0}\"", landkurz);
            try
            {
                OleDbDataAdapter datacon = new OleDbDataAdapter(cmd, conn);
                datacon.Fill(dx, "tbl_stadt");
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
                this.Close();
            }
            DataTable tbl1 = dx.Tables["tbl_stadt"];
            daten.ItemsSource = tbl1.DefaultView;
        }
    }
}
