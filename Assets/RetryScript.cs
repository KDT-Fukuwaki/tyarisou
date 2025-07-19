using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        /*Debug.Log("���g���C�������ꂽ!");*/  // ���O���o��

        //�@�|�[�YUI���\���ɂ���
        GameObject pauseUI = GameObject.Find("Pause");
        if (pauseUI)
        {
            // ���݂̃V�[�����ă��[�h���܂�
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Pause�ɂ��Ă���<PauseScript>���擾����
            var pauseScript = pauseUI.GetComponent<PauseScript>();
            pauseScript.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("Pause��������܂���B");
        }
    }

}
