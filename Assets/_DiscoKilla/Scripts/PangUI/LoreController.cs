using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreController : MonoBehaviour
{
    [SerializeField] private GameObject PanelA;
    [SerializeField] private GameObject PanelB;
    [SerializeField] private GameObject PanelC;
    [SerializeField] private GameObject MainLore;
    private bool isPanelOne;
    private bool isPanelTwo;
    private bool isPanelThree;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StepOne();
    }

    public void StepOne()
    {
        isPanelOne = true;
        PanelA.SetActive(true);
        PanelB.SetActive(false);
        PanelC.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StepTwo()
    {
        isPanelTwo = true;
        PanelA.SetActive(false);
        PanelB.SetActive(true);
        PanelC.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StepThree()
    {
        isPanelThree = true;
        PanelA.SetActive(false);
        PanelB.SetActive(false);
        PanelC.SetActive(true);
        Time.timeScale = 0f;
    }

    public void FinalStep()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MainLore.SetActive(false);
    }

    public void GoNext()
    {
        if (isPanelOne == true)
        {
            isPanelOne = false;
            StepTwo();
        }
        else if (isPanelTwo == true)
        {
            isPanelTwo = false;
            StepThree();
        }
        else if (isPanelThree == true)
        {
            isPanelThree = false;
            FinalStep();
        }
    }

    public void GoBack()
    {
        if (isPanelOne == true)
        {
            isPanelOne = true;
        }
        else if (isPanelTwo == true)
        {
            isPanelOne = true;
            StepOne();
        }
        else if (isPanelThree == true)
        {
            isPanelTwo = true;
            StepTwo();
        }
    }
}