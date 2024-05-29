using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthButton : MonoBehaviour
{
    // List of GameObjects to disable
    [SerializeField]
    private List<GameObject> objectsToDisable;

    // List of GameObjects to enable
    [SerializeField]
    private List<GameObject> objectsToEnable;

    // Function to disable and enable the specified GameObjects
    public void ToggleObjects()
    {
        // Disable specified GameObjects
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Enable specified GameObjects
        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
