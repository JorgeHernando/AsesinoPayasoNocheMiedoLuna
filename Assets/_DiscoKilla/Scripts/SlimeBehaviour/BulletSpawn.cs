using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float firerate;
    public float nextfire;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] Vector3 posBullet;

    public void SpawnBullet()
    {
        if( Time.time > firerate)
        {
            nextfire = Time.time + firerate;
            Debug.Log(nextfire);
            GameObject bulletPrefab = Instantiate(prefabBullet, this.transform.position + posBullet, Quaternion.identity);
            Destroy(bulletPrefab, 5);
            //prefabParticles

        }
    }
}
