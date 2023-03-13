using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace aviakompania
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu(string email)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            

        }

        private void exit_btn_click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Hide();
        }

        private void add_user_btn_click(object sender, RoutedEventArgs e)
        {

        }

        static IEnumerable<User> ExecuteSql(string sql)
        {

            SqlConnection CONNECTION_DB_STRING = new SqlConnection(
                "Data Source = DUMILIN-LAPTOP; Initial Catalog = session1_xx; Integrated Security = True;"
                );

            using (CONNECTION_DB_STRING)
            {
                CONNECTION_DB_STRING.Open();

                SqlCommand cmd = new SqlCommand(sql, CONNECTION_DB_STRING);
                SqlDataReader read = cmd.ExecuteReader();

                string role = null;
                string office = null;
                using (read)
                {
                    while (true)
                    {
                        if (read.Read() == false) break;
                        if (read["ID_Role"].ToString() == "1") role = "administrator";
                        else if (read["ID_Role"].ToString() == "2") role = "office user";

                        if (read["ID_Role"].ToString() == "1") role = "administrator";
                        else if (read["ID_Role"].ToString() == "2") role = "office user";
                        else if (read["ID_Role"].ToString() == "2") role = "office user";
                        else if (read["ID_Role"].ToString() == "2") role = "office user";

                        User user = new User()
                        {
                            RoleID = role,
                            Email = (string)read["Email"],
                            Password = (string)read["Password"],
                            FirstName = (string)read["FirstName"],
                            LastName = (string)read["LastName"],
                            OfficeID = office,
                            Birthdate = (string)read["Password"],
                            Active = (string)read["Password"],
                        };

                        yield return user;
                    }
                }
            }
        }
    }

    public class User
    {
        public string RoleID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficeID { get; set; }
        public string Birthdate { get; set; }
        public string Active { get; set; }
    }
}
