﻿namespace AthleteSportTournamentsApp.Data
{
    public class Sport : BaseEntity
    {
        public string SportName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }
    }
}
