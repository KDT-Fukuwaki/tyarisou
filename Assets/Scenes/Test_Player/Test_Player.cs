using UnityEngine;



public class Test_Player : MonoBehaviour
{
    int jump_mode = 0;
    int jump_frame = 0;

    Rigidbody2D m_rb;

    //Move�֐����g����悤�ɂ��邽�߂Ɏ������Ă��܂��B
    //Move�֐��̒��g�̏���
    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) >= 0)
        {
            //Quaternion rot = transform.rotation;s

            //transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);

            // Vector3(x,y,z);
            //var pos = transform.position;
            //pos.x += 0.5f;
            //pos.y += 0;
            //transform.position = pos;
        }
        if (jump == true)
        {
            jump_mode = 1;
        }
       
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = this.GetComponent<Rigidbody2D>();  // rigidbody���擾

    }

    // Update is called once per fram

    void Update()
    {
        // Horizontal->���E�̓��͂�ΏۂƂ���
        // Vertical->�㉺�̓��͂�ΏۂƂ���
        //  �v����ɂ��̏��������������ĂȂ���΂O�A���E�L�[���������΁A�|1�`�P�̊Ԃ̒l��Ԃ��B

        //if (jump_mode==1) {
        //    jump_frame +=1;
        //}
        if (jump_mode == 0){
            var pos = transform.position;
            pos.y -= 0.4f;
            transform.position = pos;
        }
        else
        {
            jump_frame +=1; 
        }
        if (jump_mode == 1 && jump_frame <= 120){
            var pos = transform.position;
            pos.x += 0;
            pos.y += 2.0f;
            transform.position = pos;
        }
        else{
            jump_frame = 0;
            jump_mode = 0;
        }

        float x = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        Move(x, jump);
        //�d�͏����֌W
        Vector3 force = new Vector3(0.0f, 100.0f, 100.0f);    // �͂�ݒ�
        m_rb.AddForce(force);  // �͂�������

    }
}
