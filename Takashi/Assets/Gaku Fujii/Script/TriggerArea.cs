using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *  ÉGÉäÉAîªíËÇçsÇ§
 */
[RequireComponent(typeof(AudioSource))]
public class TriggerArea : MonoBehaviour
{
    [SerializeField] GameObject success_;
    [SerializeField] GameObject failure_;

    [SerializeField] AudioClip success_se_;
    [SerializeField] AudioClip failure_se_;
    AudioSource audio_source_;

    private bool on_click_ = false;
    private int get_success_;
    private int get_failure_;

    private void Start()
    {
        on_click_ = false;
        get_success_ = 0;
        get_failure_ = 0;

        audio_source_ = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log("Success: " + get_success_ + "  Failure: " + get_failure_);

        if (on_click_)
        {
            StartCoroutine(ClickCoroutine());
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Somen")) {
            if (on_click_)   {
                Debug.Log("Somen Click");
                audio_source_.PlayOneShot(success_se_);

                GameObject effect = Instantiate(success_, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(effect, 0.5f);
                get_success_++;

                return;
            }
        }

        if (collision.CompareTag("Not Somen")) {
            if (on_click_) {
                Debug.Log("Not Somen Click");
                audio_source_.PlayOneShot(failure_se_);

                GameObject effect = Instantiate(failure_, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(effect, 0.5f);
                get_failure_++;

                return;
            }
        }
    }

    public void OnClick()
    {
        on_click_ = true;
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        on_click_ = false;
    }


    public bool GetOnClick()
    {
        return on_click_;
    }

    public int GetSuccess()
    {
        return get_success_;
    }

    public int GetFailure()
    {
        return get_failure_;
    }
}
