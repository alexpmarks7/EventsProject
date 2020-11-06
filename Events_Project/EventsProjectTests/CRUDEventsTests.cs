using NUnit.Framework;
using EventsProjectBusiness;
using EventsProject;
using System.Linq;
using System;

namespace EventsProjectTests
{
	public class Tests
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]

		public void Setup()
		{
			using (var db = new EventsProjectContext())
			{

				var selectedVenue =
				from v in db.Venues
				where v.VenueId == "OLDTR"
				select v;


				foreach (var c in selectedVenue)
				{
					db.Venues.Remove(c);
				}

				db.SaveChanges();
			}
		}

		[TearDown]

		public void TearDown()
		{
			using (var db = new EventsProjectContext())
			{

				var selectedVenue =
				from v in db.Venues
				where v.VenueId == "OLDTR"
				select v;


				foreach (var c in selectedVenue)
				{
					db.Venues.Remove(c);
				}

				db.SaveChanges();
			}
		}
		// Testing to ensure method that creates a new venue works
		[Test]
		public void CreateVenueTest()
		{
			using (var db = new EventsProjectContext())
			{
				var eventsBefore = db.Venues.Count();
				_crudManager.CreateVenue("OLDTR", "Old Trafford", "Manchester", "UK", 76000);
				var eventsAfter = db.Venues.Count();
				Assert.AreEqual(eventsBefore + 1, eventsAfter);
			}
		}
		// Testing to ensure you cannot create a venue with a negative capacity
		[Test]
		public void CreateVenueWithNegativeCapacityTest()
		{
			using (var db = new EventsProjectContext())
			{
				var ex = Assert.Throws<ArgumentException>(()=>_crudManager.CreateVenue("OLDTR", "Old Trafford", "Manchester", "UK", -1));
				Assert.AreEqual(ex.Message, "A venue's capacity must not be negative");
			}
		}
		// Testing to guarantee VenueId is exactly 5 chars long
		[Test]
		public void CreateVenueWithVenueIDTooSmallTest()
		{
			using (var db = new EventsProjectContext())
			{
				var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateVenue("OLDT", "Old Trafford", "Manchester", "UK", 76000));
				Assert.AreEqual(ex.Message, "A VenueId needs to be exactly 5 characters long");
			}
		}
		// Testing to guarantee VenueId is exactly 5 chars long
		[Test]
		public void CreateVenueWithVenueIDTooLongTest()
		{
			using (var db = new EventsProjectContext())
			{
				var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateVenue("OLDTRA", "Old Trafford", "Manchester", "UK", 76000));
				Assert.AreEqual(ex.Message, "A VenueId needs to be exactly 5 characters long");
			}
		}
		// Testing that a VenueId created is saved in uppercase
		[Test]
		public void CreateVenueWithLowerCaseLettersTest()
		{
			using (var db = new EventsProjectContext())
			{
				_crudManager.CreateVenue("oldtr", "Old Trafford", "Manchester", "UK", 76000);
				Assert.AreEqual(db.Venues.Where(v => v.VenueId == "OLDTR").FirstOrDefault().VenueId, "OLDTR");
			}
		}
		// Testing that method to delete a venue does remove the venue from the database
		[Test]
		public void DeleteVenueTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newVenue = new Venue()
				{
					VenueId = "OLDTR",
					VenueName = "Old Trafford",
					City = "Manchester",
					Country = "UK",
					Capacity = 76000
				};
				db.Venues.Add(newVenue);
				db.SaveChanges();
				var oldCount = db.Venues.Count();
				_crudManager.RemoveVenue("OLDTR");
				var newCount = db.Venues.Count();
				Assert.AreEqual(oldCount - 1, newCount);
			}
		}
		// Testing that you can change a venues capacity within the database
		[Test]
		public void EditVenueCapacityTest()
		{
			using(var db = new EventsProjectContext())
			{
				var newVenue = new Venue()
				{
					VenueId = "OLDTR",
					VenueName = "Old Trafford",
					City = "Manchester",
					Country = "UK",
					Capacity = 76000
				};
				db.Venues.Add(newVenue);
				db.SaveChanges();
				_crudManager.EditVenue("OLDTR", "Old Trafford", "Manchester", "UK", 70000);
				var testVenueCapacity = db.Venues.Where(v => v.VenueId == "OLDTR").Select(s => new { s.Capacity }).FirstOrDefault();
				Assert.AreEqual(testVenueCapacity.Capacity, 70000);
			}
		}
		// Testing that you can change a venues country
		[Test]
		public void EditVenueCountryTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newVenue = new Venue()
				{
					VenueId = "OLDTR",
					VenueName = "Old Trafford",
					City = "Manchester",
					Country = "UK",
					Capacity = 76000
				};
				db.Venues.Add(newVenue);
				db.SaveChanges();
				_crudManager.EditVenue("OLDTR", "Old Trafford", "Manchester", "USA", 76000);
				var testVenueCountry = db.Venues.Where(v => v.VenueId == "OLDTR").Select(s => new { s.Country }).FirstOrDefault();
				Assert.AreEqual(testVenueCountry.Country, "USA");
			}
		}
		// Testing that you can change a venues city
		[Test]
		public void EditVenueCityTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newVenue = new Venue()
				{
					VenueId = "OLDTR",
					VenueName = "Old Trafford",
					City = "Manchester",
					Country = "UK",
					Capacity = 76000
				};
				db.Venues.Add(newVenue);
				db.SaveChanges();
				_crudManager.EditVenue("OLDTR", "Old Trafford", "Birmingham", "UK", 76000);
				var testVenueCity = db.Venues.Where(v => v.VenueId == "OLDTR").Select(s => new { s.City }).FirstOrDefault();
				Assert.AreEqual(testVenueCity.City, "Birmingham");
			}
		}
		// Testing that you can change a venues name
		[Test]
		public void EditVenueNameTest()
		{
			using (var db = new EventsProjectContext())
			{
				var newVenue = new Venue()
				{
					VenueId = "OLDTR",
					VenueName = "Old Trafford",
					City = "Manchester",
					Country = "UK",
					Capacity = 76000
				};
				db.Venues.Add(newVenue);
				db.SaveChanges();
				_crudManager.EditVenue("OLDTR", "New Trafford", "Manchester", "UK", 76000);
				var testVenueName = db.Venues.Where(v => v.VenueId == "OLDTR").Select(s => new { s.VenueName }).FirstOrDefault();
				Assert.AreEqual(testVenueName.VenueName, "New Trafford");
			}
		}
	}
}

