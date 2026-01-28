namespace AgendaBuilder.Models
{
    public class Preference
    {
        public required string DelegateId{get; set;}
        public required string SessionId{get; set;}
        public required int Score{get; set;}
    }
}
