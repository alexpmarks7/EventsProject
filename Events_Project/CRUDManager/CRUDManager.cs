using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EventsProject;

namespace EventsProjectBusiness
{
	public class CRUDManager
	{
		public Venue SelectedVenue { get; set; }
		public Event SelectedEvent { get; set; }
		public Sport SelectedSport { get; set; }
		public Music SelectedMusic { get; set; }

		public void SetSelectedVenue(object selectedItem)
		{
			SelectedVenue = (Venue)selectedItem;
		}
		public void SetSelectedEvent(object selectedItem)
		{
			SelectedEvent = (Event)selectedItem;
		}

		public List<Venue> RetrieveVenues()
		{
			using (var db = new EventsProjectContext())
			{
				return db.Venues.ToList();
			}
		}
		// retrieving info from DB to populate GUI
		public List<Event> RetrieveEvents()
		{
			using (var db = new EventsProjectContext())
			{
				return db.Events.ToList();
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

		static void Main(string[] args)
		{
		
		}
	}
}
