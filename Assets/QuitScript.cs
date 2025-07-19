using UnityEngine;

public class QuitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ボタンが押された場合
    /* 現在はゲーム終了にしています */
    public void OnClick()
    {
        /*Debug.Log("ホームが押された!");*/  // ログを出力

#if UNITY_EDITOR
        // Unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
    }

}
