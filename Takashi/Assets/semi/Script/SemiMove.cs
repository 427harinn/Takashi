using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiMove : MonoBehaviour
{
    bool isCry;     // ���Ă��邩�ǂ���
    public bool isGet;     // �߂܂������ǂ��� ���n�߂��葁�������ꂽ��߂܂����Ȃ�
    float shakeSpeed; // �h��鑬��

    [SerializeField] Timer timer; // Timer�X�N���v�g�ւ̎Q�� 
    [SerializeField] Sound sound; // Sound�X�N���v�g�ւ̎Q��
    [SerializeField] semiButtonScript button; // ButtonScript�X�N���v�g�ւ̎Q��

    Vector3 eulerAngles;
    Vector3 targetPsision;


    public void OnClick()
    {
        if (timer.cryToClickInterval > 0)
        {
            isGet = true;
            isCry = false;
        }
        else
        {
            isGet = false;
            isCry = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        isCry = false;
        isGet = false;
        shakeSpeed = 0.5f;
        targetPsision = new Vector3(-4.0f, 6.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCry && Time.time > sound.timeElapsed)
        {
            isCry = true;
        }

        //�@���Ă���Ƃ��A���߂܂��Ă��Ȃ��Ƃ�
        if (isCry && !isGet)
        {
            // transform���擾
            Transform myTransform = this.transform;

            // ���[�J�����W����ɁA��]���擾
            eulerAngles = myTransform.eulerAngles;

            if (eulerAngles.z > 10.0f || eulerAngles.z < -10.0f)
            {
                shakeSpeed = -shakeSpeed;
            }
            eulerAngles.z += shakeSpeed;

            myTransform.eulerAngles = eulerAngles; // ��]�p�x��ݒ�

        }
        Debug.Log(eulerAngles.z);

        // �{�^�������������߂܂��Ă��Ȃ���������
        if (!isGet && button.pushButton)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPsision, 0.3f);
        }


    }
}
