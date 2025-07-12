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
        //Å@ÉLÅ[Çì¸óÕÇ≥ÇÍÇΩÇ∆Ç´
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpFlag == true)
            {
                rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {

            JumpFlag = true;

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {

            JumpFlag = false;

        }
    }


}

