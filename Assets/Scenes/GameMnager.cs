using UnityEngine;
using UnityEngine.UI;  // UIを操作するために必要
using UnityEngine.SceneManagement;
using System.Diagnostics;  // シーン管理

public class GameManager : MonoBehaviour
{
    public GameObject player;           // プレイヤーオブジェクト
    public float gameOverY = -10f;      // ゲームオーバーのY座標
    public GameObject gameOverMenu;     // ゲームオーバーメニューUIオブジェクト
    public GameObject gameOverPanel;     // ゲームオーバーメニューUIオブジェクト
    public Text gameOverText1;           // ゲームオーバーのメッセージ（m）
    public Text gameOverText2;           // ゲームオーバーのメッセージ（s）
    public ScoreManager scoreManager;   // スコアを管理するスクリプト
    public ScoreManager2 scoreManager2;   // スコア2を管理するスクリプト

    private bool isGameOver = false;
    private RectTransform m_rectTfm;

    void Start()
    {
        m_rectTfm = player.GetComponent<RectTransform>();
        gameOverPanel.SetActive(false);  // メニューを表示
    }

    void Update()
    {
        // プレイヤーが指定したY座標を下回ったらゲームオーバー
        if (m_rectTfm.position.y < gameOverY && !isGameOver)
        {
            isGameOver = true;
        }

        if (isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {  
        // ゲームオーバーメニューを表示
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // メニューを表示
        }

        // スコアの更新を停止
        if (scoreManager != null && scoreManager2 != null)
        {
            scoreManager.enabled = false;  // ScoreManagerを無効にしてスコアを更新しない
            scoreManager2.enabled = false;  // ScoreManagerを無効にしてスコアを更新しない
        }

        // ゲームオーバーメニューを表示
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);  // メニューを表示
        }

        // ゲームオーバーメッセージにスコアを表示
        if (gameOverText1 != null)
        {
            gameOverText1.text = $"Game Over\nScore: {scoreManager.score_num}m\n";
            gameOverText2.text = $"Time: {scoreManager2.score_num:F1}s\n";
        }
    }

}
