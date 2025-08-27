using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
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
        GManager.instance.scenenumber = 1;
        Invoke("sceneload", 0.5f);
    }

    public void sceneload()
    {
        SceneManager.LoadScene("suikawari_info");
    }
}
