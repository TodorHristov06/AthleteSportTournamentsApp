namespace AthleteSportTournamentsApp.Data
{
    public class Sport
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }

        public ICollection<AthleteSportTournaments> AthleteSportTournaments { get; set; }
    }
}
