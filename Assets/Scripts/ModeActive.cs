using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeActive : MonoBehaviour
{
    [Header("Mode Active")][Space]
    [SerializeField] private GameObject modeDance;
    [SerializeField] private GameObject modeHelth;
    [SerializeField] private GameObject modeSport;
    [SerializeField] private GameObject primeMenu;

    public void ActiveMode()
    {
        primeMenu.SetActive(false);
        modeDance.SetActive(true);
        modeHelth.SetActive(true);
        modeSport.SetActive(true);
    }
}
