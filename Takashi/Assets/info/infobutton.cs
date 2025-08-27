using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class infobutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Invoke("sceneload", 0.5f);
    }

    public void sceneload()
    {
        SceneManager.LoadScene("CountDownScene");
    }
}
