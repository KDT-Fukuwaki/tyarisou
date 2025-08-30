using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;



public class Player : MonoBehaviour
{
    //　これはひつようないわ↓
    enum player{
    zero, 
    one,
    two
        };


    public Rigidbody2D rd;

    public float JumpPower = 100;
    //　jumpFlag　の初期化（最初はfalse）
    public bool JumpFlag = false;
    //　二段ジャンプを可能にする変数
    int jump_situation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        // transformを取得
        //Transform myTransform = this.transform;

        // Debug.Log($"地面判定 : {JumpFlag}");
        //　キーを入力されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //　キーが押されたらjumpsituationのカウントを進める
            jump_situation++;
            //　確認、デバッグ用
            UnityEngine.Debug.Log($"地面判定 : {jump_situation}");
            //　jumpsituationを使用して二階までjumpを可能にする
            if (jump_situation <= 2)
            {
                if (JumpFlag == true)
                {
                    //　jumpFlagがtrueになった時、Y軸方向に移動量をプラスする
                    rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }

   /// <summary>
   /// 床のタイルとの当たり判定を確認＆jumpに関連する処理の実行
   /// </summary>
   /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //　床のタイルと当たったらjumpFlagをtureにしてjumpを可能にする
        if (collision.gameObject.tag == "floor")
        {
            JumpFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //　ジャンプは二回までしかさせたくないので、jump回数を制限しつつ床のタイルに触れるとjumpsituationを０にする + jumpflagをfalseにする↓
        if (jump_situation >=2)
        {
            if (collision.gameObject.tag == "floor")
            {
                JumpFlag = false;
                jump_situation=0;
            }
        }
    }


    /*追加*/
    private void OnTriggerEnter2D(Collider2D collision)
    {

   if (collision.gameObject.tag == "GameOver")
        {
            UnityEngine.Debug.Log("ゲームオーバー");
        }

    }



}// class

