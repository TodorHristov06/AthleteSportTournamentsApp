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
        public DbSet<AthleteSportTournaments> AthleteSportTournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AthleteSportTournaments>()
                .HasKey(ast => new { ast.AthleteId, ast.SportId, ast.TournamentId });

            modelBuilder.Entity<AthleteSportTournaments>()
                .HasOne(ast => ast.Athlete)
                .WithMany(a => a.AthleteSportTournaments)
                .HasForeignKey(ast => ast.AthleteId);

            modelBuilder.Entity<AthleteSportTournaments>()
                .HasOne(ast => ast.Sport)
                .WithMany(s => s.AthleteSportTournaments)
                .HasForeignKey(ast => ast.SportId);

            modelBuilder.Entity<AthleteSportTournaments>()
                .HasOne(ast => ast.Tournament)
                .WithMany(t => t.AthleteSportTournaments)
                .HasForeignKey(ast => ast.TournamentId);
        }
    }
}
