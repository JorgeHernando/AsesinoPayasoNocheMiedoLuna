using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject UIBubbleText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("A");
        UIBubbleText.SetActive(true);
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Me morí");
        }
        if (other.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("State: Scared");
        }
    }

    
}
