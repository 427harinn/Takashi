using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMove : MonoBehaviour
{
    private Transform transform_;
    private Vector3 move_point_ = new(-0.3f, -10.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        transform_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float move_speed = Random.Range(10.0f, 30.0f);
        transform.position = Vector3.MoveTowards(transform.position, move_point_, move_speed * Time.deltaTime);
    }
}
