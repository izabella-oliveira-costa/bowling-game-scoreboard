namespace BowlingGameScoreboard.Domain.Exceptions;

public class BowlingException : Exception
{
    public BowlingException(string message) : base(message) { }
}