using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMusicManager : MusicManager
{
    public override void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("Sound");

        if(objs.Length == 0)
        {   
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic";
        }
        else
        {
              BGMusic = GameObject.Find("BGMusic");
        }
        //DontDestroyOnLoad(volumeUI);   
    }
}
