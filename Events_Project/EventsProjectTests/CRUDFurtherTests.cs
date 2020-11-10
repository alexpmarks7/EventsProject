using NUnit.Framework;
using EventsProjectBusiness;
using EventsProject;
using System.Linq;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace EventsProjectTests
{
	public class AddMusicTypeTests
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]

		public void Setup()
		{

		}

		[TearDown]

		public void TearDown()
		{
			using (var db = new EventsProjectContext())
			{
				var hipHop = db.Musics.Where(m => m.MusicId == "HPHOP").FirstOrDefault();
				db.Musics.Remove(hipHop);
				db.SaveChanges();

			}
		}

		[Test]

		public void AddMusicTypeTest()
		{
			using (var db = new EventsProjectContext())
			{
				var countBefore = db.Musics.Count();
				_crudManager.AddMusicType("HPHOP", "Hip Hop");
				var countAfter = db.Musics.Count();
				Assert.AreEqual(countBefore + 1, countAfter);
			}
		}
	}

	public class AddSportTypeClass
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]

		public void Setup()
		{
		
		}
		[TearDown]

		public void TearDown()
		{
			using (var db = new EventsProjectContext())
			{
				var badminton = db.Sports.Where(m => m.SportId == "BDMTN").FirstOrDefault();
				db.Sports.Remove(badminton);
				db.SaveChanges();
			}
		}
		[Test]

		public void AddSportTypeTest()
		{
			using (var db = new EventsProjectContext())
			{
				var countBefore = db.Sports.Count();
				_crudManager.AddSportType("BDMTN", "Badminton");
				var countAfter = db.Sports.Count();
				Assert.AreEqual(countBefore + 1, countAfter);
			}
		}
	}
	public class SellingSportTicketsTests
	{
		CRUDManager _crudManager = new CRUDManager();
		private int? currentSportEventId;
		[SetUp]
		public void Setup()
		{
			currentSportEventId = null;
		}

		[TearDown]
		public void TearDown()
		{
			if (currentSportEventId != null)
			{
				using (var db = new EventsProjectContext())
				{
					var selectedSportEvent = db.SportEvents.Where(se => se.SportEventId == currentSportEventId).FirstOrDefault();
					db.SportEvents.Remove(selectedSportEvent);
					db.SaveChanges();
				}
			}
		}
		[Test]
		public void SellingTicketsChangesNumberOfTicketsSoldTest()
		{
			using(var db = new EventsProjectContext())
			{
				var newEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "A vs B",
					dateTime = new DateTime(2020, 11, 20, 20, 00, 00),
					TicketsSold = 10
				};
				db.SportEvents.Add(newEvent);
				db.SaveChanges();
				var newFixtureId = db.SportEvents.Where(se => se.Fixture == "A vs B").Select(se => se.SportEventId).FirstOrDefault();
				_crudManager.SellSportTickets(100, "Wembley Stadium", newEvent);
				var testTicketsSold = db.SportEvents.Where(se => se.SportEventId == newFixtureId).Select(se => se.TicketsSold).FirstOrDefault();
				Assert.AreEqual(110, testTicketsSold);
				currentSportEventId = db.SportEvents.Where(me => me.Fixture == "A vs B").Select(me => me.SportEventId).FirstOrDefault();
			}
		}
		[Test]
		public void CannotSellTicketsOverCapacityTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "A vs B",
					dateTime = new DateTime(2020, 11, 20, 20, 00, 00),
					TicketsSold = 90000
				};
				db.SportEvents.Add(newEvent);
				db.SaveChanges();
				var ex = Assert.Throws<ArgumentException>(() => _crudManager.SellSportTickets(100, "Wembley Stadium", newEvent));
				Assert.AreEqual(ex.Message, "Ticket sales cannot exceed the events capacity");
				currentSportEventId = db.SportEvents.Where(me => me.Fixture == "A vs B").Select(me => me.SportEventId).FirstOrDefault();
			}
		}
	}
	public class SellingMusicTicketsTests
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
		[Test]
		public void SellingTicketsChangesNumberOfTicketsSoldTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "A",
					dateTime = new DateTime(2020, 11, 20, 20, 00, 00),
					TicketsSold = 10
				};
				db.MusicEvents.Add(newEvent);
				db.SaveChanges();
				var newArtistId = db.MusicEvents.Where(se => se.Artist == "A").Select(se => se.MusicEventId).FirstOrDefault();
				_crudManager.SellMusicTickets(100, "Wembley Stadium", newEvent);
				var testTicketsSold = db.MusicEvents.Where(se => se.MusicEventId == newArtistId).Select(se => se.TicketsSold).FirstOrDefault();
				Assert.AreEqual(110, testTicketsSold);
				currentMusicEventId = db.MusicEvents.Where(me => me.Artist == "A").Select(me => me.MusicEventId).FirstOrDefault();
			}
		}
		[Test]
		public void CannotSellTicketsOverCapacityTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newEvent = new MusicEvent()
				{
					VenueId = "WMBLY",
					MusicId = "_POP_",
					Artist = "A",
					dateTime = new DateTime(2020, 11, 20, 20, 00, 00),
					TicketsSold = 90000
				};
				db.MusicEvents.Add(newEvent);
				db.SaveChanges();
				var ex = Assert.Throws<ArgumentException>(() => _crudManager.SellMusicTickets(100, "Wembley Stadium", newEvent));
				Assert.AreEqual(ex.Message, "Ticket sales cannot exceed the events capacity");
				currentMusicEventId = db.MusicEvents.Where(me => me.Artist == "A").Select(me => me.MusicEventId).FirstOrDefault();
			}
		}
	}
}