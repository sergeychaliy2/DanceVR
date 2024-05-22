using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeActive : MonoBehaviour
{
    public GameObject modeDance;
    public GameObject modeHelth;
    public GameObject modeSport;
    public GameObject primeMenu;

    public void ActiveMode()
    {
        primeMenu.SetActive(false);
        modeDance.SetActive(true);
        modeHelth.SetActive(true);
        modeSport.SetActive(true);
    }
}
