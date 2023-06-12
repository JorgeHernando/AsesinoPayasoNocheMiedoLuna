using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PangPauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private string DesiredScene;
    [SerializeField] private GameObject MusicGame;
    private bool isPaused;
    private bool isCreditsActive = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //[SerializeField]  animFade;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Credits()
    {
        CreditsPanel.SetActive(true);
        PausePanel.SetActive(false);
        isCreditsActive = true;
    }

    public void PauseGame()
    {
        isPaused = true;
        PausePanel.SetActive(true);
        MusicGame.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Renaudar");
        isPaused = false;
        PausePanel.SetActive(false);
        MusicGame.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoBack()
    {
        if (isCreditsActive == true)
        {
            CreditsPanel.SetActive(false);
            PausePanel.SetActive(true);
            isCreditsActive = false;
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(DesiredScene);
        Time.timeScale = 1f;
    }
}