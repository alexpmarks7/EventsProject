using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using EventsProject;

namespace EventsProjectBusiness
{
	public class CRUDManager
	{
		public Venue SelectedVenue { get; set; }
		public EventType SelectedEventType { get; set; }
		public Sport SelectedSport { get; set; }
		public Music SelectedMusic { get; set; }
		public SportEvent SelectedSportEvent { get; set; }
		public MusicEvent SelectedMusicEvent { get; set; }

		public void SetSelectedVenue(object selectedItem)
		{
			SelectedVenue = (Venue)selectedItem;
		}
		public void SetSelectedEventType(object selectedItem)
		{
			SelectedEventType = (EventType)selectedItem;
		}
		public void SetSelectedSportType(object selectedItem)
		{
			SelectedSport = (Sport)selectedItem;
		}
		public void SetSelectedMusicType(object selectedItem)
		{
			SelectedMusic = (Music)selectedItem;
		}
		public void setSelectedSportEvent(object selectedItem)
		{
			SelectedSportEvent = (SportEvent)selectedItem;
		}
		public void setSelectedMusicEvent(object selectedItem)
		{
			SelectedMusicEvent = (MusicEvent)selectedItem;
		}
		public List<Venue> RetrieveVenues()
		{
			using (var db = new EventsProjectContext())
			{
				return db.Venues.ToList();
			}
		}
		// retrieving info from DB to populate GUI
		public List<EventType> RetrieveEventTypes()
		{
			using (var db = new EventsProjectContext())
			{
				return db.EventTypes.ToList();
			}
		}
		public List<Sport> RetrieveSports()
		{
			using (var db = new EventsProjectContext())
			{
				return db.Sports.ToList();
			}
		}
		public List<Music> RetrieveMusic()
		{
			using (var db = new EventsProjectContext())
			{
				return db.Musics.ToList();
			}
		}
		public List<SportEvent> RetrieveSportEvents()
		{
			using (var db = new EventsProjectContext())
			{
				return db.SportEvents.Where(se => se.SportId == SelectedSport.SportId).ToList();
			}
		}
		public List<MusicEvent> RetrieveMusicEvents()
		{
			using (var db = new EventsProjectContext())
			{
				return db.MusicEvents.Where(me => me.MusicId == SelectedMusic.MusicId).ToList();
			}
		}


		// method to create a new venue, ensuring the ID is 5 letters long and capacity is not negative
		public void CreateVenue(string newVenueId, string newVenueName, string newVenueCity, string newVenueCountry, int newVenueCapacity)
		{
			using (var db = new EventsProjectContext())
			{
				if (newVenueId.Length != 5)
				{
					throw new ArgumentException($"A VenueId needs to be exactly 5 characters long");
				}
				else if (newVenueCapacity < 0)
				{
					throw new ArgumentException($"A venue's capacity must not be negative");
				}
				else
				{
					var newVenue = new Venue()
					{
						VenueId = newVenueId.ToUpper(),
						VenueName = newVenueName,
						City = newVenueCity,
						Country = newVenueCountry,
						Capacity = newVenueCapacity
					};
					db.Venues.Add(newVenue);
					db.SaveChanges();
				}
			}
		}
		// method to remove a venue
		public void RemoveVenue(string venueIdToRemove)
		{
			using (var db = new EventsProjectContext())
			{
				var venue = db.Venues.Where(v => v.VenueId == venueIdToRemove).FirstOrDefault();
				var sportEvents = db.SportEvents.Where(v => v.VenueId == venueIdToRemove).ToList();
				var musicEvents = db.MusicEvents.Where(v => v.VenueId == venueIdToRemove).ToList();
				foreach(var ev in sportEvents)
				{
					db.SportEvents.Remove(ev);
				}
				foreach(var ev in musicEvents)
				{
					db.MusicEvents.Remove(ev);
				}
				db.Venues.RemoveRange(venue);
				db.SaveChanges();
			}
		}
		// method to edt a venue, ensuring certain parameters are met
		public void EditVenue(string venueId, string newVenueName, string newVenueCity, string newVenueCountry, int newVenueCapacity)
		{
			using (var db = new EventsProjectContext())
			{
				SelectedVenue = db.Venues.Where(v => v.VenueId == venueId).FirstOrDefault();
				if (newVenueCapacity < 0)
				{
					throw new ArgumentException($"A venue's capacity must not be negative");
				}
				else
				{
					SelectedVenue.VenueName = newVenueName;
					SelectedVenue.City = newVenueCity;
					SelectedVenue.Country = newVenueCountry;
					SelectedVenue.Capacity = newVenueCapacity;
					db.SaveChanges();
				}
			}
		}
		public void AddSportEvent(string venueId, string sportId, string fixture, DateTime date, int ticketsSold)
		{
			using (var db = new EventsProjectContext())
			{
				var venueCapacity = db.Venues.Where(v => v.VenueId == venueId).Select(v => v.Capacity).FirstOrDefault();
				if (ticketsSold > venueCapacity)
				{
					throw new ArgumentException("Tickets sold cannot exceed capacity");
				}
				else
				{
					var newSportEvent = new SportEvent()
					{
						VenueId = venueId,
						SportId = sportId,
						Fixture = fixture,
						dateTime = date,
						TicketsSold = ticketsSold
					};
					db.SportEvents.Add(newSportEvent);
					db.SaveChanges();
				}
			}
		}
		public void RemoveSportEvent(int sportEventIDToRemove)
		{
			using (var db = new EventsProjectContext())
			{
				var sportEvent = db.SportEvents.Where(se => se.SportEventId == sportEventIDToRemove).FirstOrDefault();
				db.SportEvents.Remove(sportEvent);
				db.SaveChanges();
			}
		}
		public void EditSportEvent(int sportEventId, string venueName, string fixture, DateTime date, int ticketsSold)
		{
			using (var db = new EventsProjectContext())
			{
				if (ticketsSold > db.Venues.Where(v => v.VenueName == venueName).Select(v => v.Capacity).FirstOrDefault())
				{
					throw new ArgumentException("Tickets sold exceeds events capacity");
				}
				try
				{
					SelectedSportEvent = db.SportEvents.Where(se => se.SportEventId == sportEventId).FirstOrDefault();
					SelectedSportEvent.VenueId = db.Venues.Where(v => v.VenueName == venueName).Select(v => v.VenueId).FirstOrDefault();
					SelectedSportEvent.Fixture = fixture;
					SelectedSportEvent.dateTime = date;
					SelectedSportEvent.TicketsSold = ticketsSold;
					db.SaveChanges();
				}
				catch (Exception)
				{
					
				}
			}
		}
		public void AddMusicEvent(string venueId, string musicId, string artist, DateTime date, int ticketsSold)
		{
			using (var db = new EventsProjectContext())
			{
				var venueCapacity = db.Venues.Where(v => v.VenueId == venueId).Select(v => v.Capacity).FirstOrDefault();
				if (ticketsSold > venueCapacity)
				{
					throw new ArgumentException("Tickets sold cannot exceed capacity");
				}
				var newMusicEvent = new MusicEvent()
				{
					VenueId = venueId,
					MusicId = musicId,
					Artist = artist,
					dateTime = date,
					TicketsSold = ticketsSold
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
			}
		}
		public void RemoveMusicEvent(int musicEventIDToRemove)
		{
			using (var db = new EventsProjectContext())
			{
				var musicEvent = db.MusicEvents.Where(me => me.MusicEventId == musicEventIDToRemove).FirstOrDefault();
				db.MusicEvents.Remove(musicEvent);
				db.SaveChanges();
			}
		}

		public void EditMusicEvent(int musicEventId, string venueName, string artist, DateTime date, int ticketsSold)
		{
			using (var db = new EventsProjectContext())
			{
				if (ticketsSold > db.Venues.Where(v => v.VenueName == venueName).Select(v => v.Capacity).FirstOrDefault())
				{
					throw new ArgumentException("Tickets sold exceeds events capacity");
				}
				try
				{ SelectedMusicEvent = db.MusicEvents.Where(me => me.MusicEventId == musicEventId).FirstOrDefault();
					SelectedMusicEvent.VenueId = db.Venues.Where(v => v.VenueName == venueName).Select(v => v.VenueId).FirstOrDefault();
					SelectedMusicEvent.Artist = artist;
					SelectedMusicEvent.dateTime = date;
					SelectedMusicEvent.TicketsSold = ticketsSold;
					db.SaveChanges();
				}
				catch (Exception)
				{
					
				}
			}
		}

		public void AddMusicType(string musicTypeId, string musicTypeInfo)
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicType = new Music()
				{
					EventTypeId = "MUSIC",
					MusicId = musicTypeId,
					Genre = musicTypeInfo
				};
				db.Musics.Add(newMusicType);
				db.SaveChanges();
			}
			
		}

		public void AddSportType(string sportTypeId, string sportTypeInfo)
		{
			using (var db = new EventsProjectContext())
			{
				var newSportType = new Sport()
				{
					EventTypeId = "Sport",
					SportId = sportTypeId,
					SportName = sportTypeInfo
				};
				db.Sports.Add(newSportType);
				db.SaveChanges();
			}

		}
		public void SellSportTickets(int numberOfTickets, string venue, SportEvent sportEvent)
		{
			using (var db = new EventsProjectContext())
			{
				var whichEvent = db.SportEvents.Where(se => se.SportEventId == sportEvent.SportEventId).FirstOrDefault();
				var whichVenue = db.Venues.Where(v => v.VenueName == venue).FirstOrDefault();
				if(whichEvent.TicketsSold + numberOfTickets <= whichVenue.Capacity)
				{
					whichEvent.TicketsSold += numberOfTickets;
					db.SaveChanges();
				}
				else
				{
					throw new ArgumentException($"Ticket sales cannot exceed the events capacity");
				}
			}
		}

		public void SellMusicTickets(int numberOfTickets, string venue, MusicEvent musicEvent)
		{
			using (var db = new EventsProjectContext())
			{
				var whichEvent = db.MusicEvents.Where(se => se.MusicEventId == musicEvent.MusicEventId).FirstOrDefault();
				var whichVenue = db.Venues.Where(v => v.VenueName == venue).FirstOrDefault();
				if (whichEvent.TicketsSold + numberOfTickets <= whichVenue.Capacity)
				{
					whichEvent.TicketsSold += numberOfTickets;
					db.SaveChanges();
				}
				else
				{
					throw new ArgumentException($"Ticket sales cannot exceed the events capacity");
				}
			}
		}
		static void Main(string[] args)
		{

		}
	}
}
