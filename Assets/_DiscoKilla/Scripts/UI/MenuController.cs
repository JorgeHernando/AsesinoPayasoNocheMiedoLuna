using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Space]
    [SerializeField] Animator animFade;
    [SerializeField] Animator startUp;
    [SerializeField] Animator handDown;
    [Space]
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject menuPanel;

    private bool isOptionsActive = false;
    private bool isCreditsActive = false;

    public void ButtonUp()
    {
        startUp.SetTrigger("ButtonUp");
    }

    public void HandDown()
    {
        handDown.SetTrigger("StartAnim");
    }

    public void NewGame()
    {
        Invoke("LoadFirstLevel", 5);
        animFade.SetTrigger("FadeIn");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
        menuPanel.SetActive(false);
        isOptionsActive = true;
    }
    
    public void Credits()
    {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(false);
        isCreditsActive = true;
    }

    public void GoBack()
    {
        if(isOptionsActive == true)
        {
            optionsPanel.SetActive(false);
            menuPanel.SetActive(true);
            isOptionsActive = false;
        }
        else if (isCreditsActive == true)
        {
            creditsPanel.SetActive(false);
            menuPanel.SetActive(true);
            isCreditsActive = false;
        }
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Exit()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
    }
}
