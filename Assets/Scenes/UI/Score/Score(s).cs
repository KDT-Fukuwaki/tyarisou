using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // �ǉ�


public class ScoreManager2 : MonoBehaviour
{


    public GameObject score_object = null; // Text�I�u�W�F�N�g
    public int score_num = 0; // �X�R�A�ϐ�
    int frame = 0;
    bool enable = true;

    // ������
    void Start()
    {
        score_num = 0;
        frame = 0;
        m_testTime = 0;
        enable = true;
    }


    float m_testTime;


    // �X�V
    void Update()
    {
        if (enable) { 
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();

        m_testTime += Time.deltaTime;
        score_text.text = $"{(int)m_testTime,4:D0}s";
        }

    }
}