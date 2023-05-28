using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAndShoot : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] string LoseScene;
    public float saltoDistancia;
    private float direction;
    public float speed;

    private bool enElaire;

    private BulletSpawn bulletSpawn;
    [SerializeField] int coolDown;
    private Animator animator;

    public bool canDie;
    bool facingRight = true;

    //PowerUps
    public bool isBulletPowered;
    public bool canTripleShoot;

    public GameObject deathSFX;
    public int GameOverTimer;
    #region ModoPro
    RaycastHit2D hit;
    public Vector3 v3;
    public LayerMask layer;
    public float distance;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bulletSpawn = GetComponent<BulletSpawn>();
        animator = GetComponent<Animator>();

        //PowerUps
        isBulletPowered = false;
        canTripleShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Detector_Plataforma();

        if (Input.GetMouseButtonDown(0))
        {
            ShootIfCan();
        }

        direction = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(direction));

        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

        // Check for walls in the movement direction and adjust movement if necessary
        if (direction > 0 && !facingRight)
            Flip();
        else if (direction < 0 && facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Enemy" && canDie == true)
        {
            Debug.Log("Game Over!");
            StartCoroutine(DiesSequence());
        }
    }

    void ShootIfCan()
    {
        if (canTripleShoot == false)
        {
            animator.SetTrigger("Shoot");
            bulletSpawn.canTripleShoot = false;
            if (!isBulletPowered)
                bulletSpawn.SpawnBullet();
            else
                bulletSpawn.SpawnPoweredBullet();
        }
        else if (canTripleShoot == true)
        {
            animator.SetTrigger("Shoot");
            bulletSpawn.canTripleShoot = true;
            if (!isBulletPowered)
                bulletSpawn.SpawnBullet();
            else
                bulletSpawn.SpawnPoweredBullet();
        }
    }

    public bool CheckCollision
    {
        get
        {
            hit = Physics2D.Raycast(transform.position + v3, transform.up * -1, distance, layer);
            return hit.collider != null;
        }
    }
    
    public void Detector_Plataforma()
    {
        if (CheckCollision)
        {
            transform.parent = hit.collider.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * distance);
    }

    public IEnumerator DiesSequence()
    {
        animator.SetTrigger("Dies");
        GameObject explosionSlime = Instantiate(deathSFX, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(GameOverTimer);
        Destroy(explosionSlime, 3f);
        SceneManager.LoadScene(LoseScene);
    }
}
