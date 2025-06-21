using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Test_Player : MonoBehaviour
{

    //Move関数を使えるようにするために実装しています。
    //Move関数の中身の処理
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
        // Horizontal->左右の入力を対象とする
        // Vertical->上下の入力を対象とする
        //  要するにこの処理を何も押してなければ０、左右キーが押されれば、－1～１の間の値を返す。

        float x = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        Move(x, jump);
    }
}
