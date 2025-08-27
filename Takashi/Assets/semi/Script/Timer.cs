using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float onClickTime = 0.0f;           // ボタンが押された時間
    public float resultTime = 0.0f;              // 結果表示用の時間
    public float gameEndTime = 0.0f;          // ゲーム終了時間

    public float cryToClickInterval = 0.0f;    // セミが鳴き始めてからボタンが押されるまでの時間
    [SerializeField] Sound sound;       // Soundスクリプトへの参照

    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        onClickTime = Time.time;
        resultTime = onClickTime + 1.0f;
        cryToClickInterval = onClickTime - sound.timeElapsed;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameEndTime = Time.time + 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "クリック時間(秒)" + cryToClickInterval);
        Debug.Log( "経過時間(秒)" + Time.time);

        if (Time.time > resultTime && resultTime != 0.0f)
        {
            
        }

    }
}
