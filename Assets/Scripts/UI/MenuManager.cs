using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Space]
    [SerializeField] Animator animFade;
    [SerializeField] Animator startUp;
    [SerializeField] Animator handDown;

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

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

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
