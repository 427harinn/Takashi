using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public int[] score = new int[5]; //1:すいかわり 2:セミ 3:そうめん 4:金魚 5:しゅくだい

    public int scenenumber = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}