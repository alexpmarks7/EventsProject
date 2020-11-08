using NUnit.Framework;
using EventsProjectBusiness;
using EventsProject;
using System.Linq;
using System;

namespace EventsProjectTests
{
	public class MusicEventTests
	{
		CRUDManager _crudManager = new CRUDManager();
		private int? currentMusicEventId;
		[SetUp]
		public void Setup()
		{
			currentMusicEventId = null;
		}

		[TearDown]
		public void TearDown()
		{
			if (currentMusicEventId != null)
			{
				using (var db = new EventsProjectContext())
				{
					var selectedMusicEvent = db.MusicEvents.Where(se => se.MusicEventId == currentMusicEventId).FirstOrDefault();
					db.MusicEvents.Remove(selectedMusicEvent);
					db.SaveChanges();
				}
			}
		}
		// Testing to ensure method that creates a new sport event works
		[Test]
		public void CreateMusicEventTest()
		{
			using (var db = new EventsProjectContext())
			{
				var musicEventsBefore = db.MusicEvents.Count();
				_crudManager.AddMusicEvent("WMBLY", "_POP_", "Beyonce", new DateTime(2020, 11, 07, 20, 00, 00), 40000);
				var musicEventsAfter = db.MusicEvents.Count();
				Assert.AreEqual(musicEventsBefore + 1, musicEventsAfter);
			}
		}
		[Test]
		public void RemoveMusicEventTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "Beyonce",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
				var oldCount = db.MusicEvents.Count();
				var musicId = db.MusicEvents.Where(se => se.Artist == "Beyonce").FirstOrDefault();
				_crudManager.RemoveMusicEvent(musicId.MusicEventId);
				var newCount = db.MusicEvents.Count();
				//currentSportEventId = sportId.SportEventId;
				Assert.AreEqual(oldCount - 1, newCount);
			}
		}
		[Test]
		public void EditMusicEventTicketsSoldTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "Beyonce",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
				_crudManager.EditMusicEvent(newMusicEvent.MusicEventId, "WMBLY", "Beyonce", new DateTime(2020, 11, 07, 20, 00, 00), 50000);
				var testMusicEventTicketsSold = db.MusicEvents.Where(se => se.MusicEventId == newMusicEvent.MusicEventId).Select(s => new { s.TicketsSold }).FirstOrDefault();
				Assert.AreEqual(testMusicEventTicketsSold.TicketsSold, 50000);
			}
		}
		[Test]
		public void EditMusicEventDateTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "Beyonce",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
				_crudManager.EditMusicEvent(newMusicEvent.MusicEventId, "WMBLY", "Beyonce", new DateTime(2020, 12, 07, 20, 00, 00), 40000);
				var testMusicEventDate = db.MusicEvents.Where(se => se.MusicEventId == newMusicEvent.MusicEventId).Select(s => new { s.dateTime }).FirstOrDefault();
				Assert.AreEqual(testMusicEventDate.dateTime, new DateTime(2020, 12, 07, 20, 00, 00));
			}
		}
		[Test]
		public void EditMusicEventArtistTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "Beyonce",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
				_crudManager.EditMusicEvent(newMusicEvent.MusicEventId, "WMBLY", "Kasabian", new DateTime(2020, 11, 07, 20, 00, 00), 40000);
				var testMusicEventFixture = db.MusicEvents.Where(se => se.MusicEventId == newMusicEvent.MusicEventId).Select(s => new { s.Artist, s.MusicEventId }).FirstOrDefault();
				currentMusicEventId = testMusicEventFixture.MusicEventId;
				Assert.AreEqual(testMusicEventFixture.Artist, "Kasabian");
			}
		}

		[Test]
		public void EditMusicEventVenueIdTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newMusicEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "Beyonce",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 10000
				};
				db.MusicEvents.Add(newMusicEvent);
				db.SaveChanges();
				_crudManager.EditMusicEvent(newMusicEvent.MusicEventId, "Wembley Arena", "Beyonce", new DateTime(2020, 11, 07, 20, 00, 00), 10000);
				var testMusicEventVenueId = db.MusicEvents.Where(se => se.MusicEventId == newMusicEvent.MusicEventId).Select(s => new { s.VenueId }).FirstOrDefault();
				Assert.AreEqual(testMusicEventVenueId.VenueId, "WBLAR");
			}
		}

	}
}