using UnityEngine;



public class Test_Player : MonoBehaviour
{
    int jump_mode = 0;
    int jump_frame = 0;

    Rigidbody2D m_rb;

    //Move関数を使えるようにするために実装しています。
    //Move関数の中身の処理
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
        m_rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得

    }

    // Update is called once per fram

    void Update()
    {
        // Horizontal->左右の入力を対象とする
        // Vertical->上下の入力を対象とする
        //  要するにこの処理を何も押してなければ０、左右キーが押されれば、－1～１の間の値を返す。

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
        //重力処理関係
        Vector3 force = new Vector3(0.0f, 100.0f, 100.0f);    // 力を設定
        m_rb.AddForce(force);  // 力を加える

    }
}
