using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;

    AudioSource audioSource;

    [SerializeField] SemiMove semi; // SemiMove�X�N���v�g�ւ̎Q��
    [SerializeField] semiButtonScript buttoun; // ButtonScript�X�N���v�g�ւ̎Q��

    bool isPlayed = false;
    public float timeElapsed = 0.0f;   //�@�Z�~���������܂ł̎���
    float addRandomTime = 0.0f; // �����_���ɒǉ����鎞��

    public void OnClick()
    {
        // �{�^���������ꂽ�Ƃ��̏���
        audioSource.Stop();
        // ��(sound2)��炷
        audioSource.PlayOneShot(sound2);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Component���擾
        audioSource = GetComponent<AudioSource>();
        addRandomTime = Random.Range(0.0f, 6.0f); // 0�`5�b�̃����_���Ȏ��Ԃ�ǉ�
        timeElapsed = Time.time + 5.0f + addRandomTime; // 5�b��ɉ���炷
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log( "�Đ��J�n����(�b)" + timeElapsed);
        // ���Ԍo�߂ŉ���炷
        if (Time.time > timeElapsed && !isPlayed)
        {
            // ��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            isPlayed = true;
        }

        if (Time.time < timeElapsed && buttoun.pushButton && !isPlayed)
        {

            // ��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            isPlayed = true;
        }


        //if(semi.isGet)
        //{
        //    audioSource.Stop();
        //}
    }
}
