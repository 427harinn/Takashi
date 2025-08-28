using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backTitle : MonoBehaviour
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

    public void onClicked()
    {
        audioSource.Play();
        Invoke("toTitle", 0.5f);
    }

    public void toTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
