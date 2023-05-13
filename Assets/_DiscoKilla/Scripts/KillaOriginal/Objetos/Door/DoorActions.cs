using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorActions : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField] private string? levelName;

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (levelName == null)
        {
            levelName = "A";
        }
    }

    public void PlayWhenOpen() 
    {
        audioSource.Play();
    }

    public void ChangeSceneAfterOpening()
    {
        if (levelName != null)
            SceneManager.LoadScene(levelName);
    }
}