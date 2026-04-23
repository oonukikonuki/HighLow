
using UnityEngine;
using TMPro;

public class HighLowGameManager : MonoBehaviour
{
    public TextMeshProUGUI cardText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI streakText;

    int currentCard;

    // 🔹 連勝管理を委譲
    StreakManager streakManager = new StreakManager();

    void Start()
    {
        DrawFirstCard();
        UpdateStreakUI();
    }

    void DrawFirstCard()
    {
        currentCard = Random.Range(1, 14);
        cardText.text = currentCard.ToString();
        resultText.text = "";
    }

    public void OnHighButton()
    {
        Judge(true);
    }

    public void OnLowButton()
    {
        Judge(false);
    }

    void Judge(bool isHigh)
    {
        int nextCard = Random.Range(1, 14);

        // 🔸 DRAW
        if (nextCard == currentCard)
        {
            resultText.text = "DRAW";
            streakManager.Draw();
        }
        else
        {
            bool isWin = isHigh
                ? nextCard > currentCard
                : nextCard < currentCard;

            if (isWin)
            {
                resultText.text = "WIN!";
                streakManager.Win();
            }
            else
            {
                resultText.text = "LOSE...";
                streakManager.Lose();
            }
        }

        currentCard = nextCard;
        cardText.text = currentCard.ToString();
        UpdateStreakUI();
    }

    void UpdateStreakUI()
    {
        streakText.text =
            $"Current Streak: {streakManager.CurrentStreak}\n" +
            $"Max Streak: {streakManager.MaxStreak}";
    }
}
