using UnityEngine;
using UnityEngine.UI;

public class ToggleThemeList : MonoBehaviour
{
    public GameObject themeList;
    public void ToggleThemeListVisibility()
    {
        if (themeList != null)
        {
            themeList.SetActive(!themeList.activeSelf);
        }
    }
}
