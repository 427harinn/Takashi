using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopstick : MonoBehaviour
{
    [SerializeField] GameObject chopstick_miss_;
    [SerializeField] GameObject chopstick_norm_;
    private Vector3 initial_position_   = new(0.81f, 1.0f,  0.0f);
    private Vector3 move_point_         = new(0.24f, 1.52f, 0.0f);
    Transform transform_norm_;

    private bool on_click_ = false;
    private bool on_hit_   = false;

    // Start is called before the first frame update
    void Start()
    {
        transform_norm_ = chopstick_norm_.GetComponent<Transform>();
        transform_norm_.position = initial_position_;

        on_click_ = false; 
        on_hit_ = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Somen"))     {
            on_hit_ = true;
        }

        if (collision.CompareTag("Not Somen")) {
            on_hit_ = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Somen"))     {
            on_hit_ = false;
        }
        if (collision.CompareTag("Not Somen")) {
            on_hit_ = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on_hit_ && on_click_) {
            transform_norm_.position = Vector3.MoveTowards(transform_norm_.position, move_point_, 5f);
            StartCoroutine(ClickCoroutine());
        }
        else{
            transform_norm_.position = Vector3.MoveTowards(transform_norm_.position, initial_position_, 5f);
        }

        if (!on_hit_ && on_click_) {
            on_click_ = false;
            chopstick_miss_.SetActive(true);
            chopstick_norm_.SetActive(false);
        }
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        on_click_ = false;
    }

    public void OnClick()
    {
        on_click_ = true;
    }

}
