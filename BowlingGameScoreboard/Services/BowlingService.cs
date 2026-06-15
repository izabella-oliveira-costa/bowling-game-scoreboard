namespace BowlingGameScoreboard.Services;

using BowlingGameScoreboard.Domain.Exceptions;

public class BowlingService
{
    public int Calculate(List<int> rolls)
    {
        if (rolls == null || rolls.Count == 0)
            throw new ArgumentException("Rolls cannot be null or empty.");

        if (rolls.Any(r => r < 0 || r > 10))
            throw new InvalidRollException("Roll must be between 0 and 10.");

        ValidateGameStructure(rolls);

        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (IsStrike(rolls, rollIndex))
            {
                score += 10
                       + rolls[rollIndex + 1]
                       + rolls[rollIndex + 2];

                rollIndex++;
            }
            else if (IsSpare(rolls, rollIndex))
            {
                score += 10
                       + rolls[rollIndex + 2];

                rollIndex += 2;
            }
            else
            {
                score += rolls[rollIndex]
                       + rolls[rollIndex + 1];

                rollIndex += 2;
            }
        }

        return score;
    }

    private static bool IsStrike(List<int> rolls, int rollIndex)
    {
        return rolls[rollIndex] == 10;
    }

    private static bool IsSpare(List<int> rolls, int rollIndex)
    {
        if (rollIndex + 1 >= rolls.Count)
            return false;

        return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
    }

    private static void ValidateGameStructure(List<int> rolls)
    {
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rollIndex >= rolls.Count)
                throw new InvalidGameException("Incomplete game.");

            // strike
            if (rolls[rollIndex] == 10)
            {
                rollIndex++;
                continue;
            }

            // normal frame needs 2 rolls
            if (rollIndex + 1 >= rolls.Count)
                throw new InvalidGameException("Incomplete frame.");

            int frameScore = rolls[rollIndex] + rolls[rollIndex + 1];

            if (frameScore > 10)
                throw new InvalidGameException("Frame cannot exceed 10 pins.");

            rollIndex += 2;
        }
    }
}