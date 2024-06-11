using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Services;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginService _loginService;

        public Login()
        {
            InitializeComponent();

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            var customerContext = new FuminiHotelManagementContext();
            var customerRepo = new CustomerRepository(customerContext);
            _loginService = new LoginService(configuration, customerRepo);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = Mail.Text;
            string password = Password.Text;

            string role = _loginService.Authenticate(email, password);
            if (role == "Admin")
            {
                MessageBox.Show("Login successful, Admin!");
                Admin adminWindow = new();
                adminWindow.Show();
                this.Close();
            }
            else if (role == "Customer")
            {
                Customer cus = _loginService.GetCustomerByEmailAndPassword(email, password);
                CustomerWindow customer = new CustomerWindow(cus);
                customer.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password");
            }
        }
    }
}
