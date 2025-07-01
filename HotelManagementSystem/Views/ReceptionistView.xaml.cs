using HotelManagementSystem.Services;
using System.Linq;
using System.Windows.Controls;

namespace HotelManagementSystem.Views
{
    public partial class ReceptionistView : UserControl
    {
        public ReceptionistView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var context = Helper.GetContext();

            var reservations = context.Reservations
                .Include("Guests")
                .Include("Rooms")
                .Include("Statuses")
                .ToList();

            ReservationsDataGrid.ItemsSource = reservations;

            var guests = context.Guests.ToList();
            GuestsComboBox.ItemsSource = guests;

            var rooms = context.Rooms
                .Where(r => r.Availability == true)
                .ToList();
            RoomsComboBox.ItemsSource = rooms;
        }
    }
}