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
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<MusicEvent> MusicEvents { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }


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
    public partial class EventType
    {
        public string EventTypeId { get; set; }
        public string EventTypeName { get; set; }
    }

    public partial class Sport
    {
        public EventType EventType { get; set; }
        public string EventTypeId { get; set; }
        public string SportId { get; set; }
        public string SportName { get; set; }

    }

    public partial class SportEvent
    {
        public Venue Venue { get; set; }
        public Sport Sport { get; set; }
        public string VenueId { get; set; }
        public string SportId { get; set; }
        public int SportEventId { get; set; }
        public string Fixture { get; set; }
        public DateTime dateTime { get; set; }
        public int TicketsSold { get; set; }
    }

    public partial class Music
    {
        public EventType EventType { get; set; }
        public string EventTypeId { get; set; }
        public string MusicId { get; set; }
        public string Genre { get; set; }

    }
    public partial class MusicEvent
    {
        public Venue Venue { get; set; }
        public Music Music { get; set; }
        public string VenueId { get; set; }
        public string MusicId { get; set; }
        public int MusicEventId { get; set; }
        public string Artist { get; set; }
        public DateTime dateTime { get; set; }
        public int TicketsSold { get; set; }
    }
}
