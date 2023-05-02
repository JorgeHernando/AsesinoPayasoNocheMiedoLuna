using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorActions : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField] private string levelName;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWhenOpen() 
    {
        audioSource.Play();
    }

    public void ChangeSceneAfterOpening()
    {
        SceneManager.LoadScene(levelName);
    }
}