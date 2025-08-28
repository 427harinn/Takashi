using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    [SerializeField] GameObject[] diary;

    int[] active;
    int count = 0;

    public void OnClick()
    {
        Debug.Log("osareta!!!!");
        count++;
        for(int i = 0; i < diary.Length; i++)
        {
            active[i] = 0;
        }
        if (count > diary.Length - 1)
        {
            count = 0;
        }
        active[count] = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        active = new int[diary.Length];
        for(int i = 0; i < diary.Length; i++)
        {
            active[i] = 0;
            diary[i].SetActive(false);
        }
        active[0] = 1;
        diary[active[0]].SetActive(true);     
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < diary.Length; i++)
        {
            if(active[i] == 1)
            {
                diary[i].SetActive(true);
            }
            else if(active[i] == 0)
            {
                diary[i].SetActive(false);
            }
        }

        
    }


}
