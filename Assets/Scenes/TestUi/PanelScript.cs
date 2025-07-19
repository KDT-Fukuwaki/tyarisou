using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public GameObject Plane;
    GameObject[] step = new GameObject[10];
    float speed = 20;
    float disappear = -30;
    float respawn = 30;

    /// <summary>
    /// 一定の基準値より大きいか比較　
    /// </summary>
    /// <param name="scaleThreshold"></param>
    /// <returns></returns>
    public bool IsScaleThresholdPlus(float standard_pos, float scaleThreshold)
    {
        for(int i=0;i<step.Length;i++)
        {
            var scale =  step[i].transform.localScale;
            if (scale.y >= standard_pos + scaleThreshold) return true;
        }
        return false;
    }

    public bool IsScaleThresholdMinus(float standard_pos, float scaleThreshold)
    {
        for (int i = 0; i < step.Length; i++)
        {
            var scale = step[i].transform.localScale;
            if (scale.y <= standard_pos - scaleThreshold) return true;
        }
        return false;
    }


    void Start()
    {
        for (int i = 0; i < step.Length; i++)
        {
            step[i] = Instantiate(Plane, new Vector3(4 * i, 0, 0), Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < step.Length; i++)
        {
            step[i].gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (step[i].gameObject.transform.position.x < disappear)
            {
                ChangeScale(i);
                step[i].gameObject.transform.position = new Vector3(respawn, 0, 0);
            }
        }
    }
    void ChangeScale(int i)
    {
        int x = (i + 9) % 10; //(i+9)を10で割った余りをxとする。
        if (step[x].transform.localScale.y == 0.5)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(0, 2), 0);
        }
        else
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-1, 2), 0);
        }
    }

}
