using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadMove : MonoBehaviour
{
    Vector3 targetPsision;
    bool is_move = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPsision = new Vector3(1.5f, 4.0f, 0.0f);
    }
    
    public void SetMoveFlag(bool flag)
    {
        is_move = flag;
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
