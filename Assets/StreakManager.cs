
public class StreakManager
{
    public int CurrentStreak { get; private set; }
    public int MaxStreak { get; private set; }

    // 勝利時
    public void Win()
    {
        CurrentStreak++;

        if (CurrentStreak > MaxStreak)
        {
            MaxStreak = CurrentStreak;
        }
    }

    // 敗北時
    public void Lose()
    {
        CurrentStreak = 0;
    }

    // 引き分け時（何もしない）
    public void Draw()
    {
        // current streakを維持
    }

    // 初期化
    public void Reset()
    {
        CurrentStreak = 0;
        MaxStreak = 0;
    }
}
