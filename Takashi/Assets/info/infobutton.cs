using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class infobutton : MonoBehaviour
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

    public void OnClick()
    {
        audioSource.Play();
        Invoke("sceneload", 0.5f);
    }

    public void sceneload()
    {
        SceneManager.LoadScene("CountDownScene");
    }
}
