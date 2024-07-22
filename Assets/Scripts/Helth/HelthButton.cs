using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToDisable;
    [Space]
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
