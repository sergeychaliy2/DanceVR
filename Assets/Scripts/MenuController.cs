using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject primeMenuButton;
    public GameObject exitConfirmation;

    //off PrimeMenuButton
    public void ShowExitConfirmation()
    {
        if (primeMenuButton != null && exitConfirmation != null)
        {
            primeMenuButton.SetActive(false);
            exitConfirmation.SetActive(true);
        }
    }
    //on PrimeMenuButton
    public void HideExitConfirmation()
    {
        if (primeMenuButton != null && exitConfirmation != null)
        {
            primeMenuButton.SetActive(true);
            exitConfirmation.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
