using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{
    Vector3 Posision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Posision = transform.position;
        Posision.x += 0.0005f;
        transform.position = Posision;
    }
}
