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
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace RozvrhHodin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }
		// if u by somehow downloaded my project :D find ur datasource to the DB
		//@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Michal\C#\RozvrhHodin\RozvrhHodin\Rozvrh.mdf;Integrated Security=True"
		SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Michal\C#\Csharp-master\RozvrhHodin\RozvrhHodin\Rozvrh.mdf;Integrated Security=True");
        public string Table = "";
        private void Save_Click(object sender, RoutedEventArgs e)
        {
			OpenConnection();
			//conn.Open();            
            string query = query = "update " + Table + " set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + Den.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query,conn);
            SDA.SelectCommand.ExecuteNonQuery();
			CloseConnection();
			//conn.Close();
            showw();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
				OpenConnection();
				//conn.Open();
                string query = "update " + Table + " set " + ("_" + Hodina.Text) + " = '" + "" + "' where rozvrh = '" + Den.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
				CloseConnection();
				//conn.Close();
                showw();
        }

        private void Deleteall_Click(object sender, RoutedEventArgs e)
        {
			OpenConnection();      
			//conn.Close();
            SqlDataAdapter SDA = new SqlDataAdapter("delete from " + Table, conn);
            SDA.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA1 = new SqlDataAdapter("insert into " + Table + " (rozvrh) values ('Pondelí')", conn);
            SDA1.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA2 = new SqlDataAdapter("insert into " + Table + " (rozvrh) values ('Úterý')", conn);
            SDA2.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA3 = new SqlDataAdapter("insert into " + Table + " (rozvrh) values ('Streda')", conn);
            SDA3.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA4 = new SqlDataAdapter("insert into " + Table + " (rozvrh) values ('Ctvrtek')", conn);
            SDA4.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA5 = new SqlDataAdapter("insert into " + Table + " (rozvrh) values ('Pátek')", conn);
            SDA5.SelectCommand.ExecuteNonQuery();
			CloseConnection();
			//conn.Close();
            showw();
        }

		private void Help_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("1.'Vložit' zvolte den, hodinu a předmět.\n2.'Vymazat' ujistete se ze mate správný den a hodinu.\n3.'Vymazat vše' příjdete o celý rozvrh.\n4.'Zobrazit' po změně týdne kliknete na Zobrazit", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
		}

        void showw()
        {
			OpenConnection();
			//conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from " + Table;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            //DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //DG1.DataContext = dt.DefaultView;
            DG1.ItemsSource = dt.Tables[0].DefaultView;
			CloseConnection();
			//conn.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Chcete opravdu opustit program?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }            
        }
		public void OpenConnection()
		{
			if (conn.State != System.Data.ConnectionState.Open)
			{
				conn.Open();
			}
		}
		public void CloseConnection()
		{
			if (conn.State != System.Data.ConnectionState.Closed)
			{
				conn.Close();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			showw();
		}

        private void Tyden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox box = sender as ComboBox;
            if (!Tyden.IsLoaded)
            {
                Table = "rozvrhodinnS";
            }
            else
            {
                switch (Tyden.SelectedIndex)
                {
                    case 0:
                        Table = "rozvrhodinnS";
                        showw();
                        break;
                    case 1:
                        Table = "rozvrhodinnL";
                        showw();
                        break;
                }
            }
        }
    }
}
