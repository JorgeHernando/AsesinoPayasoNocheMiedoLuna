using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoreNPC : MonoBehaviour
{
    protected GameObject gameManager;
    protected GameObject player;
    public GameObject healthText;

    public float HideCooldown;
    public bool canHide;
    public bool canMove;
    public bool hiding;
    public bool isAlive = true;

    public int health;


    private bool isAfraid;
    protected Color color;

    protected Animator animator;
    Vector3 previousPosition;
    Vector3 lastMoveDirection;
    public GameObject soundAttack;
    public Vector3 deathPos;

    protected void Start()
    {
        color = GlobalManager.Instance.GetOriginalColor;

        Initialize();
        gameManager = GlobalManager.Instance.StateGlobal;
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
    }

    public int Health
    {
        set
        {
            if (value < health)
            {
                //Set health loss text position on top of the enemy
                GameObject gm = Instantiate(healthText);
                RectTransform textTransform = gm.GetComponent<RectTransform>();
                Vector3 v3 = transform.position;
                v3.y += 0.16f;
                textTransform.transform.position = v3;

                //Add damage dealet
                TextMeshProUGUI textMesh = gm.GetComponent<TextMeshProUGUI>();
                int damage = health - value;
                textMesh.SetText(damage.ToString());

                //Set health loss text inside the canvas
                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }

            health = value;
            if (health <= 0) Defeated();                                        //calling defeated void if health value <= 0
        }
        get
        {
            return health;
        }
    }

    public void Initialize()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameManager = GlobalManager.Instance.StateGlobal;
        isAfraid = false;
        canMove = true;
        hiding = false;
        canHide = true;
        //canMoveChecker = true;
    }

    virtual public void Defeated()
    {
        deathPos = transform.position;
        isAlive = false;
        canMove = false;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        //Destroy(transform.GetChild(0).gameObject);
        //if (transform.childCount > 1) Destroy(transform.GetChild(1).gameObject);
        animator.SetTrigger("isDeath");

    }

    public bool Hiding
    {
        set { hiding = value; }
        get { return hiding; }
    }

    protected void SetHiding()
    {
        if (hiding && canHide)
        {
            animator.SetTrigger("isHiding");
            StartCoroutine(StartCooldown());
        }
    }

    public IEnumerator StartCooldown()
    {
        canHide = false;
        yield return new WaitForSeconds(HideCooldown);
        canHide = true;
    }

    public void Nauseous(int damage, int ticks)
    {
        if (!isAfraid)
        {
            StartCoroutine(VisualEffect(new Color(1.0f, 0.64f, 0.0f), 0.1f, ticks, 0.5f));
            StartCoroutine(WaitForNausea(0.5f, damage, ticks));
        }
    }

    private IEnumerator VisualEffect(Color _color, float duration, int loop, float ticktime)
    {
        for (int x = 0; x < loop; x++)
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            sr.color = _color;
            yield return new WaitForSeconds(duration);
            sr.color = color;
            yield return new WaitForSeconds(ticktime - duration);
        }
    }

    private IEnumerator VisualEffect(Color color, float duration)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        sr.color = color;
        yield return new WaitForSeconds(duration);
        sr.color = color;
    }

    private IEnumerator WaitForNausea(float duration, int damage, int ticks)
    {
        isAfraid = true;
        for (int i = 0; i < ticks; i++)
        {
            Health -= damage;
            yield return new WaitForSeconds(duration);
        }
        isAfraid = false;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hidder")
        {
            Hiding = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hidder")
        {
            Hiding = false;
        }
    }

    protected void Movement()
    {
        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;

            SetMove();

            animator.SetFloat("movementX", lastMoveDirection.x);
            animator.SetFloat("movementY", lastMoveDirection.y);
        }
    }

    private void SetMove()
    {
        bool auxMoveX = false;
        bool auxMoveY = false;
        float y = lastMoveDirection.y;
        float x = lastMoveDirection.x;

        if (Mathf.Sign(x) == -1)
        {
            x = -x;
            auxMoveX = true;
        }
        if (Mathf.Sign(y) == -1)
        {
            y = -y;
            auxMoveY = true;
        }
        if (x >= y) y = 0;
        else x = 0;

        lastMoveDirection.x = auxMoveX ? -x : x;
        lastMoveDirection.y = auxMoveY ? -y : y; ;
        lastMoveDirection = lastMoveDirection.normalized;
    }

    public void SetDinamic()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetKinetic()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnLockMovement()
    {
        if (!canHide) canMove = true;
    }
}
