using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject primeMenu;

    public void ActiveBackButton()
    {
        if (settingsMenu != null && primeMenu != null)
        {
            // ���� settingsMenu ��������, ��������� ��� � �������� primeMenu
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                primeMenu.SetActive(true);
            }
            // ���� primeMenu ��������, ��������� ��� � �������� settingsMenu
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
