using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rd;

    public float JumpPower = 100;

    public bool JumpFlag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        Debug.Log($"地面判定 : {JumpFlag}");
        //　キーを入力されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpFlag == true)
            {
                rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

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
        if (collision.gameObject.tag == "floor")
        {
            JumpFlag = false;
        }
    }
}// class

