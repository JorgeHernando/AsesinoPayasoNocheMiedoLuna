using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
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
