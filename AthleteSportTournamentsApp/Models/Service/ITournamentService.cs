using AthleteSportTournaments.DTOs;

namespace AthleteSportTournamentsApp.Models.Service
{
    public interface ITournamentService
    {
        IEnumerable<TournamentDTO> GetAllTournaments();
        TournamentDTO GetTournamentById(int id);
        TournamentDTO CreateTournament(TournamentDTO tournamentDTO);
        TournamentDTO UpdateTournament(int id, TournamentDTO tournamentDTO);
        void DeleteTournament(int id);
    }
}
