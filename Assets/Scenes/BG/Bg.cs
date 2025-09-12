using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour 
{
    [SerializeField, Header("スクロール速度")]
    private float scrollSpeed = 1f;   // 背景ごとに速度を設定

    private float length;
    private float startPosX;

    void Start()
    {
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        // 時間経過で動かす
        float dist = Mathf.Repeat(Time.time * scrollSpeed, length);

        transform.position = new Vector3(startPosX - dist, transform.position.y, transform.position.z);
    }
}
    
