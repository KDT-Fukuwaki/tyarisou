using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
 
public class GameOverScript : MonoBehaviour {

	//　停止中に表示するUI
	[SerializeField]
	private GameObject gameoverUI;

 
	// Start is called before the first frame update
	void Start() {

		//　スタート時にゲームオーバーUIを非表示にする
		gameoverUI.SetActive(false);
	}
 

	// Update is called once per frame
	void Update() {
		//　画面外時にゲームオーバー表示

		
	}


	//UIの表示非表示
/*	public void SetActive(bool isActive)
	{
		gameoverUI.SetActive(isActive);
	} */



}