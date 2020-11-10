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
using EventsProject;
using EventsProjectBusiness;
using EventsProjectGUI;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventsProjectGUI
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
			EventDropBox.ItemsSource = _crudManager.RetrieveEventTypes();
		}
		// next 2 methods populate events based on the event type
		private void PopulateEventListBoxWithSport()
		{
			EventsListBox.ItemsSource = _crudManager.RetrieveSports();
		}
		private void PopulateEventListBoxWithMusic()
		{
			EventsListBox.ItemsSource = _crudManager.RetrieveMusic();
		}
		private void PopulateChosenEventListBox()
		{

			if (EventDropBox.SelectedItem.ToString() == "Sport")
			{
				ChosenEventListBox.ItemsSource = _crudManager.RetrieveSportEvents();
			}
			if (EventDropBox.SelectedItem.ToString() == "Music")
			{
				ChosenEventListBox.ItemsSource = _crudManager.RetrieveMusicEvents();
			}
		}


		// populating the venue text boxes with venue information
		private void PopulateVenueFields()
		{
			if (_crudManager.SelectedVenue != null)
			{
				EditButton.IsEnabled = true;
				RemoveVenueButton.IsEnabled = true;
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
		private void ClearChosenEventListBox()
		{
			ChosenEventListBox.ItemsSource = null;
		}

		//// methodology below is to interact with GUI buttons and boxes...
		// room for refactoring here
		private void AddVenueButton_Click(object sender, RoutedEventArgs e)
		{
			NewVenueWindow win1 = new NewVenueWindow();
			win1.ShowDialog();
		}

		// button to call remove venue method, update the drop box and empty the venue text boxes
		private void RemoveVenueButton_Click(object sender, RoutedEventArgs e)
		{
			if(VenueDropBox.SelectedItem == null)
			{
				MessageBox.Show("No venue selected", "Warning");
			}
			else
			{
				MessageBoxResult mbr = MessageBox.Show("All events associated to this venue will be removed.  Do you wish to proceed?", "Warning", MessageBoxButton.YesNo);
				switch(mbr)
				{
					case MessageBoxResult.Yes:
						var venueToRemove = _crudManager.SelectedVenue.VenueId;
						_crudManager.RemoveVenue(venueToRemove);
						ClearVenueFields();
						break;
				}
			}

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
				AddEvent.IsEnabled = true;
				VenueNameText.IsReadOnly = true;
				VenueCityText.IsReadOnly = true;
				VenueCountryText.IsReadOnly = true;
				VenueCapacityText.IsReadOnly = true;
				VenueDropBox.IsEnabled = true;
				EventDropBox.IsEnabled = true;
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
				AddEvent.IsEnabled = false;
				VenueNameText.IsReadOnly = false;
				VenueCityText.IsReadOnly = false;
				VenueCountryText.IsReadOnly = false;
				VenueCapacityText.IsReadOnly = false;
				VenueDropBox.IsEnabled = false;
				EventDropBox.IsEnabled = false;
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
					if(ChosenEventListBox.Items != null)
					{
						ClearChosenEventListBox();
					}
				}
				if (EventDropBox.SelectedItem.ToString() == "Music")
				{
					PopulateEventListBoxWithMusic();
					if(ChosenEventListBox != null)
					{
						ClearChosenEventListBox();
					}
				}
			}
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

		private void EventsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(EventsListBox.SelectedItem != null)
			{
				if (EventDropBox.SelectedItem.ToString() == "Sport")
				{
					_crudManager.SetSelectedSportType(EventsListBox.SelectedItem);
					PopulateChosenEventListBox();
				}
				if (EventDropBox.SelectedItem.ToString() == "Music")
				{
					_crudManager.SetSelectedMusicType(EventsListBox.SelectedItem);
					PopulateChosenEventListBox();
				}
			}
		}



		private void ChosenEventListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(ChosenEventListBox.SelectedItem != null)
			{
				if(EventDropBox.SelectedItem.ToString() == "Sport")
				{
					SportEventWindow win1 = new SportEventWindow(ChosenEventListBox.SelectedItem);
					win1.ShowDialog();
				}
				if (EventDropBox.SelectedItem.ToString() == "Music")
				{
					MusicEventWindow win1 = new MusicEventWindow(ChosenEventListBox.SelectedItem);
					win1.ShowDialog();
				}
				ChosenEventListBox.SelectedItem = null;
			}
		}

		private void AddEventButton_Click(object sender, RoutedEventArgs e)
		{
			NewEventWindow win1 = new NewEventWindow();
			win1.ShowDialog();

		}
	}
}
