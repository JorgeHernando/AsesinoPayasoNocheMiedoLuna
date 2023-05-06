using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
	public int counter = 0;
	
	void OnTriggerEnter2D(Collider2D col)
	{

		//Chain.IsFired = false;

		if (col.tag == "Enemy")
		{
			col.GetComponent<DivisiondeBola>().SpawnObject();
			counter++;
			Debug.Log(counter);
		}

		/*if (counter == 31)
		{

			Debug.Log("Level2");
			Application.LoadLevel("Level2");
			//			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}*/
	}
}
