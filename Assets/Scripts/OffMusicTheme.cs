using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMusicThemeController
{
    void MuteMusic();
    void OffShowThemeList();
    void OnMuteMusic();
    void OnShowThemeList();
    void AllMusicTheme();
}

public class OffMusicTheme : MonoBehaviour, IMusicThemeController
{
    [Header("Music Theme"),Space] 
    [SerializeField] private GameObject sliderMusic;
    [SerializeField] private GameObject themeList;

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
