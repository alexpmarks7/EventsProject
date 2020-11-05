using System;

namespace EventsProject
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new EventsProjectContext())
			{
				//not added to db yet
			 //  var newVenue = new Venue() { VenueId = "WBLYA", VenueName = "Wembley Arena", City = "London", Country = "UK", Capacity = 12500 };
				//var newVenue2 = new Venue() { VenueId = "WMBLY", VenueName = "Wembley Stadium", City = "London", Country = "UK", Capacity = 90000 };
				//var newEvent = new Event() { EventId = "SPORT", EventTypeName = "Sport" };
				//var newEvent2 = new Event() { EventId = "MUSIC", EventTypeName = "Music" };
				//var newMusicEvent = new Music()
				//{
				//	VenueId = "WBLYA",
				//	EventId = "MUSIC",
				//	Artist = "Beyonce",
				//	Genre = "Hip-Hop",
				//	Date_Time = new DateTime(2020, 12, 10, 20, 00, 00),
				//	TicketsSold = 10000
				//};
				//db.Venues.Add(newVenue);
				//db.Venues.Add(newVenue2);
				//db.Events.Add(newEvent);
				//db.Events.Add(newEvent2);
				//db.Musics.Add(newMusicEvent);
				//db.SaveChanges();
			}
		}
	}
}
