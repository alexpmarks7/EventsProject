using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EventsProject;
using EventsProjectBusiness;
using Microsoft.EntityFrameworkCore;

namespace EventsProjectGUI
{
	/// <summary>
	/// Interaction logic for SportEventWindow.xaml
	/// </summary>
	public partial class SportEventWindow : Window
	{
		private CRUDManager _crudManager = new CRUDManager();
		private bool _isClicked = false;

		public SportEventWindow()
		{
		}
		private void PopulateVenueDropBox()
		{
			NewVenue.ItemsSource = _crudManager.RetrieveVenues();
		}
		public SportEventWindow(object sportEvent)
		{
			InitializeComponent();
			_crudManager.setSelectedSportEvent(sportEvent);
			PopulateTextBoxes();
			PopulateVenueDropBox();
		}

		private void PopulateTextBoxes()
		{
			if(_crudManager.SelectedSportEvent != null)
			{
				using (var db = new EventsProjectContext()) 
				{
					var sportEvent = _crudManager.SelectedSportEvent;
					FixtureInfo.Text = sportEvent.Fixture;
					VenueInfo.Text = db.Venues.Where(v => v.VenueId == sportEvent.VenueId).Select(v => v.VenueName).FirstOrDefault();
					CityInfo.Text = db.Venues.Where(v => v.VenueId == sportEvent.VenueId).Select(v => v.City).FirstOrDefault();
					CountryInfo.Text = db.Venues.Where(v => v.VenueId == sportEvent.VenueId).Select(v => v.Country).FirstOrDefault();
					CapacityInfo.Text = db.Venues.Where(v => v.VenueId == sportEvent.VenueId).Select(v => v.Capacity).FirstOrDefault().ToString();
					DateInfo.Text = sportEvent.dateTime.ToShortDateString();
					TimeInfo.Text = sportEvent.dateTime.ToShortTimeString();
					TicketsSoldInfo.Text = sportEvent.TicketsSold.ToString();
				}
			}
		}

		private void EditEvent_Click(object sender, RoutedEventArgs e)
		{
			var sportEvent = _crudManager.SelectedSportEvent;
			if (_isClicked == false)
			{
				//  changing the GUI and forcing the user to confirm an edit
				CityInfo.Visibility = Visibility.Hidden;
				CountryInfo.Visibility = Visibility.Hidden;
				CapacityInfo.Visibility = Visibility.Hidden;
				FixtureInfo.IsReadOnly = false;
				VenueInfo.Visibility = Visibility.Hidden;
				NewVenue.Visibility = Visibility.Visible;
				DateInfo.IsReadOnly = false;
				TimeInfo.IsReadOnly = false;
				TicketsSoldInfo.IsReadOnly = false;
				EditEvent.Content = "Confirm Edit";
				_isClicked = true;
			}
			else if (_isClicked == true)
			{
				try
				{
					// changing submitted date and time into valid entries for a date time object and then using catch blocks to ensure all entries are valid
					int year = DateTime.Parse(DateInfo.Text).Year;
					var month = DateTime.Parse(DateInfo.Text).Month;
					var day = DateTime.Parse(DateInfo.Text).Day;
					var hour = DateTime.Parse(TimeInfo.Text).Hour;
					var min = DateTime.Parse(TimeInfo.Text).Minute;
					var dateTime = new DateTime(year, month, day, hour, min, 0);

					using (var db = new EventsProjectContext())
					{
						if (NewVenue.SelectedItem != null)
						{
							try
							{
								_crudManager.EditSportEvent(sportEvent.SportEventId, NewVenue.SelectedItem.ToString(), FixtureInfo.Text, dateTime, Int32.Parse(TicketsSoldInfo.Text));
								this.Close();
								CityInfo.Visibility = Visibility.Visible;
								CountryInfo.Visibility = Visibility.Visible;
								CapacityInfo.Visibility = Visibility.Visible;
								EditEvent.Content = "Edit Event";
								VenueInfo.Visibility = Visibility.Visible;
								NewVenue.Visibility = Visibility.Hidden;
								_isClicked = false;
								PopulateTextBoxes();
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
						else
						{
							MessageBox.Show("No venue selected");
						}

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void AddEvent_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// date time entries to valid DateTime parameters
				int year = DateTime.Parse(DateInfo.Text).Year;
				var month = DateTime.Parse(DateInfo.Text).Month;
				var day = DateTime.Parse(DateInfo.Text).Day;
				var hour = DateTime.Parse(TimeInfo.Text).Hour;
				var min = DateTime.Parse(TimeInfo.Text).Minute;
				var dateTime = new DateTime(year, month, day, hour, min, 0);
				_crudManager.AddSportEvent(NewVenue.SelectedItem.ToString(), _crudManager.SelectedSport.SportId, FixtureInfo.Text, dateTime, Int32.Parse(TicketsSoldInfo.Text));
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void SportBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (SportBox.SelectedItem != null)
			{
				_crudManager.SetSelectedSportType(SportBox.SelectedItem);
			}
		}

		private void RemoveEvent_Click(object sender, RoutedEventArgs e)
		{
			// ensuring user actually wants to eelete an event
			MessageBoxResult mbr = MessageBox.Show("Are you sure you want to remove this event?", "Warning", MessageBoxButton.YesNo);
			switch(mbr)
			{
				case MessageBoxResult.Yes:
					_crudManager.RemoveSportEvent(_crudManager.SelectedSportEvent.SportEventId);
					this.Close();
					break;
			}
			
		}

		private void SellTickets_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// trying to sell tickets, and updating tickets sold field.  Displaying a message if ticket sell was successful
				var ticketsSold = Int32.Parse(SellTicketsInfo.Text);
				_crudManager.SellSportTickets(ticketsSold, VenueInfo.Text, _crudManager.SelectedSportEvent);
				MessageBox.Show($"Nice! You sold {SellTicketsInfo.Text} tickets for {FixtureInfo.Text} on {DateInfo.Text}");
				SellTicketsInfo.Text = "";
				var newTickets = Int32.Parse(TicketsSoldInfo.Text);
				TicketsSoldInfo.Text = (newTickets + ticketsSold).ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				SellTicketsInfo.Text = "";
			}
		}
	}
}
