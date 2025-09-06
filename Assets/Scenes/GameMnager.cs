using UnityEngine;
using UnityEngine.UI;  // UIを操作するために必要
using UnityEngine.SceneManagement;  // シーン管理

public class GameManager : MonoBehaviour
{
    public GameObject player;           // プレイヤーオブジェクト
    public float gameOverY = -10f;      // ゲームオーバーのY座標
    public GameObject gameOverMenu;     // ゲームオーバーメニューUIオブジェクト
    public Text gameOverText1;           // ゲームオーバーのメッセージ（m）
    public Text gameOverText2;           // ゲームオーバーのメッセージ（s）
    public ScoreManager scoreManager;   // スコアを管理するスクリプト
    public ScoreManager2 scoreManager2;   // スコア2を管理するスクリプト
    //public GameObject retry;
    //public GameObject end;

    private bool isGameOver = false;

    void Update()
    {
        // プレイヤーが指定したY座標を下回ったらゲームオーバー
        if (player.transform.position.y < gameOverY && !isGameOver)
        {
            GameOver();
        }

    }

    //public void OnRestartButtonClicked()
    //{
    //    Debug.Log("再挑戦ボタンがクリックされました！");
    //    // ここにゲームのリセット処理を追加する

    //    RestartGame();
    //}

    //// 終了ボタンがクリックされたときの動作
    //public void OnQuitButtonClicked()
    //{
    //    Debug.Log("終了ボタンがクリックされました！");
    //    Application.Quit();
    //    QuitGame();
    //}


    void GameOver()
    {
        isGameOver = true;

        // スコアの更新を停止
        if (scoreManager != null)
        {
            scoreManager.enabled = false;  // ScoreManagerを無効にしてスコアを更新しない
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

//    // 再挑戦ボタンの処理
//    public void RestartGame()
//    {
//        // ゲームオーバー状態をリセット
//        isGameOver = false;

//        // プレイヤーを初期位置に戻す
//        player.transform.position = new Vector3(0, 0, 0);

//        // スコアとタイマーをリセット
//        if (scoreManager != null)
//        {
//            scoreManager.score_num = 0;
//            scoreManager.frame = 0;
//            scoreManager.enabled = true;  // ScoreManagerを有効にしてスコアを更新

//            scoreManager2.score_num = 0;
//            scoreManager2.enabled = true;  // ScoreManager2を有効にしてスコアを更新

//        }

//        // ゲームオーバーメニューを非表示にする
//        if (gameOverMenu != null)
//        {
//            gameOverMenu.SetActive(false);
//        }
//    }

//    // ゲーム終了ボタンの処理
//    public void QuitGame()
//    {
//        // アプリケーションを終了
//        Debug.Log("Quit Game");
//        Application.Quit();

//        // エディタでの動作確認用
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
//    }
}
