using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
 
public class PauseScript : MonoBehaviour {
	//�@��~���ɕ\������UI
	[SerializeField]
	private GameObject pauseUI;
 
	// Start is called before the first frame update
	void Start() {
       
        //�@�X�^�[�g���Ƀ|�[�YUI���\���ɂ���
        pauseUI.SetActive(false);
	}
 
	// Update is called once per frame
	void Update() {
		//�@�|�[�Y�{�^������������
		if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseUI.SetActive(true);
			if (Mathf.Approximately(Time.timeScale, 1f)) {
                Time.timeScale = 0f;
            } else {
				pauseUI.SetActive(false);
				Time.timeScale = 1f;
			}
		}
	}
}