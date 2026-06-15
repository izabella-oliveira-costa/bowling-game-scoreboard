namespace BowlingGameScoreboard.Services;

public class BowlingService
{
    public int Calculate(List<int> rolls)
    {
        if (rolls == null || rolls.Count == 0)
            throw new ArgumentException("Rolls cannot be null or empty.");

        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rollIndex >= rolls.Count)
                break;

            if (IsStrike(rolls, rollIndex))
            {
                score += 10
                       + GetRoll(rolls, rollIndex + 1)
                       + GetRoll(rolls, rollIndex + 2);

                rollIndex++;
            }
            else if (IsSpare(rolls, rollIndex))
            {
                score += 10
                       + GetRoll(rolls, rollIndex + 2);

                rollIndex += 2;
            }
            else
            {
                score += GetRoll(rolls, rollIndex)
                       + GetRoll(rolls, rollIndex + 1);

                rollIndex += 2;
            }
        }

        return score;
    }

    private static bool IsStrike(List<int> rolls, int rollIndex)
    {
        return GetRoll(rolls, rollIndex) == 10;
    }

    private static bool IsSpare(List<int> rolls, int rollIndex)
    {
        return GetRoll(rolls, rollIndex)
             + GetRoll(rolls, rollIndex + 1) == 10;
    }

    private static int GetRoll(List<int> rolls, int index)
    {
        return index < rolls.Count ? rolls[index] : 0;
    }
}