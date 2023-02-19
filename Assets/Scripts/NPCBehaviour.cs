using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject DeadBodyPrefab;

    TopDownMovement characterPlayer;

    private bool isScared;

    private void Awake()
    {
        characterPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            isScared = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            isScared = false;
            characterPlayer.ToggleStateNormal();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Me morí");
        }
        if (other.gameObject.CompareTag("DeadBody") && isScared)
        {
            Debug.Log("State: Scared");
            characterPlayer.ToggleStateScared();
        }
    }

    public void KillNPC()
    {
        Instantiate(DeadBodyPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
