using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float onClickTime = 0.0f;           // ボタンが押された時間
    public float resultTime = 0.0f;     // 結果表示用の時間
    public float gameEndTime = 0.0f;    // ゲーム終了時間
    public float timeElapsed = 0.0f;    // セミが鳴き始める時間
    float addRandomTime = 0.0f;         // ランダムな時間を設定 

    public float cryToClickInterval = 0.0f;    // セミが鳴き始めてからボタンが押されるまでの時間
    [SerializeField] Sound sound;       // Soundスクリプトへの参照

    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        onClickTime = Time.time;
        resultTime = onClickTime + 0.5f;
        cryToClickInterval = onClickTime - timeElapsed;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameEndTime = Time.time + 15.0f;
        addRandomTime = Random.Range(0.0f, 6.0f); // 0~5秒のランダムな時間を設定
        timeElapsed = Time.time + 5.0f + addRandomTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "クリック時間(秒)" + cryToClickInterval);
        Debug.Log( "経過時間(秒)" + Time.time);

        
    }
}
