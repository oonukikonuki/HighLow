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

    // 最初の1枚を引く
    void DrawFirstCard()
    {
        currentCard = Random.Range(1, 14);
        cardText.text = currentCard.ToString();
        resultText.text = "";
    }

    // HIGHボタン
    public void OnHighButton()
    {
        Judge(true);
    }

    // LOWボタン
    public void OnLowButton()
    {
        Judge(false);
    }

    // 勝敗判定
    void Judge(bool isHigh)
    {
        int nextCard = Random.Range(1, 14);

        bool isWin;

        if (isHigh)
        {
            isWin = nextCard > currentCard;
        }
        else
        {
            isWin = nextCard < currentCard;
        }

        // 次のカードを表示
        currentCard = nextCard;
        cardText.text = currentCard.ToString();

        // 結果表示
        resultText.text = isWin ? "WIN!" : "LOSE...";
    }
}