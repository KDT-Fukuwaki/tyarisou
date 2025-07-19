//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class cameraManager : MonoBehaviour
//{

//    public GameObject target; // �Ǐ]����Ώۂ����߂�ϐ�
//    Vector3 pos;              // �J�����̏����ʒu���L�����邽�߂̕ϐ�

//    // Start is called before the first frame update
//    void Start()
//    {
//        pos = Camera.main.gameObject.transform.position; //�J�����̏����ʒu��ϐ�pos�ɓ����
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector3 cameraPos = target.transform.localScale; // cameraPos�Ƃ����ϐ������A�Ǐ]����Ώۂ̈ʒu������

//        // �����Ώۂ̉��ʒu��0��菬�����ꍇ
//        if (target.transform.localScale.x < 5)
//        {
//            cameraPos.x = 5; // �J�����̉��ʒu��0������
//        }

//        // �����Ώۂ̏c�ʒu��3��菬�����ꍇ
//        if (target.transform.localScale.y < 5)
//        {
//            cameraPos.y = 5;  // �J�����̏c�ʒu��0������
//        }

//        // �����Ώۂ̏c�ʒu��3���傫���ꍇ
//        if (target.transform.localScale.y > 3)
//        {
//            cameraPos.y = target.transform.localScale.y;   // �J�����̏c�ʒu�ɑΏۂ̈ʒu������
//        }

//        cameraPos.z = -10; // �J�����̉��s���̈ʒu��-10������
//        Camera.main.gameObject.transform.localScale = cameraPos; //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������

//    }
//}

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

    void Start()
    {
        // �J�����̏���Y���W��ۑ�
        initialCameraPosition = transform.position;

        // groundPanel���ݒ肳��Ă��Ȃ��ꍇ�̌x��
        if (groundPanel == null)
        {
            Debug.LogWarning("Ground Panel���ݒ肳��Ă��܂���B�C���X�y�N�^�[�Őݒ肵�Ă��������B", this);
        }
    }

    void LateUpdate()
    {
        // groundPanel���ݒ肳��Ă��邱�Ƃ��m�F
        if (groundPanel != null)
        {
            float panelScaleY = groundPanel.transform.localScale.y;
            Vector3 targetPosition = initialCameraPosition;

            // Panel��Y�X�P�[����臒l�ȏ�̏ꍇ
            if (panelScaleY >= scaleThreshold)
            {
                // �J�����̖ڕWY���W���グ��
                // initialCameraPosition.y �� heightOffset �����Z
                targetPosition.y = initialCameraPosition.y + heightOffset;
            }
            // Panel��Y�X�P�[����臒l�����̏ꍇ�A���̍����ɖ߂��i�I�v�V�����j
            else
            {
                targetPosition.y = initialCameraPosition.y;
            }

            // �J�����̌��݂̈ʒu����ڕW�ʒu�փX���[�Y�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}