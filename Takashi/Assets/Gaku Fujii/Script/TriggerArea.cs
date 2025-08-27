using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * エリアに入ったオブジェクトを判定
 */
public class TriggerArea : MonoBehaviour
{
    [SerializeField] GameObject success_;
    [SerializeField] GameObject failure_;

    bool on_click_ = false;

    private void Start()
    {
        on_click_ = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Somen")) {
            if (on_click_)   {
                Debug.Log("Somen Click");

                GameObject effect = Instantiate(success_, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(effect, 0.5f);

                return;
            }
        }

        if (collision.CompareTag("Not Somen")) {
            if (on_click_) {
                Debug.Log("Not Somen Click");

                GameObject effect = Instantiate(failure_, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(effect, 0.5f);

                return;
            }
        }
    }

    public void OnClickTrigger(bool is_click)
    {
        on_click_ = is_click;
    }

}
