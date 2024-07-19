using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthButton : MonoBehaviour
{
    // List of GameObjects to disable
    [SerializeField] private List<GameObject> objectsToDisable;
    [Space]
    // List of GameObjects to enable
    [SerializeField] private List<GameObject> objectsToEnable;
    public void ToggleObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
