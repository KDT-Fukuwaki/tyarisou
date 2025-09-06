using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加

public class ScoreManager : MonoBehaviour
{

    public GameObject score = null; // Textオブジェクト
    public int score_num = 0; // スコア変数
    public float frame = 0;
    public bool enable = true;

    // 初期化
    void Start()
    {
        score_num = 0;
        frame = 0;
        enable = true;
    }

    // 更新
    void Update()
    {
        if (enable) { 

            frame++;
            // test (スコア増加)
            if(frame % 30 == 0) { 
                score_num += 1;
            }
            // オブジェクトからTextコンポーネントを取得
            Text score_text = score.GetComponent<Text>();
            // テキストの表示を入れ替える
            score_text.text = score_num + "m";

        }
    }
}
