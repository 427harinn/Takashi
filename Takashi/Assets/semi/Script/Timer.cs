using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float onClickTime = 0.0f;           // �{�^���������ꂽ����
    public float resultTime = 0.0f;     // ���ʕ\���p�̎���
    public float gameEndTime = 0.0f;    // �Q�[���I������
    public float timeElapsed = 0.0f;    // �Z�~�����n�߂鎞��
    float addRandomTime = 0.0f;         // �����_���Ȏ��Ԃ�ݒ� 

    public float cryToClickInterval = 0.0f;    // �Z�~�����n�߂Ă���{�^�����������܂ł̎���
    [SerializeField] Sound sound;       // Sound�X�N���v�g�ւ̎Q��

    public void OnClick()
    {
        Debug.Log("�����ꂽ!");  // ���O���o��
        onClickTime = Time.time;
        resultTime = onClickTime + 0.5f;
        cryToClickInterval = onClickTime - timeElapsed;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameEndTime = Time.time + 15.0f;
        addRandomTime = Random.Range(0.0f, 6.0f); // 0~5�b�̃����_���Ȏ��Ԃ�ݒ�
        timeElapsed = Time.time + 5.0f + addRandomTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "�N���b�N����(�b)" + cryToClickInterval);
        Debug.Log( "�o�ߎ���(�b)" + Time.time);

        
    }
}
