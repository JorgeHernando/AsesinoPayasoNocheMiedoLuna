using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeAnalyzer : MonoBehaviour
{
    private GameObject[] activeSlimes;
    [SerializeField] private string nextScene;
    public void Update()
    {
        activeSlimes = GameObject.FindGameObjectsWithTag("Enemy");

        if (activeSlimes.Length == 0)
        {
            Victory();
        }
    }

    public void Victory()
    {
        if (activeSlimes.Length == 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}