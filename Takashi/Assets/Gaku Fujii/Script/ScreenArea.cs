using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��ʊO�ɏo���I�u�W�F�N�g������
 */
public class ScreenArea : MonoBehaviour
{
    public bool is_screen_in_;
    private void Start()
    {
        is_screen_in_ = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Somen"))    {
            is_screen_in_ = false;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Not Somen")) {
            is_screen_in_ = false;
            Destroy(collision.gameObject);
        }
    }
}
