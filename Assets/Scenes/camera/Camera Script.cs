using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // �C���X�y�N�^�[����ݒ肷��Panel�i�n�ʁj��GameObject
    [SerializeField]
    private GameObject groundPanel;

    // �J�����̊Y���W����̃I�t�Z�b�g
    [SerializeField]
    private float heightOffset = 2.0f;

    // Y�X�P�[�������̒l�ȏ�̏ꍇ�ɃJ�������グ��
    [SerializeField]
    private float scaleThreshold = 5.0f;

    // �J������Y���W���ω����鑬�x�i�X���[�Y�ɓ��������߁j
    [SerializeField]
    private float smoothSpeed = 0.5f;

    private Vector3 initialCameraPosition;

    PlaneScript m_planeScript;

    // ��l�ϐ�
    float standard_pos;

    void Start()
    {
        // �J�����̏���Y���W��ۑ�
        initialCameraPosition = transform.position;

        // groundPanel���ݒ肳��Ă��Ȃ��ꍇ�̌x��
        if (groundPanel == null)
        {
            Debug.LogWarning("Ground Panel���ݒ肳��Ă��܂���B�C���X�y�N�^�[�Őݒ肵�Ă��������B", this);
        }

        m_planeScript = groundPanel.GetComponent<PlaneScript>();

        // ��l�ϐ��@���@���݂�camera���W
        standard_pos = initialCameraPosition.y;

    }

    void LateUpdate()
    {

        // groundPanel���ݒ肳��Ă��邱�Ƃ��m�F
        if (groundPanel != null)
        {
            float panelScaleY = groundPanel.transform.localScale.y;
            Vector3 targetPosition = initialCameraPosition;

            // Panel��Y�X�P�[����臒l�ȏ�̏ꍇ
            //if (panelScaleY >= scaleThreshold)

            // ��l�ϐ����w�萔��葽���Ƃ�
            // if (true){ camera���W�𑝉��@��l�ϐ��@���@���݂�camera���W�p
            if (m_planeScript.IsScaleThresholdPlus(standard_pos,scaleThreshold))
            {
                // �J�����̖ڕWY���W���グ��
                // initialCameraPosition.y �� heightOffset �����Z
                targetPosition.y = initialCameraPosition.y + heightOffset;
                Debug.Log($"+�f�o�b�N�m�F");

                standard_pos = initialCameraPosition.y;


            }

            // ��l�ϐ����w�萔��菬�����Ƃ�
            // if(true) { camera���W�����ہ@��l�ϐ� ���@���݂�camera���W�p
            if (m_planeScript.IsScaleThresholdMinus(standard_pos,scaleThreshold))
            {
                // �J�����̖ڕWY���W���グ��
                // initialCameraPosition.y �� heightOffset �����Z
                targetPosition.y = initialCameraPosition.y - heightOffset;
                Debug.Log($"-�f�o�b�N�m�F");

                standard_pos = initialCameraPosition.y;


            }



            // �J�����̌��݂̈ʒu����ڕW�ʒu�փX���[�Y�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}