namespace AthleteSportTournamentsApp.Data
{
    public class Tournament : BaseEntity
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Sport? Sport { get; set; }
        public int SportId { get; set; }
    }
}
