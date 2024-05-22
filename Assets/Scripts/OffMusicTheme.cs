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

    public void OnMuteMusic()
    {
        if (sliderMusic != null)
        {
            sliderMusic.SetActive(true);
        }

    }

    public void OnShowThemeList()
    {
        if (themeList != null)
        {
            themeList.SetActive(true);
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
