using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class TextSemi : MonoBehaviour
{
    
    [SerializeField] Text KeyText;
    [SerializeField] Timer timer; // Timerスクリプトへの参照 
    [SerializeField] GameObject result_text; // 結果表示用のテキスト


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
                KeyText.text = timer.cryToClickInterval.ToString("N3") + "秒";
            }
            else
            {
                KeyText.text = "逃げられてしまった....";
            }
        }

        if(timer.gameEndTime < Time.time)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}