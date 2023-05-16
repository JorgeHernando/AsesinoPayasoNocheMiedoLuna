using UnityEngine;

public class DivisiondeBola : MonoBehaviour
{
    [SerializeField] GameObject prefabParticles;
    public Vector2 initialForce;
    public Rigidbody2D rb;
    private Slime slime;
    [SerializeField] private GameObject nextBall;

    void Start()
    {
        slime = GetComponent<Slime>();
    }

public void SpawnObject()
    {
        if (nextBall != null)
        {
            GameObject BolaA = Instantiate(nextBall, transform.position + Vector3.right * 1.1f, Quaternion.identity);
            GameObject BolaB = Instantiate(nextBall, transform.position + Vector3.left * 1.1f, Quaternion.identity);

            if (nextBall.GetComponent<DivisiondeBola>() != null)
            {
                BolaA.GetComponent<DivisiondeBola>().initialForce = new Vector2(4f, 10f);
                BolaA.GetComponent<Rigidbody2D>().AddForce(BolaA.GetComponent<DivisiondeBola>().initialForce, ForceMode2D.Impulse);
                BolaB.GetComponent<DivisiondeBola>().initialForce = new Vector2(-4f, 10f);
                BolaB.GetComponent<Rigidbody2D>().AddForce(BolaB.GetComponent<DivisiondeBola>().initialForce, ForceMode2D.Impulse);

                if (prefabParticles != null)
                {
                    GameObject explosionSlime = Instantiate(prefabParticles, this.transform.position, Quaternion.identity);
                    Destroy(explosionSlime, 5f);
                }
                slime.DestroyMe();

            }
            else if(nextBall.GetComponent<LastSlime>() != null)
            {
                BolaA.GetComponent<LastSlime>().initialForce = new Vector2(2f, 5f);
                BolaB.GetComponent<LastSlime>().initialForce = new Vector2(-2f, 5f);
                if (prefabParticles != null)
                {
                    GameObject explosionSlime = Instantiate(prefabParticles, this.transform.position, Quaternion.identity);
                    Destroy(explosionSlime, 5f);
                    slime.DestroyMe();
                }
            }
        }
    }
}
