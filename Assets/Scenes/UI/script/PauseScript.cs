using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
 
public class PauseScript : MonoBehaviour {
	//　停止中に表示するUI
	[SerializeField]
	private GameObject pauseUI;
 
	// Start is called before the first frame update
	void Start() {
       
        //　スタート時にポーズUIを非表示にする
        pauseUI.SetActive(false);
	}
 

	// Update is called once per frame
	void Update() {
		//　ポーズボタンを押した時
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

	//UIの表示非表示
	public void SetActive(bool isActive)
	{
        pauseUI.SetActive(isActive);
    }


}