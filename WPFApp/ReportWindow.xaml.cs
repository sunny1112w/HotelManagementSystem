using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private BookingDetailService _bookingDetailService;
      

        public ReportWindow()
        {
            InitializeComponent();
            var bookingDetailContext = new FuminiHotelManagementContext();
            var bookingDetailRepo = new BookingDetailRepository(bookingDetailContext);
            _bookingDetailService = new BookingDetailService(bookingDetailRepo);

            DataGrid.ItemsSource = _bookingDetailService.GetAlls();

            
        }

        private void RoomWindow_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow room = new();
            room.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            room.Show();
            
            this.Close();
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            
            this.Close();
        }

        private void ReportWindow_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
