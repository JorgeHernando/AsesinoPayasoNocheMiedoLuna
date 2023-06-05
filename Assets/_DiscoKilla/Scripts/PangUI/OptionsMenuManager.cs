using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField]
    private string MainMenu;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
