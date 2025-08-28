using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
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
        GManager.instance.scenenumber = 1;
        audioSource.Play();
        Invoke("sceneload", 0.5f);
    }

    public void OnClick2()
    {
        GManager.instance.scenenumber = 1;
        audioSource.Play();
        GManager.instance.scoreattack = true;
        Invoke("CountDownScene", 0.5f);
    }

    public void sceneload()
    {
        SceneManager.LoadScene("suikawari_info");
    }
    public void CountDownScene()
    {
        SceneManager.LoadScene("CountDownScene");
    }
}
