using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        /*Debug.Log("リトライが押された!");*/  // ログを出力

        //　ポーズUIを非表示にする
        GameObject pauseUI = GameObject.Find("Pause");
        if (pauseUI)
        {
            // 現在のシーンを再ロードします
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Pauseについている<PauseScript>を取得する
            var pauseScript = pauseUI.GetComponent<PauseScript>();
            pauseScript.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("Pauseが見つかりません。");
        }
    }

}
