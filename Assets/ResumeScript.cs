using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
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
        //Debug.Log("押された!");  // ログを出力

        //　ポーズUIを非表示にする
        GameObject pauseUI = GameObject.Find("Pause");
        if (pauseUI)
        {
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
