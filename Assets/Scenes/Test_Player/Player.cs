using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    enum player{
    zero, 
    one,
    two
        };


    public Rigidbody2D rd;

    public float JumpPower = 100;

    public bool JumpFlag = false;

    int jump_situation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
       // Debug.Log($"地面判定 : {JumpFlag}");
        //　キーを入力されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump_situation++;
            Debug.Log($"地面判定 : {jump_situation}");
            if (jump_situation <= 2)
            {
                if (JumpFlag == true)
                {
                 rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

                }
            }
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "floor")
        {
            JumpFlag = true;
           
        }
     
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (jump_situation >=2)
        {
            if (collision.gameObject.tag == "floor")
            {
                JumpFlag = false;
                jump_situation=0;
            }
        }
    }
}// class

