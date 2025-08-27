using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/*
 * GameManager 
 */
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] somen_;           /// @brief Somen Array
    [SerializeField] GameObject success_;
    [SerializeField] GameObject failure_;
    [SerializeField] ScreenArea generated_;         /// @brief Exit

    GameObject generate_somen_;                     /// @brief Generated Somen

    bool is_generate_ = false;                  /// @brief �������ꂽ������
    bool is_interval_ = false;                  /// @brief �L�����N�^�[�����̊Ԋu�𐧌�
    bool is_touch_screen_ = false;                  /// @brief �{�^�����z�o�[����Ă��邩
    bool is_started_ = false;                  /// @brief �Q�[���J�n��Ԃ��Ǘ�

    public static bool is_finished_ = false;        /// @brief �Q�[���I������

    const int kMaxSomen = 10;                       /// @brief Somen �̍ő吔 
    int current_somen_ = 0;                        /// @brief ���݂�Somen ��

    int score_;                                     /// @brief �X�R�A���Ǘ�
    [SerializeField] TextMeshProUGUI score_text_;   /// @brief �X�R�A�\���p��TextMeshProUGUI

    // Start is called before the first frame update
    void Start()
    {
        is_finished_ = false;
        is_generate_ = false;
        is_interval_ = true;
        is_touch_screen_ = false;
        is_started_ = false;
        current_somen_ = 0;

        score_ = 0;
        score_text_.text = score_.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_finished_) return;

        if (!is_started_)
        {
            StartCoroutine(IntervalCoroutine());
        }

        //! somen_����������Ă��Ȃ��A����somen_�����݂��Ȃ��Ƃ�
        if (!is_generate_ && !is_interval_ && !CheckExistSomen())
        {
            CreateSomen();
            generated_.is_screen_in_ = true;
            is_generate_ = true;
        }

        if (!CheckExistSomen())
        {
            is_generate_ = false;
            is_interval_ = true;
            StartCoroutine(IntervalCoroutine());
        }

        //! current_somen_ ���ő�l�𒴂����Ƃ��Q�[���I��
        if (current_somen_ > kMaxSomen) is_finished_ = true;
    }

    void CreateSomen()
    {
        generate_somen_ = Instantiate(somen_[Random.Range(0, somen_.Length)],
            transform.position, Quaternion.identity);

        current_somen_++;
    }

    IEnumerator IntervalCoroutine()
    {
        yield return new WaitForSeconds(3f);
        is_interval_ = false;
        is_started_ = true;
    }

    bool CheckExistSomen()
    {
        return generated_.is_screen_in_;
    }

    void UpdateScore()
    {
        score_++;
        score_text_.text = score_.ToString();
    }
}