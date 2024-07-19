using UnityEngine;
using UnityEngine.UI;

public class ToggleThemeList : MonoBehaviour
{
    [Header("Type Theme")]
    [SerializeField] private GameObject themeList;
    public void ToggleThemeListVisibility()
    {
        if (themeList != null)
        {
            themeList.SetActive(!themeList.activeSelf);
        }
    }
}
