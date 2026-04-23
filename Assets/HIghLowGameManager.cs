using UnityEngine;
using TMPro;

public class HighLowGameManager : MonoBehaviour
{
    public TextMeshProUGUI cardText;

    int currentCard;

    void Start()
    {
        DrawNewCard();
    }

    void DrawNewCard()
    {
        currentCard = Random.Range(1, 14);
        cardText.text = currentCard.ToString();

        Debug.Log("Current Card: " + currentCard);
    }

    public void OnHighButton()
    {
        Debug.Log("HIGH button pressed");
        DrawNewCard();
    }

    public void OnLowButton()
    {
        Debug.Log("LOW button pressed");
        DrawNewCard();
    }
}