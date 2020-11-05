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
			PopulateVenueBox();
			PopulateEventDropBox();
			//PopulateEventListBoxWithSport();
			
		}
		private void PopulateVenueBox()
		{
			VenueListBox.ItemsSource = _crudManager.RetrieveVenues();
		}
		
		private void PopulateEventDropBox()
		{
			EventDropBox.ItemsSource = _crudManager.RetrieveEvents();
		}
		private void PopulateEventListBoxWithSport()
		{
			EventListBox.ItemsSource = _crudManager.RetrieveSports();
		}
		private void PopulateEventListBoxWithMusic()
		{
			EventListBox.ItemsSource = _crudManager.RetrieveMusic();
		}
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
		private void ClearVenueFields()
		{

			VenueIDText.Text = "";
			VenueNameText.Text = "";
			VenueCityText.Text = "";
			VenueCountryText.Text = "";
			VenueCapacityText.Text = "";

		}

		private void VenueSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (VenueListBox.SelectedItem != null)
			{
				_crudManager.SetSelectedVenue(VenueListBox.SelectedItem);
				PopulateVenueFields();
			}
		}

		private void AddVenueButton_Click(object sender, RoutedEventArgs e)
		{
			NewVenueWindow win1 = new NewVenueWindow();
			win1.Show();
		}


		private void RemoveVenueButton_Click(object sender, RoutedEventArgs e)
		{
			if (VenueListBox.SelectedItem != null)
			{
				var venueToRemove = _crudManager.SelectedVenue.VenueId;
				_crudManager.RemoveVenue(venueToRemove);
			}
			PopulateVenueBox();
			ClearVenueFields();

		}

		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			if (_isEditClicked == false)
			{
				PopulateVenueBox();
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
				PopulateVenueBox();
				VenueListBox.IsEnabled = true;
				EditButton.IsEnabled = true;
			}

		}

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
				VenueListBox.IsEnabled = false;
				EditButton.IsEnabled = false;

			}
		}

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
	}
}
