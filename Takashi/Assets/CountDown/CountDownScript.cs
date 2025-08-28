using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneLoad()
    {

        if (GManager.instance.scoreattack)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("suikaScene");
            return;
        }

        if (GManager.instance.scenenumber == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("suikaScene");
        }
        else if (GManager.instance.scenenumber == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("semiScene");
        }
        else if (GManager.instance.scenenumber == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SomenScene");
        }
        else if (GManager.instance.scenenumber == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("kingyoScene");
        }
        else if (GManager.instance.scenenumber == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("syuku");
        }
    }

    public void finishCountDown()
    {
        Invoke("SceneLoad", 0.5f);
    }
}
