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
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Michal\C#\RozvrhHodin\RozvrhHodin\Rozvrh.mdf;Integrated Security=True");

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();            
            string day;
            string query = "";
            switch (Den.Text)
            {
                case "Pondělí":
                    day = "Pondelí";
                    query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + day + "'";
                    break;
                case "Úterý":
                    day = "Úterý";
                    query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + day + "'";
                    break;
                case "Středa":
                    day = "Streda";
                    query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + day + "'";
                    break;
                case "Čtvrtek":
                    day = "Ctvrtek";
                    query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + day + "'";
                    break;
                case "Pátek":
                    day = "Pátek";
                    query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + Predmet.Text + "' where rozvrh = '" + day + "'";
                    break;
                
            }            
            SqlDataAdapter SDA = new SqlDataAdapter(query,conn);
            SDA.SelectCommand.ExecuteNonQuery();
            conn.Close();
            showw();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ujiste se ze mate spravně den a hodinu!", "Opravdu chcete vymazat záznam?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                conn.Open();
                string nott = "";
                string day;
                string query = "";
                switch (Den.Text)
                {
                    case "Pondělí":
                        day = "Pondelí";
                        query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + nott + "' where rozvrh = '" + day + "'";
                        break;
                    case "Úterý":
                        day = "Úterý";
                        query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + nott + "' where rozvrh = '" + day + "'";
                        break;
                    case "Středa":
                        day = "Streda";
                        query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + nott + "' where rozvrh = '" + day + "'";
                        break;
                    case "Čtvrtek":
                        day = "Ctvrtek";
                        query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + nott + "' where rozvrh = '" + day + "'";
                        break;
                    case "Pátek":
                        day = "Pátek";
                        query = "update rozvrhodinn2 set " + ("_" + Hodina.Text) + " = '" + nott + "' where rozvrh = '" + day + "'";
                        break;
                }
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close();
                showw();
            }
            else
            {
                
            }
            
        }

        private void Deleteall_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();            
            SqlDataAdapter SDA = new SqlDataAdapter("delete from rozvrhodinn2", conn);
            SDA.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA1 = new SqlDataAdapter("insert into rozvrhodinn2 (rozvrh) values ('Pondelí')", conn);
            SDA1.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA2 = new SqlDataAdapter("insert into rozvrhodinn2 (rozvrh) values ('Úterý')", conn);
            SDA2.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA3 = new SqlDataAdapter("insert into rozvrhodinn2 (rozvrh) values ('Streda')", conn);
            SDA3.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA4 = new SqlDataAdapter("insert into rozvrhodinn2 (rozvrh) values ('Ctvrtek')", conn);
            SDA4.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter SDA5 = new SqlDataAdapter("insert into rozvrhodinn2 (rozvrh) values ('Pátek')", conn);
            SDA5.SelectCommand.ExecuteNonQuery();
            conn.Close();

            showw();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            showw();
        }
        void showw()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rozvrhodinn2";
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            //DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //DG1.DataContext = dt.DefaultView;
            DG1.ItemsSource = dt.Tables[0].DefaultView;
            conn.Close();
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
    }
}
