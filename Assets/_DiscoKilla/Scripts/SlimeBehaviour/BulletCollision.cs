using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
	public int counter = 0;
	[SerializeField] private float bulletSpeed;

	void Start()
	{
		if (bulletSpeed == 0)
        {
			bulletSpeed = 4f;
        }
	}

    private void Update()
    {
		transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Ground"))
        {
			Destroy(this.gameObject);
			Debug.Log("Toco Colision");
		}
	}

    void OnTriggerEnter2D(Collider2D col)
	{

		//Chain.IsFired = false;
		if (col.gameObject.GetComponent<DivisiondeBola>())
		{
			col.GetComponent<DivisiondeBola>().SpawnObject();
			counter++;
			Debug.Log(counter);
			Destroy(this.gameObject);
		}

		if (col.gameObject.GetComponent<LastSlime>())
        {
			col.gameObject.GetComponent<LastSlime>().Death();
			counter++;
			Destroy(this.gameObject);
		}

		/*if (counter == 31)
		{

			Debug.Log("Level2");
			Application.LoadLevel("Level2");
			//			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}*/
	}

}
