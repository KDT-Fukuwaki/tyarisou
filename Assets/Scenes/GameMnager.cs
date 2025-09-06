using UnityEngine;
using UnityEngine.UI;  // UI�𑀍삷�邽�߂ɕK�v
using UnityEngine.SceneManagement;  // �V�[���Ǘ�

public class GameManager : MonoBehaviour
{
    public GameObject player;           // �v���C���[�I�u�W�F�N�g
    public float gameOverY = -10f;      // �Q�[���I�[�o�[��Y���W
    public GameObject gameOverMenu;     // �Q�[���I�[�o�[���j���[UI�I�u�W�F�N�g
    public Text gameOverText1;           // �Q�[���I�[�o�[�̃��b�Z�[�W�im�j
    public Text gameOverText2;           // �Q�[���I�[�o�[�̃��b�Z�[�W�is�j
    public ScoreManager scoreManager;   // �X�R�A���Ǘ�����X�N���v�g
    public ScoreManager2 scoreManager2;   // �X�R�A2���Ǘ�����X�N���v�g
    //public GameObject retry;
    //public GameObject end;

    private bool isGameOver = false;

    void Update()
    {
        // �v���C���[���w�肵��Y���W�����������Q�[���I�[�o�[
        if (player.transform.position.y < gameOverY && !isGameOver)
        {
            GameOver();
        }

    }

    //public void OnRestartButtonClicked()
    //{
    //    Debug.Log("�Ē���{�^�����N���b�N����܂����I");
    //    // �����ɃQ�[���̃��Z�b�g������ǉ�����

    //    RestartGame();
    //}

    //// �I���{�^�����N���b�N���ꂽ�Ƃ��̓���
    //public void OnQuitButtonClicked()
    //{
    //    Debug.Log("�I���{�^�����N���b�N����܂����I");
    //    Application.Quit();
    //    QuitGame();
    //}


    void GameOver()
    {
        isGameOver = true;

        // �X�R�A�̍X�V���~
        if (scoreManager != null)
        {
            scoreManager.enabled = false;  // ScoreManager�𖳌��ɂ��ăX�R�A���X�V���Ȃ�
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

//    // �Ē���{�^���̏���
//    public void RestartGame()
//    {
//        // �Q�[���I�[�o�[��Ԃ����Z�b�g
//        isGameOver = false;

//        // �v���C���[�������ʒu�ɖ߂�
//        player.transform.position = new Vector3(0, 0, 0);

//        // �X�R�A�ƃ^�C�}�[�����Z�b�g
//        if (scoreManager != null)
//        {
//            scoreManager.score_num = 0;
//            scoreManager.frame = 0;
//            scoreManager.enabled = true;  // ScoreManager��L���ɂ��ăX�R�A���X�V

//            scoreManager2.score_num = 0;
//            scoreManager2.enabled = true;  // ScoreManager2��L���ɂ��ăX�R�A���X�V

//        }

//        // �Q�[���I�[�o�[���j���[���\���ɂ���
//        if (gameOverMenu != null)
//        {
//            gameOverMenu.SetActive(false);
//        }
//    }

//    // �Q�[���I���{�^���̏���
//    public void QuitGame()
//    {
//        // �A�v���P�[�V�������I��
//        Debug.Log("Quit Game");
//        Application.Quit();

//        // �G�f�B�^�ł̓���m�F�p
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
//    }
}
