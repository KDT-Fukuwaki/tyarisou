using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加


public class ScoreManager2 : MonoBehaviour
{


    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数
    int frame = 0;
    bool enable = true;

    // 初期化
    void Start()
    {
        score_num = 0;
        frame = 0;
        m_testTime = 0;
        enable = true;
    }


    float m_testTime;


    // 更新
    void Update()
    {
        if (enable) { 
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();

        m_testTime += Time.deltaTime;
        score_text.text = $"{(int)m_testTime,4:D0}s";
        }

    }
}