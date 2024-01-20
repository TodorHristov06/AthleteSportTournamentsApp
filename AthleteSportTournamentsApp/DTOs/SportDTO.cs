using System.ComponentModel.DataAnnotations;

namespace AthleteSportTournaments.DTOs
{
    public class SportDTO
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }
    }
}
