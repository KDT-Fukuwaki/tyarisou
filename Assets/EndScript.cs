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

    // �A�v���P�[�V�������I��
    UnityEngine.Debug.Log("Quit Game");
        UnityEngine.Application.Quit();

        // �G�f�B�^�ł̓���m�F�p
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
