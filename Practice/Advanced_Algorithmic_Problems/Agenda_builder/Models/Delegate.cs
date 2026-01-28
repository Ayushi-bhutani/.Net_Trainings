namespace AgendaBuilder.Models {
    public class ConferenceDelegate {
        public required string Id;
        public List <Session> AssignedSessions = new List <Session>();
    }
}