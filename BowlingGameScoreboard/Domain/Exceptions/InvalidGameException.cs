namespace BowlingGameScoreboard.Domain.Exceptions;

public class InvalidGameException : BowlingException
{
    public InvalidGameException(string message) : base(message) { }
}