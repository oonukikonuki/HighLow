
using TMPro;
using UnityEngine;

public class LoseLimitRule : IGameRule
{
    const int MAX_LOSE = 3;

    int loseCount = 0;

    TextMeshProUGUI loseText;
    GameObject retryButton;

    System.Action onGameOver;
    System.Action onRetry;

    public LoseLimitRule(
        TextMeshProUGUI loseText,
        GameObject retryButton,
        System.Action onGameOver,
        System.Action onRetry
    )
    {
        this.loseText = loseText;
        this.retryButton = retryButton;
        this.onGameOver = onGameOver;
        this.onRetry = onRetry;
    }

    public void OnGameStart()
    {
        loseCount = 0;
        UpdateUI();
        retryButton.SetActive(false);
    }

    public void OnResult(GameResult result)
    {
        if (result != GameResult.Lose) return;

        loseCount++;
        UpdateUI();

        if (loseCount >= MAX_LOSE)
        {
            onGameOver?.Invoke();
            retryButton.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        if (loseText == null) return;

        loseText.text = new string('×', loseCount);
    }

    // RetryButton 用（GameManagerから呼ばれる）
    public void Retry()
    {
        loseCount = 0;
        UpdateUI();
        retryButton.SetActive(false);
        onRetry?.Invoke();
    }
}
