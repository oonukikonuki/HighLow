using UnityEngine;
using TMPro;

public class HighLowGameManager : MonoBehaviour
{
    public TextMeshProUGUI cardText;
    public TextMeshProUGUI resultText;

    int currentCard;

    void Start()
    {
        DrawFirstCard();
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

        // ① 引き分け判定（最優先）
        if (nextCard == currentCard)
        {
            currentCard = nextCard;
            cardText.text = currentCard.ToString();
            resultText.text = "DRAW";
            return;
        }

        // ② 勝敗判定
        bool isWin;

        if (isHigh)
        {
            isWin = nextCard > currentCard;
        }
        else
        {
            isWin = nextCard < currentCard;
        }

        currentCard = nextCard;
        cardText.text = currentCard.ToString();
        resultText.text = isWin ? "WIN!" : "LOSE...";
    }
}