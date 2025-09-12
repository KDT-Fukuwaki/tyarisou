using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour 
{
    [SerializeField, Header("�X�N���[�����x")]
    private float scrollSpeed = 1f;   // �w�i���Ƃɑ��x��ݒ�

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
        // ���Ԍo�߂œ�����
        float dist = Mathf.Repeat(Time.time * scrollSpeed, length);

        transform.position = new Vector3(startPosX - dist, transform.position.y, transform.position.z);
    }
}
    
