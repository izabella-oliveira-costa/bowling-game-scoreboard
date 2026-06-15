namespace BowlingGameScoreboard.Domain.Exceptions;

public class InvalidRollException : BowlingException
{
    public InvalidRollException(string message) : base(message) { }
}