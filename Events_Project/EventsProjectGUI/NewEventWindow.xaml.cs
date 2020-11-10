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
	public partial class NewEventWindow : Window
	{
		private CRUDManager _crudManager = new CRUDManager();

		public NewEventWindow()
		{
			InitializeComponent();
			PopulateSportMusicBox();
			PopulateVenueBox();
		}
		private void PopulateSportMusicBox()
		{
			SportMusicBox.ItemsSource = _crudManager.RetrieveEventTypes();
		}

		private void SportMusicBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TypeBox.Visibility = Visibility.Visible;
			if(SportMusicBox.SelectedItem != null)
			{
				if(SportMusicBox.SelectedItem.ToString() == "Music")
				{
					TypeSM.Content = "Genre";
					NewGenre.Content = "New Genre";
					NewGenreId.Content = "New Genre ID";
					NewGenreInfo.Visibility = Visibility.Visible;
					NewGenreIdInfo.Visibility = Visibility.Visible;
					PopulateTypeBoxWithMusic();
				}
				if (SportMusicBox.SelectedItem.ToString() == "Sport")
				{
					TypeSM.Content = "Sport";
					NewGenre.Content = "New Sport";
					NewGenreId.Content = "New Sport ID";
					NewGenreInfo.Visibility = Visibility.Visible;
					NewGenreIdInfo.Visibility = Visibility.Visible;
					PopulateTypeBoxWithSport();
				}
			}
		}
		private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(SportMusicBox.SelectedItem.ToString() == "Music")
			{
				_crudManager.SetSelectedMusicType(TypeBox.SelectedItem);
			}
			else if(SportMusicBox.SelectedItem.ToString() == "Sport")
			{
				_crudManager.SetSelectedSportType(TypeBox.SelectedItem);
			}
		}
		private void NewVenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(NewVenue.SelectedItem != null)
			{
				_crudManager.SetSelectedVenue(NewVenue.SelectedItem);
			}
		}

		private void PopulateTypeBoxWithMusic()
		{
			TypeSM.Content = "Genre";
			TypeBox.ItemsSource = _crudManager.RetrieveMusic();
		}

		private void PopulateTypeBoxWithSport()
		{
			TypeSM.Content = "Sport";
			TypeBox.ItemsSource = _crudManager.RetrieveSports();
		}
		private void PopulateVenueBox()
		{
			NewVenue.ItemsSource = _crudManager.RetrieveVenues();
		}

		private void AddEvent_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var artist = FixtureGenreInfo.Text;
				var ticketsSold = Int32.Parse(TicketsSoldInfo.Text);
				int year = DateTime.Parse(DateInfo.Text).Year;
				var month = DateTime.Parse(DateInfo.Text).Month;
				var day = DateTime.Parse(DateInfo.Text).Day;
				var hour = DateTime.Parse(TimeInfo.Text).Hour;
				var min = DateTime.Parse(TimeInfo.Text).Minute;
				var dateTime = new DateTime(year, month, day, hour, min, 0);

				if (SportMusicBox.SelectedItem != null)
				{
					if (TypeBox.SelectedItem == null)
					{
						var id = NewGenreIdInfo.Text;
						var info = NewGenreInfo.Text;
						if (SportMusicBox.SelectedItem.ToString() == "Music")
						{
							_crudManager.AddMusicType(id, info);
							var venue = _crudManager.SelectedVenue;
							try
							{
								_crudManager.AddMusicEvent(venue.VenueId, id, artist, dateTime, ticketsSold);
								this.Close();
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
						else if (SportMusicBox.SelectedItem.ToString() == "Sport")
						{
							_crudManager.AddSportType(id, info);
							var venue = _crudManager.SelectedVenue;
							try
							{
								_crudManager.AddSportEvent(venue.VenueId, id, artist, dateTime, ticketsSold);
								this.Close();
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
					}

					else if (SportMusicBox.SelectedItem.ToString() == "Music")
					{
						var venue = _crudManager.SelectedVenue;
						var music = _crudManager.SelectedMusic;
						_crudManager.AddMusicEvent(venue.VenueId, music.MusicId, artist, dateTime, ticketsSold);
						this.Close();
					}
					else if (SportMusicBox.SelectedItem.ToString() == "Sport")
					{
						var venue = _crudManager.SelectedVenue;
						var sport = _crudManager.SelectedSport;
						_crudManager.AddSportEvent(venue.VenueId, sport.SportId, artist, dateTime, ticketsSold);
						this.Close();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Input was invalid");
			}
			
		}


	}
}