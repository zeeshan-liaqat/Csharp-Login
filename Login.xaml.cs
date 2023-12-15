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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender,RoutedEventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source= Qc/UserDB ;Initial Catalog=UserDB;Integrated Security= True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();

                string query = "SELECT COUNT User WHERE Username=@username AND Password=@password";
                SqlCommand sqlCmd = new SqlCommand(query,cnn);
                sqlCmd.CommandType =CommandType.Text;
                sqlCmd.Parameters.Add(new SqlParameter("@username",txtUsername.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@password", txtPassword.Password));
                int count =Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Incorrect username or password");
                }


            }
        }
    }
}
