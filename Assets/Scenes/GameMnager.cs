using UnityEngine;
using UnityEngine.UI;  // UI�𑀍삷�邽�߂ɕK�v
using UnityEngine.SceneManagement;
using System.Diagnostics;  // �V�[���Ǘ�

public class GameManager : MonoBehaviour
{
    public GameObject player;           // �v���C���[�I�u�W�F�N�g
    public float gameOverY = -10f;      // �Q�[���I�[�o�[��Y���W
    public GameObject gameOverMenu;     // �Q�[���I�[�o�[���j���[UI�I�u�W�F�N�g
    public GameObject gameOverPanel;     // �Q�[���I�[�o�[���j���[UI�I�u�W�F�N�g
    public Text gameOverText1;           // �Q�[���I�[�o�[�̃��b�Z�[�W�im�j
    public Text gameOverText2;           // �Q�[���I�[�o�[�̃��b�Z�[�W�is�j
    public ScoreManager scoreManager;   // �X�R�A���Ǘ�����X�N���v�g
    public ScoreManager2 scoreManager2;   // �X�R�A2���Ǘ�����X�N���v�g

    private bool isGameOver = false;
    private RectTransform m_rectTfm;

    void Start()
    {
        m_rectTfm = player.GetComponent<RectTransform>();
        gameOverPanel.SetActive(false);  // ���j���[��\��
    }

    void Update()
    {
        // �v���C���[���w�肵��Y���W�����������Q�[���I�[�o�[
        if (m_rectTfm.position.y < gameOverY && !isGameOver)
        {
            isGameOver = true;
        }

        if (isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {  
        // �Q�[���I�[�o�[���j���[��\��
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // ���j���[��\��
        }

        // �X�R�A�̍X�V���~
        if (scoreManager != null && scoreManager2 != null)
        {
            scoreManager.enabled = false;  // ScoreManager�𖳌��ɂ��ăX�R�A���X�V���Ȃ�
            scoreManager2.enabled = false;  // ScoreManager�𖳌��ɂ��ăX�R�A���X�V���Ȃ�
        }

        // �Q�[���I�[�o�[���j���[��\��
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);  // ���j���[��\��
        }

        // �Q�[���I�[�o�[���b�Z�[�W�ɃX�R�A��\��
        if (gameOverText1 != null)
        {
            gameOverText1.text = $"Game Over\nScore: {scoreManager.score_num}m\n";
            gameOverText2.text = $"Time: {scoreManager2.score_num:F1}s\n";
        }
    }

}
