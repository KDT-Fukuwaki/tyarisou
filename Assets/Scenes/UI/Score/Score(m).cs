using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // �ǉ�

public class ScoreManager : MonoBehaviour
{

    public GameObject score = null; // Text�I�u�W�F�N�g
    public int score_num = 0; // �X�R�A�ϐ�
    public float frame = 0;
    public bool enable = true;

    // ������
    void Start()
    {
        score_num = 0;
        frame = 0;
        enable = true;
    }

    // �X�V
    void Update()
    {
        if (enable) { 

            frame++;
            // test (�X�R�A����)
            if(frame % 30 == 0) { 
                score_num += 1;
            }
            // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
            Text score_text = score.GetComponent<Text>();
            // �e�L�X�g�̕\�������ւ���
            score_text.text = score_num + "m";

        }
    }
}
