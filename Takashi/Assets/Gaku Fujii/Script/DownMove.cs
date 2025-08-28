using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMove : MonoBehaviour
{
    private Transform transform_;
    private Vector3 move_point_ = new(-0.3f, -10.0f, 0.0f);
    private float move_speed_;
    List<float> index_list = new List<float>() { 10f, 15f, 15f, 15f, 20f, 15f, 15f, 12f, 18f, 10f, 10f };

    // Start is called before the first frame update
    void Start()
    {
        transform_ = GetComponent<Transform>();

        for (int i = index_list.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            (index_list[j], index_list[i]) = (index_list[i], index_list[j]);
        }

        if (index_list[0] > 15f)
        {
            index_list[0] = 15f;
        }

        move_speed_ = index_list[Random.Range(0, index_list.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("speed: " + move_speed_);
        transform.position = Vector3.MoveTowards(transform.position, move_point_, move_speed_ * Time.deltaTime);
    }
}
