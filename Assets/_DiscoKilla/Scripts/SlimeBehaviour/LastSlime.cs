using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSlime : MonoBehaviour
{
    [SerializeField] GameObject prefabParticles;
    private Slime slime;
    private Rigidbody2D rb;
    public Vector2 initialForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.AddForce(initialForce, ForceMode2D.Impulse);
        slime = GetComponent<Slime>();
    }

    public void Death()
    {
        if (prefabParticles != null)
        {
            GameObject explosionSlime = Instantiate(prefabParticles, this.transform.position , Quaternion.identity);
            Destroy(explosionSlime, .5f);
            slime.DestroyMe();
        }
    }
}
