using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDiary : MonoBehaviour
{
    [SerializeField] private AudioSource source1;
    [SerializeField] private AudioClip nextPage;

    [SerializeField] private AudioSource source2;
    [SerializeField] private AudioClip bgm;

    public void OnClick()
    {
        source1.PlayOneShot(nextPage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!source2.isPlaying)
        {
            source2.PlayOneShot(bgm);
        }
    }
}
