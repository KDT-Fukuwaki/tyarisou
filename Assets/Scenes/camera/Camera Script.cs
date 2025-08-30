using System.Diagnostics;
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

    Transform m_tfm;


    PlaneScript m_planeScript;

    // 基準値変数
    float standard_pos;

    void Start()
    {
        // カメラの初期Y座標を保存
        initialCameraPosition = transform.position;
        m_tfm = transform;
        // groundPanelが設定されていない場合の警告
        if (groundPanel == null)
        {
            UnityEngine.Debug.LogWarning("Ground Panelが設定されていません。インスペクターで設定してください。", this);
        }

        m_planeScript = groundPanel.GetComponent<PlaneScript>();

        // 基準値変数　＝　現在のcamera座標
        standard_pos = m_tfm.position.y;

    }

    void LateUpdate()
    {

        // groundPanelが設定されていることを確認
        if (groundPanel != null)
        {
            float panelScaleY = groundPanel.transform.localScale.y;
            Vector3 targetPosition = m_tfm.position;

            UnityEngine.Debug.Log($"カメラ座標 : {targetPosition.y}");

            // PanelのYスケールが閾値以上の場合
            //if (panelScaleY >= scaleThreshold)

            // 基準値変数が指定数より多きとき
            // if (true){ camera座標を増加　基準値変数　＝　現在のcamera座標｝
            if (m_planeScript.IsScaleThresholdPlus(standard_pos, scaleThreshold))
            {
                // カメラの目標Y座標を上げる
                // initialCameraPosition.y に heightOffset を加算
                targetPosition.y = m_tfm.position.y + heightOffset;
                UnityEngine.Debug.Log($"+デバック確認");

                standard_pos = m_tfm.position.y;


            }

            // 基準値変数が指定数より小さいとき
            // if(true) { camera座標を現象　基準値変数 ＝　現在のcamera座標｝
            if (m_planeScript.IsScaleThresholdMinus(standard_pos, 4.5f))
            {
                // カメラの目標Y座標を上げる
                // initialCameraPosition.y に heightOffset を加算
                targetPosition.y = m_tfm.position.y - heightOffset;
                UnityEngine.Debug.Log($"-デバック確認");

                standard_pos = m_tfm.position.y;


            }



            // カメラの現在の位置から目標位置へスムーズに移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}