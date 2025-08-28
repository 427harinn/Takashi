using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    bool is_interval_ = false;                  /// @brief 

    const int kMaxSomen = 10;              /// @brief 
    int current_generated_somen_ = 0;               /// @brief 

    const int kSuccessScore = 12;              /// @brief
    const int kFailureScore = -12;             /// @brief
    private int score_;                             /// @brief 

    // Start is called before the first frame update
    void Start()
    {
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
        if (current_generated_somen_ == kMaxSomen)
        {
            is_game_finished_ = true;
            GManager.instance.score[GManager.instance.scenenumber - 1] = GetSomenScore();
            if (GManager.instance.scoreattack)
            {
                Invoke("sceneload2", 0.5f);
            }
            else
            {
                Invoke("sceneload", 0.5f);
            }

        }

        if (is_game_finished_)
        {
            Debug.Log("Score: " + score_);
            CalcScore();
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
        int value = index_list[current_generated_somen_];

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

    /// @TODO �X�R�A�͂�������擾���Ă��������I�I��낵�����肢���܂��I�I������
    public int GetSomenScore()
    {
        return score_;
    }

    public int GetCurrentGeneratedSomen()
    {
        return current_generated_somen_;
    }

    public bool GetIsSomenGameFinished()
    {
        return is_game_finished_;
    }

    public void sceneload()
    {
        SceneManager.LoadScene("nikki_soumen");
    }

    public void sceneload2()
    {
        GManager.instance.scenenumber = 4;
        SceneManager.LoadScene("kingyoScene");
    }
}