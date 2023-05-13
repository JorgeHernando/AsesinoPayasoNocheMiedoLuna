using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isOpen;
    private AudioSource audioSource;

    private DoorActions doorActions;

    public bool isLevelChanger;
    public int timeBeforeChangeScene;
    private void Start()
    {
        isOpen = false;
        audioSource = GetComponent<AudioSource>();
        doorActions = GetComponent<DoorActions>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
            doorActions.PlayWhenOpen();
        if (isLevelChanger == true)
            doorActions.Invoke("ChangeSceneAfterOpening", timeBeforeChangeScene);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            Debug.Log("Abrete sesamo");
            animator.SetBool("OpenDoor", isOpen);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = false;
            Debug.Log("Abrete sesamo");
            animator.SetBool("OpenDoor", isOpen);
        }
    }
}
