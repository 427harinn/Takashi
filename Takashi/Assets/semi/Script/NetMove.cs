using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMove : MonoBehaviour
{
    Vector3 targetPsision;
    bool is_move = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPsision = new Vector3(0.6f, -3.8f, 0.0f);
    }
    public void OnClick()
    {
        is_move = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPsision, 5.0f);

        }

    }
}
