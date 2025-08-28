using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField] Text[] resulttext;
    int scoresum = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < resulttext.Length; i++)
        {
            scoresum += GManager.instance.score[i];
            resulttext[i].text = GManager.instance.score[i].ToString() + "点";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
