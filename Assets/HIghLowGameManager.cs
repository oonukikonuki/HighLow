
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighLowGameManager : MonoBehaviour
{
    public TextMeshProUGUI cardText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI streakText;

    int currentCard;
    List<IGameRule> rules = new List<IGameRule>();

    void Start()
    {
        // ルール登録（ここだけ触る）
        rules.Add(new StreakRule(streakText));

        foreach (var rule in rules)
            rule.OnGameStart();

        DrawFirstCard();
    }

    void DrawFirstCard()
    {
        currentCard = Random.Range(1, 14);
        cardText.text = currentCard.ToString();
        resultText.text = "";
    }

    public void OnHighButton() => Judge(true);
    public void OnLowButton() => Judge(false);

    void Judge(bool isHigh)
    {
        int nextCard = Random.Range(1, 14);
        GameResult result;

        if (nextCard == currentCard)
            result = GameResult.Draw;
        else if (isHigh && nextCard > currentCard ||
                 !isHigh && nextCard < currentCard)
            result = GameResult.Win;
        else
            result = GameResult.Lose;

        currentCard = nextCard;
        cardText.text = currentCard.ToString();
        resultText.text = result.ToString().ToUpper();

        foreach (var rule in rules)
            rule.OnResult(result);
    }
}
