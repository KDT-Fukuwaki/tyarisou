using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;



public class Player : MonoBehaviour
{
    //�@����͂Ђ悤�Ȃ��큫
    enum player{
    zero, 
    one,
    two
        };


    public Rigidbody2D rd;

    public float JumpPower = 100;
    //�@jumpFlag�@�̏������i�ŏ���false�j
    public bool JumpFlag = false;
    //�@��i�W�����v���\�ɂ���ϐ�
    int jump_situation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        // transform���擾
        //Transform myTransform = this.transform;

        // Debug.Log($"�n�ʔ��� : {JumpFlag}");
        //�@�L�[����͂��ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�@�L�[�������ꂽ��jumpsituation�̃J�E���g��i�߂�
            jump_situation++;
            //�@�m�F�A�f�o�b�O�p
            UnityEngine.Debug.Log($"�n�ʔ��� : {jump_situation}");
            //�@jumpsituation���g�p���ē�K�܂�jump���\�ɂ���
            if (jump_situation <= 2)
            {
                if (JumpFlag == true)
                {
                    //�@jumpFlag��true�ɂȂ������AY�������Ɉړ��ʂ��v���X����
                    rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }

   /// <summary>
   /// ���̃^�C���Ƃ̓����蔻����m�F��jump�Ɋ֘A���鏈���̎��s
   /// </summary>
   /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //�@���̃^�C���Ɠ���������jumpFlag��ture�ɂ���jump���\�ɂ���
        if (collision.gameObject.tag == "floor")
        {
            JumpFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�@�W�����v�͓��܂ł������������Ȃ��̂ŁAjump�񐔂𐧌������̃^�C���ɐG����jumpsituation���O�ɂ��� + jumpflag��false�ɂ��遫
        if (jump_situation >=2)
        {
            if (collision.gameObject.tag == "floor")
            {
                JumpFlag = false;
                jump_situation=0;
            }
        }
    }


    /*�ǉ�*/
    private void OnTriggerEnter2D(Collider2D collision)
    {

   if (collision.gameObject.tag == "GameOver")
        {
            UnityEngine.Debug.Log("�Q�[���I�[�o�[");
        }

    }



}// class

