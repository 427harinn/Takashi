using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/*
 * GameManager 
 */
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] somen_;        /// @brief Somen Array
    [SerializeField] GameObject success_;
    [SerializeField] GameObject failure_;
    [SerializeField] ScreenArea screen_area_;
    [SerializeField] TriggerArea trigger_area_;
    private GameObject somen_instance_;                     /// @brief Generated Somen

    [SerializeField] AudioClip fall_se_;
    AudioSource audio_source_;

    List<int> index_list = new List<int>() { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, };

    public static bool is_game_finished_ = false;   /// @brief 
    bool is_generate_ = false;                  /// @brief 
    bool is_play_finished_ = false;                 /// @brief
    bool is_interval_ = false;                  /// @brief 

    const int kMaxSomen = 10;              /// @brief 
    int current_generated_somen_ = 0;               /// @brief 

    const int kSuccessScore = 12;              /// @brief
    const int kFailureScore = 12;              /// @brief
    private int score_;                             /// @brief 

    // Start is called before the first frame update
    void Start()
    {


        is_play_finished_ = false;
        is_game_finished_ = false;
        is_interval_ = false;
        is_generate_ = false;
        current_generated_somen_ = 0;
        score_ = 0;

        audio_source_ = GetComponent<AudioSource>();

        for (int i = index_list.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            (index_list[j], index_list[i]) = (index_list[i], index_list[j]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IsGameFinished: " + is_game_finished_);
        if (current_generated_somen_ == kMaxSomen && !is_play_finished_)
        {
            if (GManager.instance.scoreattack)
            {
                GManager.instance.scenenumber = 4;
                UnityEngine.SceneManagement.SceneManager.LoadScene("kingyoScene");
                GManager.instance.score[GManager.instance.scenenumber - 1] = GetSomenScore();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("nikki_soumen");
                GManager.instance.score[GManager.instance.scenenumber - 1] = GetSomenScore();
            }
            StartCoroutine(FinishCoroutine());
            is_play_finished_ = true;

        }

        if (is_game_finished_)
        {
            Debug.Log("Score: " + score_);
            CalcScore();
            return;
        }

        if (is_play_finished_)
        {
            Debug.Log("PlayFinished");
            return;
        }

        Debug.Log("Generated: " + current_generated_somen_);

        if (!is_generate_ && !is_interval_ && !screen_area_.IsObjectExist())
        {
            is_generate_ = true;
            GenerateSomen();
        }

        if (is_generate_ && !is_interval_ && !screen_area_.IsObjectExist())
        {
            is_interval_ = true;
            StartCoroutine(IntervalCoroutine());
        }

    }

    void GenerateSomen()
    {
        int value;

        if (current_generated_somen_ < kMaxSomen)
        {
            value = index_list[current_generated_somen_];
        }
        else
        {
            value = index_list[9];
        }

        somen_instance_ = Instantiate(somen_[value],
                transform.position, Quaternion.identity);

        audio_source_.PlayOneShot(fall_se_);

        current_generated_somen_++;
    }

    IEnumerator IntervalCoroutine()
    {
        yield return new WaitForSeconds(1f);
        is_interval_ = false;
        is_generate_ = false;
    }

    IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(2f);
        is_game_finished_ = true;


    }


    void CalcScore()
    {
        if (trigger_area_.GetFailure() == 0 && trigger_area_.GetSuccess() == 8)
        {
            Debug.Log("Full Score!");
            score_ = 100;
            return;
        }

        Debug.Log("Score!");
        int success = trigger_area_.GetSuccess() * kSuccessScore;
        int failure = trigger_area_.GetFailure() * kFailureScore;

        score_ = success + failure;
    }

    /// @TODO スコアはここから取得してください！！よろしくお願いします！！藤井より
    public int GetSomenScore()
    {
        return score_;
    }

    public bool GetIsGameFinished()
    {
        return is_game_finished_;
    }
}