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
using EventsProjectBusiness;
using EventsProjectGUI;

namespace Events_Project_GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private CRUDManager _crudManager = new CRUDManager();
		private bool _isEditClicked = false;
		public MainWindow()
		{
			InitializeComponent();
			PopulateVenueDropBox();
			PopulateEventDropBox();			
		}
		// populating the drop boxes with venues and events
		private void PopulateVenueDropBox()
		{
			VenueDropBox.ItemsSource = _crudManager.RetrieveVenues();
		}
		private void PopulateEventDropBox()
		{
			EventDropBox.ItemsSource = _crudManager.RetrieveEvents();
		}
		// next 2 methods populate events based on the event type
		private void PopulateEventListBoxWithSport()
		{
			EventListBox.ItemsSource = _crudManager.RetrieveSports();
		}
		private void PopulateEventListBoxWithMusic()
		{
			EventListBox.ItemsSource = _crudManager.RetrieveMusic();
		}

		// populating the venue text boxes with venue information
		private void PopulateVenueFields()
		{
			if (_crudManager.SelectedVenue != null)
			{
				VenueIDText.Text = _crudManager.SelectedVenue.VenueId;
				VenueNameText.Text = _crudManager.SelectedVenue.VenueName;
				VenueCityText.Text = _crudManager.SelectedVenue.City;
				VenueCountryText.Text = _crudManager.SelectedVenue.Country;
				VenueCapacityText.Text = _crudManager.SelectedVenue.Capacity.ToString();
			}
		}
		// emptying all the info in the venue fields
		private void ClearVenueFields()
		{

			VenueIDText.Text = "";
			VenueNameText.Text = "";
			VenueCityText.Text = "";
			VenueCountryText.Text = "";
			VenueCapacityText.Text = "";

		}
		//// methodology below is to interact with GUI buttons and boxes...
		// room for refactoring here
		private void AddVenueButton_Click(object sender, RoutedEventArgs e)
		{
			NewVenueWindow win1 = new NewVenueWindow();
			win1.Show();
		}

		// button to call remove venue method, update the drop box and empty the venue text boxes
		private void RemoveVenueButton_Click(object sender, RoutedEventArgs e)
		{
			if (VenueDropBox.SelectedItem != null)
			{
				var venueToRemove = _crudManager.SelectedVenue.VenueId;
				_crudManager.RemoveVenue(venueToRemove);
			}
			PopulateVenueDropBox();
			ClearVenueFields();

		}
		// button that refreshes venue box or if edit function is called allows edit to be completed
		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			if (_isEditClicked == false)
			{
				PopulateVenueDropBox();
			}
			if (_isEditClicked == true)
			{
				_crudManager.EditVenue(_crudManager.SelectedVenue.VenueId, VenueNameText.Text, VenueCityText.Text, VenueCountryText.Text, Int32.Parse(VenueCapacityText.Text));
				RefreshButton.Content = "Refresh";
				AddVenueButton.IsEnabled = true;
				RemoveVenueButton.IsEnabled = true;
				VenueNameText.IsReadOnly = true;
				VenueCityText.IsReadOnly = true;
				VenueCountryText.IsReadOnly = true;
				VenueCapacityText.IsReadOnly = true;
				_isEditClicked = false;
				PopulateVenueDropBox();
				EditButton.IsEnabled = true;
			}

		}
		// edit button disables most of GUI, and changes refresh button to a confirm edit button
		private void EditButton_Click(object sender, RoutedEventArgs e)
		{

			if (_isEditClicked == false)
			{
				RefreshButton.Content = "Confirm Edit";
				AddVenueButton.IsEnabled = false;
				RemoveVenueButton.IsEnabled = false;
				VenueNameText.IsReadOnly = false;
				VenueCityText.IsReadOnly = false;
				VenueCountryText.IsReadOnly = false;
				VenueCapacityText.IsReadOnly = false;
				_isEditClicked = true;
				EditButton.IsEnabled = false;

			}
		}
		//  method to show eith sport or music events dependent on what was selected
		private void EventDropBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (EventDropBox.SelectedItem != null)
			{
				if (EventDropBox.SelectedItem.ToString() == "Sport")
				{
					PopulateEventListBoxWithSport();
				}
				if (EventDropBox.SelectedItem.ToString() == "Music")
				{
					PopulateEventListBoxWithMusic();
				}
			}
		}

		private void EventsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}
		// method to populate venue text boxes with info from selcted venue
		private void VenueDropBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (VenueDropBox.SelectedItem != null)
			{
				_crudManager.SetSelectedVenue(VenueDropBox.SelectedItem);
				PopulateVenueFields();
			}
		}
	}
}
