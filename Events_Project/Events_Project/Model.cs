using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic.CompilerServices;

namespace EventsProject
{
    public class EventsProjectContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Sport> Sports { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=EventsProject;");
    }

    public partial class Venue
    {
        public string VenueId { get; set; }
        public string VenueName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Capacity { get; set; }
    }
    public partial class Event
    {
        public string EventId { get; set; }
        public string EventTypeName { get; set; }
    }

    public partial class Sport
    {
        public Event Event { get; set; }
        public Venue Venue { get; set; }
        public string EventId { get; set; }
        public string VenueId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Fixture { get; set; }
        public DateTime Date_Time { get; set; }
        public int TicketsSold { get; set; }
    }

    public partial class Music
    {
        public Event Event { get; set; }
        public string EventId { get; set; }
        public string VenueId { get; set; }
        public int MusicId { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime Date_Time { get; set; }
        public int TicketsSold { get; set; }
    }


}
