using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class TextSemi : MonoBehaviour
{
    
    [SerializeField] Text KeyText;
    [SerializeField] Timer timer; // Timer�X�N���v�g�ւ̎Q�� 
    [SerializeField] GameObject result_text; // ���ʕ\���p�̃e�L�X�g


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.resultTime < Time.time && timer.resultTime != 0.0f)
        {
            result_text.SetActive(true);
            if (timer.cryToClickInterval > 0)
            {
                KeyText.text = timer.cryToClickInterval.ToString("N3") + "�b";
            }
            else
            {
                KeyText.text = "�������Ă��܂���....";
            }
        }

        if(timer.gameEndTime < Time.time)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}