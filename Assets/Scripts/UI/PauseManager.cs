using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isPaused;

    //[SerializeField]  animFade;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            PausePanel.SetActive(true);
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        isPaused = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
