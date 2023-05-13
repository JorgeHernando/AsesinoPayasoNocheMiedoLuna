using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject CreditsPanel;

    private bool isPaused;
    private bool isOptionsActive;
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

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciar");

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
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Renaudar");
    }

    public void OptionsButton()
    {
        OptionsPanel.SetActive(true);
        PausePanel.SetActive(false);
        isOptionsActive = true;
    }

    public void GoBack()
    {
        if (isOptionsActive == true)
        {
            OptionsPanel.SetActive(false);
            PausePanel.SetActive(true);
            isOptionsActive = false;
        }
        else if (isCreditsActive == true)
        {
            CreditsPanel.SetActive(false);
            PausePanel.SetActive(true);
            isCreditsActive = false;
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}