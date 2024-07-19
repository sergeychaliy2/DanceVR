using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [Header("Toggle")][Space]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject primeMenu;

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
    }
}
