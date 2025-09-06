using UnityEngine;

public class EndScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() { 

    // アプリケーションを終了
    UnityEngine.Debug.Log("Quit Game");
        UnityEngine.Application.Quit();

        // エディタでの動作確認用
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
