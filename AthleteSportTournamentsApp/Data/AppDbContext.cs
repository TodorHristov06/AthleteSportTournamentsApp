using Microsoft.EntityFrameworkCore;

namespace AthleteSportTournamentsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<AthleteTournament> AthleteSportTournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AthleteTournament>()
                .HasKey(ast => new { ast.AthleteId, ast.TournamentId });

        }
    }
}
