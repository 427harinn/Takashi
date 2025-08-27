using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextSemi : MonoBehaviour
{
    [SerializeField] Text KeyText;
    [SerializeField] Timer timer;              // Timerスクリプトへの参照
    [SerializeField] GameObject result_text;   // 結果表示用のテキスト

    // Update is called once per frame
    void Update()
    {
        // 結果判定タイム
        if (timer.resultTime < Time.time && timer.resultTime != 0.0f)
        {
            result_text.SetActive(true);

            int score = 0;

            if (timer.cryToClickInterval > 0)
            {
                // スコア判定
                float interval = timer.cryToClickInterval;

                if (interval <= 0.35f)
                {
                    score = 100;
                }
                else if (interval <= 0.40f)
                {
                    score = 90;
                }
                else if (interval <= 0.55f)
                {
                    score = 80;
                }
                else if (interval <= 0.70f)
                {
                    score = 70;
                }
                else
                {
                    score = 0; // 判定外は0点
                }

                // 表示
                KeyText.text = interval.ToString("N3") + "秒";
            }
            else
            {
                KeyText.text = "ざんねん....";
                score = 0;
            }

            // スコア格納
            if (GManager.instance != null && GManager.instance.score != null)
            {
                int index = GManager.instance.scenenumber - 1;
                GManager.instance.score[index] = score;
            }

            // 1秒後にシーン遷移
            Invoke("loadscene", 1.0f);
        }

        // ゲーム終了タイム
        if (timer.gameEndTime < Time.time)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void loadscene()
    {
        SceneManager.LoadScene("nikki_semi");
    }
}
