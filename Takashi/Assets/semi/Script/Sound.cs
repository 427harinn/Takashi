using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource source1;
    [SerializeField] private AudioSource source2;
    [SerializeField] private AudioSource source3;
    [SerializeField] private AudioSource source4;


    [SerializeField] private AudioClip crySemi;
    [SerializeField] private AudioClip moveNet;
    [SerializeField] private AudioClip getFalse;
    [SerializeField] private AudioClip getTrue;


    [SerializeField] SemiMove semi; // SemiMove�X�N���v�g�ւ̎Q��
    [SerializeField] semiButtonScript buttoun; // ButtonScript�X�N���v�g�ւ̎Q��
    [SerializeField] Timer timer; // ButtonScript�X�N���v�g�ւ̎Q��
    [SerializeField] SadMove sad; // SadMove�X�N���v�g�ւ̎Q��

    bool isPlayed = false;
    bool isPlayedResult = false;

    public void OnClick()
    {
        // �{�^���������ꂽ�Ƃ��̏���
        source1.Stop();
        // ��(sound2)��炷
        source2.PlayOneShot(moveNet);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Component���擾
        //source1 = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 鳴くときの処理
        if (Time.time > timer.timeElapsed && !isPlayed)
        {
            // ��(sound1)��炷
            source1.PlayOneShot(crySemi);
            isPlayed = true;
        }

        // 鳴くよりも前に捕まえようとしたときの処理
        if (Time.time < timer.timeElapsed && buttoun.pushButton && !isPlayed)
        {
            // ��(sound1)��炷
            source1.PlayOneShot(crySemi);
            isPlayed = true;
        }

        if (timer.resultTime < Time.time && timer.resultTime != 0.0f && !isPlayedResult)
        {
            // 捕まえたときの処理
            if (semi.isGet)
            {
                // ��(sound3)��炷
                source4.PlayOneShot(getTrue);
                isPlayedResult = true;
            }
            else
            {
                // ��(sound2)��炷
                source3.PlayOneShot(getFalse);
                isPlayedResult = true;
                sad.SetMoveFlag(true);
            }
        }



    }
}
