namespace AgendaBuilder.Models
{
    public class Session
    {
        public required string Id{get; set;}
        public required int Start{get; set;}
        public required int End {get; set;}
        public required string VenueId{get; set;}
        public required int Capacity{get; set;}
        public int UsedCapacity{get; set;}

    }
}