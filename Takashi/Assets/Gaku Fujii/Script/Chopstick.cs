using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopstick : MonoBehaviour
{
    [SerializeField] GameObject chopstick_norm_;

    private Vector3 initial_position_ = new(0.8f, 1f, 0f);
    private Vector3 move_point_       = new(0.5f, 1.5f, 0f);
    private Transform transform_norm_;

    private bool on_click_ = false;

    // Start is called before the first frame update
    void Start()
    {
        transform_norm_ = chopstick_norm_.GetComponent<Transform>();
        transform_norm_.position = initial_position_;

        on_click_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (on_click_)
        {
            transform_norm_.position = Vector3.MoveTowards(transform_norm_.position, move_point_, 5f);
            StartCoroutine(ClickCoroutine());
        }
        else
        {
            transform_norm_.position = Vector3.MoveTowards(transform_norm_.position, initial_position_, 5f);
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
