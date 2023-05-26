using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{
    //public Transform[] spawnPos;
    [SerializeField]
    private GameObject[] powerUps;
    //Rango de aparición
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    //Rango de tiempo
    public float spawnWait;
    public float spawnTime;

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
        int randomizer = Random.Range(0, powerUps.Length);
        
        Instantiate(powerUps[randomizer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
        /*for (int i = 0; i < powerUps.Length; i++)
            Instantiate(powerUps[i], transform.position + new Vector3(x, y, 0), transform.rotation);*/
    }
}
