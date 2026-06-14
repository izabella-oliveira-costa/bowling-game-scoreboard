namespace BowlingGameScoreboard.Models
{
    public class ScoreRequest
    {
        public List<int> Rolls { get; set; } = [];
    }

    public class ScoreResponse
    {
        public int Score { get; set; }
    }
}