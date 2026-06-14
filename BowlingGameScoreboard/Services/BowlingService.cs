namespace BowlingGameScoreboard.Services;

public class BowlingService
{
    public int Calculate(List<int> rolls)
    {
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
        return rolls[rollIndex]
             + rolls[rollIndex + 1] == 10;
    }
}