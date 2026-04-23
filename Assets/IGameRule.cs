public enum GameResult
{
    Win,
    Lose,
    Draw
}

public interface IGameRule
{
    // ゲーム開始時
    void OnGameStart();

    // 勝敗が決まったとき
    void OnResult(GameResult result);

    // UI更新が必要な場合
    void UpdateUI();
}