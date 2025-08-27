using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickMiss : MonoBehaviour
{
    [SerializeField] GameObject chopstick_miss_;
    [SerializeField] GameObject chopstick_norm_;

    private Vector3 initial_position_ = new(0.24f, 1.52f, 0.0f);
    private Transform transform_;

    // Start is called before the first frame update
    void Start()
    {
        transform_ = chopstick_miss_.GetComponent<Transform>();
        transform_.position = initial_position_;
    }

    // Update is called once per frame
    void Update()
    {
        if (chopstick_miss_.activeSelf)
        {
            StartCoroutine(ClickCoroutine());
        }
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        chopstick_norm_.SetActive(true);
        chopstick_miss_.SetActive(false);
    }

    public void OnClick()
    {
    }

}
