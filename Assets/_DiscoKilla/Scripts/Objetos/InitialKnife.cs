using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialKnife : MonoBehaviour
{
    [SerializeField]
    private GameObject knifeUI;
    [SerializeField]
    private GameObject pickKnife;

    private SpriteRenderer sRenderer;
    
    [SerializeField]
    private AudioClip sfx;

    private bool interacted;

    [SerializeField]
    private GameObject exitTrigger;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        interacted = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            knifeUI.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                AudioSource.PlayClipAtPoint(sfx, transform.position);
                Destroy(gameObject);
                exitTrigger.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            knifeUI.SetActive(false);
        }
    }
}
