using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
 
public class GameOverScript : MonoBehaviour {

	//�@��~���ɕ\������UI
	[SerializeField]
	private GameObject gameoverUI;

 
	// Start is called before the first frame update
	void Start() {

		//�@�X�^�[�g���ɃQ�[���I�[�o�[UI���\���ɂ���
		gameoverUI.SetActive(false);
	}
 

	// Update is called once per frame
	void Update() {
		//�@��ʊO���ɃQ�[���I�[�o�[�\��

		
	}


	//UI�̕\����\��
/*	public void SetActive(bool isActive)
	{
		gameoverUI.SetActive(isActive);
	} */



}