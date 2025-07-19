//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class cameraManager : MonoBehaviour
//{

//    public GameObject target; // 追従する対象を決める変数
//    Vector3 pos;              // カメラの初期位置を記憶するための変数

//    // Start is called before the first frame update
//    void Start()
//    {
//        pos = Camera.main.gameObject.transform.position; //カメラの初期位置を変数posに入れる
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector3 cameraPos = target.transform.localScale; // cameraPosという変数を作り、追従する対象の位置を入れる

//        // もし対象の横位置が0より小さい場合
//        if (target.transform.localScale.x < 5)
//        {
//            cameraPos.x = 5; // カメラの横位置に0を入れる
//        }

//        // もし対象の縦位置が3より小さい場合
//        if (target.transform.localScale.y < 5)
//        {
//            cameraPos.y = 5;  // カメラの縦位置に0を入れる
//        }

//        // もし対象の縦位置が3より大きい場合
//        if (target.transform.localScale.y > 3)
//        {
//            cameraPos.y = target.transform.localScale.y;   // カメラの縦位置に対象の位置を入れる
//        }

//        cameraPos.z = -10; // カメラの奥行きの位置に-10を入れる
//        Camera.main.gameObject.transform.localScale = cameraPos; //　カメラの位置に変数cameraPosの位置を入れる

//    }
//}

using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // インスペクターから設定するPanel（地面）のGameObject
    [SerializeField]
    private GameObject groundPanel;

    // カメラの基準Y座標からのオフセット
    [SerializeField]
    private float heightOffset = 2.0f;

    // Yスケールがこの値以上の場合にカメラを上げる
    [SerializeField]
    private float scaleThreshold = 5.0f;

    // カメラのY座標が変化する速度（スムーズに動かすため）
    [SerializeField]
    private float smoothSpeed = 0.5f;

    private Vector3 initialCameraPosition;

    void Start()
    {
        // カメラの初期Y座標を保存
        initialCameraPosition = transform.position;

        // groundPanelが設定されていない場合の警告
        if (groundPanel == null)
        {
            Debug.LogWarning("Ground Panelが設定されていません。インスペクターで設定してください。", this);
        }
    }

    void LateUpdate()
    {
        // groundPanelが設定されていることを確認
        if (groundPanel != null)
        {
            float panelScaleY = groundPanel.transform.localScale.y;
            Vector3 targetPosition = initialCameraPosition;

            // PanelのYスケールが閾値以上の場合
            if (panelScaleY >= scaleThreshold)
            {
                // カメラの目標Y座標を上げる
                // initialCameraPosition.y に heightOffset を加算
                targetPosition.y = initialCameraPosition.y + heightOffset;
            }
            // PanelのYスケールが閾値未満の場合、元の高さに戻す（オプション）
            else
            {
                targetPosition.y = initialCameraPosition.y;
            }

            // カメラの現在の位置から目標位置へスムーズに移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}