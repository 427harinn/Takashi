using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void finishAnim()
    {
        audioSource.Play();
        Invoke("sceneload", 0.5f);
    }

    public void sceneload()
    {
        GManager.instance.scenenumber += 1;

        if (GManager.instance.scenenumber == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("semi_info");
        }
        else if (GManager.instance.scenenumber == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("somen_info");
        }
        else if (GManager.instance.scenenumber == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("kingyo_info");
        }
        else if (GManager.instance.scenenumber == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("syuku_info");
        }
        else if (GManager.instance.scenenumber == 6)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("resultScene");
        }
    }
}
