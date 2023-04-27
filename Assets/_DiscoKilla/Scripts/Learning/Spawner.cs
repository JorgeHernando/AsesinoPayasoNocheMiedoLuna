using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] cajas;
    public GameObject caja;
    //Rango de aparición
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    //Rango de tiempo
    public float spawnWait;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawnear();
            spawnTime = Time.time + spawnWait; 
        }
    }

    void Spawnear()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Instantiate(caja, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
