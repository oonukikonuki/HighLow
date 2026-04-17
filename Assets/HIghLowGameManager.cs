using UnityEngine;
using TMPro;

public class HighLowGameManager : MonoBehaviour
{
    public TextMeshProUGUI cardText;

    void Start()
    {
        int cardNumber = Random.Range(1, 14);
        cardText.text = cardNumber.ToString();

        Debug.Log("Card Number: " + cardNumber);
    }
}
