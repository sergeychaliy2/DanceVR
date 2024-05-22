using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffMusicTheme : MonoBehaviour
{
    public GameObject sliderMusic;
    public GameObject themeList;

    public void MuteMusic()
    {
        if (sliderMusic != null)
        {
            sliderMusic.SetActive(false);
        }

    }

    public void OffShowThemeList()
    {
        if (themeList != null)
        {
            themeList.SetActive(false);
        }
    }

    public void AllMusicTheme()
    {
        if (sliderMusic != null && themeList != null)
        {
            sliderMusic.SetActive(false);
            themeList.SetActive(false);
        }

    }
}
