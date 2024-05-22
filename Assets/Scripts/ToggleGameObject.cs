using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject primeMenu;

    public void ActiveBackButton()
    {
        if (settingsMenu != null && primeMenu != null)
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                primeMenu.SetActive(true);
            }
            else if (primeMenu.activeSelf)
            {
                settingsMenu.SetActive(true);
                primeMenu.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Settings Menu or Prime Menu GameObject is not assigned.");
        }
    }
}
