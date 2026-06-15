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
                score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                rollIndex++; 
            }
            else if (IsSpare(rolls, rollIndex))
            {
                score += 10 + rolls[rollIndex + 2];
                rollIndex += 2;
            }
            else
            {
                score += rolls[rollIndex] + rolls[rollIndex + 1];
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
        return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
    }

    private static void ValidateGameStructure(List<int> rolls)
    {
        int rollIndex = 0;

        for (int frame = 1; frame <= 9; frame++)
        {
            if (rollIndex >= rolls.Count)
                throw new InvalidGameException("Incomplete game.");

            if (rolls[rollIndex] == 10)
            {
                rollIndex++;
            }
            else
            {
                if (rollIndex + 1 >= rolls.Count)
                    throw new InvalidGameException("Incomplete frame.");

                if (rolls[rollIndex] + rolls[rollIndex + 1] > 10)
                    throw new InvalidGameException("Frame cannot exceed 10 pins.");

                rollIndex += 2;
            }
        }

        if (rollIndex + 1 >= rolls.Count)
            throw new InvalidGameException("10th frame is incomplete.");

        int ball1 = rolls[rollIndex];
        int ball2 = rolls[rollIndex + 1];

        if (ball1 == 10)
        {
            if (rollIndex + 2 != rolls.Count - 1) 
                throw new InvalidGameException("10th frame strike requires exactly 2 bonus rolls.");
            
            int ball3 = rolls[rollIndex + 2];
            if (ball2 != 10 && (ball2 + ball3 > 10))
                throw new InvalidGameException("Invalid bonus rolls in 10th frame.");
        }
        else if (ball1 + ball2 == 10)
        {
            if (rollIndex + 2 != rolls.Count - 1)
                throw new InvalidGameException("10th frame spare requires exactly 1 bonus roll.");
        }
        else
        {
            if (ball1 + ball2 > 10)
                throw new InvalidGameException("10th frame cannot exceed 10 pins.");
            
            if (rollIndex + 1 != rolls.Count - 1)
                throw new InvalidGameException("Too many rolls for a standard 10th frame.");
        }
    }
}