using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class ResultText : MonoBehaviour
{
    [SerializeField] Text[] resulttext;
    [SerializeField] Text totalscoretext;
    [SerializeField] Sprite[] hankos;
    [SerializeField] Image hankoimage;
    int scoresum = 0;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < resulttext.Length; i++)
        {
            scoresum += GManager.instance.score[i];
            resulttext[i].text = GManager.instance.score[i].ToString() + "点";
        }
        if (scoresum >= 450)
        {
            hankoimage.sprite = hankos[0];
        }
        else if (scoresum >= 350)
        {
            hankoimage.sprite = hankos[1];
        }
        else
        {
            hankoimage.sprite = hankos[2];
        }

        totalscoretext.text = scoresum.ToString() + "点";
        UnityroomApiClient.Instance.SendScore(1, scoresum, ScoreboardWriteMode.Always);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
