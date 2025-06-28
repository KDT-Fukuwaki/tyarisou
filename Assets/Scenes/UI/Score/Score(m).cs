using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加

public class ScoreManager : MonoBehaviour
{

    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数

    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = score_num + "m";

        // test (スコア増加)
        score_num += 1;

    }
}