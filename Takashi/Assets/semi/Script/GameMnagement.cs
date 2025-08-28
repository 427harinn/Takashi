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
    [SerializeField] kirakriaMove kirakira;              // Timerスクリプトへの参照

    [SerializeField] GameObject result_text;   // 結果表示用のテキスト

    Vector3 targetPsision;
    bool is_move = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPsision = new Vector3(0.0f, 2.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 結果判定タイム
        if (timer.resultTime < Time.time && timer.resultTime != 0.0f)
        {
            result_text.SetActive(true);
            is_move = true;
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
                result_text.transform.position = Vector3.MoveTowards(result_text.transform.position, targetPsision, 0.5f);

                kirakira.SetMoveFlag(true);
            }
            else
            {
                KeyText.color = new Color(0, 1, 1, 1); ;
                KeyText.text = "ざんねん....";
                score = 0;
            }

            // スコア格納
            if (GManager.instance != null && GManager.instance.score != null)
            {
                int index = GManager.instance.scenenumber - 1;
                GManager.instance.score[index] = score;
            }

            if (GManager.instance.scoreattack)
            {
                Invoke("loadscene2", 1.0f);
            }
            else
            {
                // 1秒後にシーン遷移
                Invoke("loadscene", 1.0f);
            }

        }

        // ゲーム終了タイム
        if (timer.gameEndTime < Time.time)
        {
            UnityEditor.EditorApplication.isPlaying = false;

        }
    }

    public void loadscene()
    {
        SceneManager.LoadScene("nikki_semi");
    }

    public void loadscene2()
    {
        GManager.instance.scenenumber = 3;
        SceneManager.LoadScene("SomenScene");
    }
}
