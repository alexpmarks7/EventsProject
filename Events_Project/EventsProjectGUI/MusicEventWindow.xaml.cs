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
	public partial class MusicEventWindow : Window
	{
		private CRUDManager _crudManager = new CRUDManager();
		private bool _isClicked = false;

		public MusicEventWindow()
		{

		}
		private void PopulateMusicBox()
		{
			MusicBox.ItemsSource = _crudManager.RetrieveMusic();
		}
		private void PopulateVenueDropBox()
		{
			NewVenue.ItemsSource = _crudManager.RetrieveVenues();
		}
		public MusicEventWindow(object musicEvent)
		{
			InitializeComponent();
			_crudManager.setSelectedMusicEvent(musicEvent);
			PopulateTextBoxes();
			PopulateVenueDropBox();
		}

		private void PopulateTextBoxes()
		{
			if (_crudManager.SelectedMusicEvent != null)
			{
				using (var db = new EventsProjectContext())
				{
					var musicEvent = _crudManager.SelectedMusicEvent;
					ArtistInfo.Text = musicEvent.Artist;
					VenueInfo.Text = db.Venues.Where(v => v.VenueId == musicEvent.VenueId).Select(v => v.VenueName).FirstOrDefault();
					CityInfo.Text = db.Venues.Where(v => v.VenueId == musicEvent.VenueId).Select(v => v.City).FirstOrDefault();
					CountryInfo.Text = db.Venues.Where(v => v.VenueId == musicEvent.VenueId).Select(v => v.Country).FirstOrDefault();
					CapacityInfo.Text = db.Venues.Where(v => v.VenueId == musicEvent.VenueId).Select(v => v.Capacity).FirstOrDefault().ToString();
					DateInfo.Text = musicEvent.dateTime.ToShortDateString();
					TimeInfo.Text = musicEvent.dateTime.ToShortTimeString();
					TicketsSoldInfo.Text = musicEvent.TicketsSold.ToString();
				}
			}
		}

		private void EditEvent_Click(object sender, RoutedEventArgs e)
		{
			var musicEvent = _crudManager.SelectedMusicEvent;
			if (_isClicked == false)
			{
				CityInfo.Visibility = Visibility.Hidden;
				CountryInfo.Visibility = Visibility.Hidden;
				CapacityInfo.Visibility = Visibility.Hidden;
				ArtistInfo.IsReadOnly = false;
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
								_crudManager.EditMusicEvent(musicEvent.MusicEventId, NewVenue.SelectedItem.ToString(), ArtistInfo.Text, dateTime, Int32.Parse(TicketsSoldInfo.Text));
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
			{ int year = DateTime.Parse(DateInfo.Text).Year;
				var month = DateTime.Parse(DateInfo.Text).Month;
				var day = DateTime.Parse(DateInfo.Text).Day;
				var hour = DateTime.Parse(TimeInfo.Text).Hour;
				var min = DateTime.Parse(TimeInfo.Text).Minute;
				var dateTime = new DateTime(year, month, day, hour, min, 0);
				_crudManager.AddMusicEvent(NewVenue.SelectedItem.ToString(), _crudManager.SelectedSport.SportId, ArtistInfo.Text, dateTime, Int32.Parse(TicketsSoldInfo.Text));
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void MusicBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MusicBox.SelectedItem != null)
			{
				_crudManager.SetSelectedMusicType(MusicBox.SelectedItem);
			}
		}

		private void RemoveEvent_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult mbr = MessageBox.Show("Are you sure you want to remove this event?", "Warning", MessageBoxButton.YesNo);
			switch (mbr)
			{
				case MessageBoxResult.Yes:
					_crudManager.RemoveMusicEvent(_crudManager.SelectedMusicEvent.MusicEventId);
					this.Close();
					break;
			}

		}
		private void SellTickets_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var ticketsSold = Int32.Parse(SellTicketsInfo.Text);
				_crudManager.SellMusicTickets(ticketsSold, VenueInfo.Text, _crudManager.SelectedMusicEvent);
				MessageBox.Show($"Nice! You sold {SellTicketsInfo.Text} tickets for {ArtistInfo.Text} on {DateInfo.Text}");
				SellTicketsInfo.Text = "";
				var newTickets = Int32.Parse(TicketsSoldInfo.Text);
				TicketsSoldInfo.Text = (newTickets + ticketsSold).ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				SellTicketsInfo.Text = "";
			}
		}
	}
}
