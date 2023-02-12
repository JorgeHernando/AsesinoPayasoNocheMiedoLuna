using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    
    [SerializeField]
    private int RunMultiplier;

    private bool canKill;
    private bool canDrag;
    [SerializeField]
    private GameObject DraggerPrefab;
    [SerializeField]
    private GameObject NPCAlive;
    [SerializeField]
    private GameObject DeadBodyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canKill = false;
        canDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity = moveInput * RunMultiplier;
        }
        else
            rb2d.velocity = moveInput * moveSpeed;

        if (Input.GetMouseButtonDown(0) && canKill)
        {
            Debug.Log("Lo matas");
            KillNPC();
        }
        else if (Input.GetMouseButtonDown(0))
            Debug.Log("No lo puedes matar");

        if (Input.GetMouseButtonDown(1) && canDrag)
            DraggerPrefab.SetActive(true);
        else if (Input.GetMouseButtonUp(1))
            DraggerPrefab.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Activar Dragger");
            canDrag = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPCAlive"))
        {
            Debug.Log("Puede matar");
            canKill = true;
            //other.gameObject.GetComponent<NPCBehaviour>().Death();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPCAlive"))
        {
            Debug.Log("No puede matar");
            canKill = false;
        }
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Activar Dragger");
            canDrag = false;
        }
    }

    private void KillNPC()
    {
        Instantiate(DeadBodyPrefab, NPCAlive.transform.position, Quaternion.identity);
        Destroy(NPCAlive);
    }
}
