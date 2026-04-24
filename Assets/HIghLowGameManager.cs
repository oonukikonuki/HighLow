
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighLowGameManager : MonoBehaviour
{
    // ===== UI参照 =====
    [Header("UI References")]
    public TextMeshProUGUI cardText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI streakText;
    public TextMeshProUGUI loseCountText;
    public GameObject retryButton;

    // ===== ゲーム状態 =====
    int currentCard;
    bool isGameOver = false;

    // ===== ルール管理 =====
    List<IGameRule> rules = new List<IGameRule>();

    // LoseLimitRule は Retry ボタンから使うため保持
    LoseLimitRule loseLimitRule;

    // ===== Unity Start =====
    void Start()
    {
        // --- ルール登録 ---
        rules.Add(new StreakRule(streakText));

        loseLimitRule = new LoseLimitRule(
            loseCountText,
            retryButton,
            OnGameOver,
            ResetGame
        );
        rules.Add(loseLimitRule);

        // --- Retry ボタン設定 ---
        retryButton.GetComponent<Button>()
            .onClick.AddListener(() => loseLimitRule.Retry());

        // --- ルール初期化 ---
        foreach (var rule in rules)
        {
            rule.OnGameStart();
        }

        DrawFirstCard();
    }

    // ===== 最初のカード =====
    void DrawFirstCard()
    {
        currentCard = Random.Range(1, 14);
        cardText.text = currentCard.ToString();
        resultText.text = "";
    }

    // ===== ボタン入力 =====
    public void OnHighButton()
    {
        Judge(true);
    }

    public void OnLowButton()
    {
        Judge(false);
    }

    // ===== 勝敗判定 =====
    void Judge(bool isHigh)
    {
        // ★ 追加：ゲームオーバー時は入力無効
        if (isGameOver)
        {
            return;
        }

        int nextCard = Random.Range(1, 14);
        GameResult result;

        // --- 判定 ---
        if (nextCard == currentCard)
        {
            result = GameResult.Draw;
        }
        else if (
            (isHigh && nextCard > currentCard) ||
            (!isHigh && nextCard < currentCard)
        )
        {
            result = GameResult.Win;
        }
        else
        {
            result = GameResult.Lose;
        }

        // --- 表示更新 ---
        currentCard = nextCard;
        cardText.text = currentCard.ToString();
        resultText.text = result.ToString().ToUpper();

        // --- ルールに結果通知 ---
        foreach (var rule in rules)
        {
            rule.OnResult(result);
        }
    }

    // ===== ゲームオーバー処理 =====
    void OnGameOver()
    {
        isGameOver = true;
    }

    // ===== リトライ処理 =====
    void ResetGame()
    {
        isGameOver = false;

        foreach (var rule in rules)
        {
            rule.OnGameStart();
        }

        DrawFirstCard();
    }
}
