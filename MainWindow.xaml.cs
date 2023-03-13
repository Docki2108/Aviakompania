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
using System.Security.Cryptography;
using System.Data.SqlClient;



namespace aviakompania
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int loginCounter = 0;

        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void login_btn_click(object sender, RoutedEventArgs e)
        {
            if(email.Text.Trim() != "" && password.Password.Trim() != "")
            {
                const string CONNECTION_DB_STRING = "Data Source = DUMILIN-LAPTOP; Initial Catalog = session1_xx; Integrated Security = True;";
                SqlConnection connection = new SqlConnection(CONNECTION_DB_STRING);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Users] WHERE [Email] = '" + email.Text + "' AND [Password] = '" + password.Password + "'", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Аккаунта не существует", "Ошибка");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (reader["RoleID"].ToString() == "1")
                            {
                                AdminMenu adminMenu = new AdminMenu(email.Text);
                                adminMenu.Show();
                                this.Hide();
                            }
                            if (reader["RoleID"].ToString() == "2")
                            {
                                UserMenu userMenu = new UserMenu(email.Text);
                                userMenu.Show();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все пустые поля!", "Ошибка");
                loginCounter++;
                if (loginCounter == 3)
                {
                    MessageBox.Show("Число попыток превышено! Подождите 10 секунд", "Предупреждение");
                    loginCounter = 0;
                }
            }
        }

        private void loginExaption()
        {

        }

        private void exit_btn_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
