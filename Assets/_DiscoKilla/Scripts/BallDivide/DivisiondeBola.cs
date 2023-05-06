using UnityEngine;

public class DivisiondeBola : MonoBehaviour
{
    public Vector2 initialForce;
    public Rigidbody2D rb;

    [SerializeField] private GameObject nextBall;

    void Start()
    {
        rb.AddForce(initialForce, ForceMode2D.Impulse);
    }

    public void SpawnObject()
    {
        if (nextBall != null)
        {
            GameObject BolaA = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject BolaB = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            nextBall.GetComponent<DivisiondeBola>().initialForce = new Vector2(2f, 5f);
            nextBall.GetComponent<DivisiondeBola>().initialForce = new Vector2(-2f, 5f);
        }
        Destroy(gameObject);
    }
}
