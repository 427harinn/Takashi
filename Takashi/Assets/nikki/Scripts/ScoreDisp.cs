using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text scoretext;
    void Start()
    {
        scoretext.text = GManager.instance.score[GManager.instance.scenenumber - 1].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
