using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Test_Player : MonoBehaviour
{

    //Move�֐����g����悤�ɂ��邽�߂Ɏ������Ă��܂��B
    //Move�֐��̒��g�̏���
    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) >= 0)
        {
            //Quaternion rot = transform.rotation;s

            //transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);

            // Vector3(x,y,z);
            var pos = transform.position;
            pos.x += 0.5f;
            pos.y += 0;
            transform.position = pos;
        }

       
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per fram

    void Update()
    {
        // Horizontal->���E�̓��͂�ΏۂƂ���
        // Vertical->�㉺�̓��͂�ΏۂƂ���
        //  �v����ɂ��̏��������������ĂȂ���΂O�A���E�L�[���������΁A�|1�`�P�̊Ԃ̒l��Ԃ��B

        float x = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        Move(x, jump);
    }
}
