using NUnit.Framework;
using EventsProjectBusiness;
using EventsProject;
using System.Linq;
using System;

namespace EventsProjectTests
{
	public class SportEventTests
	{
		CRUDManager _crudManager = new CRUDManager();
		private int ? currentSportEventId;
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
		// Testing to ensure method that creates a new sport event works
		[Test]
		public void CreateSportEventTest()
		{
			using (var db = new EventsProjectContext())
			{
				var sportEventsBefore = db.SportEvents.Count();
				_crudManager.AddSportEvent("WMBLY", "FTBAL", "Aston Villa vs Chelsea", new DateTime(2020, 11, 07, 20, 00, 00), 40000);
				var sportEventsAfter = db.SportEvents.Count();
				Assert.AreEqual(sportEventsBefore + 1, sportEventsAfter);
			}
		}
		[Test]
		public void RemoveSportEventTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newSportEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "Aston Villa vs Chelsea",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.SportEvents.Add(newSportEvent);
				db.SaveChanges();
				var oldCount = db.SportEvents.Count();
				var sportId = db.SportEvents.Where(se => se.Fixture == "Aston Villa vs Chelsea").FirstOrDefault();
				_crudManager.RemoveSportEvent(sportId.SportEventId);
				var newCount = db.SportEvents.Count();
				//currentSportEventId = sportId.SportEventId;
				Assert.AreEqual(oldCount - 1, newCount);
			}
		}
		[Test]
		public void EditSportEventTicketsSoldTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newSportEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "Aston Villa vs Chelsea",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.SportEvents.Add(newSportEvent);
				db.SaveChanges();
				_crudManager.EditSportEvent(newSportEvent.SportEventId, "WMBLY", "Aston Villa vs Chelsea", new DateTime(2020, 11, 07, 20, 00, 00), 50000);
				var testSportEventTicketsSold= db.SportEvents.Where(se => se.SportEventId == newSportEvent.SportEventId).Select(s => new { s.TicketsSold }).FirstOrDefault();
				Assert.AreEqual(testSportEventTicketsSold.TicketsSold, 50000);
			}
		}
		[Test]
		public void EditSportEventDateTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newSportEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "Aston Villa vs Chelsea",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.SportEvents.Add(newSportEvent);
				db.SaveChanges();
				_crudManager.EditSportEvent(newSportEvent.SportEventId, "WMBLY", "Aston Villa vs Chelsea", new DateTime(2020, 12, 07, 20, 00, 00), 40000);
				var testSportEventDate = db.SportEvents.Where(se => se.SportEventId == newSportEvent.SportEventId).Select(s => new { s.dateTime }).FirstOrDefault();
				Assert.AreEqual(testSportEventDate.dateTime, new DateTime(2020, 12, 07, 20, 00, 00));
			}
		}
		[Test]
		public void EditSportEventFixtureTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newSportEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "Aston Villa vs Chelsea",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 40000
				};
				db.SportEvents.Add(newSportEvent);
				db.SaveChanges();
				_crudManager.EditSportEvent(newSportEvent.SportEventId, "WMBLY", "Aston Villa vs Arsenal", new DateTime(2020, 11, 07, 20, 00, 00), 40000);
				var testSportEventFixture = db.SportEvents.Where(se => se.SportEventId == newSportEvent.SportEventId).Select(s => new { s.Fixture, s.SportEventId }).FirstOrDefault();
				currentSportEventId = testSportEventFixture.SportEventId;
				Assert.AreEqual(testSportEventFixture.Fixture, "Aston Villa vs Arsenal");
			}
		}

		[Test]
		public void EditSportEventVenueIdTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newSportEvent = new SportEvent()
				{
					VenueId = "WMBLY",
					SportId = "FTBAL",
					Fixture = "Aston Villa vs Chelsea",
					dateTime = new DateTime(2020, 11, 07, 20, 00, 00),
					TicketsSold = 10000
				};
				db.SportEvents.Add(newSportEvent);
				db.SaveChanges();
				_crudManager.EditSportEvent(newSportEvent.SportEventId, "Wembley Arena", "Aston Villa vs Chelsea", new DateTime(2020, 11, 07, 20, 00, 00), 10000);
				var testSportEventVenueId = db.SportEvents.Where(se => se.SportEventId == newSportEvent.SportEventId).Select(s => new { s.VenueId }).FirstOrDefault();
				Assert.AreEqual(testSportEventVenueId.VenueId, "WBLAR");
			}
		}

	}
}