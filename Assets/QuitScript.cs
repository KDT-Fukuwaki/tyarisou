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

    // �{�^���������ꂽ�ꍇ
    /* ���݂̓Q�[���I���ɂ��Ă��܂� */
    public void OnClick()
    {
        /*Debug.Log("�z�[���������ꂽ!");*/  // ���O���o��

#if UNITY_EDITOR
        // Unity�G�f�B�^�[�ł̓���
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ���ۂ̃Q�[���I������
        Application.Quit();
#endif
    }

}
