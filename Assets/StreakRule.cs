using TMPro;

public class StreakRule : IGameRule
{
    int currentStreak = 0;
    int maxStreak = 0;

    TextMeshProUGUI streakText;

    public StreakRule(TextMeshProUGUI streakText)
    {
        this.streakText = streakText;
    }

    public void OnGameStart()
    {
        currentStreak = 0;
        maxStreak = 0;
        UpdateUI();
    }

    public void OnResult(GameResult result)
    {
        switch (result)
        {
            case GameResult.Win:
                currentStreak++;
                if (currentStreak > maxStreak)
                    maxStreak = currentStreak;
                break;

            case GameResult.Lose:
                currentStreak = 0;
                break;

            case GameResult.Draw:
                // 何もしない
                break;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (streakText == null) return;

        streakText.text =
            $"Current Streak: {currentStreak}\n" +
            $"Max Streak: {maxStreak}";
    }
}