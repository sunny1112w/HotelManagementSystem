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
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly BookingReservationService _bookingReservationService;
        public Customer currentCustomer;

        public HistoryWindow(BusinessObjects.Models.Customer currentCus)
        {
            InitializeComponent();

            var bookingReservationContext = new FuminiHotelManagementContext();
            var bookingReservationRepo = new BookingReservationRepository(bookingReservationContext);
            _bookingReservationService = new BookingReservationService(bookingReservationRepo);
            BookingListView.ItemsSource = _bookingReservationService.GetBookingReservationByCustomerID(currentCus.CustomerId);
            currentCustomer = currentCus;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new();
            login.Show();
            this.Close();
        }
    }

}
